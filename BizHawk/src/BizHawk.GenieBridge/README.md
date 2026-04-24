# BizHawk.GenieBridge

This project is the first code-facing surface for the Game Genie bridge.

It currently defines:

- channel manifest models
- session snapshot models
- bridge command and lifecycle models
- audit/checkpoint models
- provider-routing models
- named-pipe IPC command/result models
- a first bridge service and pipe server/client surface
- the first narrow bridge interface

It does not yet implement:

- IRC server integration
- The Lounge client integration
- BizHawk runtime binding
- voice command handling
- runtime mutation machinery

Those are intentionally deferred until the bootstrap seam is stable.
