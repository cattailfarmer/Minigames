# Battleship-AH Architecture

## Role In The Platform

Battleship-AH is the first game plugin for AlienHand.

Its job is to prove:

- host-authoritative hidden state
- station-private view projection
- station-specific input handling
- turn-safe transition flow

## Domain Shape

### Match State

The match owns:

- two players
- two boards
- ship roster
- placement state
- shot history
- current turn
- final winner state

### Station Views

Each station sees:

- its own board
- its own ships
- incoming attack results
- its own known outgoing results
- turn and status messaging

It does not see:

- undiscovered enemy ship positions

### Integration Boundary

Battleship-AH now consists of:

- a standalone `BattleshipMatch` engine
- a standalone `BattleshipAH.Core` project for rules and view models
- a standalone `BattleshipAH.Smoke` project for scripted engine verification
- a standalone `BattleshipAH.Cli` project for local console play
- a thin AlienHand-facing `BattleshipSession` adapter
- a separate `BattleshipAH.AlienHandAdapter` project for platform projection

The standalone engine owns:

- rules
- state
- placement
- turns
- hit and sink resolution
- private/shared view generation

The adapter exports:

- station templates for two players
- a session object that handles station input
- station-bounded view projection

The standalone shell exports:

- a local handoff-based console experience
- placement and combat loops without platform routing
- a temporary wireframe-like ASCII board presentation

AlienHand later supplies:

- station identity
- endpoint routing
- pairing lifecycle
- host authority shell
