# Skill: command-query_separation
name: command-query_separation
description: The skill of ensuring every function/method is either a Command (performs an action, changes state, returns nothing/void) or a Query (returns a value without side effects), but never both. This improves predictability, testability, and reasoning about code.  
case: Activate when designing or refactoring function signatures that mix mutation with return values, when debugging unexpected state changes, or when a method both does something and returns useful data.
file: command-query_separation.md

#### Purpose (Waist)
command-query-separation is the skill of making side effects and return values orthogonal so that code becomes easier to reason about, test, and compose without hidden surprises.

#### Workflow (3-Boundary Pants Structure)

**Waist – Mixed Responsibility Declaration**  
Explicitly name the function/method and declare where it currently mixes command behavior (mutation/side effects) with query behavior (returning a value).

**Leg 1 – Separation Analysis**  
Classify the current method:
- Does it change state or produce side effects?
- Does it return a value that the caller uses for further computation?
If both are true, identify the two distinct responsibilities.

**Leg 2 – Refactoring to Pure Command or Query**  
Split into two clear pieces:
- Turn the mutation part into a pure Command (rename to verb, return void/nothing or a simple success indicator like Result/Unit).
- Turn the value-returning part into a pure Query (no side effects).
If a combined operation is genuinely needed, compose them explicitly at the caller level rather than hiding the mix inside one method. Validate with tests that commands are side-effect only and queries are pure. Hand off the separated signatures to `function-signature-design` and `tell-dont-ask`.

#### Core Rules (always enforce)
- A method must be either a Command OR a Query — never both.
- Commands should have verb names and typically return void (or a minimal success/failure token).
- Queries must be side-effect free and idempotent (calling them multiple times produces the same result).
- When a command needs to communicate a result, return a simple status or use events/callbacks instead of mixing return values.
- Preserve epistemic-uncertainty when domain constraints make perfect separation difficult (e.g., some legacy APIs or performance-critical paths).

#### Integration Rules
- Pairs tightly with `function-signature-design` (clean separation in signatures), `tell-dont-ask` (commands become clear "tells"), and `small-functions-single-responsibility` (each piece stays focused).
- Feeds predictable, testable code directly into `flow-control-strategy` and `second-order-thinking` (long-term reasoning improves dramatically).

#### Boundaries / When Not to Use
- Do not force separation when it adds needless ceremony in very simple scripts or throwaway code.
- Do not break separation for performance in hot paths without clear measurement and documentation of the trade-off.

#### Resolution
Functions become predictable building blocks. Commands clearly change the world; queries clearly answer questions. Code is easier to test, debug, compose, and reason about, with far fewer hidden side effects or surprising return values.