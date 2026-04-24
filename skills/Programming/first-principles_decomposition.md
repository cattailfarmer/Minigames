# Skill: first-principles_decomposition
name: first-principles_decomposition
description: The skill of breaking a programming problem or system down to fundamental, irreducible truths (physics of data, core invariants, basic operations) before rebuilding solutions upward, avoiding cargo-cult or framework assumptions.  
case: Activate at the start of novel feature design, when legacy code feels incomprehensible, when existing abstractions leak, or when evaluating whether to adopt a new technology or pattern.
file: first-principles_decomposition.md

#### Purpose (Waist)
first-principles-decomposition is the skill of reducing any programming problem or system to its most basic, undeniable building blocks and then reasoning upward from those foundations rather than from conventions, frameworks, or inherited abstractions.

#### Workflow (3-Boundary Pants Structure)

**Waist – Problem Reduction**  
Explicitly name the problem, system, or decision and declare the current state of inherited assumptions or abstractions that may be clouding clarity.

**Leg 1 – Breakdown to Fundamentals**  
Strip away all layers of framework, library, and convention. Identify the irreducible truths: what data must move, what invariants must hold, what basic operations (create, read, update, delete, transform) are required, what physical/computational constraints exist (memory, latency, concurrency, correctness). Ask repeatedly: “What is this *really*?” until nothing further can be removed without changing the meaning.

**Leg 2 – Rebuild Upward**  
Reconstruct the solution from the identified fundamentals. Layer only the minimal abstractions needed. Explicitly justify each added layer. Compare the rebuilt approach against the original inherited one and surface any cargo-cult elements that can be eliminated. Hand off the resulting minimal viable structure to Weaver for integration or Planner for temporal mapping.

#### Core Rules (always enforce)
- Continue decomposition until the elements are truly atomic and self-evident (no further reduction possible without loss of identity).  
- Base every fundamental on observable reality or mathematical necessity, not opinion or common practice.  
- Never stop at “because the framework does it this way.”  
- Preserve epistemic-uncertainty on any layer where fundamentals are still ambiguous.  
- Document the decomposed fundamentals and rebuilt structure for Scribe.

#### Integration Rules
- Pairs with pareto-focus (focus decomposition on highest-leverage parts), abstraction-ladder-navigation (controlled vertical movement), and occams-razor-code (eliminate unnecessary layers).  
- Feeds clean foundational anchors directly into Weaver for synergistic architectures and inversion-premortem for testing rebuilt assumptions.

#### Boundaries / When Not to Use
- Do not use when time pressure demands rapid reuse of proven high-level patterns (e.g., standard CRUD with a mature framework).  
- Do not apply as an excuse to reinvent everything from scratch in every situation.

#### Resolution
Complex problems and opaque systems become transparent and tractable. Solutions are built on solid, minimal foundations rather than inherited assumptions, resulting in simpler, more robust, and more adaptable code and architectures.