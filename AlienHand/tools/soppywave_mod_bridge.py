#!/usr/bin/env python3
import argparse
import json
import math
import struct
import wave
from pathlib import Path


TONE_FAMILIES = {
    "sonar_tone": {"waveform": "sine", "attack": 0.002, "decay": 0.18, "sustain": 0.0, "release": 0.22},
    "chip_bass": {"waveform": "square", "attack": 0.002, "decay": 0.08, "sustain": 0.35, "release": 0.12},
    "pulse_pluck": {"waveform": "square", "attack": 0.001, "decay": 0.06, "sustain": 0.0, "release": 0.08},
    "drone_pad": {"waveform": "triangle", "attack": 0.06, "decay": 0.12, "sustain": 0.45, "release": 0.2},
    "noise_hat": {"waveform": "noise", "attack": 0.001, "decay": 0.03, "sustain": 0.0, "release": 0.03},
}


NOTE_INDEX = {
    "C": 0, "C#": 1, "DB": 1, "D": 2, "D#": 3, "EB": 3, "E": 4, "F": 5,
    "F#": 6, "GB": 6, "G": 7, "G#": 8, "AB": 8, "A": 9, "A#": 10, "BB": 10, "B": 11,
}


def parse_note(note_text: str) -> float:
    text = note_text.strip().upper()
    if len(text) < 2:
        raise ValueError(f"Invalid note '{note_text}'.")
    if text[1] in {"#", "B"} and len(text) >= 3:
        name = text[:2]
        octave = int(text[2:])
    else:
        name = text[:1]
        octave = int(text[1:])
    semitone = NOTE_INDEX[name]
    midi = (octave + 1) * 12 + semitone
    return 440.0 * (2.0 ** ((midi - 69) / 12.0))


def osc_value(waveform: str, phase: float, noise_seed: int) -> float:
    if waveform == "sine":
        return math.sin(phase)
    if waveform == "square":
        return 1.0 if math.sin(phase) >= 0 else -1.0
    if waveform == "triangle":
        return (2.0 / math.pi) * math.asin(math.sin(phase))
    if waveform == "noise":
        # deterministic hash noise
        return (((noise_seed * 1103515245 + 12345) & 0x7FFFFFFF) / 1073741824.0) - 1.0
    raise ValueError(f"Unsupported waveform '{waveform}'.")


def envelope_value(t: float, duration: float, attack: float, decay: float, sustain: float, release: float) -> float:
    sustain_time = max(0.0, duration - attack - decay - release)
    if t < attack:
        return t / max(attack, 1e-6)
    if t < attack + decay:
        progress = (t - attack) / max(decay, 1e-6)
        return 1.0 - ((1.0 - sustain) * progress)
    if t < attack + decay + sustain_time:
        return sustain
    progress = (t - attack - decay - sustain_time) / max(release, 1e-6)
    return max(0.0, sustain * (1.0 - progress))


def render_tone(family_name: str, frequency: float, duration: float, sample_rate: int):
    family = TONE_FAMILIES[family_name]
    samples = []
    total = max(1, int(duration * sample_rate))
    for index in range(total):
        t = index / sample_rate
        amplitude = envelope_value(
            t, duration,
            family["attack"], family["decay"], family["sustain"], family["release"],
        )
        phase = 2.0 * math.pi * frequency * t
        value = osc_value(family["waveform"], phase, index + int(frequency * 100))
        if family_name == "sonar_tone":
            value += 0.18 * math.sin(phase * 2.0)
        elif family_name == "chip_bass":
            value += 0.1 * math.sin(phase / 2.0)
        elif family_name == "drone_pad":
            value = (value * 0.7) + (0.3 * math.sin(phase * 0.5))
        samples.append(max(-1.0, min(1.0, value * amplitude * 0.6)))
    return samples


def write_wav(path: Path, samples, sample_rate: int):
    path.parent.mkdir(parents=True, exist_ok=True)
    with wave.open(str(path), "wb") as wav_file:
        wav_file.setnchannels(1)
        wav_file.setsampwidth(2)
        wav_file.setframerate(sample_rate)
        frames = b"".join(struct.pack("<h", int(sample * 32767.0)) for sample in samples)
        wav_file.writeframes(frames)


def bake_tone_command(args):
    frequency = parse_note(args.note)
    samples = render_tone(args.family, frequency, args.duration, args.sample_rate)
    output = Path(args.output)
    write_wav(output, samples, args.sample_rate)
    output.with_suffix(output.suffix + ".json").write_text(json.dumps({
        "tool": "soppywave_mod_bridge",
        "family": args.family,
        "note": args.note,
        "frequency": round(frequency, 4),
        "duration_seconds": args.duration,
        "sample_rate": args.sample_rate,
        "schema": "schema/SOPPyWave-MOD_bridge.md",
    }, indent=2), encoding="utf-8")


def bind_module_command(args):
    module = json.loads(Path(args.input).read_text(encoding="utf-8"))
    bindings = {
        "1": {"tone_family": "sonar_tone"},
        "2": {"tone_family": "chip_bass"},
        "3": {"tone_family": "pulse_pluck"},
        "4": {"tone_family": "noise_hat"},
        "5": {"tone_family": "drone_pad"},
    }
    module["procedural_bindings"] = bindings
    module["bridge_schema"] = "schema/SOPPyWave-MOD_bridge.md"
    Path(args.output).write_text(json.dumps(module, indent=2), encoding="utf-8")


def build_parser():
    parser = argparse.ArgumentParser(description="Bridge tracker modules to procedural SOPPyWave tones.")
    subparsers = parser.add_subparsers(dest="command", required=True)

    bake_parser = subparsers.add_parser("bake-tone")
    bake_parser.add_argument("--family", choices=sorted(TONE_FAMILIES), required=True)
    bake_parser.add_argument("--note", required=True)
    bake_parser.add_argument("--output", required=True)
    bake_parser.add_argument("--duration", type=float, default=0.6)
    bake_parser.add_argument("--sample-rate", type=int, default=44100)
    bake_parser.set_defaults(func=bake_tone_command)

    bind_parser = subparsers.add_parser("bind-module")
    bind_parser.add_argument("--input", required=True)
    bind_parser.add_argument("--output", required=True)
    bind_parser.set_defaults(func=bind_module_command)
    return parser


def main():
    parser = build_parser()
    args = parser.parse_args()
    args.func(args)


if __name__ == "__main__":
    main()
