# Battleship-AH Generated Assets

## Purpose

This file tracks asset generation through the SOPPy tool lane.

## Current Tool Paths

- [soppywave.py](C:/Project/Minigames/AlienHand/tools/soppywave.py)
- [audio_analyze.py](C:/Project/Minigames/AlienHand/tools/audio_analyze.py)
- [soppyvfx.py](C:/Project/Minigames/AlienHand/tools/soppyvfx.py)
- [vfx_analyze.py](C:/Project/Minigames/AlienHand/tools/vfx_analyze.py)

AlienHand owns the reusable tooling. Battleship-AH consumes it and stores generated packs under its own project tree.

## Initial Battleship Asset Families

### Audio

- pairing accept
- pairing reject
- ready confirm
- placement confirm
- placement invalid
- turn start
- handoff curtain
- fire command
- hit confirm
- miss confirm
- sink confirm
- victory stinger
- defeat stinger
- sonar ping
- water splash

### VFX

- board grid
- ship outline
- hit marker
- miss marker
- sonar ping
- water splash
- impact flash
- handoff glow
- victory frame

## Expected Output

Each generated artifact should have:

- the artifact file itself
- a sidecar JSON describing lineage and parameters
- optional analysis JSON when inspected
- a manifest file when generated as part of a full pack
