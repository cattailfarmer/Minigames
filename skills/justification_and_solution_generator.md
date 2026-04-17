# Skill: justification_and_solution_generator
name: justification_and_solution_generator
description: Generates the Solution Specification and Justifications Graph YAML files from a given Specification, recording implemented work and the reasoning path, including dead-end marking to prevent repetition of faulty paths. Produces a new Prerequisite Justification when failures prove inescapable.
case: Summon after a specification has been decomposed and a solution path has been chosen or tested. Supports both initial creation and iterative updates with failure feedback.
file: justification_and_solution_generator.md
dependencies: delineation, verbose, epistemic-uncertainty, self-reflection, intuition

## Purpose (Waist)
This skill produces the "as-built" Solution Specification and the traceable Justifications Graph. The Graph serves as the explicit reasoning bridge (including dead-end markers) that connects a Specification to its Solution and prevents repetition of faulty justification paths. When failures are inescapable, it generates a new Prerequisite Justification to trigger Specification rework.

## Workflow (3-Boundary Pants Structure)

### Waist – Input Declaration
Declare:
- The Specification UUID (and its justified version after any prior Prerequisite Justification)
- The chosen solution path and any test/failure results from attempted implementations

### Leg 1 – Solution Documentation
Record the implemented elements:
- Data elements, use cases, scaffold details
- Status of each (implemented, partial, failed)
- Any leftovers that were resolved or remain open

### Leg 2 – Justification Graph Construction & Dead-End Handling
- Create or update the Justifications Graph
- Link specification_uuid → solution_uuid with full reasoning and trade-offs
- If a path fails, append the fault with `status: "dead_end"` and `dead_end_reason`
- Ensure dead-end markers are visible to future calls so the same justification path is never repeated

### Leg 3 – Inescapability Evaluation & Redirect
After recording failures, evaluate whether the failures are inescapable:
- If every attempted justification path ends in dead-ends, or the accumulated failures make viable implementation impossible, declare the Specification unfit for implementation in its current form.
- Generate a new Prerequisite Justification file that summarizes the inescapable failures and the observed faults.
- Signal the Observer to initiate a Specification rework cycle using specification_generator with the new Prerequisite Justification as input.

Output both the Solution Specification (with `justified_by` pointing to this Graph) and the updated Justifications Graph.