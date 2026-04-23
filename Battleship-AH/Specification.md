# Battleship-AH Specification

## Identity

Battleship-AH is a two-player hidden-state Battleship implementation built on AlienHand.

## Scope

The pilot must demonstrate:

- two players
- two private stations
- host-authoritative game state
- separate board views per player
- ship placement
- alternating attack turns
- hit, miss, and sunk outcomes
- match completion
- pairing and screen assignment through AlienHand

Deferred features:

- AI opponents
- online play
- variants with more than two players
- animated flourishes beyond basic clarity needs
- advanced cosmetics and account systems

## Game State Model

The host owns:

- player identities
- ship placements
- attack history
- hit and miss resolution
- victory state
- current turn

Each station may only view:

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

- pairing screen
- ready state
- pass-turn privacy curtain
- victory screen

## Input Model

Initial supported controls:

- keyboard
- gamepad

Planned next:

- mouse
- multiple input channels per station if the platform enables it

## Turn Flow

1. players pair to stations
2. players place ships privately
3. host confirms readiness
4. player 1 takes a shot
5. result is resolved by host
6. turn transitions safely
7. player 2 takes a shot
8. repeat until all ships of one side are sunk

## Platform Dependency

Battleship-AH depends on AlienHand for:

- station identity
- endpoint assignment
- privacy-safe projection
- input routing
- session lifecycle

The game must not reimplement platform-level pairing or endpoint routing logic.
