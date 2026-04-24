# AlienHand Protocol Baseline

## Transport Direction

The first AlienHand transport uses structured messages instead of video streaming.

The host sends:

- lobby snapshot
- endpoint registration result
- station assignment result
- bounded station view
- transition events
- disconnect or heartbeat policy

Endpoints send:

- hello and endpoint identity
- pairing response
- local input event
- heartbeat

## Message Families

### Session And Lobby

- `HostHello`
- `LobbySnapshot`
- `StationAssignment`
- `EndpointAnnouncement`

### Pairing

- `PairingChallenge`
- `PairingResponse`
- `PairingResult`

### Input

- `StationInputEvent`
- `InputAcceptance`

### Projection

- `StationViewEnvelope`
- `TransitionEnvelope`

## Core Rule

No protocol message may send a station more information than that station is permitted to view.

That privacy boundary is more important than convenience of serialization.
