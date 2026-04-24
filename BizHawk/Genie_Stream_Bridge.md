# Genie Stream Bridge

## Purpose

This file defines the first thin client-facing join surface for BizHawk runtime output.

## Principle

The integrated client does not receive raw emulator authority.

It receives:

- a bounded stream or display feed
- session snapshot updates
- Genie notices
- optional allowed control surfaces

## Required Surfaces

### Stream Attachment

The client needs a way to attach to the current running session's output.

The first system only needs to define:

- stream identity
- role of the attached client
- whether the surface is player, spectator, or host

### Session Snapshot Feed

The client must receive updated session snapshot state independently of video or frame transport.

### Genie Notice Feed

The client must receive:

- launch notices
- pause/resume notices
- role changes
- mutation notices
- recovery notices

### Control Path

The first design should keep control narrow and explicit.

Allowed first control classes:

- join request
- ready state
- console commands
- later player input attachment

## Deferred

The first stream bridge deliberately does not yet choose:

- raw pixel streaming
- remote desktop-like transport
- encoded video transport
- WebRTC or non-WebRTC path

Those should remain open until the bootstrap shell is proven.
