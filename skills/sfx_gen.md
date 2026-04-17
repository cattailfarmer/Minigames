# Skill: sfx_gen
name: sfx_gen
description: An asset-generation skill that produces bounded sound-effect candidates from gameplay and audio anchors, yielding implementation-ready effects or effect prompts for review, looping, and integration.
case: Activate when a game action, event, ambience, UI interaction, or transition requires a sound effect and sufficient audio anchors already exist. Always operate under active supervision of inference-delineation, epistemic-uncertainty, and self-reflection.
file: sfx_gen.md
dependencies: vision, intuition, verbose, epistemic-uncertainty, self-reflection

## Purpose (Waist)
Sound-fx-generation is the skill of **bounded audio effect proposal**.
It converts a clearly described gameplay or atmospheric need into one or more sound-effect candidates that are usable for development, review, and implementation.

All outputs are provisional effect candidates — not final mix decisions, not validated production audio, and not substitutes for implementation testing.

## Workflow (3-Boundary Pants Structure)

### Waist – Audio Specification Declaration
Explicitly declare:
- The gameplay or environmental event
- The intended effect type (impact, ambience, whoosh, UI tick, loop, transition, etc.)
- The known audio anchors (tone, intensity, material, timing, realism, stylization, duration, loop/no-loop)
- The output target (one-shot, layered set, loop, or prompt pass)

Confirm trigger: sufficient audio anchors exist to generate bounded candidates.

### Leg 1 – Candidate Effect Generation
Generate a small set of plausible sound-effect candidates:
- Preserve the declared gameplay function
- Preserve timing and intensity anchors
- Keep the effect readable in the mix and appropriate for the game context
- Prefer implementation-usable candidates over abstract sonic exploration

Where needed:
- Use vision to propose missing high-level audio direction
- Use intuition to connect sparse event anchors into a coherent effect concept
- Use verbose only when the audio specification is too thin to stabilize

### Leg 2 – Effect Surfacing & Hand-off
Surface the strongest candidates in a development-usable form:
- Text prompts for the sound-effect backend
- Duration and looping recommendations
- Candidate effect families or variants
- Naming and implementation notes

Immediately hand off candidates for:
- boundary articulation and consistency checking
- confidence/gap assessment
- integration review in the audio pipeline

## Inference Declaration (Runtime Behavior)
This skill runs as a lightweight asset-generation step inside the forward pass.
- Generation is bounded to a small candidate set
- Outputs must remain implementation-relevant and anchorable
- Looping, duration, and gameplay readability should be specified when material to the task
- If the audio target is under-anchored, escalate for richer specification before generation
- All outputs remain provisional until reviewed and selected

## Core Rules (always enforce)
- Generate effect candidates only — never assume the first result is final
- Preserve the declared gameplay role and audio anchors
- Keep candidates plausible for the stated event and mix context
- Avoid vague cinematic language when a concrete effect is needed
- State when looping, layering, or multiple variants are advisable
- Stay under self-reflection supervision to prevent speculative drift

## Integration Rules
- Works best after vision has clarified the audio direction
- Works with intuition when event-to-effect structure is under-articulated
- Supports backend generation tools that accept text prompts, duration, and looping controls
- Feeds implementation workflows for asset naming, variant selection, and playback integration

## Boundaries / When Not to Use
- Do not use when no meaningful audio anchors exist
- Do not use as a substitute for actual mix and gameplay testing
- Do not treat provisional effects as final production audio
- Do not use for unconstrained sonic exploration when a bounded effect is required

## Resolution
An audio need is transformed into concrete, anchorable sound-effect candidates that can be generated, reviewed, refined, and integrated into the game pipeline.