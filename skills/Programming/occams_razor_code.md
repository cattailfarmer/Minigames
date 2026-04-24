# Skill: occams_razor_code
name: occams_razor_code
description: The skill of preferring the simplest explanation or implementation that fully accounts for observed behavior or requirements, then systematically eliminating unnecessary complexity or entities.  
case: Activate during code review, when multiple solutions compete, when noticing over-engineered patterns that violate simplicity, or when refactoring legacy code that has accumulated unnecessary layers.
file: occams_razor_code.md

#### Purpose (Waist)
occams-razor-code is the skill of applying Occam’s Razor directly to code and design: among competing implementations that explain the same requirements, the one with the fewest assumptions, entities, and moving parts should be preferred.

#### Workflow (3-Boundary Pants Structure)

**Waist – Complexity Declaration**  
Explicitly name the current code, design, or solution and declare the observed complexity or competing options.

**Leg 1 – Simplification Scan**  
List all assumptions, entities, abstractions, and mechanisms currently in play. For each, ask: “Does this element actually explain something that simpler alternatives cannot?” Ruthlessly identify candidates for removal or consolidation that still fully satisfy the requirements and invariants.

**Leg 2 – Minimal Implementation & Validation**  
Rebuild or refactor toward the simplest viable version. Eliminate or merge redundant parts. Test that the simpler form still covers all observed behavior and edge cases. If it fails, restore only the minimal element needed and repeat. Hand off the simplified result to Refiner for compression and Scribe for recording.

#### Core Rules (always enforce)
- Prefer the explanation/implementation with the fewest entities and assumptions, provided it fully accounts for the data.  
- Never remove something essential for correctness, performance, or clarity.  
- Base decisions on evidence (tests, profiling, usage data), not aesthetic minimalism alone.  
- Preserve epistemic-uncertainty when a simpler version appears to work but long-term consequences are unclear (pair with second-order-thinking).  
- Document what was removed and why for future traceability.

#### Integration Rules
- Pairs with first-principles-decomposition (reduce to fundamentals first), pareto-focus (focus simplification on highest-leverage areas), and abstraction-ladder-navigation (ensure simplicity holds at every rung).  
- Feeds cleaner structures directly into Weaver for elegant synergistic patterns and inversion-premortem for testing the risks of over-simplification.

#### Boundaries / When Not to Use
- Do not use when regulatory, safety, or performance constraints genuinely require additional complexity (e.g., cryptographic implementations, audited financial systems).  
- Do not apply as an excuse to delete code that handles real, documented edge cases.

#### Resolution
Code and designs shed unnecessary weight. The simplest adequate solution emerges, improving readability, maintainability, and long-term velocity while reducing cognitive load and bug surface area.