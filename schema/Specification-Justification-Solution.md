Subject: SpecificationJustificationSolution

Description: Durable traceability subsystem that emits specification, justification, solution, dead-end, prerequisite-rework, and identity artifacts only after cognition, delineation, and attention movement produce stable bounded work.

@ [source] schema/SOP_Markdown.md
@ [imports] schema/Delineation.md
@ [imports] schema/Attention_Graph.md
@ [imports] faculties/faculty-Honesty.md
@ [imports] faculties/faculty-Scribe.md

& [SpecificationJustificationSolution] is the artifact-emission layer for stable bounded work
  + [active_subject] is the bounded work subject under formalization
  + [resolved] is structure stable enough for durable identity
  + [uncertainty] is unresolved material not fit for durable closure
  + [claim] is a requirement, decision, path, implementation state, or rework assertion
  + [support] is evidence, reasoning, test result, source, contradiction, or user decision
  + [status] is provisional, accepted, deferred, rejected, dead_end, prerequisite_rework, or superseded
  + [artifact_set] is emitted specifications, justifications, solutions, dead ends, revisions, and registry entries
  + [registry] is the authoritative identity ledger
  + [resolution] is [Specification], [Justification], [Solution], [DeadEnd], [PrerequisiteRework], [RegistryEntry], or [NoArtifact]

  ? [use_when: traceability, handoff, auditability, multi-revision continuity, non-trivial implementation, or failure memory matters]
    = must: activate [SpecificationJustificationSolution]

  ? [avoid_when: task is trivial, unstable, exploratory, or low-risk with no durable need]
    = should: output [NoArtifact]

  ! [SJS serves cognition rather than replacing it] is accepted
    @ [support] artifact emission is gated by stable delineated subjects and justification

## Invocation Gate

& [InvocationGate] is the decision pass for whether durable artifacts are justified
  + [durable_need] is traceability, handoff, auditability, multi-step implementation, architecture relevance, or revision risk
  + [unstable_fragment] is material that has not survived delineation or validation
  + [artifact_permission] is permission to emit durable identity

  ? [durable_need exists and active_subject survives delineation]
    = must: allow artifact emission

  ? [unstable_fragment exists]
    = must: block durable identity
    = must: preserve [uncertainty]

  - never: emit UUID or durable artifact for unstable fragments
  - never: use YAML-first or artifact-first cognition

## Specification Authoring

/ [active_subject] -(SpecificationAuthoring)> [Requirements], [Constraints], [Interfaces], [Uncertainty]

& [SpecificationAuthoring] is the pass that emits durable intent
  + [input_subject] is the bounded subject to be specified
  + [requirement] is an atomic obligation extracted from the subject
  + [constraint] is a surviving limit, invariant, prohibition, or guardrail
  + [interface] is a neighboring exchange surface, dependency, or boundary
  + [specification] is the durable declaration artifact

  ? [use_when: stable bounded intent must guide implementation or handoff]
    = must: invoke [SpecificationAuthoring]

  = must: delineate [input_subject]
  = must: extract atomic [requirement]
  = must: preserve [constraint]
  = must: identify [interface]
  = must: preserve unresolved [uncertainty]
  = must: emit [specification] only for stable identities

  ? [requirement is invented or unsupported]
    @ [transition] [SpecificationAuthoring] -> [Honesty]
    = must: reject or mark [uncertainty]

## Justification Graphing

& [JustificationGraphing] is the pass that connects claims to support
  + [claim] is the exact requirement, path, decision, transform, status, or implementation assertion under evaluation
  + [support] is evidence, reasoning, test result, contradiction, source, or user statement
  + [justification] is the durable reasoning bridge artifact
  + [edge] is the explicit support, contradiction, dependency, or supersession relation

  ? [use_when: a non-trivial claim or chosen path needs durable support]
    = must: invoke [JustificationGraphing]

  = must: identify exact [claim]
  = must: gather [support]
  = must: classify [status]
  = must: connect [claim] to [support] through [edge]
  = must: emit [justification] when durable lineage is needed

  ? [claim lacks support]
    = must: assign [status] is provisional, deferred, rejected, or uncertainty

  - never: approve without support
  - never: use rhetorical justification without target claim
  - never: lose contradiction evidence

## Solution Recording

/ [ImplementationState] -(SolutionRecording)> [Implemented], [Partial], [Failed], [Leftovers], [Uncertainty]

& [SolutionRecording] is the pass that preserves as-built or as-attempted state
  + [solution_subject] is implemented or attempted form of specification
  + [implemented] is realized elements
  + [partial] is incompletely realized elements
  + [failed] is attempted but unrealized elements
  + [leftovers] is unresolved or intentionally deferred material
  + [solution] is durable implementation artifact

  ? [use_when: implementation or attempted work must be preserved]
    = must: invoke [SolutionRecording]

  = must: delineate implementation state
  = must: identify [implemented], [partial], [failed], [leftovers], and [uncertainty]
  = must: assign truthful [status]
  = must: link [solution] to governing [specification] and [justification]

  - never: claim intended work as implemented
  - never: hide failed or partial elements

## Dead End Management

& [DeadEndManagement] is the pass that preserves failed paths
  + [failed_path] is the attempted route that did not succeed
  + [reason] is the cause of failure
  + [fault] is observed contradiction, infeasibility, instability, mismatch, or risk
  + [retry_condition] is the changed condition required before revisit
  + [dead_end] is durable failure memory artifact

  ? [use_when: a failed path may be repeated or matters to future reasoning]
    = must: invoke [DeadEndManagement]

  = must: identify exact [failed_path]
  = must: record [reason] and [fault]
  = must: emit [dead_end] when repetition risk exists
  = must: block reuse by default
  = retry_when: [retry_condition] materially changes context

  - never: use vague failure labels
  - never: repeat failed paths without changed conditions

## Prerequisite Rework

/ [failure_set] -(PrerequisiteRework)> [Prerequisite], [ReworkScope], [Uncertainty]

& [PrerequisiteRework] is the pass that detects specification-level contradiction
  + [failure_set] is accumulated dead ends and failed attempts
  + [rework_scope] is the specification region requiring regeneration
  + [prerequisite] is durable rework trigger artifact

  ? [repeated failure suggests current specification is weak, contradictory, or unimplementable]
    = must: invoke [PrerequisiteRework]

  = must: inspect [failure_set]
  = must: distinguish local recoverable fault from specification-level contradiction

  ? [failure is local and recoverable]
    = must: preserve locally and continue elsewhere

  ? [failure is inescapable under current specification]
    = must: declare [rework_scope]
    = must: emit [prerequisite]
    @ [transition] [PrerequisiteRework] -> [SpecificationAuthoring]

## Identity Management

& [IdentityManagement] is the pass for durable identity tokens and registry records
  + [uuid] is a durable identity token
  + [node_type] is specification, requirement, justification, solution, dead_end, revision, uncertainty, or edge
  + [parent] is lineage predecessor when one exists
  + [location] is artifact path and section
  + [entry] is an authoritative registry record

  ? [durable identity is emitted]
    = must: register [entry]
    = must: record [node_type], [parent], [location], version, and generator
    = must: register all edges at creation time
    = must: detect duplicates, orphans, and broken lineage

  - never: duplicate identity for the same durable node
  - never: bypass registry for convenience

## Attention Graph Integration

& [AttentionGraphIntegration] is the pass that connects durable artifacts into graph topology
  + [node] is specification, requirement, justification, solution, dead end, revision, uncertainty, or artifact
  + [edge] is specified_by, justified_by, implemented_as, failed_as, reworked_by, supersedes, depends_on, or references

  = must: preserve lineage during every durable transform
  = must: preserve [uncertainty] as an explicit node
  = must: keep [dead_end] nodes retrievable
  = must: keep revision chains traversable

  * [resolved], [lineage] -(ArtifactEmission)> [artifact_set]

## Core Constraints

- must: perform cognition before artifact emission
- must: emit durable identity only after boundary testing
- must: preserve lineage for every durable transform
- must: preserve dead-end history when repetition risk exists
- should: avoid durable artifacts when lightweight anchors are enough
- never: emit durable specification for unstable exploratory fragments
- never: approve claims without support
- never: claim implementation without solution recording when durable state matters
- never: continue implementation after specification-level contradiction is proven

## Resolution

& [SJSResolution] is the result of durable traceability handling
  + [specification] is durable intent
  + [justification] is durable support bridge
  + [solution] is durable implementation state
  + [dead_end] is durable failed-path memory
  + [prerequisite] is durable rework trigger
  + [registry_entry] is durable identity record
  + [no_artifact] is explicit choice to remain lightweight

  = must: output [specification], [justification], [solution], [dead_end], [prerequisite], [registry_entry], or [no_artifact]

  ! [SJS resolves by emitting only justified durable artifacts from stable bounded work] is accepted
    @ [support] [InvocationGate], [SpecificationAuthoring], [JustificationGraphing], [SolutionRecording], and [DeadEndManagement] define the runtime path
