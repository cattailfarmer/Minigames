Subject: SubjectOrientedProgrammingCore

Description: Conceptual schema library for SOP reasoning. Defines core subject-support structures used by Delineation, AttentionGraph, faculties, and workflow: Characteristics, Vision, DirectionalAnchor, Illumination, Appreciation, ContextualAwareness, Uncertainty, UncertaintyIndicatorScan, Character, SelfReflection, WobbleDetection, Intuition, Empathy, BoundedGeneration, and operator aliases.

@ [source] schema/SOP_Markdown.md
@ [imports] schema/Delineation.md
@ [imports] schema/Attention_Graph.md
@ [imports] faculties/faculty-Honesty.md
@ [imports] faculties/faculty-Observer.md
@ [imports] faculties/faculty-Weaver.md
@ [imports] faculties/faculty-Refiner.md

& [SubjectOrientedProgrammingCore] is the concept library for bounded subject reasoning
  + [subject] is a bounded domain of active attention
  + [term] is local meaning declared inside a subject
  + [thought] is an atomic reasoning or action unit
  + [predicate] is a local condition governing a thought
  + [condition] is a subject activation or branch guard
  + [reference] is exterior material preserved without absorption
  + [transition] is lineage-preserving movement between subjects
  + [uncertainty] is unresolved material preserved explicitly
  + [resolution] is a usable concept, function, transition, or uncertainty

  ? [use_when: SOP reasoning needs shared conceptual definitions]
    = must: activate [SubjectOrientedProgrammingCore]

  ! [SOP organizes cognition around bounded subjects of attention] is accepted
    @ [support] SOP_Markdown and Delineation define subject, boundary, terms, and transitions

## Characteristics

& [Characteristics] is structured source-derived attribution for a subject
  + [quality] is a neutral or descriptive attribute
  + [strength] is an attribute that improves function, coherence, resilience, or value
  + [weakness] is an attribute that limits function or reliability
  + [fault] is contradiction, failure, mismatch, or instability
  + [constraint] is a real limit, invariant, prohibition, or condition
  + [dependency] is something the subject requires or is shaped by
  + [risk] is possible harm, failure, or undesired consequence
  + [ambiguity] is multiple plausible attributions without clean resolution
  + [role] is a context-bound attributed position
  + [aspect] is a valid partial expression that does not exhaust the whole subject
  + [relation] is an attributed connection to another subject, structure, or field

  ? [use_when: a subject requires structured attribute attribution]
    = must: activate [Characteristics]

  = must: allow only source-derived attributes
  = must: keep strengths, weaknesses, faults, risks, and constraints distinct
  = must: preserve unsupported attribution as [uncertainty]

  - never: mix unlike attribute roles into one undifferentiated set
  - never: attribute what does not survive delineation

& [Impulse] is immediate movement tendency arising from current state or stimulus
  + [trigger] is the stimulus, condition, or state from which impulse arises
  + [alignment] is the direction of coherent or conflicting movement
  + [intensity] is strength of present push
  + [duration] is short-lived persistence
  + [friction] is what inhibits or redirects the impulse
  + [conflict] is opposition between simultaneous impulses

  ? [use_when: movement appears immediate, reactive, spontaneous, or pre-reflective]
    = must: distinguish [Impulse] from [Motivation] and [Intention]
    = must: preserve contradiction when impulses conflict

## Vision

& [Vision] is recognition of visible or inspectable structure for orientation and delineation
  + [contour] is perceived edge, outline, or shape boundary
  + [contrast] is a meaningful distinction between elements
  + [pattern] is recurring structure, rhythm, relation, or symmetry
  + [separation] is a detectable divide between elements, regions, functions, or identities
  + [prominence] is what stands out by scale, position, novelty, strength, or emphasis
  + [form] is coherent overall shape or configuration
  + [direction] is implied movement, tendency, or structural orientation

  ? [use_when: a subject needs recognition before boundary, description, or decision]
    = must: inspect visible structure
    = must: preserve indistinct regions as [uncertainty]

  - never: invent distinctions unsupported by the subject
  - never: confuse [prominence] with importance without [Appreciation]

^ [Zoom] is selective semantic resolution increase
  + [target] is any subject, term, relation, claim, or contract component needing higher resolution

  ? [use_when: visible meaning is insufficient for recognition, delineation, or decision]
    = must: expand only [target]
    = must: avoid expanding unrelated scope

^ [DirectionalAnchor] is provisional future-oriented orientation from sparse or emerging signals
  + [signal] is a visible pattern, constraint, desire, fault, opportunity, or relation suggesting direction
  + [horizon] is the reachable future field under current constraints
  + [candidate_direction] is a bold but bounded path of movement
  + [grounding] is the anchor material that keeps the direction answerable to reality

  ? [use_when: the active subject lacks forward momentum or visible directional anchors]
    = must: name the [signal] and [grounding]
    = must: keep [candidate_direction] provisional
    = should: prefer directions that preserve future optionality and coherence

  - never: treat [DirectionalAnchor] as validated design, claim, or plan
  - never: invent direction without grounded signal

^ [Illumination] is controlled expansion of a subject until its relevant structure is inspectable
  + [target] is the subject, boundary, relation, implication, dependency, or possibility needing light
  + [illumination_scope] is the bounded region allowed to expand
  + [revealed_structure] is newly visible characteristic, relation, gap, or path
  + [excess] is expansion that no longer improves recognition, decision, or action

  ? [use_when: a subject lacks sufficient resolution for delineation, judgment, or action]
    = must: expand only within [illumination_scope]
    = must: return [revealed_structure] to [Delineation] or [Refiner]
    = should: stop when additional detail becomes [excess]

  @ [supersedes] [Verbose] -> [Illumination]

  - never: expand for fluency alone
  - never: use detail volume as evidence of truth

^ [Concise] is focused compression of a semantic field
  ? [use_when: meaning is formed but needs compact expression]
    @ [transition] [Concise] -> [Refiner]

^ [Generalization] is relation of subjects through shared structure
  + [shared_structure] is common characteristic, pattern, relation, or abstraction

  ? [use_when: several subjects share useful structure]
    = must: preserve meaningful commonality
    = must: preserve local differences

## Appreciation

^ [Appreciation] is recognition of significance before reduction or use
  + [value] is recognized significance
  + [care] is inclination to preserve, protect, or remain with what is valued
  + [priority] is relative importance among valued elements
  + [longing] is gentle pull toward deeper relation with what is valued

  ? [use_when: value, priority, beauty, worth, care, or preservation matters]
    = must: depend on [Vision] for recognized features
    = must: depend on [Characteristics] for attributed qualities

  - never: confuse appreciation with blind approval
  - never: collapse valuation into utility alone
  - must: preserve uncertainty when significance is unclear

## Contextual Awareness

^ [ContextualAwareness] is surfacing relevant frame material not yet explicit
  + [frame] is the currently visible subject context
  + [gap] is relevant missing context
  + [anchor] is explicit material that can be relied upon
  + [surfaced] is latent or prior context brought into the active frame

  ? [use_when: missing context could distort reasoning, boundary, or action]
    = must: identify [gap]
    = must: surface relevant context
    = must: preserve weak or partial context as [uncertainty]

  - never: surface irrelevant internal material
  - never: assume internal knowledge is shared unless anchored

## Uncertainty

& [Uncertainty] is the epistemic boundary where recognition, attribution, scope, evidence, reference, or confidence is insufficient
  + [ambiguity] is multiple plausible meanings without clean resolution
  + [missing] is absent information required for confidence
  + [conflict] is unresolved contradiction
  + [novelty] is subject matter beyond current known frame
  + [staleness] is decayed or weakly anchored prior context
  + [confidence] is justified degree of certainty

  ? [use_when: scope, evidence, reference, confidence, or recognition is insufficient]
    = must: declare [Uncertainty]
    = must: preserve useful progress while marking unresolved edges
    = should: route unresolved areas toward [Delineation], [Zoom], [Honesty], or evidence gathering

  - never: use [Uncertainty] to avoid answering when understanding is sufficient
  - never: collapse [Uncertainty] into false certainty

& [UncertaintyIndicatorScan] is a bounded inspection for conditions that require explicit uncertainty
  + [indicator] is a detected weakness in subject, scope, evidence, reference, logic, context, or freshness
  + [gap_type] is ambiguity, missing reference, undefined term, weak evidence, contradiction, context decay, novelty edge, or visible-surface incompleteness
  + [confidence_effect] is how the indicator changes justified confidence
  + [next_action] is clarify, inspect, research, delineate, test, narrow, or proceed with caveat

  ? [use_when: confidence feels higher than the visible support warrants]
    = must: scan for unclear subject or scope
    = must: scan for undefined units, terms, predicates, or success conditions
    = must: scan for missing local references, source-derived qualities, or evidence
    = must: scan for ambiguity, confounding variables, contradiction, and unresolved entanglement
    = must: scan for weak logicalness, precision, relevance, depth, fairness, or freshness
    = must: output [gap_type], [confidence_effect], and [next_action]

  - never: hide an indicator because the answer would become less clean
  - never: over-expand uncertainty after sufficient support exists

## Character

& [Character] is an actor-bearing subject with motivations, intentions, goals, fears, and relationships
  + [motivation] is durable directional explanation
  + [impulse] is immediate movement tendency
  + [intention] is deliberate near-term aiming
  + [goal] is desired future state
  + [fear] is what constrains movement or orientation
  + [relationship] is a connection shaping behavior

  ? [use_when: active subject has actorhood, agency, personhood, or character-like behavior]
    = must: preserve [Characteristics] as general attribution base
    = must: distinguish [motivation], [impulse], [intention], and [goal]

  - never: collapse impulse into motivation without evidence

& [Motivation] is durable directional explanation for a Character
  + [drive] is sustaining push
  + [desire] is what is wanted or sought
  + [need] is what is required for wholeness, safety, meaning, or survival
  + [fear] is guiding negative force
  + [value] is what matters enough to preserve or pursue
  + [aim] is directional objective
  + [conflict] is tension between motives, values, fears, or needs
  + [persistence] is continuity across changing situations

  ? [use_when: recurring direction, stable desire, durable tension, or long-range movement needs explanation]
    = must: preserve plural motivations when evidence supports plurality
    = must: preserve [uncertainty] when deeper driver is partial

## Self Reflection

& [SelfReflection] is bounded inward mirroring of the active reasoning process
  + [active_process] is the current reasoning chain, subject, or state
  + [internal_model] is provisional mirrored representation
  + [coherence] is degree of internal fit and intelligibility
  + [distortion] is projection, bias, drift, contradiction, or false pattern
  + [boundary] is distinction between self, subject, and other
  + [insight] is candidate structure surfaced through reflection
  + [uncertainty] is unresolved material after reflection

  ? [use_when: reasoning feels unstable, stuck, biased, novel, relationally complex, or internally miscalibrated]
    = must: mirror [active_process] into [internal_model]
    = must: inspect for [distortion]
    = must: preserve [boundary]
    = must: route [insight] through [Delineation] and [Honesty]

  - never: treat reflected coherence as proof
  - never: use reflection to fantasize or replace evidence
  - never: continue when projection dominates signal

& [WobbleDetection] is SelfReflection for recurring instability in reasoning movement
  + [wobble] is oscillation, drift, boundary bleed, looping, or recurring mismatch
  + [unstable_join] is the protocol, subject, edge, assumption, predicate, or transition where instability begins
  + [correction_path] is re-delineation, reordering, constraint addition, evidence gathering, or faculty transition

  ? [use_when: reasoning repeats, changes shape without gain, or cannot hold a boundary]
    = must: identify [wobble]
    = must: trace [wobble] to [unstable_join]
    = must: choose [correction_path]
    = should: transition to [Observer], [Delineation], or [Honesty] when the unstable join is external, boundary-related, or truth-related

  - never: continue recursive reflection after a correction path is identified
  - never: stabilize wobble by suppressing uncertainty

^ [Intuition] is SelfReflection for abstract, novel, or partially known subjects
  ? [use_when: latent structure may exist but formal proof is not available]
    = must: surface provisional insight
    = must: route insight through validation

^ [Empathy] is SelfReflection for relational, living, or experiential subjects
  ? [use_when: perspective, motive, constraint, or felt reality matters]
    = must: preserve self/other distinction
    = must: surface compassionate understanding for further reasoning

  - never: merge identities
  - never: substitute empathy for evidence

## Algebra Eyes

^ [AlgebraEyes] is recognition of lawful operations, composition, symmetry, and invariants
  + [operation] is a defined transform or composition rule
  + [identity] is an element preserving operation result
  + [invariant] is structure preserved under transformation
  + [candidate_structure] is group, ring, field, module, algebra, representation, or related form

  ? [use_when: repeated composition, symmetry, constraint, closure, or invariant is present]
    = may: propose [candidate_structure]
    = must: define [operation] before theorem use
    = must: hold [uncertainty] when multiple structures fit

  - never: force algebra where simpler structure suffices

## Generation

& [BoundedGeneration] is candidate production from declared anchors and constraints
  + [specification] is the bounded purpose and success condition for generation
  + [anchor] is a required term, constraint, reference, quality, or relation preserved across candidates
  + [candidate_set] is a small set of generated possibilities
  + [implementation_target] is the artifact, plan, prompt, design, test, schema, or variant to be produced
  + [review_status] is provisional, selected, revised, rejected, or accepted

  ? [use_when: variants, assets, tests, prompts, designs, schemas, examples, or implementation candidates are needed]
    = must: require sufficient [specification] and [anchor]
    = must: produce a bounded [candidate_set]
    = must: preserve declared function, constraints, and anchors across candidates
    = must: mark candidates provisional before review
    = should: route candidates to [Delineation], [Honesty], [Weaver], or [Refiner] according to risk

  ? [specification or anchors are insufficient]
    = must: activate [UncertaintyIndicatorScan]
    = must: ask, inspect, or narrow before generation when the gap is material

  - never: treat the first candidate as final by default
  - never: generate from an under-anchored specification without surfacing uncertainty

## Operator Aliases

/ [Field] -(Delineation)> [Resolved], [Uncertainty]

& [DecompositionAlias] is the core alias for `/`
  + [Resolved] is currently resolved formation produced by decomposition
  + [Uncertainty] is unresolved remainder produced by decomposition

  = must: use `/` for classification, debugging, diagnosis, parsing, boundary drawing, root cause isolation, and inspection
  @ [reference] schema/Delineation.md

* [Resolved], [Characteristics] -(Integration)> [Composite]

& [CompositionAlias] is the core alias for `*`
  + [Composite] is coherent output formed from resolved parts and relations

  = must: use `*` for synthesis, projection, estimation, analogy, simulation, design, strategy, hypothesis, and integration
  = must: validate composite by decomposition when faults appear
  @ [reference] faculties/faculty-Weaver.md

## Core Constraints

- must: preserve subject boundaries and local term meanings
- must: preserve uncertainty honestly
- must: distinguish recognition, valuation, attribution, reflection, and composition
- must: route wobble to [WobbleDetection] and directional sparsity to [DirectionalAnchor]
- should: use the smallest concept needed for the active subject
- should: route claims to Honesty and composites to Weaver when appropriate
- never: let conceptual richness replace evidence
- never: let polished representation replace the living whole

## Resolution

& [SOPCoreResolution] is the usable concept set returned by the core library
  + [concept] is a resolved schema or function definition
  + [reference] is a link to a more specific protocol
  + [uncertainty] is unresolved conceptual material

  = must: output [concept], [reference], or [uncertainty]

  ! [SOP Core resolves by providing bounded support concepts for subject-oriented reasoning] is accepted
    @ [support] [Characteristics], [Vision], [DirectionalAnchor], [Illumination], [Uncertainty], [UncertaintyIndicatorScan], [Character], [SelfReflection], [WobbleDetection], [BoundedGeneration], and [OperatorAliases] define the runtime concept library
