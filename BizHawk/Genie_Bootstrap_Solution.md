# Game Genie Bootstrap Solution

## Current Chosen Direction

The current chosen bootstrap direction is:

- `Ergo` for IRC server foundation
- `The Lounge` for IRC client foundation
- `Genie Bridge` as the new orchestration layer
- `BizHawk` as runtime destination and session truth center

## Current Truth

At present this is a specified direction, not yet an implemented fork integration.

What is now resolved:

- the entry point is IRC boot, not BizHawk boot
- BizHawk is the runtime authority destination
- the first implementation should not rewrite IRC infrastructure from scratch
- the bridge layer is the correct seam for Game Genie logic
- the bridge now has a first code-facing model surface under `src/BizHawk.GenieBridge`

## Immediate Next Build Target

The next concrete build target should be a narrow bootstrap proof:

1. define a machine-readable game-channel manifest
2. define the bridge-side session snapshot format
3. define the first BizHawk bridge commands:
   - stage launch
   - report runtime state
4. only then choose the exact fork/customization surface inside Ergo and The Lounge

Current bridge artifacts:

- [Genie_Channel_Manifest.md](C:/Project/Minigames/BizHawk/Genie_Channel_Manifest.md)
- [Genie_Session_Snapshot.md](C:/Project/Minigames/BizHawk/Genie_Session_Snapshot.md)
- [Genie_Bridge_Command_Set.md](C:/Project/Minigames/BizHawk/Genie_Bridge_Command_Set.md)
- [Genie_Bridge_Lifecycle.md](C:/Project/Minigames/BizHawk/Genie_Bridge_Lifecycle.md)
- [Genie_Bridge_Implementation_Plan.md](C:/Project/Minigames/BizHawk/Genie_Bridge_Implementation_Plan.md)
- [Genie_Integrated_Client.md](C:/Project/Minigames/BizHawk/Genie_Integrated_Client.md)
- [Genie_Pause_Policy.md](C:/Project/Minigames/BizHawk/Genie_Pause_Policy.md)
- [Genie_Stream_Bridge.md](C:/Project/Minigames/BizHawk/Genie_Stream_Bridge.md)
- [Genie_Client_Join_Lifecycle.md](C:/Project/Minigames/BizHawk/Genie_Client_Join_Lifecycle.md)
- [BizHawk.GenieBridge](C:/Project/Minigames/BizHawk/src/BizHawk.GenieBridge/README.md)

## Remaining Open Questions

- where channel manifest storage should live first:
  - server-side extension
  - bridge-side sidecar store
  - hybrid approach
- whether Genie notices are represented as:
  - IRC service/bot messages
  - tagged system messages
  - client-side enriched rendering
- what the first BizHawk control seam should be implemented in:
  - local process bridge
  - HTTP
  - WebSocket
  - named pipes

## Status

This is now a durable build choice and architectural baseline, but not yet code-integrated.
