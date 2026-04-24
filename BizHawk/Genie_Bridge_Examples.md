# Genie Bridge Examples

## Example Manifest To Stage Launch

1. channel manifest exists for `#mario-party-lab`
2. Genie verifies host, seats, and approved mods
3. bridge creates:
   - `stage_launch` command
   - staged lifecycle state
   - updated session snapshot

## Example Runtime State Request

1. user asks Genie what is currently running
2. Genie routes `report_runtime_state`
3. bridge returns a bounded `SessionSnapshot`
4. Genie publishes the snapshot as:
   - IRC-visible state notice
   - later, client-enriched view

## Example Save/Load Ladder

The first bridge model already reserves:

- `save_checkpoint`
- `load_checkpoint`

These remain intentionally narrow and named.

They should not begin as arbitrary savestate poking.
