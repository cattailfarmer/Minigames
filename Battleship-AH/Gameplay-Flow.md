# Battleship-AH Gameplay Flow

## Core Claim

Battleship-AH can be built almost entirely as a standalone hidden-state game engine.

Its dependency on AlienHand is primarily the projection layer:

- where player views are rendered
- how stations are paired to screens or endpoints
- how transitions are presented

The game core itself should therefore be developed first as a complete host-authoritative rules engine.

## Full Game Flow

### 1. Match Initialization

- create player one state
- create player two state
- create empty attack histories
- create board state and ship roster
- set first turn
- set match phase

### 2. Placement Phase

Each player:

- sees only their own board
- places ships legally
- confirms readiness

The engine must validate:

- ship length
- orientation
- board bounds
- no overlap

### 3. Transition To Play

When both players are ready:

- lock ship placement
- begin active play
- reveal only legal station-specific information

### 4. Turn Loop

On each turn:

- active player selects one target coordinate
- engine validates that the coordinate has not already been targeted by that player
- engine resolves miss, hit, sink, or victory
- engine records the event in both private and public terms
- engine advances or terminates turn state

### 5. End State

When one fleet is destroyed:

- set winner
- set completed phase
- preserve final boards and shot history
- expose result-specific private views

## Engine Outputs

The game core should emit view models for:

- player one private view
- player two private view
- optional shared/transition summary

These outputs should be truthful without assuming any specific screen technology.

## Current Gap

The current core already handles:

- initialized boards
- placement validation
- readiness validation
- turn order
- shot parsing
- hit/miss/sink/victory
- bounded player views
- compile-clean standalone builds
- a stronger smoke path with explicit rule checks
- a local console shell for manual play

The next major engine gap is:

- stronger transition/privacy presentation for real handoff play
- broader edge-case coverage if rules evolve
- later projection hookup after the standalone loop feels good
