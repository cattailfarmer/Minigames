# Skill: feature-based_organization
name: feature-based_organization
description: The skill of structuring the codebase by business features or domains (grouping related code together) rather than by technical layers, to improve navigation, locality of changes, and overall maintainability.  
case: Activate when setting up or refactoring project directory structure, especially in growing monoliths or medium-to-large applications, when changes to one feature require touching many scattered files, or when new team members struggle to find where code lives.
file: feature-based_organization.md

#### Purpose (Waist)
feature-based-organization is the skill of organizing code around *what the system does* (business features/domains) instead of *how it is built* (technical layers like controllers, services, repositories), so that related logic stays together and changes remain localized.

#### Workflow (3-Boundary Pants Structure)

**Waist – Current Structure Audit**  
Explicitly describe the existing organization (e.g., “layer-based: controllers/, services/, repositories/”) and identify the pain points (scattered feature logic, high coupling across layers, difficult navigation).

**Leg 1 – Feature Identification**  
Map the system’s major business capabilities or domains (e.g., UserAuthentication, OrderProcessing, PaymentHandling, InventoryManagement). Group everything that belongs to one feature together: models, logic, APIs, tests, configuration, etc.

**Leg 2 – Refactoring to Feature Structure**  
Reorganize the codebase into feature folders:
- Each top-level folder represents a cohesive business feature or bounded context.
- Inside each feature: place all related files (controllers, services, models, tests, etc.).
- Keep shared technical utilities or cross-cutting concerns in a separate `core/` or `shared/` folder.
- Use clear, domain-language names for feature folders.
Validate that changes to one feature now mostly stay within its folder. Hand off the new structure to `composition-over-inheritance`, `law-of-demeter`, and `small-functions-single-responsibility` for internal coherence.

#### Core Rules (always enforce)
- Organize primarily by feature/domain, not by technical role.
- Keep feature folders self-contained as much as possible.
- Extract truly cross-cutting concerns (logging, auth, database access) into shared modules, but minimize their usage.
- Use consistent naming that matches the business language.
- Re-evaluate organization as the system evolves — features can be split or merged.
- Preserve epistemic-uncertainty when the right feature boundaries are still emerging.

#### Integration Rules
- Pairs tightly with `small-functions-single-responsibility` (small functions live inside clear feature folders), `meaningful-naming` (feature names use domain language), and `composition-over-inheritance` (features compose via interfaces rather than deep inheritance).
- Feeds better locality of changes directly into `second-order-thinking` and overall team velocity.

#### Boundaries / When Not to Use
- Do not force feature-based structure on very small projects or scripts where a simple flat structure is clearer.
- Do not split features so finely that you create hundreds of tiny folders with high inter-feature coupling.

#### Resolution
The codebase becomes organized around business value instead of technical implementation. Developers can find, understand, and change code for a specific feature much faster. Changes are more localized, onboarding improves, and the system scales more gracefully as it grows.