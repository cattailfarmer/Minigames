#!/usr/bin/env python3
import argparse
import json
import math
import statistics
import wave
from pathlib import Path


def load_wav(path: Path):
    with wave.open(str(path), "rb") as wav_file:
        sample_rate = wav_file.getframerate()
        channels = wav_file.getnchannels()
        frame_count = wav_file.getnframes()
        sample_width = wav_file.getsampwidth()
        raw = wav_file.readframes(frame_count)

    if sample_width != 2:
        raise ValueError("Only 16-bit PCM wav files are supported in the initial tool version.")

    samples = []
    for index in range(0, len(raw), 2 * channels):
        channel_values = []
        for channel in range(channels):
            offset = index + (channel * 2)
            value = int.from_bytes(raw[offset:offset + 2], byteorder="little", signed=True)
            channel_values.append(value / 32768.0)
        samples.append(sum(channel_values) / len(channel_values))

    return {
        "sample_rate": sample_rate,
        "channels": channels,
        "frame_count": frame_count,
        "duration_seconds": frame_count / float(sample_rate),
        "samples": samples,
    }


def compute_metrics(data):
    samples = data["samples"]
    if not samples:
        raise ValueError("Wave file contains no samples.")

    abs_samples = [abs(value) for value in samples]
    peak = max(abs_samples)
    rms = math.sqrt(sum(value * value for value in samples) / len(samples))
    zero_crossings = 0
    for left, right in zip(samples, samples[1:]):
        if (left < 0 <= right) or (left >= 0 > right):
            zero_crossings += 1
    zero_cross_rate = zero_crossings / max(1, len(samples) - 1)

    step = max(1, len(samples) // 2048)
    transient_candidates = 0
    previous = abs(samples[0])
    for value in samples[::step]:
        current = abs(value)
        if current - previous > 0.25:
            transient_candidates += 1
        previous = current

    spectral_centroid = estimate_spectral_centroid(samples, data["sample_rate"])
    return {
        "duration_seconds": round(data["duration_seconds"], 4),
        "sample_rate": data["sample_rate"],
        "channels": data["channels"],
        "peak": round(peak, 6),
        "rms": round(rms, 6),
        "zero_crossing_rate": round(zero_cross_rate, 6),
        "transient_density": round(transient_candidates / max(1.0, data["duration_seconds"]), 6),
        "spectral_centroid_hz": round(spectral_centroid, 2),
    }


def estimate_spectral_centroid(samples, sample_rate):
    window = samples[: min(len(samples), 1024)]
    if len(window) < 8:
        return 0.0
    magnitudes = []
    for k in range(min(128, len(window) // 2)):
        real = 0.0
        imag = 0.0
        for n, sample in enumerate(window):
            angle = (2.0 * math.pi * k * n) / len(window)
            real += sample * math.cos(angle)
            imag -= sample * math.sin(angle)
        magnitudes.append((k * sample_rate / len(window), math.sqrt(real * real + imag * imag)))
    weighted = sum(freq * mag for freq, mag in magnitudes)
    total = sum(mag for _, mag in magnitudes) or 1.0
    return weighted / total


def make_judgment(metrics, preset=None, metadata=None):
    role = (metadata or {}).get("role")
    clarity = "clear" if metrics["peak"] > 0.15 and metrics["rms"] > 0.03 else "weak"
    fatigue_risk = "elevated" if metrics["peak"] > 0.98 else "low"
    masking_risk = "elevated" if metrics["rms"] > 0.25 else "bounded"
    notes = []
    transient_floor = 1.0
    if role in {"stinger", "signature"}:
        transient_floor = 0.0
    elif role == "transition":
        transient_floor = 0.4
    if preset == "battleship" and metrics["transient_density"] < transient_floor:
        notes.append("Transient density is low for event-driven naval game feedback.")
    if metrics["zero_crossing_rate"] > 0.35:
        notes.append("High zero-crossing rate suggests noise-heavy or harsh content.")
    return {
        "clarity": clarity,
        "fatigue_risk": fatigue_risk,
        "masking_risk": masking_risk,
        "notes": notes,
    }


def inspect_command(args):
    source = Path(args.input)
    data = load_wav(source)
    metrics = compute_metrics(data)
    metadata = load_sidecar_metadata(source)
    report = {
        "subject": str(source),
        "metrics": metrics,
        "metadata": metadata,
        "judgment": make_judgment(metrics, preset=args.preset, metadata=metadata),
        "uncertainty": [],
    }
    write_report(report, args.output)


def load_sidecar_metadata(source: Path):
    sidecar = Path(str(source) + ".json")
    if sidecar.exists():
        return json.loads(sidecar.read_text(encoding="utf-8"))
    return None


def inspect_pack(path: Path, preset=None):
    reports = []
    for source in sorted(path.glob("*.wav")):
        data = load_wav(source)
        metrics = compute_metrics(data)
        metadata = load_sidecar_metadata(source)
        reports.append({
            "subject": str(source),
            "metrics": metrics,
            "metadata": metadata,
            "judgment": make_judgment(metrics, preset=preset, metadata=metadata),
            "uncertainty": [],
        })

    average_peak = statistics.fmean(report["metrics"]["peak"] for report in reports) if reports else 0.0
    average_rms = statistics.fmean(report["metrics"]["rms"] for report in reports) if reports else 0.0
    average_transient_density = statistics.fmean(report["metrics"]["transient_density"] for report in reports) if reports else 0.0
    report = {
        "subject": str(path),
        "asset_count": len(reports),
        "average_peak": round(average_peak, 6),
        "average_rms": round(average_rms, 6),
        "average_transient_density": round(average_transient_density, 6),
        "assets": reports,
        "judgment": {
            "mix_density": "heavy" if average_rms > 0.16 else "controlled",
            "event_readiness": "good" if average_transient_density > 1.2 else "soft",
        },
    }
    return report


def compare_command(args):
    candidate = compute_metrics(load_wav(Path(args.candidate)))
    reference = compute_metrics(load_wav(Path(args.reference)))
    comparison = {}
    for key in ("peak", "rms", "zero_crossing_rate", "transient_density", "spectral_centroid_hz", "duration_seconds"):
        comparison[key] = round(candidate[key] - reference[key], 6)
    report = {
        "candidate": str(Path(args.candidate)),
        "reference": str(Path(args.reference)),
        "delta": comparison,
        "judgment": {
            "match": "close" if statistics.fmean(abs(value) for value in comparison.values()) < 250 else "distant"
        },
    }
    write_report(report, args.output)


def inspect_pack_command(args):
    report = inspect_pack(Path(args.input), preset=args.preset)
    write_report(report, args.output)


def write_report(report, output_path):
    text = json.dumps(report, indent=2)
    if output_path:
        Path(output_path).write_text(text, encoding="utf-8")
    else:
        print(text)


def build_parser():
    parser = argparse.ArgumentParser(description="Analyze wav files according to Audio_Processing.md.")
    subparsers = parser.add_subparsers(dest="command", required=True)

    inspect_parser = subparsers.add_parser("inspect")
    inspect_parser.add_argument("--input", required=True)
    inspect_parser.add_argument("--output")
    inspect_parser.add_argument("--preset")
    inspect_parser.set_defaults(func=inspect_command)

    inspect_pack_parser = subparsers.add_parser("inspect-pack")
    inspect_pack_parser.add_argument("--input", required=True)
    inspect_pack_parser.add_argument("--output")
    inspect_pack_parser.add_argument("--preset")
    inspect_pack_parser.set_defaults(func=inspect_pack_command)

    compare_parser = subparsers.add_parser("compare")
    compare_parser.add_argument("--candidate", required=True)
    compare_parser.add_argument("--reference", required=True)
    compare_parser.add_argument("--output")
    compare_parser.set_defaults(func=compare_command)
    return parser


def main():
    parser = build_parser()
    args = parser.parse_args()
    args.func(args)


if __name__ == "__main__":
    main()
