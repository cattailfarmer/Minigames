# Game Genie Bootstrap Specification

## Subject

First executable bootstrap stack for the Game Genie system.

## Intent

Establish a practical, MIT-licensed starting point for:

- IRC server boot
- channel/client participation
- Game Genie coordination
- BizHawk launch staging

without prematurely building the full runtime transformation system from scratch.

## Required Shape

The first bootstrap stack shall consist of:

1. `Ergo`
   as the IRC server starting point
2. `The Lounge`
   as the client and channel interaction starting point
3. `Genie Bridge`
   as a new layer that connects:
   - channel manifests
   - replay/state snapshots
   - Genie commands
   - BizHawk launch/session control

## Required Boundaries

### IRC Server

The IRC server is the initialization entry point.

It must own:

- channels
- nick/join/part semantics
- message transport
- channel presence

It may be extended with:

- channel manifest storage
- bounded replay/state snapshot support
- Genie-visible system notices

### Client

The client must support:

- joining the game channel
- reading replay/state snapshot
- seeing Genie notices distinctly
- issuing Genie commands through a visible command surface

### Genie Bridge

The bridge must own:

- interpretation of channel manifest into launch staging
- visible session state snapshot generation
- command routing to BizHawk-facing control seams
- audit of Genie-originated launch/control actions

The bridge must not:

- replace the IRC server
- replace the client
- replace BizHawk runtime authority

### BizHawk

BizHawk remains the runtime destination and session truth center.

The first bootstrap layer only needs a narrow control seam:

- stage launch
- load ROM/profile
- report runtime state
- save/load/checkpoint when supported later

## First Deliverable

A narrow first deliverable should prove:

1. channel boot through Ergo
2. client participation through The Lounge
3. a machine-readable game-channel manifest
4. Genie bridge reads the manifest
5. bridge emits a staged BizHawk launch request
6. bridge publishes a visible session snapshot back to the channel/client surface

## Deferred

The following are deferred until after the bootstrap stack works:

- live voice command authority
- deep runtime mutation
- cross-game mechanic grafting
- advanced ROM decomposition
- non-native participant injection beyond minimal staging support
