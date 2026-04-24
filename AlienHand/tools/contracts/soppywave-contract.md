# SOPPyWave Contract

Implements the actuation shape described by:

- [SOPPyWave.md](C:/Project/Minigames/schema/SOPPyWave.md)

Commands:

```text
soppywave.py render --preset <name> --output <wav> [--duration 0.8] [--sample-rate 44100]
soppywave.py vary --preset <name> --output-dir <dir> [--count 4]
```

Initial presets:

- `sonar_ping`
- `water_splash`
- `ui_lockon`
- `impact_boom`

Required behavior:

- emit durable WAV artifacts
- emit sidecar JSON metadata next to generated files
- preserve parameter lineage
- allow bounded variation
