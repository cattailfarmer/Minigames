# Genie IPC Seam

## Purpose

This file defines the first process-to-process control seam between the Game Genie bridge and BizHawk runtime authority.

## Chosen First Seam

The first implementation seam should be:

- local named pipes

## Why

The Game Genie bridge initially needs a host-local authority path for:

- stage launch
- commit launch
- report runtime state
- pause/resume
- checkpoint save/load later

Remote players and IRC clients do not need direct runtime authority.

They should reach runtime truth through:

- IRC/bootstrap coordination
- session snapshot and notice surfaces
- stream attachment surfaces
- host-governed Genie bridge actions

Therefore the first runtime authority seam should remain local and narrow.

## Scope

The named-pipe seam is only for:

- Genie bridge to BizHawk host authority

It is not:

- the client streaming protocol
- the IRC protocol
- the remote player protocol

## Required Traits

- local-only by default
- explicit command envelopes
- explicit result envelopes
- visible failure reporting
- safe command whitelisting
- no unchecked provider output

## Deferred

The following remain separate future surfaces:

- remote stream transport
- remote control transport
- voice-command transport
- client-enriched websocket or HTTP surfaces
