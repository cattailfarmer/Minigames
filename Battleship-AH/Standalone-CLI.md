# Battleship-AH Standalone CLI

## Purpose

`BattleshipAH.Cli` exists so the game can be played and judged locally before AlienHand screen routing is attached.

It is not the final product surface. It is a standalone proving shell for:

- private board flow
- placement and readiness
- turn-by-turn combat
- simple privacy handoff between players

## Current Behavior

The CLI currently provides:

- sequential private placement for both players
- optional automatic legal fleet placement through `AUTO`
- readiness confirmation
- a neutral transition screen between hidden states
- private combat turns
- shared shot-resolution screens
- final private result review

## Temporary Visual Mode

The CLI uses an intentional ASCII wireframe style:

- bounded board frames
- explicit row and column labels
- simple hit, miss, ship, and unknown marks
- neutral transition screens instead of leaking private state

## Relation To AlienHand

This shell is a local proving ground, not a replacement for AlienHand.

Its role is to make sure the Battleship engine feels truthful and coherent before the projection layer returns.
