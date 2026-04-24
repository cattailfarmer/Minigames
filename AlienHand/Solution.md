# AlienHand Solution Baseline

## Current Intended Direction

AlienHand will be developed as a host platform first, not as a collection of game-specific hacks.

The first concrete solution target is:

- a host application
- a LAN PC display endpoint
- a station assignment and pairing flow
- a game integration contract sufficient for Battleship-AH
- a Windows-first .NET 10 implementation skeleton
- a reusable AlienHand-owned media toolchain for asset generation and review

## Initial Deliverables

1. Define the host/session/station/endpoint contracts.
2. Define the pairing and assignment protocol.
3. Build a host application shell.
4. Build a slim LAN PC endpoint.
5. Build Battleship-AH against the platform contract.
6. Centralize media tooling under AlienHand so multiple games can consume one pipeline.

## Known Open Decisions

- final desktop UI stack
- raw multi-device support timing
- whether remote endpoints are render-model driven or scene-command driven

## Immediate Next Step

Implement the first technical architecture for the host and endpoint applications, validate the shared contract boundary with Battleship-AH, and then choose the first desktop UI layer on top of the working core.
