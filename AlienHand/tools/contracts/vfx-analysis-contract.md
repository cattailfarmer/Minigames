# VFX Analysis Contract

Implements the visual inspection side described by:

- [SOPPyVFX.md](C:/Project/Minigames/schema/SOPPyVFX.md)

Commands:

```text
vfx_analyze.py inspect-frame --input <svg> [--output <json>]
vfx_analyze.py inspect-sequence --input <dir> [--output <json>]
vfx_analyze.py compare --candidate <svg-or-dir> --reference <svg-or-dir> [--output <json>]
```

Required behavior:

- inspect element counts, palette breadth, layer density, and frame counts
- estimate clutter risk and family coherence from emitted metadata when available
- provide JSON reports suitable for iteration
