# Skill: pattern_recognition_reuse

name: pattern_recognition_reuse
description: The skill of rapidly detecting recurring structures, motifs, or "plans" in code, data, or problems, then mapping them to known solutions, design patterns, or abstractions for efficient generalization.  
case: Activate while reading unfamiliar codebases, during algorithmic problem-solving, when generalizing a one-off fix into a reusable component, or when spotting repeated logic across modules.
file: pattern_recognition_reuse.md

#### Purpose (Waist)
pattern_recognition_reuse is the skill of treating recurring structures in code and problems as signals for abstraction, enabling fast, accurate mapping to proven solutions instead of reinventing from scratch.

#### Workflow (3-Boundary Pants Structure)

**Waist – Recurrence Declaration**  
Explicitly name the observed repetition (code block, data flow, error pattern, algorithmic motif, or problem shape) and declare the current context where it appears.

**Leg 1 – Pattern Detection**  
Scan for structural similarities: control flow, data transformations, state management, coupling style, or problem invariants. Compare against known catalogs (design patterns, algorithms, domain motifs). Identify the minimal set of invariants that define the pattern.

**Leg 2 – Reuse & Generalization**  
Map the detected pattern to the closest known solution or abstraction. Extract or refactor into a reusable form (function, class, module, or generic). Validate that the generalized version covers the original case without introducing new complexity. Hand off the reused component to Weaver for integration and Scribe for recording.

#### Core Rules (always enforce)
- Base recognition on concrete structural matches, not vague similarity.  
- Prefer established, battle-tested patterns over novel inventions when they fit.  
- Ensure generalization preserves correctness and does not add unnecessary abstraction layers (pair with occams-razor-code).  
- Preserve epistemic-uncertainty when a pattern match is partial or context-dependent.  
- Document the pattern, the mapping, and any adaptations made.

#### Integration Rules
- Pairs with first-principles-decomposition (verify the underlying fundamentals), abstraction-ladder-navigation (move between concrete and abstract), and pareto-focus (focus reuse on highest-leverage repetitions).  
- Feeds efficient, generalized components directly into Weaver for synergistic system patterns and feedback-loop-tuning for faster validation cycles.

#### Boundaries / When Not to Use
- Do not force a pattern where the fit is poor (avoid “patternitis”).  
- Do not use as a substitute for understanding the specific problem domain.

#### Resolution
Recurring structures become visible opportunities for leverage. Code moves from duplicated one-offs to clean, reusable abstractions, dramatically improving readability, maintainability, and development speed.