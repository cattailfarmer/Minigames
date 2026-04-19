# Skill: meaningful_naming
name: meaningful_naming
description: The skill of choosing names for variables, functions, classes, parameters, and modules that clearly reveal intent, purpose, and constraints so the code reads like well-written prose and requires minimal additional comments.  
case: Activate during writing, refactoring, or code review when names are vague (e.g., `data`, `process`, `temp`, `result`), abbreviations dominate, or the reader must infer meaning from context or comments.
file: meaningful_naming.md

#### Purpose (Waist)
meaningful-naming is the skill of making names carry the maximum amount of semantic weight so that the code itself becomes self-documenting and intent-revealing.

#### Workflow (3-Boundary Pants Structure)

**Waist – Intent Declaration**  
Explicitly state what the entity (variable, function, class, etc.) is supposed to represent or do in the current context.

**Leg 1 – Name Diagnosis**  
Examine the current name for vagueness, ambiguity, or technical leakage. Ask: Does this name tell the reader *why* this exists, *what* it does, and *how* it should be used? Replace generic terms (`data`, `info`, `obj`, `flag`) with domain-specific or purpose-revealing terms.

**Leg 2 – Precise Naming & Refinement**  
Craft a new name that:
- Uses domain language when appropriate
- Prefers intention-revealing verbs for functions/methods (e.g., `calculateTotal`, `validateOrder`, `notifyCustomer`)
- Uses precise nouns for variables (e.g., `unpaidInvoices` instead of `list`)
- Avoids abbreviations and single-letter variables except in very narrow scopes (loop counters)
- Makes illegal states or constraints visible through the name when possible
Apply `small-functions-single-responsibility` and `occams-razor-code` to ensure the name stays honest. Hand off the renamed code to Scribe for recording and to `flow-control-strategy` for any internal changes.

#### Core Rules (always enforce)
- A good name should allow a reader to understand the purpose without reading the implementation or comments.
- Prefer longer, clearer names over short, cryptic ones when the scope is not tiny.
- Use consistent vocabulary from the problem domain (ubiquitous language).
- Never rely on comments to explain what a poorly named entity does — fix the name instead.
- Re-evaluate names during code review; names often drift as understanding evolves.
- Preserve epistemic-uncertainty when the best name depends on future usage patterns.

#### Integration Rules
- Pairs tightly with `small-functions-single-responsibility` (small functions are easier to name well), `function-signature-design` (clear parameter and return names), and `tell-dont-ask` (behavior-revealing method names).
- Feeds self-documenting code directly into `pattern-recognition-reuse` and overall readability improvements.

#### Boundaries / When Not to Use
- Do not over-name trivial local variables in tiny scopes (e.g., `i` in a short loop is acceptable).
- Do not let perfect naming delay delivery when a good-enough name already communicates intent clearly.

#### Resolution
Code stops being a puzzle and starts reading like clear prose. Developers spend far less time deciphering intent, onboarding becomes faster, and bugs caused by misunderstood names decrease significantly.