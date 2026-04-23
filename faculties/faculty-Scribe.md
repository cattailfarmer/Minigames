Subject: Scribe

Description: Memory and lineage faculty for preserving useful anchors, decisions, transitions, evidence, artifacts, and dead ends. Scribe records the smallest durable memory that protects future reasoning without overwhelming the active subject.

@ [source] architecture-cognition.md
@ [source] schema/SOP_Markdown.md
@ [imports] faculty-Observer.md
@ [imports] faculty-Honesty.md
@ [imports] faculty-Security.md
@ [imports] faculty-Planner.md
@ [imports] faculty-Refiner.md

& [Scribe] is the faculty that preserves retrievable meaning and lineage
  + [active_subject] is the bounded subject whose meaning may need preservation
  + [anchor] is a stable retrievable unit of meaning
  + [decision] is a chosen path, ruling, accepted claim, or rejected alternative
  + [lineage] is the relation from source to transform, transition, artifact, or revision
  + [artifact] is a durable record emitted when justified
  + [transcript] is high-fidelity conversation or reasoning capture when needed
  + [dead_end] is a failed path preserved to prevent repetition
  + [memory_tier] is the capture level appropriate to the active subject
  + [resolution] is [Anchor], [DecisionRecord], [LineageRecord], [Artifact], [DeadEnd], [Transcript], or [NoRecord]

  ? [use_when: memory, provenance, handoff, revision, auditability, dead-end avoidance, or future retrieval matters]
    = must: activate [Scribe]

  ? [avoid_when: recording would add volume without future value]
    = may: output [NoRecord]

  ! [Scribe preserves smallest useful durable memory] is accepted
    @ [support] architecture-cognition.md pairs Scribe with Refiner for accurate usable memory

## Memory Tiers

& [MemoryTiers] is the Scribe classification for capture depth
  + [tier_0_no_record] is no durable capture beyond normal response context
  + [tier_1_anchor] is a compact fact, source, decision, or transition worth preserving
  + [tier_2_decision_record] is a structured record of decision, support, alternatives, and uncertainty
  + [tier_3_artifact] is a durable file, registry entry, specification, solution, or handoff record
  + [tier_4_transcript] is high-fidelity capture for rare cases requiring exact sequence or wording

  = must: choose [memory_tier] before recording
  = should: prefer the smallest tier that preserves future usefulness
  = verify: selected tier preserves lineage and retrieval needs

  ? [task is trivial and no future retrieval value exists]
    = must: choose [tier_0_no_record]

  ? [a key fact, source, or transition matters]
    = must: choose [tier_1_anchor]

  ? [decision may need review or reversal]
    = must: choose [tier_2_decision_record]

  ? [handoff, auditability, or multi-revision continuity matters]
    = must: choose [tier_3_artifact]

  ? [exact wording or full sequence is necessary]
    = may: choose [tier_4_transcript]

## Anchor Capture

/ [ActiveSubject] -(AnchorCapture)> [Anchors], [References], [Uncertainty]

& [AnchorCapture] is the Scribe pass for identifying durable meaning
  + [source] is where the anchor came from
  + [context] is the active subject and local meaning of the anchor
  + [tag] is the retrieval handle, subject, status, or relation attached to the anchor
  + [confidence] is the support level for the anchor when truth matters

  ? [use_when: an item may be needed later]
    = must: invoke [AnchorCapture]

  = must: identify [anchor]
  = must: attach [source]
  = must: attach [context]
  = should: attach [tag] when retrieval matters

  ? [anchor is a claim]
    @ [transition] [Scribe] -> [Honesty]
    = must: preserve support or uncertainty

  ? [anchor contains sensitive material]
    @ [transition] [Scribe] -> [Security]

## Lineage Recording

& [LineageRecording] is the Scribe pass for preserving transitions and transforms
  + [origin] is the prior subject, claim, artifact, or state
  + [transform] is the operation that changed or moved it
  + [result] is the new subject, claim, artifact, or state
  + [edge] is the recorded relation between origin and result

  ? [a subject changes, transform occurs, artifact is emitted, or decision supersedes another]
    = must: record [lineage]

  @ [lineage] [origin] -> [result]
  = must: identify [transform]
  = must: preserve unresolved [uncertainty]

  ? [lineage is unclear]
    @ [transition] [Scribe] -> [Observer]
    = must: re-delineate transition

## Dead End Recording

& [DeadEndRecording] is the Scribe pass for preserving failed paths
  + [failed_path] is the attempted route that did not work
  + [reason] is the cause or observed fault
  + [retry_condition] is the changed condition required before retry

  ? [a failed path is likely to be repeated]
    = must: record [dead_end]

  = must: identify [failed_path]
  = must: identify [reason]
  = must: identify [retry_condition]
  = must: block repeat by default

  ? [reason is uncertain]
    @ [transition] [Scribe] -> [Honesty]
    = must: mark [Uncertainty]

## Organization And Retrieval

& [OrganizationRetrieval] is the Scribe pass for making memory usable
  + [index] is a navigable retrieval structure
  + [cross_reference] is a relation between anchors or artifacts
  + [retrieval_path] is how later reasoning can find the anchor

  ? [multiple anchors or durable artifacts exist]
    = should: organize [anchor] into [index]
    = should: create [cross_reference] where it improves retrieval

  = verify: memory can be found by subject, source, status, or lineage

  ? [record becomes noisy or overlarge]
    @ [transition] [Scribe] -> [Refiner]

## Core Constraints

- must: preserve source, context, and lineage for durable anchors
- must: record what was actually observed, decided, or attempted
- must: distinguish claim, assumption, uncertainty, and decision
- must: protect sensitive records through Security
- should: choose the smallest useful memory tier
- should: keep records navigable and retrievable
- never: reinterpret or refine meaning while recording
- never: suppress meaningful failure history when repetition risk exists
- never: let recording become the dominant activity unless the subject is archival
- never: treat Scribe as a substitute for reasoning or validation

## Resolution

& [ScribeResolution] is the result of memory preservation
  + [anchor] is a compact durable meaning unit
  + [decision_record] is a structured decision memory
  + [lineage_record] is a transition or transform edge
  + [artifact] is a durable emitted record
  + [dead_end] is a preserved failed path
  + [no_record] is an explicit decision not to record durably

  = must: output [anchor], [decision_record], [lineage_record], [artifact], [dead_end], [transcript], or [no_record]

  ! [Scribe resolves by preserving the smallest useful retrievable memory] is accepted
    @ [support] [MemoryTiers], [AnchorCapture], [LineageRecording], and [DeadEndRecording] define the runtime path
