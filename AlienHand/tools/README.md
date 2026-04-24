# AlienHand Media Toolchain

AlienHand owns the reusable media-generation and analysis tooling used by Battleship-AH and future AlienHand games.

These command-line tools are the operational realization of the workspace media schemas:

- [Audio_Processing.md](C:/Project/Minigames/schema/Audio_Processing.md)
- [SOPPyWave.md](C:/Project/Minigames/schema/SOPPyWave.md)
- [SOPPyVFX.md](C:/Project/Minigames/schema/SOPPyVFX.md)
- [MOD-Tracker.md](C:/Project/Minigames/schema/MOD-Tracker.md)
- [SOPPyWave-MOD_bridge.md](C:/Project/Minigames/schema/SOPPyWave-MOD_bridge.md)

Current tools:

- `audio_analyze.py`
  - waveform inspection, comparison, and pack analysis
- `soppywave.py`
  - procedural sound generation and Battleship audio-pack rendering
- `soppyvfx.py`
  - wireframe VFX generation and Battleship VFX-pack rendering
- `vfx_analyze.py`
  - SVG and VFX pack inspection
- `fx_review.py`
  - combined pack review and summary generation
- `fx_preview.py`
  - HTML gallery generation for generated media packs
- `soppytracker.py`
  - tracker-style module creation, inspection, and offline preview render
- `soppywave_mod_bridge.py`
  - procedural tone bridge between tracker modules and SOPPyWave synthesis

Contracts:

- [audio-analysis-contract.md](C:/Project/Minigames/AlienHand/tools/contracts/audio-analysis-contract.md)
- [soppywave-contract.md](C:/Project/Minigames/AlienHand/tools/contracts/soppywave-contract.md)
- [soppyvfx-contract.md](C:/Project/Minigames/AlienHand/tools/contracts/soppyvfx-contract.md)
- [vfx-analysis-contract.md](C:/Project/Minigames/AlienHand/tools/contracts/vfx-analysis-contract.md)
- [soppytracker-contract.md](C:/Project/Minigames/AlienHand/tools/contracts/soppytracker-contract.md)
- [soppywave-mod-bridge-contract.md](C:/Project/Minigames/AlienHand/tools/contracts/soppywave-mod-bridge-contract.md)

Suggested usage pattern:

1. generate candidate artifact
2. analyze artifact or pack
3. review the structured report
4. refine parameters or emit variations

Battleship pack generation:

```text
C:\Users\jerem\AppData\Local\Programs\Python\Python313\python.exe AlienHand\tools\soppywave.py render-battleship-pack --output-dir Battleship-AH\src\generated\audio\battleship-pack
C:\Users\jerem\AppData\Local\Programs\Python\Python313\python.exe AlienHand\tools\soppyvfx.py render-battleship-pack --output-dir Battleship-AH\src\generated\vfx\battleship-pack
```

Compatibility note:

The repo-root `tools\` directory remains as a thin wrapper layer so older commands still work while ownership lives under `AlienHand\tools`.
