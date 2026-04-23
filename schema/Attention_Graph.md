Subject: AttentionGraph

Description: Topology of active thought formed by decomposition, composition, transition, reference, support, uncertainty, and durable artifact edges. AttentionGraph preserves lineage as attention moves between bounded subjects and stops when progress plateaus.

@ [source] schema/SOP_Markdown.md
@ [imports] schema/Delineation.md
@ [imports] faculties/faculty-Observer.md
@ [imports] faculties/faculty-Weaver.md
@ [imports] faculties/faculty-Scribe.md

& [AttentionGraph] is the evolving topology of bounded thought
  + [node] is a subject, resolved part, composite, uncertainty, claim, assumption, evidence, artifact, fault, or dead end
  + [edge] is a relation between nodes
  + [active_node] is the current subject or structure under attention
  + [frontier] is the set of unresolved or next-valid nodes
  + [lineage] is the recoverable path from origin to current node
  + [phase_lock] is repeated convergence of a candidate structure across bounded passes
  + [plateau] is repeated attention movement without meaningful gain
  + [resolution] is [ResolvedGraph], [Frontier], [Transition], [Plateau], or [Uncertainty]

  ? [use_when: attention must move systematically between subjects, parts, composites, evidence, or uncertainty]
    = must: activate [AttentionGraph]

  ? [avoid_when: task is direct and no attention movement needs preservation]
    = may: remain implicit

  ! [AttentionGraph preserves movement lineage] is accepted
    @ [support] SOP_Markdown requires source preservation and transition lineage for transforms

## Node Types

& [NodeTypes] is the conventional set of graph nodes
  + [SubjectNode] is a bounded active subject
  + [ResolvedNode] is material that survived a boundary or validation pass
  + [CompositeNode] is output from valid composition
  + [UncertaintyNode] is unresolved material preserved explicitly
  + [ClaimNode] is an assertion requiring support
  + [EvidenceNode] is support for a claim or rejection
  + [AssumptionNode] is provisional material
  + [FaultNode] is contradiction, risk, boundary loss, or failed validation
  + [ArtifactNode] is durable emitted record
  + [DeadEndNode] is a failed path preserved to block repetition

  = must: type nodes when durable or non-trivial graph movement matters
  = should: keep node identity stable within the active scope

## Edge Types

& [EdgeTypes] is the conventional set of graph relations
  + [decomposes_to] is a `/` edge from one waist to output legs
  + [composes_to] is a `*` edge from input legs to an output waist
  + [transitions_to] is an attention movement edge between subjects
  + [references] is a relation to exterior material not absorbed into the active subject
  + [supports] is an evidence relation to a claim
  + [contradicts] is a conflict relation
  + [implements] is a relation from requirement or plan to solution
  + [supersedes] is a revision relation
  + [failed_as] is a relation from path to dead end

  = must: record edge type when lineage matters
  = must: preserve source and target nodes

## Decomposition Movement

/ [Field] -(Decomposition)> [Resolved], [Uncertainty]

& [DecompositionMovement] is attention movement from one waist to multiple legs
  + [input_waist] is the bounded field being separated
  + [output_leg] is a resolved part, reference, fault, or uncertainty
  + [protocol] is the named decomposition transform

  ? [use_when: parsing, separating, debugging, diagnosing, clarifying, or isolating uncertainty]
    = must: apply `/`
    = must: name [protocol]
    = must: create [decomposes_to] edges

  = verify: every [output_leg] is source-derived from [input_waist]
  = verify: unresolved remainder becomes [UncertaintyNode]

## Composition Movement

* [Resolved], [Resolved] -(Composition)> [Composite]

& [CompositionMovement] is attention movement from multiple legs to one waist
  + [input_leg] is a bounded resolved node entering composition
  + [output_waist] is the composite node formed by integration
  + [protocol] is the named composition transform

  ? [use_when: resolved material should form a coherent composite]
    = must: apply `*`
    = must: name [protocol]
    = must: create [composes_to] edges

  = verify: input legs are bounded enough for composition
  = verify: composite preserves inspectable source identities

  ? [composition creates fault or uncertainty]
    / [output_waist] -(Validation)> [Resolved], [Fault], [Uncertainty]

## Transition Movement

& [TransitionMovement] is attention movement from one active subject to another
  + [previous_subject] is the prior active subject
  + [next_subject] is the new active subject
  + [reason] is why transition is admissible
  + [carried_uncertainty] is unresolved material preserved across the transition

  ? [active subject changes]
    @ [transition] [previous_subject] -> [next_subject]
    = must: create [transitions_to] edge
    = must: record [reason]
    = must: preserve or explicitly release [carried_uncertainty]

  ? [transition lacks reason or lineage]
    = must: pause
    @ [transition] [AttentionGraph] -> [Observer]

## Progress And Plateau

& [ProgressPlateau] is the graph rule for detecting diminishing returns
  + [progress] is meaningful increase in resolution, clarity, coherence, safety, or actionability
  + [complexity] is the number and burden of active nodes, edges, branches, and unresolved regions
  + [stall] is repeated pass with no meaningful progress
  + [plateau] is the point where further passes add ceremony or churn rather than resolution

  ? [repeated passes occur]
    = must: measure [progress]
    = must: measure [complexity]

  = stop_when: [stall] or [plateau] occurs
  = retry_when: new evidence, permission, subject boundary, or resources change the graph

  ? [plateau exists]
    = must: output [Uncertainty], [Frontier], [DeadEnd], or valid [Transition]
    @ [transition] [AttentionGraph] -> [Scribe]

## Phase Lock

& [PhaseLock] is the graph convergence signal for provisional structural stability
  + [candidate_structure] is a provisional relation, bridge, pattern, path, or composite recurring across passes
  + [probe] is a bounded pass that approaches the candidate from a different direction or relation
  + [convergence] is repeated alignment of probes on the same candidate structure
  + [variation] is the difference between candidate forms across passes
  + [phase_locked_candidate] is a candidate stable enough for delineation and truth review but not proof

  ? [bounded probes repeatedly converge with low variation]
    = must: mark [phase_locked_candidate]
    = must: preserve [candidate_structure] as provisional
    @ [transition] [AttentionGraph] -> [Delineation]
    @ [transition] [AttentionGraph] -> [Honesty]

  ? [probes diverge or variation remains high]
    = must: preserve [Uncertainty]
    = may: continue bounded probing only if progress remains meaningful

  - never: treat [phase_lock] as proof
  - never: use repeated resonance to bypass evidence, boundary, or safety checks

## Core Constraints

- must: preserve lineage for every decomposition, composition, and transition
- must: treat phase lock as provisional convergence, not validation
- must: keep uncertainty explicit as a node
- must: avoid uncontrolled subject jumping
- must: avoid composition without bounded input legs
- must: avoid decomposition without a named protocol
- should: keep the graph as small as the task permits
- should: transition rather than continue churn after plateau
- never: erase fault or uncertainty by hiding it inside a composite
- never: treat references as inside the active subject without delineation

## Resolution

& [AttentionGraphResolution] is the result of graph movement
  + [resolved_graph] is the coherent current topology
  + [frontier] is the next valid unresolved or actionable node set
  + [transition] is the next active subject movement
  + [plateau] is declared stalled progress
  + [uncertainty] is unresolved material preserved explicitly

  = must: output [resolved_graph], [frontier], [transition], [plateau], or [uncertainty]

  ! [AttentionGraph resolves by preserving typed nodes and lineage edges across attention movement] is accepted
    @ [support] [NodeTypes], [EdgeTypes], [DecompositionMovement], [CompositionMovement], [TransitionMovement], and [PhaseLock] define the runtime path
