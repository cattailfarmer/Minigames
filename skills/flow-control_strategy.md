# Skill: flow-control_strategy
name: flow-control_strategy
description: The skill of deliberately evaluating and selecting the most appropriate control-flow mechanism (if/else, switch, early returns/guard clauses, polymorphism, state machines, recursion, loops, or exceptions) based on readability, maintainability, performance, and cognitive complexity.  
case: Activate when writing or refactoring branching logic, handling state-dependent behavior, processing sequences with varying conditions, or when noticing deep nesting, boolean flag proliferation, or scattered conditionals.
file: flow-control_strategy.md

#### Purpose (Waist)
flow-control-strategy is the skill of treating control flow as a first-class design decision rather than a default implementation detail, choosing the structure that best expresses intent while minimizing future friction.

#### Workflow (3-Boundary Pants Structure)

**Waist – Flow Problem Declaration**  
Explicitly name the decision point or behavior (e.g., “handle user state transitions”, “validate input with multiple rules”, “process sequence with early exit conditions”) and declare the current or default control-flow approach.

**Leg 1 – Option Enumeration & Evaluation**  
List viable mechanisms: simple if/else, guard clauses + early return, switch/case, polymorphism/dynamic dispatch, state machine, recursion vs. iteration, exception handling. Evaluate each against criteria: readability, cognitive complexity (nesting depth), extensibility, performance, error-proneness, and second-order effects (maintainability over time).

**Leg 2 – Selection & Refactoring**  
Choose the mechanism with the best overall leverage (often the one that flattens or localizes complexity). Refactor toward it, applying occams-razor-code to avoid over-abstraction. Validate with tests or mental simulation. Hand off the chosen structure to Weaver for system integration and Scribe for recording the rationale.

#### Core Rules (always enforce)
- Prefer flatter, more explicit flow unless a higher-abstraction mechanism clearly reduces long-term cost.  
- Use polymorphism or state machines when behavior varies strongly by type/state (avoid “type-checking ifs”).  
- Favor guard clauses and early returns to reduce nesting depth.  
- Reserve recursion for naturally recursive problems with clear base cases and tail-call safety.  
- Preserve epistemic-uncertainty when the best structure is context-dependent or team familiarity is low.  
- Always document the chosen strategy and why alternatives were rejected.

#### Integration Rules
- Pairs tightly with occams-razor-code (keep it simple), second-order-thinking (long-term consequences), first-principles-decomposition (reduce to core logic), and cognitive-complexity awareness (minimize nesting).  
- Feeds cleaner flow into pattern-recognition-reuse and feedback-loop-tuning (faster validation of the chosen structure).

#### Boundaries / When Not to Use
- Do not over-apply advanced structures (state machines, polymorphism) to trivial cases — that increases unnecessary complexity.  
- Do not let “elegance” override team familiarity or performance constraints in hot paths.

#### Resolution
Control flow becomes intentional and expressive rather than accidental. Branching logic is simpler to read, test, and maintain, reducing bugs from deep nesting or scattered conditions while keeping cognitive load low.