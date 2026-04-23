# AlienHand Specification

## Identity

AlienHand is a multiplayer host platform for games that require one or more independently assigned player stations, each with its own inputs, private or shared views, and host-mediated game state.

## Scope

AlienHand is responsible for:

- host-authoritative session management
- player and station identity
- device pairing and assignment
- display and endpoint assignment
- routing per-station view models
- routing per-station input events
- privacy boundaries between stations
- lifecycle management for games hosted on the platform

AlienHand is not initially responsible for:

- internet multiplayer
- mobile phone endpoints
- Smart TV native apps
- high-framerate video streaming optimized for action games
- full anti-cheat or hostile-network security

## Core Concepts

### Host

The host is the authoritative process that owns:

- session lifecycle
- full game state
- player registry
- station registry
- device registry
- endpoint registry
- routing and privacy policy

### Station

A station is the game-facing play node assigned to a player or team.

A station may contain:

- one player identity
- one or more input channels
- one display endpoint or view target
- one privacy policy
- one role within the active game session

### Input Channel

An input channel is a bound control source with a semantic role.

Examples:

- keyboard for menu and placement
- mouse for targeting
- gamepad for full control
- second mouse for auxiliary control

AlienHand must support multiple channels per station.

### Endpoint

An endpoint is a view surface capable of rendering station state.

Initial endpoint classes:

- local host window
- LAN PC endpoint

Deferred endpoint classes:

- Smart TV endpoint
- browser endpoint
- wireless display transport

### Projection Mode

A projection mode defines what an endpoint is allowed to render.

Initial projection modes:

- private station view
- shared public view
- turn-transition privacy curtain
- lobby/pairing view
- spectator view

## Pairing Model

AlienHand must support challenge-response pairing between screens and devices.

Initial pairing instructions:

- keyboard pairing by screen-specific key combination
- mouse pairing by clicking a small rectangle at a unique screen position
- gamepad pairing by screen-specific button or d-pad combination
- endpoint pairing by lobby code or host discovery plus explicit acceptance

Pairing results in:

- device identity
- endpoint identity
- station assignment
- optional role assignment inside a station

## Networking Model

Initial networking is LAN-first.

The host sends:

- lobby state
- station assignment state
- bounded per-endpoint view models
- turn and transition events

Endpoints send:

- presence and identity
- pairing responses
- local input events when enabled
- heartbeat and disconnect events

Initial implementation should prefer structured state messages over full video streaming.

## Privacy Rules

AlienHand must allow one host to hold hidden state for multiple players without leaking private information across stations.

The platform must:

- never send a private station more state than it is allowed to view
- support public and private render models simultaneously
- support turn handoff states that conceal private boards or hands
- support endpoint reassignment without exposing prior private state

## Phased Delivery

### Phase 1

- host application
- station model
- local host rendering
- LAN PC endpoint for remote display
- keyboard and gamepad support
- Battleship-AH pilot

### Phase 2

- remote input from LAN PC endpoints
- multi-mouse and multi-keyboard raw device support on host
- richer lobby and pairing UI

### Phase 3

- Smart TV style endpoints
- additional games with mixed public/private state
- more advanced station composition

## Constraints

- the host remains authoritative
- platform state must be separable from game state
- games must declare what each station is allowed to see
- endpoint support must degrade gracefully when hardware is limited
- the first implementation must optimize for correctness of station separation over transport cleverness
