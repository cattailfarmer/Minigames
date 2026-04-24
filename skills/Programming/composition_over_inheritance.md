# Skill: composition_over_inheritance
name: composition_over_inheritance
description: The skill of preferring object composition (has-a relationships) over deep class inheritance (is-a relationships) to build flexible, reusable behavior while avoiding the fragile base class problem and tight coupling.  
case: Activate during class design, refactoring, or when inheritance hierarchies grow deep, when you need to combine behaviors without locking into a rigid hierarchy, or when changes to a base class would ripple through many subclasses.
file: composition_over_inheritance.md

#### Purpose (Waist)
composition-over-inheritance is the skill of building systems by assembling small, focused pieces rather than extending long inheritance chains, resulting in more flexible, testable, and maintainable code.

#### Workflow (3-Boundary Pants Structure)

**Waist – Hierarchy Audit**  
Explicitly name the current class or design and declare the inheritance depth or "is-a" relationships being used.

**Leg 1 – Inheritance Diagnosis**  
Analyze the inheritance tree for problems:
- Deep hierarchy (>2–3 levels)
- Subclasses that override or depend on many base class details
- Base class changes that would break many subclasses
- Behavior that is only partially relevant to some subclasses
Identify where "is-a" is being forced when "has-a" would be more natural.

**Leg 2 – Composition Refactoring**  
Replace inheritance with composition:
- Extract behaviors into small, focused classes or interfaces.
- Have the main class hold instances of those behaviors (composition).
- Delegate calls to the composed objects (e.g., `paymentProcessor.process()` instead of inheriting from `PaymentBase`).
- Use interfaces or strategies for polymorphic behavior when needed.
Favor small, single-responsibility components that can be mixed and matched. Hand off the refactored design to `tell-dont-ask`, `law-of-demeter`, and `small-functions-single-responsibility`.

#### Core Rules (always enforce)
- Prefer "has-a" over "is-a" unless the subclass truly is a specialized version of the base with no significant behavioral divergence.
- Keep composed objects small and focused (align with `small-functions-single-responsibility`).
- Favor delegation and strategy patterns over deep inheritance.
- Make composition explicit and visible rather than hidden behind inheritance magic.
- Preserve epistemic-uncertainty when domain constraints genuinely favor inheritance (e.g., some framework requirements or true taxonomic hierarchies).

#### Integration Rules
- Pairs tightly with `tell-dont-ask` (composed objects receive clear commands), `law-of-demeter` (reduces deep knowledge of internals), and `composition-over-inheritance` works especially well with `function-signature-design` and `command-query-separation`.
- Feeds flexible, loosely coupled designs directly into `second-order-thinking` (long-term maintainability) and `feature-based-organization`.

#### Boundaries / When Not to Use
- Do not force composition when a simple, shallow inheritance hierarchy is genuinely clearer and more natural.
- Do not over-abstract with excessive delegation layers in trivial cases.

#### Resolution
Inheritance hierarchies flatten or disappear. Code becomes more flexible, easier to test, and far less fragile. Behaviors can be mixed, swapped, or extended without touching unrelated classes, dramatically improving long-term maintainability and reuse.