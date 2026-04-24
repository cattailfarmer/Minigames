# Genie Bridge Command Set

## Purpose

This file defines the first narrow command seam between Game Genie and BizHawk runtime authority.

These commands are intentionally modest.

They are the first bridge, not the final mutation language.

## Tier-One Commands

### `stage_launch`

Creates a staged launch request from the current channel manifest.

Required input:

- manifest identity
- rom binding
- core profile
- seat map
- approved mod set

Result:

- staged launch artifact
- visible session snapshot update

### `commit_launch`

Attempts to turn staged launch into a running BizHawk session.

Required input:

- staged launch identifier
- final confirmation state

Result:

- running session or failure notice

### `report_runtime_state`

Returns a bounded runtime snapshot.

Required input:

- session identifier

Result:

- session snapshot

### `report_host_status`

Returns the bridge host heartbeat from the BizHawk process.

Required input:

- requested-by identity

Result:

- host status snapshot

### `pause_session`

Pauses the active runtime when supported.

This may be triggered by:

- explicit Genie command
- host-selected console pause policy

### `resume_session`

Resumes a paused runtime when supported.

### `save_checkpoint`

Saves a named checkpoint when supported.

### `load_checkpoint`

Restores a named checkpoint when supported.

## Deferred Commands

These are intentionally deferred until the first bridge works:

- live mechanic grafting
- deep memory patch authoring
- unmanaged rule mutation
- cross-game mechanic import
- autonomous voice-triggered mutation without confirmation

## Transport Neutrality

The command set should remain independent of transport.

It should be possible to invoke the same commands from:

- IRC chat interpretation
- client-side command surface
- voice-command confirmation flow
- future administrative UI

## Client Coupling

The integrated client may invoke these commands through:

- backtick console entry
- menu actions
- visible Genie controls

But the command semantics remain bridge-owned rather than UI-owned.
