# Genie Client Join Lifecycle

## Lifecycle

1. client opens integrated Genie shell
2. client joins the IRC game channel
3. client receives replay and current session snapshot
4. client sees whether the session is:
   - staging
   - staged
   - running
   - paused
   - recovering
5. if a running session exists, client may attach to stream output according to role
6. client may toggle between:
   - game view
   - channel console
7. if console entry triggers pause under current policy, pause notice is emitted
8. returning from console may leave the game paused or resume according to host/session action

## First Failure Paths

- channel joined but no manifest exists
- snapshot stale or missing
- stream available but join role denied
- pause requested but host policy disallows it

## First Recovery Paths

- fall back to channel console
- show current session snapshot even if stream attach fails
- preserve visible Genie notice about why join or pause failed
