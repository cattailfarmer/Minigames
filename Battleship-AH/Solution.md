# Battleship-AH Solution Baseline

## Current Intended Direction

Battleship-AH will first be developed as a complete hidden-state game core that can later be projected through AlienHand.

The first solution target is:

- a playable two-player game core
- host-owned rules and hidden state
- truthful private view-model output
- a standalone engine object not dependent on AlienHand runtime flow
- a project split that keeps AlienHand integration outside the core
- wireframe-first temporary visual language
- a later projection path through AlienHand

## Initial Deliverables

1. Define the complete Battleship rules engine.
2. Implement ship placement and attack resolution in host-authoritative logic.
3. Emit truthful private and transition view models.
4. Expose the engine through a standalone smoke path.
5. Only then attach projection and endpoint concerns.

## Known Open Decisions

- board size and exact ship roster
- UI style and presentation mode
- whether the first prototype uses a shared lobby screen on the host
- whether local and remote station support ship in the same first vertical slice

## Immediate Next Step

Use the now-compiling standalone engine as the center of gravity:

1. keep strengthening rule truth through the smoke executable
2. keep the standalone CLI playable without AlienHand
3. improve transition/privacy presentation in the standalone shell
4. only then return to platform projection concerns
