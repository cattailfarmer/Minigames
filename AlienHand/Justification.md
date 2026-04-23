# AlienHand Justification

## Why This Platform Exists

Most local multiplayer systems assume one screen, one controller per player, and one shared game state surface.

AlienHand exists for a different class of local play:

- multiple players on one host machine
- multiple stations composed from flexible inputs
- private state and asymmetric views
- one authoritative processor serving many local console-like endpoints

## Why Host-Authoritative

The host-authoritative model is the cleanest way to preserve:

- hidden state
- turn order
- station privacy
- consistent rule enforcement
- simpler game integration

This is especially important for games like Battleship where each player must remain blind to the other's board.

## Why LAN PC Endpoint First

LAN PC endpoints are easier than Smart TV endpoints because they provide:

- controllable runtime environment
- better debugging
- lower platform fragmentation
- lower latency risk
- a reusable endpoint protocol that later Smart TV endpoints can adopt

## Why Stations Instead Of Devices

Devices are too low-level to model the experience cleanly.

AlienHand uses stations because a station can own:

- one or more devices
- one view target
- one privacy boundary
- one player role

This makes unusual control schemes possible without warping the game model.

## Why Battleship First

Battleship is the right pilot because it proves:

- private per-player views
- host-kept hidden state
- per-station rendering
- turn transitions
- low-latency requirements that are manageable early

It validates the platform architecture without requiring complex action-game transport.
