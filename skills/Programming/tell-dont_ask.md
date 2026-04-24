# Skill: tell-dont_ask
name: tell-dont_ask
description: The skill of telling an object or module to perform an action with the data it needs, rather than querying its internal state and then deciding what to do externally. This reduces coupling and encapsulation violations.  
case: Activate when you find yourself checking object properties/flags before calling methods, when logic about another component's state is scattered outside it, or when you see repeated "if (obj.isSomething())" patterns.
file: tell-dont_ask.md

#### Purpose (Waist)
tell-dont-ask is the skill of respecting encapsulation by expressing intent through behavior rather than exposing state for external decision-making. It keeps decision logic close to the data it operates on.

#### Workflow (3-Boundary Pants Structure)

**Waist – Intent Declaration**  
Explicitly name the desired behavior and identify any current code that queries state before acting (e.g., `if (user.isAdmin()) { ... }`).

**Leg 1 – State Query Detection**  
Scan for "ask" patterns: direct property access, getter calls, or boolean checks on another object to decide behavior. Replace the external decision with a single behavioral request that carries all necessary context.

**Leg 2 – Tell Refactoring**  
Move the decision and action inside the object/module. Provide the object with the information it needs to act (via parameters if required) and issue a clear command. Ensure the new method name clearly expresses the intent. Validate that the external caller no longer needs to know internal details. Hand off the refactored code to `flow-control-strategy` (for internal implementation) and `occams-razor-code` (for simplicity).

#### Core Rules (always enforce)
- Never expose state just so external code can make decisions about it.  
- Prefer method names that start with verbs expressing the desired outcome (e.g., `approve()`, `processPayment()`, `notify()`).  
- If the object needs extra data to decide/act, pass it explicitly rather than exposing getters.  
- Preserve epistemic-uncertainty when the best "tell" method is not immediately obvious or when performance constraints apply.  
- Document the refactored intent for Scribe.

#### Integration Rules
- Pairs tightly with `function-signature-design` (clean command-style signatures), `command-query-separation` (clear command vs. query distinction), and `small-functions-single-responsibility` (keep the told behavior focused).  
- Feeds better-encapsulated modules directly into `composition-over-inheritance` and `law-of-demeter` (reduces unnecessary knowledge of internals).

#### Boundaries / When Not to Use
- Do not force "tell" when the caller genuinely needs the raw data for its own unrelated logic (true queries are still valid).  
- Do not hide important side effects behind a vague "tell" method.

#### Resolution
Code shifts from scattered, brittle "ask-then-decide" logic to clear, encapsulated "tell" behavior. Coupling decreases, maintainability improves, and the intent of each module becomes obvious without exposing internal state.