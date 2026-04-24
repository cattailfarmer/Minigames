# SOPPyTracker Contract

Implements the sequencing and module-authoring shape described by:

- [MOD-Tracker.md](C:/Project/Minigames/schema/MOD-Tracker.md)

Commands:

```text
soppytracker.py new-battleship-module --output <json>
soppytracker.py inspect-module --input <json> [--output <json>]
soppytracker.py render-module --input <json> --output <wav> [--sample-rate 44100]
```

Current behavior:

- creates internal tracker-style module JSON
- preserves order list, patterns, channels, instruments, and bindings
- renders an offline song preview from the internal representation

This is an internal hybrid representation, not a byte-accurate MOD/XM/IT exporter yet.
