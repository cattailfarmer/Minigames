# Battleship-AH Solution Baseline

## Current Intended Direction

Battleship-AH will be built only through the AlienHand platform contract.

The first solution target is:

- a playable two-player local/LAN prototype
- host-owned rules and hidden state
- at least one remote PC endpoint path
- clear station-private rendering

## Initial Deliverables

1. Define the Battleship game contract against AlienHand.
2. Implement ship placement and attack resolution in host-authoritative logic.
3. Render one private view per station.
4. Add pairing, ready, and pass-turn flow.
5. Reach end-to-end playable match completion.

## Known Open Decisions

- board size and exact ship roster
- UI style and presentation mode
- whether the first prototype uses a shared lobby screen on the host
- whether local and remote station support ship in the same first vertical slice

## Immediate Next Step

Choose the technical stack for AlienHand and Battleship-AH together, then define the shared host-to-endpoint protocol and the game integration boundary.
