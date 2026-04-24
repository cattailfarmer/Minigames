#!/usr/bin/env python3
import argparse
import json
import re
from pathlib import Path


ELEMENT_RE = re.compile(r"<(circle|ellipse|line|path|polygon|polyline|rect)\b")
COLOR_RE = re.compile(r"(?:stroke|fill)=\"([^\"]+)\"")


def inspect_svg(path: Path):
    text = path.read_text(encoding="utf-8")
    sidecar_path = Path(str(path) + ".json")
    sidecar = json.loads(sidecar_path.read_text(encoding="utf-8")) if sidecar_path.exists() else None
    colors = [value for value in COLOR_RE.findall(text) if value not in ("none", "")]
    metrics = {
        "element_count": len(ELEMENT_RE.findall(text)),
        "unique_color_count": len(set(colors)),
        "stroke_fill_mentions": len(colors),
    }
    judgment = {
        "clutter_risk": "elevated" if metrics["element_count"] > 48 else "bounded",
        "palette_density": "high" if metrics["unique_color_count"] > 8 else "controlled",
    }
    role = (sidecar or {}).get("role")
    if role == "board" and metrics["element_count"] < 10:
        judgment["structure_risk"] = "thin"
    elif role == "event" and metrics["element_count"] < 3:
        judgment["structure_risk"] = "underexpressive"
    else:
        judgment["structure_risk"] = "acceptable"
    return {
        "subject": str(path),
        "metrics": metrics,
        "metadata": sidecar,
        "judgment": judgment,
    }


def inspect_sequence(path: Path):
    frames = sorted(path.glob("*.svg"))
    frame_reports = [inspect_svg(frame) for frame in frames]
    element_counts = [report["metrics"]["element_count"] for report in frame_reports]
    color_counts = [report["metrics"]["unique_color_count"] for report in frame_reports]
    return {
        "subject": str(path),
        "frame_count": len(frame_reports),
        "average_element_count": sum(element_counts) / max(1, len(element_counts)),
        "average_unique_color_count": sum(color_counts) / max(1, len(color_counts)),
        "frames": frame_reports,
        "judgment": {
            "sequence_density": "light" if sum(element_counts) < 200 else "heavy",
        },
    }


def inspect_pack(path: Path):
    assets = [inspect_svg(source) for source in sorted(path.glob("*.svg"))]
    element_counts = [report["metrics"]["element_count"] for report in assets]
    color_counts = [report["metrics"]["unique_color_count"] for report in assets]
    return {
        "subject": str(path),
        "asset_count": len(assets),
        "average_element_count": sum(element_counts) / max(1, len(element_counts)),
        "average_unique_color_count": sum(color_counts) / max(1, len(color_counts)),
        "assets": assets,
        "judgment": {
            "pack_density": "light" if sum(element_counts) < 200 else "heavy",
            "palette_discipline": "tight" if (sum(color_counts) / max(1, len(color_counts))) <= 4 else "broad",
        },
    }


def compare(candidate_path: Path, reference_path: Path):
    candidate = inspect_path(candidate_path)
    reference = inspect_path(reference_path)
    candidate_elements = candidate.get("average_element_count", candidate["metrics"]["element_count"])
    reference_elements = reference.get("average_element_count", reference["metrics"]["element_count"])
    candidate_colors = candidate.get("average_unique_color_count", candidate["metrics"]["unique_color_count"])
    reference_colors = reference.get("average_unique_color_count", reference["metrics"]["unique_color_count"])
    return {
        "candidate": str(candidate_path),
        "reference": str(reference_path),
        "delta": {
            "element_count": round(candidate_elements - reference_elements, 3),
            "unique_color_count": round(candidate_colors - reference_colors, 3),
        },
    }


def inspect_path(path: Path):
    if path.is_dir():
        return inspect_sequence(path)
    return inspect_svg(path)


def write_output(payload, output_path):
    text = json.dumps(payload, indent=2)
    if output_path:
        Path(output_path).write_text(text, encoding="utf-8")
    else:
        print(text)


def main():
    parser = argparse.ArgumentParser(description="Analyze SVG effects according to SOPPyVFX.md.")
    subparsers = parser.add_subparsers(dest="command", required=True)

    inspect_frame = subparsers.add_parser("inspect-frame")
    inspect_frame.add_argument("--input", required=True)
    inspect_frame.add_argument("--output")

    inspect_sequence_parser = subparsers.add_parser("inspect-sequence")
    inspect_sequence_parser.add_argument("--input", required=True)
    inspect_sequence_parser.add_argument("--output")

    inspect_pack_parser = subparsers.add_parser("inspect-pack")
    inspect_pack_parser.add_argument("--input", required=True)
    inspect_pack_parser.add_argument("--output")

    compare_parser = subparsers.add_parser("compare")
    compare_parser.add_argument("--candidate", required=True)
    compare_parser.add_argument("--reference", required=True)
    compare_parser.add_argument("--output")

    args = parser.parse_args()
    if args.command == "inspect-frame":
        write_output(inspect_svg(Path(args.input)), args.output)
    elif args.command == "inspect-sequence":
        write_output(inspect_sequence(Path(args.input)), args.output)
    elif args.command == "inspect-pack":
        write_output(inspect_pack(Path(args.input)), args.output)
    else:
        write_output(compare(Path(args.candidate), Path(args.reference)), args.output)



if __name__ == "__main__":
    main()
