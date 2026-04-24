# Genie Bridge Implementation Plan

## Stage 1

- define machine-readable channel manifest
- define session snapshot contract
- define narrow command set
- create bridge-side lifecycle model
- create initial C# project with manifest and bridge models

## Stage 2

- validate manifests
- stage launches from manifest state
- emit session snapshot from staged launch
- define the first audit event set

## Stage 3

- choose first IPC seam between Genie bridge and BizHawk runtime
- implement `stage_launch`
- implement `report_runtime_state`
- implement `report_host_status`
- reserve `save_checkpoint` and `load_checkpoint`
- define integrated client state and pause policy behavior
- define named-pipe command/result transport for local runtime authority
- host the bridge from EmuHawk startup so BizHawk owns the pipe lifecycle
- optionally stage a bootstrap manifest from the EmuHawk base directory

## Stage 4

- connect Ergo bootstrap events to bridge staging
- connect The Lounge-visible state summaries to bridge snapshots
- expose Genie notices as a distinct surface
- define joined game-and-console client behavior
- define stream attachment model for player and spectator roles

## Deferred

- voice command authority
- deep runtime mutation
- cross-game mechanic grafting
- autonomous provider-driven patch synthesis without confirmation
- websocket or HTTP runtime authority seam
