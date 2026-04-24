# Genie IPC Justification

## Why Named Pipes First

Named pipes are the right first seam because they match the actual authority structure:

- BizHawk runtime authority is host-local
- Game Genie bridge is host-local
- remote participants do not need to issue raw emulator commands directly

So the first problem is not internet-scale transport.

It is safe host-local orchestration.

## Why Not Make WebSockets The First Runtime Seam

BizHawk already contains websocket-related code paths in other areas, but using a websocket seam first would blur:

- host-local authority
- remote participation
- client enrichment

That would expand the trust and attack surface too early.

WebSockets may still be useful later for:

- client-facing state feeds
- richer integrated client surfaces
- remote Genie notice delivery

But that is a later surface than the first runtime seam.

## Why This Matches The System

This preserves the topology already established:

- IRC boot is the entry surface
- Genie bridge is the governing waist
- BizHawk runtime is the destination authority

Named pipes are a good fit for the waist-to-authority edge.

## Existing Local Fit

BizHawk already contains local named-pipe usage in the codebase, which makes the seam less alien to the host environment.

So this is not an arbitrary transport choice.

It is a conservative fit with the existing code reality.
