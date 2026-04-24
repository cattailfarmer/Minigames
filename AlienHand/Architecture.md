# AlienHand Architecture

## Chosen Stack

AlienHand will start as a Windows-first .NET 10 platform with a host executable, a slim LAN endpoint executable, and shared contracts/core libraries.

Initial stack:

- .NET 10
- C#
- host-authoritative application model
- structured state projection over LAN
- keyboard and gamepad first
- raw multi-device support later

UI stack is intentionally deferred one stage.

The first working vertical slice prioritizes:

- session correctness
- station/privacy separation
- host-to-endpoint protocol shape
- game integration contract

The first code skeleton therefore uses console executables plus shared libraries rather than pretending the UI layer is already settled.

## Project Layout

- `AlienHand/src/AlienHand.Contracts`
  Shared IDs, message contracts, station definitions, and game/session interfaces.
- `AlienHand/src/AlienHand.Core`
  Host-side coordination, pairing, station registry, endpoint registry, and routing helpers.
- `AlienHand/src/AlienHand.Host`
  Host executable shell.
- `AlienHand/src/AlienHand.Endpoint`
  Slim LAN endpoint executable shell.
- `AlienHand/tools`
  Shared media-generation, analysis, review, and tracker tooling owned by the platform.
- `Battleship-AH/src/BattleshipAH.Core`
  Battleship rules, state, and station-specific view projection.

## Architectural Direction

### Host Owns Authority

The host owns:

- session lifecycle
- player identity
- station assignment
- endpoint assignment
- hidden game state
- view routing
- final rule resolution

### Endpoints Render Bounded Views

Endpoints do not receive full game state.

They receive only:

- endpoint registration and assignment state
- the bounded view model for their station
- public transition and lobby signals

### Games Plug Into AlienHand

Games must provide:

- station templates
- a session state machine
- station-bounded view projection
- handling for station input events

Games must not:

- own endpoint transport
- bypass station privacy
- directly reassign devices or endpoints

### AlienHand Owns Reusable Media Tooling

AlienHand owns the reusable audio, VFX, tracker, and analysis tooling that future games can call without rebuilding a separate pipeline.

That shared toolchain is responsible for:

- procedural SFX generation
- wireframe and prototype VFX generation
- tracker-style music authoring and preview render
- artifact analysis and review reporting
- HTML gallery generation for pack inspection

Battleship-AH consumes these tools and contributes presets, generated packs, and game-specific review targets.

## Initial Vertical Slice

The first vertical slice is:

1. host creates an AlienHand session
2. Battleship-AH creates two private stations
3. host assigns stations to players/endpoints
4. host projects station-specific views
5. endpoint renders a station summary
6. host accepts input commands and advances turn state

## Deferred Items

- final desktop UI framework
- advanced pairing visuals
- raw multi-mouse input
- Smart TV endpoints
- audio/video-rich rendering
