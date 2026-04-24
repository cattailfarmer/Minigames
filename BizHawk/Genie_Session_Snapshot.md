# Genie Session Snapshot

## Purpose

The session snapshot is the bounded current-state report that the Genie bridge publishes back to IRC clients and later voice-aware surfaces.

It is not the full emulator state.

It is the visible truth that users need in order to understand:

- what game is active
- who is present
- what the Genie is doing
- what mods or transformed rules are active
- whether launch or runtime actions are underway

## Required Fields

- `channel_name`
- `session_name`
- `launch_state`
- `active_rom`
- `active_core_profile`
- `active_roster`
- `active_seats`
- `active_mods`
- `transformed_identity`
- `recent_actions`
- `sync_status`
- `save_state_status`
- `genie_state`
- `pause_policy`
- `paused_by`

## Example Shape

```json
{
  "channel_name": "#mario-party-lab",
  "session_name": "Mario Party Experimental Lobby",
  "launch_state": "staged",
  "active_rom": "Mario Party 2 (USA)",
  "active_core_profile": "n64-default",
  "active_roster": [
    "jerem",
    "friend1",
    "friend2"
  ],
  "active_seats": {
    "p1": "jerem",
    "p2": "friend1",
    "p3": "friend2"
  },
  "active_mods": [
    "bonus-star-chaos"
  ],
  "transformed_identity": null,
  "recent_actions": [
    "Genie staged launch",
    "Host confirmed runtime-safe mod set"
  ],
  "sync_status": "not-started",
  "save_state_status": "unavailable-before-launch",
  "genie_state": "staging_launch",
  "pause_policy": "host_console_pauses",
  "paused_by": null
}
```

## Boundary Rule

The session snapshot must remain:

- smaller than full audit history
- smaller than full replay history
- more current than the manifest
- easier to render in a client than raw emulator state
