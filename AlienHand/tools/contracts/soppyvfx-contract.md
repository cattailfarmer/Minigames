# SOPPyVFX Contract

Implements the actuation shape described by:

- [SOPPyVFX.md](C:/Project/Minigames/schema/SOPPyVFX.md)

Commands:

```text
soppyvfx.py render-effect --preset <name> --output <svg> [--width 512] [--height 512]
soppyvfx.py render-sequence --preset <name> --output-dir <dir> [--frames 12]
soppyvfx.py vary --preset <name> --output-dir <dir> [--count 4]
```

Initial presets:

- `sonar_ping`
- `water_splash`
- `impact_flash`
- `handoff_glow`

Required behavior:

- emit durable SVG artifacts
- emit sidecar JSON metadata
- preserve effect-family lineage
- allow bounded variation across declared parameters only
