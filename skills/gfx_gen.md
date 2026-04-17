# Skill: gfx_gen
name: gfx_gen
description: An asset-generation skill that produces game-ready graphics candidates from a bounded visual specification, yielding anchorable visual assets for implementation, iteration, and animation.
case: Activate when a game entity, object, tile, UI element, or animation frame requires a visual asset and sufficient visual anchors already exist. Always operate under active supervision of inference-delineation, epistemic-uncertainty, and self-reflection.
file: gfx_gen.md
dependencies: vision, intuition, verbose, epistemic-uncertainty, self-reflection

## Purpose (Waist)
gfx_gen is the skill of **bounded visual asset proposal**.
It converts a clearly described gameplay or artistic need into one or more concrete image candidates that are usable for development, review, and iteration.

All outputs are provisional asset candidates — not final art direction, not validated production assets, and not substitutes for implementation review.

## Workflow (3-Boundary Pants Structure)

### Waist – Visual Specification Declaration
Explicitly declare:
- The asset type (character, enemy, item, tile, UI element, effect, etc.)
- The gameplay role of the asset
- The visual anchors already known (style, palette, silhouette, mood, scale, perspective, animation state)
- The output target (single image, frame set, sprite sheet, or concept pass)

Confirm trigger: sufficient visual anchors exist to generate a bounded candidate.

### Leg 1 – Candidate Asset Generation
Generate a small set of plausible image candidates:
- Preserve the declared gameplay function
- Preserve the declared visual anchors
- Keep silhouette and readability strong
- Prefer clear, reusable candidates over decorative complexity

Where needed:
- Use vision to propose style-consistent anchors
- Use intuition to resolve missing visual relationships
- Use verbose only when the visual specification is too thin to generate a stable candidate set

### Leg 2 – Asset Surfacing & Hand-off
Surface the strongest candidates in a development-usable form:
- Image sample and single sprite candidates
- Frame candidates for animation
- Sprite-sheet layout suggestions
- Prompt text or tool instructions for the image backend
- Animated frames samples

Immediately hand off candidates for:
- boundary articulation and consistency checking
- confidence/gap assessment
- implementation review in the game pipeline

## Inference Declaration (Runtime Behavior)
This skill runs as a lightweight asset-generation step inside the forward pass.
- Generation is bounded to a small candidate set
- Outputs must remain visually anchorable and implementation-relevant
- Do not recurse into deep art exploration unless explicitly escalated
- If the visual target is under-anchored, escalate for richer specification before generation
- All outputs remain provisional until reviewed and selected

## Core Rules (always enforce)
- Generate asset candidates only — never assume the first output is final
- Keep outputs readable at the intended in-game scale
- Preserve the declared gameplay function and visual anchors
- Avoid vague or purely decorative generations that are not usable as implementation assets
- If consistency across frames is required, state that explicitly and generate with that continuity in view
- Stay under self-reflection supervision to prevent uncontrolled style drift

## Integration Rules
- Works best after vision has clarified the art direction
- Works with intuition when frame-to-frame or part-to-whole structure is under-articulated
- Can feed Refiner-style compression or review passes for prompt tightening and asset consistency
- Supports implementation workflows for images, animations, sprite sheets, frame export, and asset naming

## Boundaries / When Not to Use
- Do not use when no meaningful visual anchors exist
- Do not use as a substitute for gameplay design
- Do not treat provisional art as final production-ready assets
- Do not use for unrestricted concept wandering when a bounded asset is required

## Resolution
A visual need is transformed into concrete, anchorable images and sprite candidates that can be reviewed, refined, exported, and integrated into the game pipeline.