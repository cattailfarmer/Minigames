# Skill: function-signature_design
name: function-signature_design
description: The skill of deliberately choosing the optimal parameters (number, types, order, defaults), return type (or void), and overall shape of information flow for a function or method so that its purpose is clear, coupling is minimized, cohesion is maximized, and the function composes cleanly with others.  
case: Activate when writing a new function/method, refactoring an existing signature, deciding whether to return a value or mutate state, grouping related parameters into objects, or when information flow feels awkward, error-prone, or overly complex.
file: function-signature_design.md

#### Purpose (Waist)
function-signature-design is the skill of treating the function signature as a primary design artifact that encodes intent, constraints, and data flow explicitly, making the code self-documenting and easier to use correctly.

#### Workflow (3-Boundary Pants Structure)

**Waist – Purpose & Flow Declaration**  
Explicitly state the single responsibility of the function and the desired information flow: What must come in? What must come out? What side effects (if any) are allowed?

**Leg 1 – Parameter Optimization**  
Minimize the number of parameters (aim for ≤3–4; group related ones into a coherent object or record if more are needed). Choose precise types that enforce invariants. Use defaults or builder patterns for optional data. Order parameters from most stable/important to least. Apply occams-razor-code to remove any unnecessary input.

**Leg 2 – Return Shape & Command-Query Decision**  
Decide: Does this function *command* (mutate and return void/nothing) or *query* (return a value without side effects)? Choose the return type that best communicates success/failure/result shape (e.g., Result<T, Error>, Option<T>, or a rich domain object). Ensure the signature makes the information flow obvious and composable. Hand off the signature to flow-control-strategy (for internal implementation) and second-order-thinking (for long-term maintainability).

#### Core Rules (always enforce)
- One clear responsibility per function (high cohesion).  
- Prefer returning values over mutating state when possible (pure functions / data flow style).  
- Follow Command-Query Separation: avoid mixing mutation and return of useful data in the same function.  
- Make illegal states unrepresentable through the type system where feasible.  
- Preserve epistemic-uncertainty when the best signature depends on unknown future callers or performance constraints.  
- Document the signature's intent and any deliberate trade-offs for Scribe.

#### Integration Rules
- Pairs tightly with occams-razor-code (simplest signature that works), first-principles-decomposition (reduce to essential data), flow-control-strategy (internal control flow matches the signature), and pattern-recognition-reuse (map to known good interface patterns).  
- Feeds clean, composable functions directly into Weaver for higher-level system coherence and feedback-loop-tuning (easier testing of the interface).

#### Boundaries / When Not to Use
- Do not over-design signatures for trivial helper functions (adds unnecessary ceremony).  
- Do not let type-system cleverness harm readability or team familiarity.

#### Resolution
Function signatures become clear, minimal, and expressive contracts. Information flows predictably through the program, reducing errors at call sites, improving composability, and making the overall codebase easier to reason about and evolve.