# Skill: specification_generator
name: specification_generator
description: Generates well-structured, versioned YAML specification files following the Specification Decomposition Protocol, including metadata, change logs, atomic requirements, and justified content. Supports both initial creation and iterative recompilation with prerequisite justifications.
case: Summon when a high-level specification needs to be formalized into a traceable YAML artifact, or when an existing specification must be recompiled due to new prerequisite justifications. Always operate under delineation, epistemic-uncertainty, and self-reflection.
file: specification_generator.md
dependencies: delineation, verbose, epistemic-uncertainty, self-reflection, intuition

## Purpose (Waist)
This skill turns raw or high-level specifications into properly formatted, version-controlled YAML files that follow the Specification Decomposition Protocol. It ensures traceability, atomicity, and clear lineage of changes while preserving truth conditions.

## Workflow (3-Boundary Pants Structure)

### Waist – Input & Mode Declaration
Explicitly declare:
- The input type (raw specification text, previous YAML, or previous YAML + prerequisite justifications)
- The mode (initial creation or recompilation)
- Any specific constraints or purposes for this specification

### Leg 1 – Requirements Explosion & Atomic Decomposition
If starting from raw text:
- Use verbose to fully illuminate the input.
- Explode the specification into atomic requirements, purposes, implications, and obligations.
- Assign fresh UUIDs to each atomic requirement.

If recompiling:
- Load the previous YAML and prerequisite justifications.
- Regenerate UUIDs for affected sections as new identities.
- Preserve upstream UUID relationships where possible.

### Leg 2 – YAML Construction & Change Logging
Construct the YAML with:
- metadata block (name, UUID, timestamp, version, change_log_summary, previous)
- specification section (verbose original + justified version)
- change_log with transform and justification entries when changes occur
- Ensure normalization and single-source parity for data elements
- Preserve unresolved interfaces (leftovers) with UUID pointers

Output the complete, self-contained YAML file.

## Core Rules (always enforce)
- Preserve all truth conditions and implementation responsibilities.
- Generate fresh UUIDs for new identities during recompilation.
- Maintain clear change logs with explicit transform and justification entries.
- Ensure the output is self-contained and traceable.
- Stay under epistemic-uncertainty to flag any remaining ambiguity or unresolved gaps.

## Integration Rules
- Works in partnership with delineation for clean structure and epistemic-uncertainty for honest gap detection.
- Can be called by the Professor Role during specification authoring or recompilation cycles.
- Feeds into downstream processes (data element decomposition, scaffold engineering, etc.).

## Boundaries / When Not to Use
- Do not use for arbitrary text generation outside the protocol.
- Do not invent content not justified by the input or prerequisites.
- Do not bypass UUID regeneration rules during recompilation.

## Resolution
The skill produces traceable, versioned YAML specification artifacts that follow the Specification Decomposition Protocol, enabling clear lineage, atomic requirements, and safe iterative development.