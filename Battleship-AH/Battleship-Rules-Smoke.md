# Battleship-AH Rules Smoke

## Current Smoke Path

The current smoke path exists in two forms:

- through the AlienHand host shell
- through the standalone `BattleshipAH.Smoke` executable that drives `BattleshipMatch` directly

It demonstrates:

- invalid placement rejection
- premature readiness rejection
- legal ship placement for both players
- readiness confirmation
- out-of-turn rejection
- duplicate-target rejection
- hit, miss, sink, and victory outcomes
- bounded target-board projection
- a shared summary view that does not leak hidden fleet layout

## What This Proves

- Battleship-AH now contains real turn state rather than placeholder text
- placement now exists as real engine state instead of pre-seeded fleets
- station views differ by player knowledge
- the host/game boundary can carry meaningful hidden-state play
- the core can now be exercised directly without waiting on projection-layer progress
- the standalone core project can evolve without pulling AlienHand contracts into every build step
- the standalone smoke executable now acts as a rules witness rather than only a toy demo
- the standalone CLI path compiles for local no-platform play

## What It Does Not Yet Prove

- endpoint transport
- disconnect recovery
- actual UI
- polished screen flow or visual identity
