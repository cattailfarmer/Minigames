# Skill: law_of_demeter
name: law_of_demeter
description: The skill of limiting direct interactions to immediate "friends" (only talk to your own methods, parameters, or directly held objects), avoiding deep chaining that creates tight coupling and fragile code.  
case: Activate when you see long method chains like `obj.getA().getB().getC().doSomething()`, when changes in one module ripple unexpectedly through many others, or when code reaches deep into another object's structure.
file: law_of_demeter.md

#### Purpose (Waist)
law-of-demeter is the skill of reducing unnecessary knowledge between objects/modules so that code becomes more stable, maintainable, and less prone to cascading changes when internal implementations evolve.

#### Workflow (3-Boundary Pants Structure)

**Waist – Chain Detection**  
Explicitly identify any deep object traversal or method chaining in the current code and declare the coupling problem it creates.

**Leg 1 – Friendship Analysis**  
Ask: “Is this object a direct friend?” (i.e., is it a parameter, a field of the current class, or created locally?).  
Trace the chain and mark every step that reaches beyond immediate friends. Identify the real intent behind the chain (what behavior is actually needed?).

**Leg 2 – Demeter Refactoring**  
Introduce a new method on the immediate friend that encapsulates the desired behavior (e.g., `user.processOrder()` instead of `user.getCart().getItems().calculateTotal()`).  
Hide internal structure behind a single, intent-revealing call.  
If the chain is unavoidable, consider restructuring with composition, dependency injection, or a facade.  
Validate that the caller no longer depends on the internal structure of distant objects. Hand off the refactored code to `tell-dont-ask` and `function-signature-design`.

#### Core Rules (always enforce)
- Only talk to your immediate friends: `this`, method parameters, fields of `this`, or objects you create locally.
- Never reach through multiple dots to access distant objects (avoid "train wrecks").
- When you need something from a distant object, ask your immediate friend to do it for you.
- Prefer adding a small method on the friend over exposing internal structure.
- Preserve epistemic-uncertainty when performance or legacy constraints make full compliance difficult.

#### Integration Rules
- Pairs tightly with `tell-dont-ask` (replace "ask then decide" chains with direct tells), `law-of-demeter` works especially well with `composition-over-inheritance` and `small-functions-single-responsibility`.
- Feeds looser coupling directly into `second-order-thinking` (long-term stability) and `flow-control-strategy` (cleaner internal flow).

#### Boundaries / When Not to Use
- Do not apply so rigidly that it forces awkward delegation layers in performance-critical or very simple code.
- Do not use it as an excuse to avoid necessary data access when a clean abstraction cannot be found.

#### Resolution
Deep, fragile object chains disappear. Code becomes more stable because changes to internal structure no longer break distant callers. Coupling decreases, maintainability improves, and the system is far easier to evolve over time.