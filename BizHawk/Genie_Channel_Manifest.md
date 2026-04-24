# Genie Channel Manifest

## Purpose

The channel manifest is the machine-readable session definition attached to a game channel during IRC bootstrap.

It is the first durable artifact that lets:

- IRC channel state become launch staging
- Game Genie reason over current session terms
- BizHawk receive a bounded launch request later

## Required Fields

### Identity

- `channel_name`
- `session_name`
- `session_mode`
- `manifest_version`

### Game Binding

- `rom_id`
- `rom_label`
- `rom_source`
- `core_profile`
- `launch_profile`

### Participation

- `host_user`
- `players`
- `spectators`
- `seat_policy`
- `ready_state`

### Genie

- `genie_enabled`
- `genie_role`
- `agent_policy`
- `provider_policy`

### Mods And Transformation

- `mod_policy`
- `active_mods`
- `transformation_scope`
- `consent_mode`

### Replay And Visibility

- `join_replay_policy`
- `state_snapshot_policy`
- `audit_visibility`

## Example Shape

```json
{
  "channel_name": "#mario-party-lab",
  "session_name": "Mario Party Experimental Lobby",
  "session_mode": "experimental",
  "manifest_version": "1.0",
  "rom_id": "n64:marioparty2:usa",
  "rom_label": "Mario Party 2 (USA)",
  "rom_source": "local-registry",
  "core_profile": "n64-default",
  "launch_profile": "four-player-netplay",
  "host_user": "jerem",
  "players": [],
  "spectators": [],
  "seat_policy": "host-confirms",
  "ready_state": "staging",
  "genie_enabled": true,
  "genie_role": "game_master",
  "agent_policy": "visible-notice-required",
  "provider_policy": "remote-or-local-routed",
  "mod_policy": "runtime-safe-with-confirmation",
  "active_mods": [],
  "transformation_scope": "bounded-runtime",
  "consent_mode": "host-confirm",
  "join_replay_policy": "summary-first",
  "state_snapshot_policy": "always-visible",
  "audit_visibility": "channel-visible"
}
```

## First Implementation Rule

The first implementation should keep the manifest:

- JSON-serializable
- versioned
- human-readable
- safe to echo back into IRC-client-visible state summaries

Do not overfit it to one game before the bridge spine exists.
