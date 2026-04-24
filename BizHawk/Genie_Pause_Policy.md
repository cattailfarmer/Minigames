# Genie Pause Policy

## Purpose

This file defines how the integrated client and Game Genie bridge should interpret console entry relative to multiplayer pause behavior.

## Principle

Opening the channel console does not inherently pause the game.

It triggers the session's selected pause policy.

## Default Policy

The preferred default policy is:

- `host_console_pauses`

This matches the common case where the host is also an involved player and wants the game paused while entering the console.

## Policy Modes

### `host_console_pauses`

If the host opens the integrated console:

- the session pauses for everyone
- a visible pause notice is emitted
- the session snapshot updates

Non-host console entry remains local unless separately elevated.

### `any_console_pauses`

If any player opens the console:

- the session pauses for everyone

This is stricter and should be used only when synchronized attention is essential.

### `console_overlay_only`

Opening the console does not pause the session.

This is suitable for looser or spectator-heavy modes.

### `host_decides_per_event`

The host may choose case by case whether entering the console pauses everyone.

## Visibility Rule

Whenever a console-triggered pause occurs, participants must be able to see:

- who caused it
- what policy caused it
- whether the session is paused or resumable

## Recovery Rule

Resume should also be visible and auditable.
