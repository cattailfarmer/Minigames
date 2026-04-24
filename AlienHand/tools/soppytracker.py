#!/usr/bin/env python3
import argparse
import json
import math
import struct
import wave
from pathlib import Path

from soppywave_mod_bridge import parse_note, render_tone


DEFAULT_MODULE = {
    "module_name": "Battleship Naval Tension",
    "format": "internal_hybrid",
    "global_tempo_bpm": 120,
    "rows_per_pattern": 16,
    "order_list": [0, 1],
    "channels": [
        {"id": 0, "role": "lead"},
        {"id": 1, "role": "bass"},
        {"id": 2, "role": "texture"},
        {"id": 3, "role": "fx"},
    ],
    "instruments": {
        "1": {"name": "Sonar Lead", "tone_family": "sonar_tone"},
        "2": {"name": "Depth Bass", "tone_family": "chip_bass"},
        "3": {"name": "Drift Pad", "tone_family": "drone_pad"},
        "4": {"name": "Noise Hat", "tone_family": "noise_hat"},
    },
    "patterns": [
        {
            "index": 0,
            "rows": [
                [{"note": "C5", "instrument": "1"}, {"note": "C2", "instrument": "2"}, {"note": "C4", "instrument": "3"}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "G4", "instrument": "1"}, {}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "A4", "instrument": "1"}, {"note": "G1", "instrument": "2"}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "G4", "instrument": "1"}, {}, {"note": "D4", "instrument": "3"}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "C5", "instrument": "1"}, {"note": "C2", "instrument": "2"}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "G4", "instrument": "1"}, {}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "A4", "instrument": "1"}, {"note": "G1", "instrument": "2"}, {"note": "E4", "instrument": "3"}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "E5", "instrument": "1"}, {}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
            ],
        },
        {
            "index": 1,
            "rows": [
                [{"note": "F5", "instrument": "1"}, {"note": "F2", "instrument": "2"}, {"note": "A3", "instrument": "3"}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "E5", "instrument": "1"}, {}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "D5", "instrument": "1"}, {"note": "D2", "instrument": "2"}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "C5", "instrument": "1"}, {}, {"note": "G3", "instrument": "3"}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "A4", "instrument": "1"}, {"note": "A1", "instrument": "2"}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "G4", "instrument": "1"}, {}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "C5", "instrument": "1"}, {"note": "C2", "instrument": "2"}, {"note": "C4", "instrument": "3"}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
                [{"note": "G4", "instrument": "1"}, {}, {}, {"note": "C6", "instrument": "4"}],
                [{}, {}, {}, {}],
            ],
        },
    ],
    "schema": "schema/MOD-Tracker.md",
}


def new_battleship_module_command(args):
    output = Path(args.output)
    output.parent.mkdir(parents=True, exist_ok=True)
    output.write_text(json.dumps(DEFAULT_MODULE, indent=2), encoding="utf-8")


def inspect_module(module):
    return {
        "module_name": module["module_name"],
        "format": module["format"],
        "pattern_count": len(module["patterns"]),
        "order_length": len(module["order_list"]),
        "channel_count": len(module["channels"]),
        "instrument_count": len(module["instruments"]),
        "schema": module.get("schema"),
    }


def inspect_module_command(args):
    module = json.loads(Path(args.input).read_text(encoding="utf-8"))
    report = inspect_module(module)
    text = json.dumps(report, indent=2)
    if args.output:
        Path(args.output).write_text(text, encoding="utf-8")
    else:
        print(text)


def write_wav(path: Path, samples, sample_rate: int):
    path.parent.mkdir(parents=True, exist_ok=True)
    with wave.open(str(path), "wb") as wav_file:
        wav_file.setnchannels(1)
        wav_file.setsampwidth(2)
        wav_file.setframerate(sample_rate)
        frames = b"".join(struct.pack("<h", max(-32767, min(32767, int(sample * 32767.0)))) for sample in samples)
        wav_file.writeframes(frames)


def mix_note(buffer, start_index, note_samples, gain=1.0):
    for i, sample in enumerate(note_samples):
        idx = start_index + i
        if idx >= len(buffer):
            break
        buffer[idx] += sample * gain


def render_module_command(args):
    module = json.loads(Path(args.input).read_text(encoding="utf-8"))
    sample_rate = args.sample_rate
    row_duration = 60.0 / module["global_tempo_bpm"] / 2.0
    total_rows = len(module["order_list"]) * module["rows_per_pattern"]
    total_samples = int((total_rows * row_duration + 1.0) * sample_rate)
    mix = [0.0] * total_samples

    for order_position, pattern_index in enumerate(module["order_list"]):
        pattern = next(pattern for pattern in module["patterns"] if pattern["index"] == pattern_index)
        for row_index, row in enumerate(pattern["rows"]):
            row_start_seconds = ((order_position * module["rows_per_pattern"]) + row_index) * row_duration
            start_index = int(row_start_seconds * sample_rate)
            for channel_event in row:
                if "note" not in channel_event:
                    continue
                instrument = module["instruments"][channel_event["instrument"]]
                frequency = parse_note(channel_event["note"])
                duration = row_duration * 0.9
                note_samples = render_tone(instrument["tone_family"], frequency, duration, sample_rate)
                gain = 0.32 if instrument["tone_family"] != "drone_pad" else 0.18
                mix_note(mix, start_index, note_samples, gain=gain)

    peak = max(abs(sample) for sample in mix) or 1.0
    normalized = [max(-1.0, min(1.0, sample / peak * 0.82)) for sample in mix]
    output = Path(args.output)
    write_wav(output, normalized, sample_rate)
    output.with_suffix(output.suffix + ".json").write_text(json.dumps({
        "tool": "soppytracker",
        "input_module": str(Path(args.input)),
        "sample_rate": sample_rate,
        "module_summary": inspect_module(module),
        "schema": "schema/MOD-Tracker.md",
    }, indent=2), encoding="utf-8")


def build_parser():
    parser = argparse.ArgumentParser(description="Tracker-style module authoring and rendering for SOPPyTracker.")
    subparsers = parser.add_subparsers(dest="command", required=True)

    new_parser = subparsers.add_parser("new-battleship-module")
    new_parser.add_argument("--output", required=True)
    new_parser.set_defaults(func=new_battleship_module_command)

    inspect_parser = subparsers.add_parser("inspect-module")
    inspect_parser.add_argument("--input", required=True)
    inspect_parser.add_argument("--output")
    inspect_parser.set_defaults(func=inspect_module_command)

    render_parser = subparsers.add_parser("render-module")
    render_parser.add_argument("--input", required=True)
    render_parser.add_argument("--output", required=True)
    render_parser.add_argument("--sample-rate", type=int, default=44100)
    render_parser.set_defaults(func=render_module_command)
    return parser


def main():
    parser = build_parser()
    args = parser.parse_args()
    args.func(args)


if __name__ == "__main__":
    main()
