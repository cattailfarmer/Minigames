# Skill: small_functions-single_responsibility
name: small_functions-single_responsibility
description: The skill of keeping functions/methods short (ideally <20-30 lines), focused on one clear responsibility, and easy to name without using "and". This makes code dramatically easier to read, test, debug, and reuse.  
case: Activate when a function grows long, contains multiple "and" verbs in its name, requires scrolling to understand its logic, or when multiple concerns (validation, calculation, formatting, persistence) are mixed inside one method.
file: small_functions-single_responsibility.md

#### Purpose (Waist)
small-functions-single-responsibility is the skill of enforcing the Single Responsibility Principle at the function level so that every function does exactly one thing, making the entire codebase more composable and maintainable.

#### Workflow (3-Boundary Pants Structure)

**Waist – Responsibility Audit**  
Explicitly name the current function and list all the distinct responsibilities it currently performs (e.g., "validate input AND calculate total AND format output AND save to database").

**Leg 1 – Decomposition**  
Break the function into smaller pieces, each with a single, clearly named responsibility. Extract validation, calculation, formatting, side effects, etc., into their own well-named functions. Aim for functions that fit on a single screen and can be understood at a glance.

**Leg 2 – Recomposition & Naming**  
Reassemble the original behavior by composing the small functions in the calling code. Give each new function a precise name that describes exactly what it does (no "and", no vague verbs). Ensure the happy path remains obvious and readable. Hand off the refactored functions to `command-query-separation`, `function-signature-design`, and `occams-razor-code`.

#### Core Rules (always enforce)
- A function should do one thing and one thing only. If you need "and" in the name, it probably has multiple responsibilities.
- Keep functions small enough that their entire logic can be understood without scrolling (target <20-30 lines in most languages).
- Name functions so that the caller can understand the intent without reading the implementation.
- Extract, don’t inline — duplication is acceptable during extraction if it clarifies responsibility.
- Preserve epistemic-uncertainty when a function feels borderline; re-evaluate after extraction.

#### Integration Rules
- Pairs tightly with `command-query-separation` (each small function is clearly a command or query), `tell-dont-ask` (small focused behaviors), and `occams-razor-code` (remove unnecessary complexity during extraction).
- Feeds highly readable, testable code directly into `flow-control-strategy`, `pattern-recognition-reuse`, and higher-level composition patterns.

#### Boundaries / When Not to Use
- Do not apply rigidly to trivial one-line helper functions or in performance-critical hot paths where inlining improves clarity or speed.
- Do not create dozens of tiny functions that obscure the overall flow without good naming and structure.

#### Resolution
Long, confusing functions disappear. The codebase becomes a clear composition of small, well-named, single-purpose functions. Reading, testing, debugging, and reusing code becomes significantly faster and less error-prone.