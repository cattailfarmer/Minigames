# Genie Integrated Client

## Purpose

The integrated client is the joined game-and-channel surface through which a participant plays, returns to the Genie console, sees session state, and joins the BizHawk-backed runtime stream.

It is not a separate IRC app sitting beside a game app.

It is one client shell with multiple bounded views.

## Core Views

### Game View

The primary play or watch surface.

It shows:

- BizHawk-derived stream output
- game HUD or thin session overlays
- critical Genie notices when relevant

### Channel Console

The embedded IRC-and-Genie console surface.

It shows:

- channel chat
- Genie notices
- session snapshot
- launch/join controls
- command surface

### Session Overlay

The minimal in-game overlay for current session truth.

It may show:

- pause state
- host notices
- Genie notices
- transformed-session identity

## Toggle Rule

The default console toggle is:

- backtick: `` ` ``

An equivalent menu option must also exist.

## Client Rule

Opening the console is always a local client action.

Whether that action pauses the session is determined by session pause policy rather than by the keybind itself.

## Required Capabilities

- join IRC channel
- receive replay and session snapshot
- show Genie/system notices distinctly from ordinary chat
- join or attach to BizHawk streaming output
- allow return from game view to channel console
- reflect current pause state and session policy

## First Delivery Bias

The first integrated client may still begin by extending an IRC client starting point.

But the durable design target is one joined shell, not two unrelated programs.
