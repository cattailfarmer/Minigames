# Battleship-AH Justification

## Why Battleship-AH Is The Pilot

Battleship-AH is a strong first game because it matches AlienHand's core strengths:

- separate private player views
- clear host authority
- turn-based pacing
- simple but meaningful hidden information
- low transport complexity compared with action games

## Why It Proves The Platform

If Battleship-AH works, AlienHand will have already proven:

- one host can safely hold hidden state
- endpoints can receive station-specific views
- players can pair to stations cleanly
- turn transitions can protect privacy

That is enough to justify expansion into other asymmetric and private-information games.

## Why The Game Core Should Be Built First

The Battleship rules engine can be developed independently from final screen routing because the crucial truths are already local to the game:

- hidden information boundaries
- legal move structure
- turn progression
- result resolution
- private per-player view generation

That means most of the meaningful work can proceed before visual execution or endpoint routing is finalized.

## Why Wireframe-First Visuals Are Correct

Wireframe-first temporary visuals are justified because they:

- communicate state cleanly
- look intentional instead of unfinished
- keep the team moving before final art exists
- fit Battleship's grid- and boundary-heavy structure especially well

This allows gameplay and projection work to continue without waiting for polished asset production.

## Why Automatic Placement Is Justified

Automatic placement is justified in the standalone phase because it:

- reduces setup friction while the temporary shell is still rough
- keeps repeated playtests focused on privacy flow and combat rhythm
- still exercises the same placement legality rules
- helps the team reach more full matches per iteration
