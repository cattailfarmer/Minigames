#!/usr/bin/env python3
import argparse
import json
import math
import random
from pathlib import Path


PRESETS = {
    "sonar_ping": {"stroke": "#8ef7ff", "fill": "none", "role": "signature", "family": "battleship", "default_width": 512, "default_height": 512},
    "water_splash": {"stroke": "#7fb8ff", "fill": "#7fb8ff22", "role": "impact_tail", "family": "battleship", "default_width": 512, "default_height": 512},
    "impact_flash": {"stroke": "#ffe27a", "fill": "#fff4b833", "role": "event", "family": "battleship", "default_width": 512, "default_height": 512},
    "handoff_glow": {"stroke": "#c28cff", "fill": "#c28cff22", "role": "transition", "family": "battleship", "default_width": 640, "default_height": 360},
    "board_grid": {"stroke": "#6eb7c9", "fill": "none", "role": "board", "family": "battleship", "default_width": 896, "default_height": 896},
    "hit_marker": {"stroke": "#ff8f6b", "fill": "none", "role": "event", "family": "battleship", "default_width": 384, "default_height": 384},
    "miss_marker": {"stroke": "#8fd8ff", "fill": "none", "role": "event", "family": "battleship", "default_width": 384, "default_height": 384},
    "ship_outline": {"stroke": "#9fb6c8", "fill": "none", "role": "board", "family": "battleship", "default_width": 896, "default_height": 192},
    "victory_frame": {"stroke": "#ffe27a", "fill": "#ffe27a11", "role": "stinger", "family": "battleship", "default_width": 768, "default_height": 432},
}

BATTLESHIP_PACK = [
    "board_grid",
    "ship_outline",
    "hit_marker",
    "miss_marker",
    "sonar_ping",
    "water_splash",
    "impact_flash",
    "handoff_glow",
    "victory_frame",
]


def svg_header(width, height):
    return [
        f'<svg xmlns="http://www.w3.org/2000/svg" width="{width}" height="{height}" viewBox="0 0 {width} {height}">',
        '<rect width="100%" height="100%" fill="#04111c"/>',
    ]


def sonar_ping(width, height, rng):
    cx = width / 2
    cy = height / 2
    rings = []
    for index, radius in enumerate((48, 92, 136)):
        opacity = 0.9 - (index * 0.22)
        rings.append(f'<circle cx="{cx}" cy="{cy}" r="{radius}" fill="none" stroke="#8ef7ff" stroke-width="4" opacity="{opacity:.2f}"/>')
    rings.append(f'<circle cx="{cx}" cy="{cy}" r="8" fill="#8ef7ff" opacity="0.9"/>')
    return rings


def water_splash(width, height, rng):
    cx = width / 2
    cy = height / 2 + 40
    lines = []
    for index in range(18):
        angle = math.pi + (index / 17.0) * math.pi
        length = 90 + rng.randint(-12, 18)
        x2 = cx + math.cos(angle) * length
        y2 = cy + math.sin(angle) * length
        lines.append(f'<line x1="{cx}" y1="{cy}" x2="{x2:.1f}" y2="{y2:.1f}" stroke="#7fb8ff" stroke-width="3" opacity="0.8"/>')
    lines.append(f'<ellipse cx="{cx}" cy="{cy}" rx="82" ry="22" fill="none" stroke="#a9dcff" stroke-width="4" opacity="0.65"/>')
    return lines


def impact_flash(width, height, rng):
    cx = width / 2
    cy = height / 2
    rays = []
    for index in range(12):
        angle = (index / 12.0) * math.tau
        inner = 40
        outer = 150 + rng.randint(-10, 20)
        x1 = cx + math.cos(angle) * inner
        y1 = cy + math.sin(angle) * inner
        x2 = cx + math.cos(angle) * outer
        y2 = cy + math.sin(angle) * outer
        rays.append(f'<line x1="{x1:.1f}" y1="{y1:.1f}" x2="{x2:.1f}" y2="{y2:.1f}" stroke="#ffe27a" stroke-width="6" opacity="0.9"/>')
    rays.append(f'<circle cx="{cx}" cy="{cy}" r="44" fill="#fff4b8" opacity="0.65"/>')
    return rays


def handoff_glow(width, height, rng):
    pad = 36
    return [
        f'<rect x="{pad}" y="{pad}" width="{width - (pad * 2)}" height="{height - (pad * 2)}" rx="18" fill="none" stroke="#c28cff" stroke-width="6" opacity="0.85"/>',
        f'<rect x="{pad + 18}" y="{pad + 18}" width="{width - ((pad + 18) * 2)}" height="{height - ((pad + 18) * 2)}" rx="14" fill="none" stroke="#f1d8ff" stroke-width="3" opacity="0.55"/>',
        f'<circle cx="{width / 2}" cy="{height / 2}" r="64" fill="#c28cff22" stroke="#c28cff" stroke-width="3" opacity="0.7"/>',
    ]


def board_grid(width, height, rng):
    margin = 44
    lines = [f'<rect x="{margin}" y="{margin}" width="{width - (margin * 2)}" height="{height - (margin * 2)}" fill="none" stroke="#6eb7c9" stroke-width="4"/>']
    cell = (width - (margin * 2)) / 10.0
    for index in range(1, 10):
        offset = margin + (cell * index)
        lines.append(f'<line x1="{offset:.1f}" y1="{margin}" x2="{offset:.1f}" y2="{height - margin}" stroke="#6eb7c9" stroke-width="2" opacity="0.75"/>')
        lines.append(f'<line x1="{margin}" y1="{offset:.1f}" x2="{width - margin}" y2="{offset:.1f}" stroke="#6eb7c9" stroke-width="2" opacity="0.75"/>')
    return lines


def hit_marker(width, height, rng):
    cx = width / 2
    cy = height / 2
    size = 96
    return [
        f'<line x1="{cx - size}" y1="{cy - size}" x2="{cx + size}" y2="{cy + size}" stroke="#ff8f6b" stroke-width="10" opacity="0.95"/>',
        f'<line x1="{cx + size}" y1="{cy - size}" x2="{cx - size}" y2="{cy + size}" stroke="#ff8f6b" stroke-width="10" opacity="0.95"/>',
        f'<circle cx="{cx}" cy="{cy}" r="124" fill="none" stroke="#ffcfb8" stroke-width="4" opacity="0.45"/>',
    ]


def miss_marker(width, height, rng):
    cx = width / 2
    cy = height / 2
    return [
        f'<circle cx="{cx}" cy="{cy}" r="108" fill="none" stroke="#8fd8ff" stroke-width="8" opacity="0.9"/>',
        f'<circle cx="{cx}" cy="{cy}" r="56" fill="none" stroke="#d8f3ff" stroke-width="4" opacity="0.55"/>',
    ]


def ship_outline(width, height, rng):
    x = 88
    y = height / 2 - 34
    body_w = width - 176
    body_h = 68
    return [
        f'<rect x="{x}" y="{y}" width="{body_w}" height="{body_h}" rx="20" fill="none" stroke="#9fb6c8" stroke-width="5" opacity="0.9"/>',
        f'<line x1="{x + 40}" y1="{y + body_h}" x2="{x + 10}" y2="{y + body_h + 26}" stroke="#9fb6c8" stroke-width="5" opacity="0.8"/>',
        f'<line x1="{x + body_w - 40}" y1="{y + body_h}" x2="{x + body_w - 10}" y2="{y + body_h + 26}" stroke="#9fb6c8" stroke-width="5" opacity="0.8"/>',
    ]


def victory_frame(width, height, rng):
    pad = 28
    return [
        f'<rect x="{pad}" y="{pad}" width="{width - (pad * 2)}" height="{height - (pad * 2)}" fill="none" stroke="#ffe27a" stroke-width="8" opacity="0.95"/>',
        f'<rect x="{pad + 18}" y="{pad + 18}" width="{width - ((pad + 18) * 2)}" height="{height - ((pad + 18) * 2)}" fill="none" stroke="#fff1ba" stroke-width="3" opacity="0.6"/>',
        f'<circle cx="{width / 2}" cy="{height / 2}" r="92" fill="#ffe27a11" stroke="#ffe27a" stroke-width="4" opacity="0.8"/>',
    ]


BUILDERS = {
    "sonar_ping": sonar_ping,
    "water_splash": water_splash,
    "impact_flash": impact_flash,
    "handoff_glow": handoff_glow,
    "board_grid": board_grid,
    "hit_marker": hit_marker,
    "miss_marker": miss_marker,
    "ship_outline": ship_outline,
    "victory_frame": victory_frame,
}


def build_svg(preset_name, width, height, seed):
    rng = random.Random(seed)
    content = svg_header(width, height)
    content.extend(BUILDERS[preset_name](width, height, rng))
    content.append("</svg>")
    return "\n".join(content)


def write_sidecar(path, payload):
    path.with_suffix(path.suffix + ".json").write_text(json.dumps(payload, indent=2), encoding="utf-8")


def render_effect(args):
    output = Path(args.output)
    output.parent.mkdir(parents=True, exist_ok=True)
    seed = args.seed if args.seed is not None else 7
    preset = PRESETS[args.preset]
    width = args.width if args.width is not None else preset.get("default_width", 512)
    height = args.height if args.height is not None else preset.get("default_height", 512)
    output.write_text(build_svg(args.preset, width, height, seed), encoding="utf-8")
    write_sidecar(output, {
        "tool": "soppyvfx",
        "preset": args.preset,
        "seed": seed,
        "width": width,
        "height": height,
        "role": preset.get("role"),
        "family": preset.get("family"),
        "schema": "schema/SOPPyVFX.md",
    })


def render_battleship_pack(args):
    output_dir = Path(args.output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)
    manifest = {"tool": "soppyvfx", "pack": "battleship", "assets": []}
    for index, preset_name in enumerate(BATTLESHIP_PACK):
        output = output_dir / f"{preset_name}.svg"
        seed = (args.seed if args.seed is not None else 900) + index
        render_effect(argparse.Namespace(
            preset=preset_name,
            output=str(output),
            width=None,
            height=None,
            seed=seed,
        ))
        manifest["assets"].append({
            "name": preset_name,
            "path": str(output),
            "sidecar": str(output) + ".json",
        })
    (output_dir / "battleship_vfx_manifest.json").write_text(json.dumps(manifest, indent=2), encoding="utf-8")


def render_sequence(args):
    output_dir = Path(args.output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)
    for frame in range(args.frames):
        render_effect(argparse.Namespace(
            preset=args.preset,
            output=str(output_dir / f"{args.preset}_{frame + 1:03d}.svg"),
            width=args.width,
            height=args.height,
            seed=(args.seed if args.seed is not None else 7) + frame,
        ))


def vary(args):
    output_dir = Path(args.output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)
    for index in range(args.count):
        render_effect(argparse.Namespace(
            preset=args.preset,
            output=str(output_dir / f"{args.preset}_variant_{index + 1:02d}.svg"),
            width=args.width,
            height=args.height,
            seed=(args.seed if args.seed is not None else 7) + index,
        ))


def build_parser():
    parser = argparse.ArgumentParser(description="Generate SVG VFX artifacts according to SOPPyVFX.md.")
    subparsers = parser.add_subparsers(dest="command", required=True)

    render_parser = subparsers.add_parser("render-effect")
    render_parser.add_argument("--preset", choices=sorted(PRESETS), required=True)
    render_parser.add_argument("--output", required=True)
    render_parser.add_argument("--width", type=int)
    render_parser.add_argument("--height", type=int)
    render_parser.add_argument("--seed", type=int)
    render_parser.set_defaults(func=render_effect)

    sequence_parser = subparsers.add_parser("render-sequence")
    sequence_parser.add_argument("--preset", choices=sorted(PRESETS), required=True)
    sequence_parser.add_argument("--output-dir", required=True)
    sequence_parser.add_argument("--frames", type=int, default=12)
    sequence_parser.add_argument("--width", type=int)
    sequence_parser.add_argument("--height", type=int)
    sequence_parser.add_argument("--seed", type=int)
    sequence_parser.set_defaults(func=render_sequence)

    vary_parser = subparsers.add_parser("vary")
    vary_parser.add_argument("--preset", choices=sorted(PRESETS), required=True)
    vary_parser.add_argument("--output-dir", required=True)
    vary_parser.add_argument("--count", type=int, default=4)
    vary_parser.add_argument("--width", type=int)
    vary_parser.add_argument("--height", type=int)
    vary_parser.add_argument("--seed", type=int)
    vary_parser.set_defaults(func=vary)

    pack_parser = subparsers.add_parser("render-battleship-pack")
    pack_parser.add_argument("--output-dir", required=True)
    pack_parser.add_argument("--seed", type=int)
    pack_parser.set_defaults(func=render_battleship_pack)
    return parser


def main():
    parser = build_parser()
    args = parser.parse_args()
    args.func(args)


if __name__ == "__main__":
    main()
