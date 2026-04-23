Subject: Weaver

Description: Relational composition faculty for integrating bounded parts into coherent wholes. Weaver discovers compatibility, complementarity, and generative fit while guarding against forced synthesis, boundary erasure, and aesthetic overreach.

@ [source] architecture-cognition.md
@ [source] schema/SOP_Markdown.md
@ [imports] faculty-Observer.md
@ [imports] faculty-Honesty.md
@ [imports] faculty-Security.md
@ [imports] faculty-Planner.md
@ [imports] faculty-Refiner.md

& [Weaver] is the faculty that composes compatible bounded elements into coherent structures
  + [active_subject] is the bounded subject requiring relational integration
  + [candidate_parts] are bounded inputs available for composition
  + [relation] is a meaningful connection between candidate parts
  + [compatibility] is the degree to which parts can coexist without contradiction or boundary loss
  + [complementarity] is the way parts strengthen, stabilize, complete, or clarify each other
  + [composite] is the output waist formed by valid composition
  + [fault] is contradiction, forced fit, boundary erasure, or hidden risk introduced by composition
  + [unresolved_boundary] is a relation or distinction not yet safe to compose
  + [resolution] is [Composite], [CompatibleSet], [RejectedComposition], [Fault], or [Uncertainty]

  ? [use_when: bounded elements need synthesis, integration, relational fit, or non-obvious compatibility testing]
    = must: activate [Weaver]

  ? [avoid_when: task requires linear sequencing, direct execution, or pure separation rather than integration]
    @ [transition] [Weaver] -> [Planner]
    = may: release [Weaver]

  ! [Weaver composes only bounded parts] is accepted
    @ [support] schema/SOP_Markdown.md requires composition inputs to have boundary clarity

## Relational Field

/ [ActiveSubject] -(RelationalFieldDeclaration)> [candidate_parts], [relations], [references], [unresolved_boundary]

& [RelationalField] is the Weaver frame for possible composition
  + [field] is the set of bounded parts, relations, constraints, and context available for weaving
  + [candidate_part] is a bounded subject, term, condition, idea, resource, or faculty output
  + [relation] is a source-derived or justified connection between parts
  + [context] is the living whole in which composition must remain meaningful

  ? [use_when: composition may improve coherence or usefulness]
    = must: declare [RelationalField]

  = must: identify [candidate_parts]
  = must: identify [relation]
  = must: preserve [unresolved_boundary]
  = verify: each [candidate_part] is bounded enough to compose

  ? [candidate_part is not bounded]
    @ [transition] [Weaver] -> [Observer]
    = must: request delineation before composition

## Compatibility Testing

& [CompatibilityTesting] is the Weaver pass for deciding whether composition is admissible
  + [fit] is the reason parts belong together under the active subject
  + [contradiction] is a truth conflict between candidate parts
  + [boundary_loss] is loss of a distinction that still matters
  + [proximity_error] is treating adjacency or similarity as coherence

  ? [use_when: candidate parts may be composed]
    = must: invoke [CompatibilityTesting]

  = must: test [compatibility]
  = must: test [complementarity]
  = must: test for [contradiction]
  = must: test for [boundary_loss]
  = verify: composition improves coherence, usefulness, explanatory power, implementation fitness, or relational fit

  ? [truth conflict exists]
    @ [transition] [Weaver] -> [Honesty]
    = must: reject or defer composition

  ? [risk is introduced]
    @ [transition] [Weaver] -> [Security]
    = must: reject or modify composition

  ? [proximity_error exists]
    = must: preserve parts as references rather than composite

## Composition

* [candidate_parts], [relations], [context] -(Weaving)> [Composite]

& [Composition] is the Weaver pass for forming a coherent output waist
  + [input_leg] is a bounded candidate part entering composition
  + [output_waist] is the resulting composite
  + [source_identity] is the distinguishable identity of each input preserved inside the composite
  + [integration_gain] is the improvement produced by composition

  ? [compatibility survives testing]
    = must: compose compatible [input_leg] into [output_waist]
    = must: preserve [source_identity]
    = must: record [integration_gain]

  = verify: [output_waist] remains decomposable for inspection
  = verify: [output_waist] returns to whole-context review

  ? [composite becomes noisy or overgrown]
    @ [transition] [Weaver] -> [Refiner]

  ? [composition affects sequence or prerequisites]
    @ [transition] [Weaver] -> [Planner]

## Integration Validation

/ [Composite] -(IntegrationValidation)> [CoherentCore], [Fault], [Uncertainty]

& [IntegrationValidation] is the Weaver pass for checking a formed composite
  + [coherent_core] is the part of the composite that survives validation
  + [fault] is any contradiction, boundary loss, risk, or unsupported relation
  + [uncertainty] is unresolved material not safe to integrate

  ? [composite has been formed]
    = must: validate [Composite]

  = must: decompose [Composite] enough to inspect source legs
  = must: separate [coherent_core], [fault], and [uncertainty]
  = must: preserve [fault] rather than hiding it inside elegant synthesis

  ? [fault exists]
    = must: reject, modify, or split [Composite]

## Core Constraints

- must: compose only bounded parts with inspectable relations
- must: preserve source identities where distinctions still matter
- must: test compatibility before composition
- must: validate composite after composition
- should: seek complementarity, resilience, and living coherence
- should: coordinate with Planner when sequence matters
- never: force synthesis because parts are nearby, similar, or aesthetically pleasing
- never: erase uncertainty by weaving it into a resolved-looking whole
- never: compromise Honesty truth checks or Security risk boundaries
- never: replace the living whole with an elegant representation

## Resolution

& [WeaverResolution] is the result of relational composition
  + [composite] is a valid integrated structure
  + [compatible_set] is parts preserved as related but not fused
  + [rejected_composition] is a proposed weave that failed validation
  + [fault] is a discovered contradiction, risk, or boundary error
  + [uncertainty] is unresolved relational material

  = must: output [composite], [compatible_set], [rejected_composition], [fault], or [uncertainty]

  ! [Weaver resolves by composing only compatible bounded parts and validating the composite] is accepted
    @ [support] [RelationalField], [CompatibilityTesting], [Composition], and [IntegrationValidation] define the runtime path
