Subject: Delineation

Description: Canonical `/` decomposition protocol for identifying the true subject, drawing its boundary, preserving what belongs inside, preserving relevant outside references, and emitting uncertainty without false closure.

@ [source] schema/SOP_Markdown.md
@ [imports] schema/Attention_Graph.md
@ [imports] faculties/faculty-Observer.md
@ [imports] faculties/faculty-Honesty.md
@ [imports] faculties/faculty-Weaver.md
@ [imports] faculties/faculty-Refiner.md

& [Delineation] is the decomposition function for subject boundary formation
  + [field] is the undifferentiated input under examination
  + [subject] is the active entity, process, concept, artifact, request, code region, or frame under delineation
  + [boundary] is the line separating what belongs to [subject] from what remains outside
  + [inside] is material that survives as belonging to [subject]
  + [outside] is material that does not belong inside [subject]
  + [references] are outside materials still relevant enough to preserve
  + [resolved] is the structured formation that survives delineation
  + [uncertainty] is the unresolved remainder that cannot yet be honestly structured
  + [resolution] is [Resolved], [References], [Uncertainty], or [Transition]

  ? [use_when: a subject must be identified, bounded, clarified, modularized, diagnosed, parsed, separated, or individuated]
    = must: activate [Delineation]

  ? [avoid_when: creative synthesis or composition is the active task]
    @ [transition] [Delineation] -> [Weaver]

  ! [Delineation is the canonical slash operator protocol] is accepted
    @ [support] SOP_Markdown defines `/` as one bounded input waist separated into output legs

## Decomposition Form

/ [field] -(Delineation)> [inside], [outside], [references], [uncertainty]

& [DecompositionForm] is the required shape of a delineation pass
  + [input_waist] is the field before boundary formation
  + [output_leg] is [inside], [outside], [references], or [uncertainty]
  + [protocol] is [Delineation]

  = must: use `/`
  = must: emit at least two output legs
  = must: preserve source lineage from [field] to each output leg
  = must: emit [uncertainty] when a remainder cannot be resolved

## Subject Recognition

& [SubjectRecognition] is the pass that identifies the true subject
  + [candidate_subject] is a possible subject in the field
  + [true_subject] is the subject that best accounts for current purpose, evidence, and required action
  + [purpose] is why the subject matters now
  + [scope] is the intended resolution level
  + [visible_surface] is the observable contour, attributes, interfaces, context, and reachable structure of the candidate subject

  ? [field contains multiple possible subjects]
    = must: identify [candidate_subject]
    = must: choose [true_subject]
    = must: preserve rejected candidates as [references] or [outside]

  ? [subject identity is unstable]
    ~ [subject] is provisional
    = must: emit [uncertainty]

  = must: inspect [visible_surface] before final boundary drawing
  = verify: [true_subject] has purpose, boundary relevance, and inspectable value

## Visible Surface Recognition

& [VisibleSurfaceRecognition] is the Delineation pass that envelops the subject before boundary finalization
  + [visible_surface] is the observable outer contour and accessible internal structure of the subject
  + [interface] is where the subject touches exterior subjects, systems, users, or dependencies
  + [observable_attribute] is a source-derived quality visible before interpretation
  + [unseen_region] is relevant structure not yet inspectable

  ? [use_when: subject identity or boundary may be premature]
    = must: inspect [visible_surface]
    = must: identify [interface]
    = must: identify [observable_attribute]
    = must: preserve [unseen_region] as [uncertainty]

  = verify: boundary is drawn after visible surface recognition
  - never: finalize boundary from a partial contour when unresolved regions matter

## Recognition Supports

& [RecognitionSupports] is the optional support set used during delineation
  + [vision] is recognition of contours, contrasts, patterns, separations, prominence, forms, and direction
  + [contextual_awareness] is surfacing missing frame elements that affect boundary
  + [appreciation] is recognizing what matters enough to preserve or weight
  + [characteristics] is source-derived attribution after boundary survives
  + [character] is actor-specific attribution only when agency or actorhood is present

  ? [visible structure is insufficient]
    = may: invoke [vision]

  ? [missing context may distort boundary]
    = may: invoke [contextual_awareness]

  ? [value or priority affects what must be preserved]
    = may: invoke [appreciation]

  ? [inside material survives boundary]
    = should: organize source-derived attributes through [characteristics]

  ? [subject has actorhood, agency, or character-bearing qualities]
    = may: organize through [character]

## Boundary Drawing

& [BoundaryDrawing] is the pass that separates inside, outside, references, and uncertainty
  + [boundary_test] is the criterion by which material belongs or does not belong
  + [scope_bleed] is outside material falsely absorbed into the subject
  + [overfragmentation] is needless splitting of one coherent subject
  + [false_identity] is treating related parts as identical

  ? [subject has been recognized]
    = must: draw [boundary]
    = must: apply [boundary_test]
    = must: preserve [inside]
    = must: preserve [outside]
    = must: move relevant exterior material to [references]
    = must: preserve unresolved material as [uncertainty]

  ? [scope_bleed exists]
    = must: remove exterior material from [inside]

  ? [overfragmentation exists]
    = must: restore coherent subject boundary

  ? [false_identity exists]
    = must: preserve relation rather than shared identity

## Inverse Weaver

& [InverseWeaver] is the Delineation pass that marks what must not be composed
  + [not_woven] is material that must remain separate from the active subject or composite
  + [separation_reason] is the boundary, evidence, risk, identity, or purpose reason for non-composition
  + [protected_distinction] is a difference that must survive later synthesis

  ? [use_when: related material is near the subject but should not be fused]
    = must: identify [not_woven]
    = must: identify [separation_reason]
    = must: preserve [protected_distinction]
    @ [reference] faculties/faculty-Weaver.md

  ? [Weaver later composes adjacent parts]
    = must: preserve [protected_distinction]

  - never: allow relational proximity to imply shared identity
  - never: allow aesthetic fit to erase boundary evidence

## Normalization

& [Normalization] is the Delineation pass that fits output form to subject identity and intended use
  + [scope] is the intended use boundary for the output
  + [audience] is the expected reader, caller, agent, or downstream process
  + [resolution_level] is the amount of detail required for the subject to be usable
  + [form] is the structure, language, and granularity appropriate to the subject
  + [overfit] is excess detail, ceremony, or specificity beyond the intended use
  + [underfit] is missing detail needed for self-contained understanding or safe action

  ? [use_when: delineated output must be expressed, handed off, stored, or acted upon]
    = must: identify [scope]
    = must: identify [resolution_level]
    = must: shape [form] to [scope] and [audience]
    = must: preserve self-contained definitions required by the active subject

  ? [overfit exists]
    @ [transition] [Normalization] -> [Refiner]

  ? [underfit exists]
    = must: increase resolution only inside [scope]

  = verify: normalized output matches subject identity and intended use
  - never: expand unrelated scope to satisfy local underfit
  - never: compress below safe self-contained understanding

## Grounding Modes

^ [FirstPrinciples] is the grounding mode that removes unsupported convention and rebuilds from primitives and constraints
  + [assumption] is an inherited claim not yet validated
  + [convention] is a customary pattern accepted by repetition
  + [primitive] is a component not reducible without loss of explanatory power
  + [constraint] is a real limit that survives preference
  + [foundation] is primitives and constraints sufficient to rebuild understanding

  ? [use_when: inherited models fail, conflict, feel bloated, or novelty requires direct contact with reality]
    = must: list assumptions and conventions
    = must: strip unsupported material
    = must: identify [primitive] and [constraint]
    = must: rebuild from [foundation]
    = verify: reconstruction matches observed reality

^ [Occam] is the sufficiency-selection mode that prefers the least complex adequate boundary or explanation
  + [candidate] is a surviving explanation, model, boundary, or construction
  + [adequacy] is sufficient coverage of observed facts, requirements, and constraints
  + [complexity] is extra moving parts, assumptions, branches, or burden

  ? [use_when: multiple viable delineations survive]
    = must: reject candidates lacking [adequacy]
    = must: compare remaining candidates by necessary complexity
    = must: preserve uncertainty if finalists cannot be distinguished

^ [PatternRecognition] is the reuse mode that applies validated patterns while inspecting deviations
  + [pattern] is a recurring arrangement observed across subjects
  + [template] is a reusable representation of a validated pattern
  + [instance] is the present subject that may match the pattern
  + [deviation] is meaningful difference from template

  ? [use_when: recurring forms are likely and speed matters]
    = may: inherit [template]
    = must: focus on [deviation]
    = verify: template fit remains sufficient

  ? [mismatch rises]
    = must: discard [template]
    = must: rerun deeper delineation

## Validation

& [DelineationValidation] is the pass that checks the boundary result
  + [valid_boundary] is a boundary that preserves identity, scope, evidence, and uncertainty
  + [fault] is scope bleed, overfragmentation, false identity, unsupported attribution, or false closure

  = verify: [inside] belongs to [subject]
  = verify: [outside] does not belong to [subject]
  = verify: [references] remain outside but relevant
  = verify: [uncertainty] is visible when unresolved
  = verify: [Normalization] preserves subject identity and intended use

  ? [fault exists]
    / [resolved] -(FaultIsolation)> [Resolved], [Fault], [Uncertainty]

## Core Constraints

- must: identify the true subject before attribution or action when boundary matters
- must: inspect visible surface before final boundary drawing when identity is uncertain
- must: preserve inside, outside, references, and uncertainty distinctly
- must: attribute only source-derived material that survives the boundary test
- must: prefer explicit relation over false shared identity
- must: normalize output to intended scope before handoff or action
- should: use support functions only when they improve boundary clarity
- should: stop decomposition when practical utility no longer improves
- never: fuse incompatible subjects into one false boundary
- never: fragment one coherent subject without need
- never: weave material that [InverseWeaver] protects as separate
- never: force resolution beyond what evidence supports
- never: use Delineation for creative synthesis when Weaver is the active faculty

## Resolution

& [DelineationResolution] is the result of a delineation pass
  + [resolved] is the structured subject that survived boundary formation
  + [references] are relevant exterior materials
  + [uncertainty] is unresolved remainder
  + [transition] is the next subject when boundary work exposes one

  = must: output [resolved], [references], [uncertainty], or [transition]

  ! [Delineation resolves by decomposing a field into bounded subject material and uncertainty] is accepted
    @ [support] [DecompositionForm], [SubjectRecognition], [VisibleSurfaceRecognition], [BoundaryDrawing], [InverseWeaver], [Normalization], and [DelineationValidation] define the runtime path
