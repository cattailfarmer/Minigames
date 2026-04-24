# Battleship-AH Specification

## Identity

Battleship-AH is a two-player hidden-state Battleship implementation with a host-authoritative game core and per-player private views.

## Scope

The pilot must demonstrate:

- two players
- host-authoritative game state
- separate private board views per player
- ship placement
- alternating attack turns
- hit, miss, and sunk outcomes
- match completion
- engine outputs that can later be routed through AlienHand

Deferred features:

- AI opponents
- online play
- variants with more than two players
- animated flourishes beyond basic clarity needs
- advanced cosmetics and account systems

## Temporary Visual Strategy

Until polished art is ready, Battleship-AH should use intentional hollow wireframe visuals rather than accidental placeholder graphics.

The temporary visual language should emphasize:

- board clarity
- hidden/public separation
- state readability
- low production cost with coherent style

## Game State Model

The game engine owns:

- player identities
- ship placements
- attack history
- hit and miss resolution
- victory state
- current turn

Each player view may only expose:

- its own board and ship layout
- its own knowledge of shots fired at the opponent
- public turn and result information

No station may view the opponent's undiscovered ship layout.

## Required Views

### Player Private View

Must show:

- own board with ship placement
- incoming hits and misses
- outgoing shot history
- current turn status
- available actions

### Shared Or Transition View

Must support:

- ready state
- pass-turn privacy curtain
- victory screen

## Input Model

Initial supported control intents:

- keyboard
- gamepad

Planned next:

- mouse
- multiple input channels per station if the platform enables it

## Turn Flow

1. player 1 places ships privately
2. player 2 places ships privately
3. both players confirm readiness
4. player 1 takes a shot
5. result is resolved by the engine
6. turn transitions safely
7. player 2 takes a shot
8. repeat until all ships of one side are sunk

Standalone development shells may additionally offer engine-driven legal auto-placement as a convenience path, as long as it uses the same placement rules and preserves hidden-state boundaries.

## Projection Dependency

Battleship-AH later depends on AlienHand for:

- privacy-safe projection
- endpoint assignment
- screen and station routing

The game core should remain valid even before platform-level projection is attached.
