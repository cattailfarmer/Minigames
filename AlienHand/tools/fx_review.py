#!/usr/bin/env python3
import argparse
import json
from pathlib import Path

import audio_analyze
import vfx_analyze


def build_review(audio_pack: Path, vfx_pack: Path):
    audio_report = audio_analyze.inspect_pack(audio_pack, preset="battleship")
    vfx_report = vfx_analyze.inspect_pack(vfx_pack)

    audio_findings = []
    for asset in audio_report["assets"]:
        metrics = asset["metrics"]
        role = (asset.get("metadata") or {}).get("role")
        if metrics["rms"] < 0.02 and role not in {"transition", "stinger"}:
            audio_findings.append(f"{Path(asset['subject']).name}: very soft RMS may reduce cue readability.")
        if metrics["peak"] > 0.9 and role != "stinger":
            audio_findings.append(f"{Path(asset['subject']).name}: peak level is aggressive and may fatigue quickly.")

    vfx_findings = []
    for asset in vfx_report["assets"]:
        metrics = asset["metrics"]
        role = (asset.get("metadata") or {}).get("role")
        if metrics["element_count"] > 40:
            vfx_findings.append(f"{Path(asset['subject']).name}: element count is relatively dense for wireframe-first clarity.")
        if metrics["unique_color_count"] > 5 and role != "stinger":
            vfx_findings.append(f"{Path(asset['subject']).name}: palette breadth may be too wide for disciplined prototype identity.")

    summary = {
        "audio": {
            "asset_count": audio_report["asset_count"],
            "mix_density": audio_report["judgment"]["mix_density"],
            "event_readiness": audio_report["judgment"]["event_readiness"],
        },
        "vfx": {
            "asset_count": vfx_report["asset_count"],
            "pack_density": vfx_report["judgment"]["pack_density"],
            "palette_discipline": vfx_report["judgment"]["palette_discipline"],
        },
    }
    return {
        "summary": summary,
        "audio_report": audio_report,
        "vfx_report": vfx_report,
        "findings": {
            "audio": audio_findings,
            "vfx": vfx_findings,
        },
    }


def write_markdown(review, output_path: Path):
    lines = [
        "# Battleship Asset Review",
        "",
        "## Summary",
        "",
        f"- audio assets: {review['summary']['audio']['asset_count']}",
        f"- audio mix density: {review['summary']['audio']['mix_density']}",
        f"- audio event readiness: {review['summary']['audio']['event_readiness']}",
        f"- vfx assets: {review['summary']['vfx']['asset_count']}",
        f"- vfx pack density: {review['summary']['vfx']['pack_density']}",
        f"- vfx palette discipline: {review['summary']['vfx']['palette_discipline']}",
        "",
        "## Audio Findings",
        "",
    ]
    if review["findings"]["audio"]:
        lines.extend(f"- {finding}" for finding in review["findings"]["audio"])
    else:
        lines.append("- No major audio issues detected by the initial heuristic pass.")

    lines.extend(["", "## VFX Findings", ""])
    if review["findings"]["vfx"]:
        lines.extend(f"- {finding}" for finding in review["findings"]["vfx"])
    else:
        lines.append("- No major VFX issues detected by the initial heuristic pass.")

    output_path.write_text("\n".join(lines) + "\n", encoding="utf-8")


def main():
    parser = argparse.ArgumentParser(description="Review generated Battleship audio and VFX packs.")
    parser.add_argument("--audio-pack", required=True)
    parser.add_argument("--vfx-pack", required=True)
    parser.add_argument("--json-output", required=True)
    parser.add_argument("--markdown-output", required=True)
    args = parser.parse_args()

    review = build_review(Path(args.audio_pack), Path(args.vfx_pack))
    Path(args.json_output).write_text(json.dumps(review, indent=2), encoding="utf-8")
    write_markdown(review, Path(args.markdown_output))


if __name__ == "__main__":
    main()
