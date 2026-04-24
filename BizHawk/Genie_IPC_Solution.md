# Genie IPC Solution

## Current Decision

The first runtime authority seam is now defined as:

- local named-pipe transport between Game Genie bridge and BizHawk host runtime

## Current Truth

This is currently a specified and modeled seam, not yet a fully running server/client pair inside BizHawk.

What is resolved:

- the first runtime seam should be local
- it should not be conflated with remote clients or stream transport
- command and result envelopes should be explicit

## Immediate Next Build Target

1. define named-pipe command/result envelope models
2. define the allowed command whitelist
3. define the first bridge service contract
4. only then implement the host-side pipe server and bridge-side pipe client

## Current Code Surface

The first implementation surface now exists under:

- [BizHawk.GenieBridge](C:/Project/Minigames/BizHawk/src/BizHawk.GenieBridge/README.md)

It includes:

- IPC envelopes
- named-pipe bridge config
- command policy
- bridge service
- host-side named-pipe server
- client-side named-pipe sender

The bridge now also records a host-side status heartbeat so EmuHawk can announce that the runtime authority is online before any session command is issued.

EmuHawk now also looks for an optional `Genie.bootstrap.json` file in the application base directory and stages it during startup when present.
