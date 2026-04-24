# SOPPyWave MOD Bridge Contract

Implements the procedural tone bridge described by:

- [SOPPyWave-MOD_bridge.md](C:/Project/Minigames/schema/SOPPyWave-MOD_bridge.md)

Commands:

```text
soppywave_mod_bridge.py bake-tone --family <name> --note <pitch> --output <wav>
soppywave_mod_bridge.py bind-module --input <json> --output <json>
```

Current behavior:

- defines procedural tone families usable by tracker instruments
- bakes tone families to wav
- enriches tracker modules with procedural instrument bindings

Initial tone families:

- `sonar_tone`
- `chip_bass`
- `pulse_pluck`
- `drone_pad`
- `noise_hat`
