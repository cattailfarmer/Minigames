#!/usr/bin/env python3
import argparse
import html
import json
from pathlib import Path


def load_json(path: Path):
    return json.loads(path.read_text(encoding="utf-8"))


def rel(from_path: Path, to_path: Path):
    return to_path.relative_to(from_path.parent).as_posix()


def build_audio_section(output_path: Path, manifest, analysis):
    cards = []
    asset_lookup = {Path(asset["subject"]).name: asset for asset in analysis.get("assets", [])}
    for asset in manifest["assets"]:
        wav_name = Path(asset["path"]).name
        analysis_asset = asset_lookup.get(wav_name, {})
        metadata = analysis_asset.get("metadata", {})
        judgment = analysis_asset.get("judgment", {})
        cards.append(f"""
        <article class="card">
          <h3>{html.escape(asset['name'])}</h3>
          <p class="meta">role: {html.escape(str(metadata.get('role', '-')))}</p>
          <audio controls src="{html.escape(rel(output_path, Path(asset['path'])))}"></audio>
          <p class="meta">clarity: {html.escape(str(judgment.get('clarity', '-')))} | fatigue: {html.escape(str(judgment.get('fatigue_risk', '-')))}</p>
        </article>
        """)
    return "\n".join(cards)


def build_vfx_section(output_path: Path, manifest, analysis):
    cards = []
    asset_lookup = {Path(asset["subject"]).name: asset for asset in analysis.get("assets", [])}
    for asset in manifest["assets"]:
        svg_name = Path(asset["path"]).name
        analysis_asset = asset_lookup.get(svg_name, {})
        metadata = analysis_asset.get("metadata", {})
        judgment = analysis_asset.get("judgment", {})
        role = str(metadata.get("role", "-"))
        card_class = "card card-wide" if role == "board" else "card"
        cards.append(f"""
        <article class="{card_class}">
          <h3>{html.escape(asset['name'])}</h3>
          <p class="meta">role: {html.escape(role)} | size: {html.escape(str(metadata.get('width', '-')))}x{html.escape(str(metadata.get('height', '-')))}</p>
          <img src="{html.escape(rel(output_path, Path(asset['path'])))}" alt="{html.escape(asset['name'])}" />
          <p class="meta">clutter: {html.escape(str(judgment.get('clutter_risk', '-')))} | structure: {html.escape(str(judgment.get('structure_risk', '-')))}</p>
        </article>
        """)
    return "\n".join(cards)


def build_html(output_path: Path, audio_manifest, vfx_manifest, review, audio_analysis_path: Path, vfx_analysis_path: Path, review_md_path: Path):
    audio_cards = build_audio_section(output_path, audio_manifest, review["audio_report"])
    vfx_cards = build_vfx_section(output_path, vfx_manifest, review["vfx_report"])
    return f"""<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8" />
  <title>Battleship-AH Asset Gallery</title>
  <style>
    body {{
      margin: 0;
      font-family: Arial, sans-serif;
      background: #07131c;
      color: #e7f3fb;
    }}
    main {{
      max-width: 1200px;
      margin: 0 auto;
      padding: 32px 24px 64px;
    }}
    h1, h2 {{
      margin-bottom: 8px;
    }}
    .summary {{
      display: grid;
      grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
      gap: 12px;
      margin: 20px 0 32px;
    }}
    .panel {{
      border: 1px solid #2a4a59;
      padding: 16px;
      background: #0c1d28;
    }}
    .grid {{
      display: grid;
      grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
      gap: 14px;
    }}
    .card {{
      border: 1px solid #224050;
      background: #0a1821;
      padding: 14px;
    }}
    .card-wide {{
      grid-column: span 2;
    }}
    .card img {{
      width: 100%;
      height: auto;
      background: #04111c;
      border: 1px solid #19303d;
    }}
    .card audio {{
      width: 100%;
      margin: 8px 0;
    }}
    .meta {{
      color: #9ab4c3;
      font-size: 0.92rem;
    }}
    a {{
      color: #8ef7ff;
    }}
    @media (max-width: 700px) {{
      .card-wide {{
        grid-column: span 1;
      }}
    }}
  </style>
</head>
<body>
  <main>
    <h1>Battleship-AH Asset Gallery</h1>
    <p class="meta">Generated from SOPPyWave and SOPPyVFX manifests with review summaries.</p>

    <section class="summary">
      <div class="panel">
        <strong>Audio</strong>
        <div>{review['summary']['audio']['asset_count']} assets</div>
        <div>mix density: {review['summary']['audio']['mix_density']}</div>
        <div>event readiness: {review['summary']['audio']['event_readiness']}</div>
      </div>
      <div class="panel">
        <strong>VFX</strong>
        <div>{review['summary']['vfx']['asset_count']} assets</div>
        <div>pack density: {review['summary']['vfx']['pack_density']}</div>
        <div>palette discipline: {review['summary']['vfx']['palette_discipline']}</div>
      </div>
      <div class="panel">
        <strong>Reports</strong>
        <div><a href="{html.escape(rel(output_path, audio_analysis_path))}">Audio analysis JSON</a></div>
        <div><a href="{html.escape(rel(output_path, vfx_analysis_path))}">VFX analysis JSON</a></div>
        <div><a href="{html.escape(rel(output_path, review_md_path))}">Review markdown</a></div>
      </div>
    </section>

    <h2>Audio Pack</h2>
    <section class="grid">
      {audio_cards}
    </section>

    <h2>VFX Pack</h2>
    <section class="grid">
      {vfx_cards}
    </section>
  </main>
</body>
</html>
"""


def main():
    parser = argparse.ArgumentParser(description="Generate an HTML gallery for Battleship asset packs.")
    parser.add_argument("--audio-manifest", required=True)
    parser.add_argument("--vfx-manifest", required=True)
    parser.add_argument("--review-json", required=True)
    parser.add_argument("--audio-analysis", required=True)
    parser.add_argument("--vfx-analysis", required=True)
    parser.add_argument("--review-markdown", required=True)
    parser.add_argument("--output", required=True)
    args = parser.parse_args()

    output_path = Path(args.output)
    output_path.parent.mkdir(parents=True, exist_ok=True)
    html_text = build_html(
        output_path,
        load_json(Path(args.audio_manifest)),
        load_json(Path(args.vfx_manifest)),
        load_json(Path(args.review_json)),
        Path(args.audio_analysis),
        Path(args.vfx_analysis),
        Path(args.review_markdown),
    )
    output_path.write_text(html_text, encoding="utf-8")


if __name__ == "__main__":
    main()
