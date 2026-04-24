# Game Genie Bootstrap Justification

## Why Not Build IRC From Scratch

The interesting originality of the Game Genie system is not basic IRC protocol reimplementation.

The originality is in:

- Game Genie session governance
- channel manifest semantics
- replay/state snapshot behavior
- BizHawk orchestration
- later runtime transformation

Using a proven IRC foundation preserves effort for those higher-value layers.

## Why Ergo

`Ergo` is the preferred server starting point because it is:

- MIT-licensed
- already a real IRC server
- already modern enough to be a serious substrate
- better suited to extension than inventing a new daemon from zero on day one

## Why The Lounge

`The Lounge` is the preferred client starting point because it is:

- MIT-licensed
- already a self-hosted IRC client
- a better substrate for visible Genie affordances than starting with a blank client

## Why A Separate Genie Bridge

The Game Genie system should not be welded directly into either:

- the IRC server core
- the client core
- the BizHawk runtime core

A separate bridge is justified because it preserves:

- protocol clarity
- tool substitution flexibility
- audit boundaries
- emulator authority boundaries

It also keeps the architecture truthful:

- IRC is the boot surface
- Genie is the governing waist
- BizHawk is runtime authority

## Why Defer Deeper Mutation

Runtime transformation is the most ambitious layer.

If attempted before the communication and orchestration spine exists, the project risks:

- architectural drift
- unclear authority boundaries
- uncontrolled complexity
- premature speculative design masquerading as build progress

Therefore the bootstrap stack should first earn:

1. channel/session formation
2. manifest and replay behavior
3. Genie command visibility
4. BizHawk launch seam

Only then should deeper mutation authority expand.
