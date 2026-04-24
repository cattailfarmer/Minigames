# Battleship-AH

Battleship-AH is the pilot game for AlienHand Games.

It exists to prove that one host PC can run a hidden-state multiplayer game across multiple stations while keeping each player's board private.

Battleship-AH is not just a Battleship clone. It is the first validation target for:

- private station rendering
- host-authoritative hidden state
- pairing and station assignment
- handoff-safe turn transitions
- LAN endpoint projection

## Standalone Development Paths

Until AlienHand projection returns to the critical path, Battleship-AH can be exercised directly through:

- `BattleshipAH.Core` for the standalone rules engine
- `BattleshipAH.Smoke` for scripted rules verification
- `BattleshipAH.Cli` for a local handoff-based console play loop
