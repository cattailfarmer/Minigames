# Skill: avoid_magic_numbers_and_strings
name: avoid_magic_numbers_and_strings
description: The skill of replacing unexplained literal values (numbers, strings, booleans) with named constants, enums, or domain-specific types that clearly explain their meaning and purpose.  
case: Activate whenever you encounter hard-coded values like `42`, `"admin"`, `true/false`, `0`, or `""` that require comments or external knowledge to understand, or during code review when literals appear without explanation.
file: avoid_magic_numbers_and_strings.md

#### Purpose (Waist)
avoid-magic-numbers-and-strings is the skill of making the meaning of literal values explicit and self-documenting so the code reveals intent instead of hiding it behind unexplained numbers and strings.

#### Workflow (3-Boundary Pants Structure)

**Waist – Literal Detection**  
Explicitly identify every magic literal in the current code (hard-coded numbers, strings, booleans, or special values) and declare what it is supposed to represent.

**Leg 1 – Meaning Extraction**  
For each literal, ask:
- What does this value actually mean in the domain?
- Why is it here?
- What would happen if it changed?
Extract the true meaning and give it a clear, intention-revealing name (constant, enum, or typed constant).

**Leg 2 – Replacement & Typing**  
Replace the literal with the named constant or domain type:
- Use `const`/`readonly`/`static final` for simple values.
- Prefer enums or sealed types when there are multiple related values.
- Group related constants into a dedicated class or namespace when appropriate.
- Update all usages and remove any explanatory comments that are now redundant.
Validate that the code remains correct and more readable. Hand off the changes to `meaningful-naming` and `small-functions-single-responsibility`.

#### Core Rules (always enforce)
- Never use unexplained literals in production code.
- Make the name describe the *purpose* or *meaning*, not just the value (e.g., `MAX_LOGIN_ATTEMPTS` instead of `5`).
- Prefer domain-specific types over primitive constants when they add safety (e.g., `UserRole` enum instead of string `"admin"`).
- Group related values together rather than scattering constants.
- Preserve epistemic-uncertainty when the best constant name or structure depends on future requirements.

#### Integration Rules
- Pairs tightly with `meaningful-naming` (names must reveal intent), `small-functions-single-responsibility` (constants often live in small focused modules), and `function-signature-design` (typed constants improve signatures).
- Feeds self-documenting, safer code directly into `second-order-thinking` and `occams-razor-code`.

#### Boundaries / When Not to Use
- Do not apply to obvious loop counters (`i`, `j`) or purely local, short-lived values in tiny scopes.
- Do not over-engineer with complex types for truly trivial one-off values in scripts or tests.

#### Resolution
Magic numbers and strings disappear. Code becomes self-explanatory, less error-prone, easier to maintain, and safer because the meaning and constraints of every value are visible and enforced by the type system or naming.