#!/usr/bin/env python3
import argparse
import json
import math
import random
import struct
import wave
from pathlib import Path


PRESETS = {
    "sonar_ping": {"frequency": 880.0, "duration": 0.9, "envelope": (0.01, 0.12, 0.0, 0.65), "waveform": "sine", "role": "signature", "family": "battleship"},
    "water_splash": {"frequency": 220.0, "duration": 0.8, "envelope": (0.001, 0.1, 0.0, 0.45), "waveform": "noise", "role": "impact_tail", "family": "battleship"},
    "ui_lockon": {"frequency": 1320.0, "duration": 0.22, "envelope": (0.002, 0.04, 0.0, 0.08), "waveform": "square", "role": "ui", "family": "battleship"},
    "impact_boom": {"frequency": 110.0, "duration": 0.7, "envelope": (0.001, 0.08, 0.0, 0.3), "waveform": "impact", "role": "impact", "family": "battleship"},
    "pairing_accept": {"frequency": 1046.5, "duration": 0.18, "envelope": (0.002, 0.03, 0.0, 0.08), "waveform": "sine", "role": "ui", "family": "battleship"},
    "pairing_reject": {"frequency": 233.1, "duration": 0.24, "envelope": (0.002, 0.05, 0.0, 0.11), "waveform": "square", "role": "ui_warning", "family": "battleship"},
    "ready_confirm": {"frequency": 783.99, "duration": 0.2, "envelope": (0.002, 0.04, 0.0, 0.08), "waveform": "sine", "role": "ui", "family": "battleship"},
    "placement_confirm": {"frequency": 659.25, "duration": 0.16, "envelope": (0.002, 0.03, 0.0, 0.06), "waveform": "sine", "role": "ui", "family": "battleship"},
    "placement_invalid": {"frequency": 196.0, "duration": 0.2, "envelope": (0.001, 0.05, 0.0, 0.09), "waveform": "square", "role": "ui_warning", "family": "battleship"},
    "turn_start": {"frequency": 523.25, "duration": 0.18, "envelope": (0.002, 0.04, 0.0, 0.08), "waveform": "sine", "role": "transition", "family": "battleship"},
    "handoff_curtain": {"frequency": 392.0, "duration": 0.5, "envelope": (0.01, 0.06, 0.0, 0.24), "waveform": "noise", "role": "transition", "family": "battleship"},
    "fire_command": {"frequency": 311.13, "duration": 0.25, "envelope": (0.001, 0.05, 0.0, 0.12), "waveform": "impact", "role": "event", "family": "battleship"},
    "hit_confirm": {"frequency": 698.46, "duration": 0.24, "envelope": (0.001, 0.04, 0.0, 0.12), "waveform": "impact", "role": "event", "family": "battleship"},
    "miss_confirm": {"frequency": 246.94, "duration": 0.28, "envelope": (0.001, 0.05, 0.0, 0.15), "waveform": "noise", "role": "event", "family": "battleship"},
    "sink_confirm": {"frequency": 174.61, "duration": 0.82, "envelope": (0.001, 0.08, 0.0, 0.42), "waveform": "impact", "role": "stinger", "family": "battleship"},
    "victory_stinger": {"frequency": 987.77, "duration": 0.9, "envelope": (0.002, 0.09, 0.0, 0.4), "waveform": "sine", "role": "stinger", "family": "battleship"},
    "defeat_stinger": {"frequency": 164.81, "duration": 0.95, "envelope": (0.002, 0.09, 0.0, 0.45), "waveform": "square", "role": "stinger", "family": "battleship"},
}

BATTLESHIP_PACK = [
    "pairing_accept",
    "pairing_reject",
    "ready_confirm",
    "placement_confirm",
    "placement_invalid",
    "turn_start",
    "handoff_curtain",
    "fire_command",
    "hit_confirm",
    "miss_confirm",
    "sink_confirm",
    "victory_stinger",
    "defeat_stinger",
    "sonar_ping",
    "water_splash",
]


def envelope_value(t, duration, attack, decay, sustain, release):
    sustain_time = max(0.0, duration - attack - decay - release)
    if t < attack:
        return t / max(attack, 1e-6)
    if t < attack + decay:
        progress = (t - attack) / max(decay, 1e-6)
        return 1.0 - ((1.0 - sustain) * progress)
    if t < attack + decay + sustain_time:
        return sustain
    release_progress = (t - attack - decay - sustain_time) / max(release, 1e-6)
    return max(0.0, sustain * (1.0 - release_progress))


def sample_value(waveform, t, frequency, rng):
    if waveform == "sine":
        return math.sin(2.0 * math.pi * frequency * t)
    if waveform == "square":
        return 1.0 if math.sin(2.0 * math.pi * frequency * t) >= 0 else -1.0
    if waveform == "noise":
        base = rng.uniform(-1.0, 1.0)
        shimmer = math.sin(2.0 * math.pi * frequency * t) * 0.25
        return (base * 0.85) + shimmer
    if waveform == "impact":
        sub = math.sin(2.0 * math.pi * frequency * t)
        grit = rng.uniform(-0.4, 0.4)
        return (sub * 0.8) + grit
    raise ValueError(f"Unsupported waveform '{waveform}'.")


def vary_preset(base_preset, seed):
    rng = random.Random(seed)
    preset = dict(base_preset)
    preset["frequency"] = round(base_preset["frequency"] * rng.uniform(0.93, 1.07), 4)
    preset["duration"] = round(base_preset["duration"] * rng.uniform(0.92, 1.08), 4)
    attack, decay, sustain, release = base_preset["envelope"]
    preset["envelope"] = (
        max(0.001, round(attack * rng.uniform(0.85, 1.15), 4)),
        max(0.005, round(decay * rng.uniform(0.85, 1.15), 4)),
        max(0.0, min(0.8, round(sustain * rng.uniform(0.9, 1.1), 4))),
        max(0.01, round(release * rng.uniform(0.85, 1.15), 4)),
    )
    return preset


def render_samples(preset_name, duration, sample_rate, seed):
    preset = vary_preset(PRESETS[preset_name], seed)
    preset["duration"] = duration or preset["duration"]
    rng = random.Random(seed)
    attack, decay, sustain, release = preset["envelope"]
    total_samples = max(1, int(sample_rate * preset["duration"]))
    samples = []
    for index in range(total_samples):
        t = index / sample_rate
        amplitude = envelope_value(t, preset["duration"], attack, decay, sustain, release)
        value = sample_value(preset["waveform"], t, preset["frequency"], rng)
        samples.append(max(-1.0, min(1.0, value * amplitude * 0.7)))
    return preset, samples


def write_wav(path, sample_rate, samples):
    path.parent.mkdir(parents=True, exist_ok=True)
    with wave.open(str(path), "wb") as wav_file:
        wav_file.setnchannels(1)
        wav_file.setsampwidth(2)
        wav_file.setframerate(sample_rate)
        frames = b"".join(struct.pack("<h", int(sample * 32767.0)) for sample in samples)
        wav_file.writeframes(frames)


def write_sidecar(path, payload):
    path.with_suffix(path.suffix + ".json").write_text(json.dumps(payload, indent=2), encoding="utf-8")


def render_command(args):
    seed = args.seed if args.seed is not None else 7
    preset, samples = render_samples(args.preset, args.duration, args.sample_rate, seed)
    output_path = Path(args.output)
    write_wav(output_path, args.sample_rate, samples)
    write_sidecar(output_path, {
        "tool": "soppywave",
        "preset": args.preset,
        "seed": seed,
        "sample_rate": args.sample_rate,
        "duration_seconds": preset["duration"],
        "waveform": preset["waveform"],
        "frequency": preset["frequency"],
        "role": preset.get("role"),
        "family": preset.get("family"),
        "schema": "schema/SOPPyWave.md",
    })


def vary_command(args):
    output_dir = Path(args.output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)
    for index in range(args.count):
        seed = 7 + index
        output = output_dir / f"{args.preset}_{index + 1:02d}.wav"
        render_command(argparse.Namespace(
            preset=args.preset,
            output=str(output),
            duration=args.duration,
            sample_rate=args.sample_rate,
            seed=seed,
        ))


def render_pack_command(args):
    output_dir = Path(args.output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)
    manifest = {"tool": "soppywave", "pack": "battleship", "assets": []}
    for index, preset_name in enumerate(BATTLESHIP_PACK):
        output = output_dir / f"{preset_name}.wav"
        seed = (args.seed if args.seed is not None else 700) + index
        render_command(argparse.Namespace(
            preset=preset_name,
            output=str(output),
            duration=None,
            sample_rate=args.sample_rate,
            seed=seed,
        ))
        manifest["assets"].append({
            "name": preset_name,
            "path": str(output),
            "sidecar": str(output) + ".json",
        })
    (output_dir / "battleship_audio_manifest.json").write_text(json.dumps(manifest, indent=2), encoding="utf-8")


def build_parser():
    parser = argparse.ArgumentParser(description="Generate audio artifacts according to SOPPyWave.md.")
    subparsers = parser.add_subparsers(dest="command", required=True)

    render_parser = subparsers.add_parser("render")
    render_parser.add_argument("--preset", choices=sorted(PRESETS), required=True)
    render_parser.add_argument("--output", required=True)
    render_parser.add_argument("--duration", type=float)
    render_parser.add_argument("--sample-rate", type=int, default=44100)
    render_parser.add_argument("--seed", type=int)
    render_parser.set_defaults(func=render_command)

    vary_parser = subparsers.add_parser("vary")
    vary_parser.add_argument("--preset", choices=sorted(PRESETS), required=True)
    vary_parser.add_argument("--output-dir", required=True)
    vary_parser.add_argument("--count", type=int, default=4)
    vary_parser.add_argument("--duration", type=float)
    vary_parser.add_argument("--sample-rate", type=int, default=44100)
    vary_parser.set_defaults(func=vary_command)

    pack_parser = subparsers.add_parser("render-battleship-pack")
    pack_parser.add_argument("--output-dir", required=True)
    pack_parser.add_argument("--sample-rate", type=int, default=44100)
    pack_parser.add_argument("--seed", type=int)
    pack_parser.set_defaults(func=render_pack_command)
    return parser


def main():
    parser = build_parser()
    args = parser.parse_args()
    args.func(args)


if __name__ == "__main__":
    main()
