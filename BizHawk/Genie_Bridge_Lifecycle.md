# Genie Bridge Lifecycle

## Purpose

This file describes the first full lifecycle of the Game Genie bridge from IRC bootstrap to BizHawk runtime destination.

## Lifecycle

1. IRC server boots
2. channel is created or resumed
3. channel manifest is loaded or declared
4. Genie joins as visible operator
5. users join the channel
6. join replay and session snapshot are shown
7. roles and seats are assigned
8. approved mod set is established
9. bridge emits `stage_launch`
10. bridge publishes staged session snapshot
11. host confirms launch
12. bridge emits `commit_launch`
13. BizHawk session becomes runtime truth
14. bridge republishes running session snapshot
15. later runtime commands may use:
    - `report_runtime_state`
    - `pause_session`
    - `resume_session`
    - `save_checkpoint`
    - `load_checkpoint`

## First Failure Paths

The first bridge must explicitly handle:

- invalid manifest
- missing ROM binding
- seat/roster mismatch
- unsupported core profile
- launch failure
- stale snapshot after failed transition

## First Recovery Paths

The first bridge should support:

- return to staging
- clear failure notice
- preserve last valid manifest
- preserve last visible session snapshot
