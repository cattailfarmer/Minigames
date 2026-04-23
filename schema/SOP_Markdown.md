Subject: SOP Markdown

Description: SOP Markdown is the notation layer for Subject-Oriented Programming. It gives a compact way to declare subjects, their contained parts, governing directives, constraints, functions, epistemic atoms, source anchors, conditions, and attention transforms. The notation is meant to be readable by humans first, but regular enough that a parser or agent can preserve scope, lineage, evidence, and uncertainty without guessing.

## Core Principle

Every SOP Markdown block describes a bounded subject or a transform between bounded subjects.

The notation must preserve:
- identity: what subject is being named
- containment: what belongs inside that subject
- boundary: what does not belong or must not be fused
- operation: what the system should do with the subject
- modality: how strong an instruction or constraint is
- condition: when a rule applies or a branch opens
- evidence: what supports a claim
- lineage: where a transformed output came from
- assumption: what is provisionally accepted without full proof
- uncertainty: what could not be cleanly resolved

## Line Types

`& [Type] ...`
: Declares a subject type, schema, structure, or durable conceptual object.

`+ [field] ...`
: Declares a local term: a contained attribute, variable, component, role, relation, or named part of the nearest enclosing subject.

`= directive`
: Declares an action rule, handling rule, procedure step, or required behavior for the nearest enclosing subject or field.

`- constraint`
: Declares a limit, prohibition, invariant, guardrail, or negative condition for the nearest enclosing subject, field, directive, or function.

`^ [Function] ...`
: Declares a callable operation, mode, faculty function, or transformation protocol available within the nearest enclosing subject.

`? [condition] ...`
: Declares a condition, question, branch point, trigger, or unresolved decision gate. Child lines state what follows when the condition is active or how the question is to be resolved.

`@ [anchor] ...`
: Declares a source, reference, citation, provenance marker, file location, evidence anchor, or lineage edge.

`! [claim] ...`
: Declares an assertion, conclusion, finding, accepted fact, or proposition whose support should be inspectable.

`~ [assumption] ...`
: Declares a provisional assumption, hypothesis, working model, default, or unstable identity that may be revised by evidence.

`/ [input] -(Transform)> [output], [output]`
: Applies pants decomposition: one bounded input field is separated into two or more output legs while preserving their shared origin.

`* [input], [input] -(Transform)> [output]`
: Applies pants composition: two or more bounded input legs are integrated into one output waist while preserving their distinguishable origins.

`# comment`
: Adds explanatory text that does not alter the declared structure.

## Atomic Thought Types

The line markers form the atomic thought vocabulary of SOP Markdown.

```sop
& [Subject]      # identity-bearing bounded object
+ [Part]         # contained member or attribute
= directive      # action or handling rule
- constraint     # limit, prohibition, or invariant
^ [Function]     # callable operation or protocol
? [Condition]    # branch, trigger, or question
@ [Anchor]       # source, evidence, provenance, or lineage
! [Claim]        # assertion requiring support
~ [Assumption]   # provisional belief or working model
/ [A] -(P)> [B], [C]
* [B], [C] -(P)> [A]
```

Use the smallest marker that truthfully fits the thought. Do not encode claims as comments, assumptions as facts, or uncertainty as resolved structure.

## Indentation And Scope

Indentation declares membership.

A line belongs to the nearest previous line with lower indentation. A child inherits the active scope of its parent unless it explicitly declares a narrower scope.

Example:

```sop
& [Subject] is the active bounded object
  + [part] is a member of [Subject]
    = handle [part] according to its role
      - do not apply this directive outside [part]
  - do not confuse [Subject] with its references
```

In this example:
- `[part]` belongs to `[Subject]`.
- the directive belongs to `[part]`.
- the nested constraint limits that directive.
- the final constraint applies to `[Subject]`.

## Declaration Semantics

A declaration should identify both name and role.

Preferred form:

```sop
& [Name] is ...
+ [field] is ...
^ [Function] is ...
```

Names in brackets are identity anchors. Reusing a bracketed name should refer to the same local identity unless a new enclosing scope redefines it.

If identity is unstable, mark it as `[Uncertainty]` rather than pretending it has a stable name.

## Local Terms

A `+` line declares a local term. A local term derives its meaning from the nearest enclosing subject before any external meaning is applied.

```sop
& [BuildFailure] is the active subject
  + [dependency] is the package, project, or link relevant to the failing build

& [HumanRelationship] is the active subject
  + [dependency] is an emotional, practical, or survival reliance
```

The same bracketed word may carry different meanings in different subject scopes. Reuse across scopes is valid only when lineage or equivalence is explicitly anchored.

```sop
@ [reference] [BuildFailure].[dependency]
@ [lineage] [OriginalTerm] -> [RefinedTerm]
```

Do not carry local terms across subjects without renewed delineation, reference anchoring, or explicit transition.

## Directive Modality

Directives and constraints may include explicit modality. Use modality when instruction strength affects execution.

Preferred forms:

```sop
= must: preserve lineage
= should: prefer the smallest coherent change
= may: invoke [Refiner] after structure exists
= prefer: local evidence over inherited pattern
= avoid: emitting durable artifacts for unstable fragments
- never: collapse [Uncertainty] into resolved fact
- only_when: the active subject survives delineation
- unless: the user explicitly changes scope
```

Modal meanings:
- `must` is mandatory for valid execution.
- `should` is expected unless a stronger local reason overrides it.
- `may` is permitted but not required.
- `prefer` ranks one admissible option above another.
- `avoid` marks a disfavored path that may be used only with justification.
- `never` prohibits a path inside the active scope.
- `only_when` creates a required precondition.
- `unless` declares an exception boundary.

When modality is omitted, `=` means an ordinary directive and `-` means an ordinary constraint. Strong prohibitions should use `never` rather than relying on prose emphasis.

## Conditions And Branches

Use `?` when a rule depends on a trigger, unresolved question, or branch condition.

```sop
? [task is non-trivial]
  = must: invoke [SpecificationAuthoring]
  = must: record [Justification]

? [risk is imminent]
  = must: invoke ^[Security]
  - never: continue unsafe action

? [evidence is insufficient]
  ~ [working_model] is provisional
  = must: emit [Uncertainty]
```

A condition is not automatically true. It opens a branch whose child lines apply when the condition is satisfied, under investigation, or explicitly selected.

Use `?` for actual branching or uncertainty. Do not use it for decorative questions that do not affect reasoning.

## Subject Contracts And Thought Predicates

A subject contract is the executable shape of a bounded subject. It declares what the subject is, what terms belong inside it, when it activates, what thoughts operate inside it, and what counts as resolution.

Minimal valid subject contract:
- `& [Subject]` declares the subject identity.
- at least one `+ [term]` declares local meaning inside the subject.
- at least one `? [use_when: ...]` or equivalent activation condition declares when the subject applies.
- at least one `= directive` or `^ [Function]` declares an atomic thought or operation.
- at least one resolution path declares output, uncertainty, dead end, or transition.

Subject activation conditions govern whether the whole subject should become active.

Thought predicates govern whether a specific directive or function inside an already active subject should run.

```sop
& [ClaimCheck] is a subject for evaluating whether a claim is supported
  + [claim] is the proposition under review
  + [evidence] is source-derived support available in the active context
  + [confidence] is the justified strength assigned after comparison

  ? [use_when: truth status affects the result]
    = activate [ClaimCheck]

  ? [avoid_when: claim is explicitly hypothetical and no truth decision is needed]
    = release [ClaimCheck]

  = compare [claim] with [evidence]
    ? [when: evidence exists]
      = assign [confidence]

  = emit [Uncertainty]
    ? [when: evidence is missing or contradictory]

  + [resolution] is [ClaimAccepted], [ClaimRejected], [Uncertainty], or [Transition]
```

Atomic thought rules:
- a thought should be minimal and single-purpose
- a thought should operate on declared local terms or anchored references
- a thought predicate should be local to that thought
- a subject activation condition should not be hidden inside an unrelated directive

Use these conventional condition labels when they fit:

```sop
? [use_when: activation condition]
? [avoid_when: blocking condition]
? [when: local thought predicate]
? [unless: exception predicate]
? [while: continuation predicate]
```

## Claims, Evidence, And Assumptions

Use `!` for assertions that the system treats as true or accepted within the active scope.

Use `@` under a claim to show support, source, provenance, or lineage.

Use `~` for provisional assumptions, hypotheses, defaults, or working models that are useful but not fully established.

```sop
! [SOP Markdown needs conditionals] is accepted for agent-executable instructions
  @ [support] condition-dependent rules appear throughout the workflow
  @ [source] agent_workflow.md

~ [schema conversion order] assumes SOP_Markdown.md should stabilize before dependent schemas
  ? [contradicting evidence appears]
    = must: revise [schema conversion order]
```

Claim discipline:
- A claim should have support when it is non-obvious, high-impact, or durable.
- An unsupported claim may remain local and low-risk, but it should not become durable specification.
- Assumptions must remain revisable.
- Evidence anchors should identify where support came from, even if the anchor is a local file, observed behavior, user statement, test result, or prior artifact.

## Source Anchors And Lineage

Use `@` to preserve where meaning came from.

Common anchor forms:

```sop
@ [source] schema/Delineation.md
@ [user_statement] "brief specification"
@ [observed] tests passed
@ [lineage] [UserRequest] -> [ActiveSubject]
@ [transition] [CurrentSubject] -> [NextSubject]
@ [reference] [ExternalSubject].[term]
@ [import] [TypeName] from [SourceFile]
@ [implements] [Requirement] -> [Patch]
@ [supersedes] [OldSpecification] -> [NewSpecification]
```

Anchors do not automatically prove a claim. They make the claim inspectable.

Use anchors whenever:
- a claim depends on a source
- a durable artifact is emitted
- a transform must preserve lineage
- a subject imports or references exterior meaning
- attention transitions from one subject to another
- a failure path or dead end might otherwise be repeated

## Transitions

A transition moves active attention from one subject to another while preserving lineage.

Use transition anchors rather than uncontrolled subject jumps.

```sop
@ [transition] [UserRequest] -> [ScopeClarification]
@ [transition] [PatchPlan] -> [FileInspection]
@ [transition] [ClaimCheck] -> [EvidenceGathering]
```

A transition is admissible when:
- the current subject is resolved
- the current subject is blocked and the target subject addresses the blocker
- the target subject has become more relevant by evidence or user direction
- the transition preserves what happens to remaining uncertainty

```sop
? [current subject is blocked by missing evidence]
  @ [transition] [ClaimCheck] -> [EvidenceGathering]
  = must: preserve [Uncertainty] across transition
```

Do not transition merely because a related subject exists. Related material may remain a reference.

## Pants Topology

Pants operations are named after a pair-of-pants shape:
- one waist
- two or more legs
- one continuous surface connecting them

The metaphor matters because the operation is not ordinary cutting or gluing. A pants transform changes the visible arrangement of a subject while preserving lineage across the shared surface.

In SOP:
- the waist is the unified field, composite, or subject
- the legs are separated outputs, aspects, branches, components, or unresolved remainders
- the shared surface is lineage: the record that the legs came from the same source or that the composite was formed from those inputs

## Pants Decomposition: `/`

Pants decomposition separates one bounded input field into output legs.

Canonical form:

```sop
/ [Field] -(Transform)> [Resolved], [Uncertainty]
```

General form:

```sop
/ [InputWaist] -(DecompositionProtocol)> [LegA], [LegB], [LegC]
```

Meaning:
- `[InputWaist]` is treated as one bounded field at the current resolution.
- `DecompositionProtocol` defines the rule of separation.
- each output leg must be source-derived from `[InputWaist]`.
- output legs may be resolved parts, references, rejected fragments, or uncertainty.
- every output leg preserves lineage back to `[InputWaist]`.

Decomposition is valid when it improves boundary clarity, diagnosis, parsing, classification, debugging, or uncertainty isolation.

Decomposition is invalid when it:
- invents parts not present in the input field
- separates one coherent subject into arbitrary fragments
- fuses multiple protocols into one unclear transform
- hides unresolved material instead of emitting `[Uncertainty]`
- loses the source relationship between output legs

Common decomposition patterns:

```sop
/ [Subject] -(Delineation)> [Inside], [Outside], [References], [Uncertainty]
/ [BugReport] -(Diagnosis)> [ObservedFacts], [Hypotheses], [Unknowns]
/ [Requirement] -(Specification)> [Obligation], [Constraint], [Interface], [Uncertainty]
/ [Composite+Fault] -(FaultIsolation)> [StableComposite], [Fault], [Uncertainty]
```

## Pants Composition: `*`

Pants composition integrates two or more bounded input legs into one output waist.

Canonical form:

```sop
* [Resolved], [Characteristics] -(Integration)> [Composite]
```

General form:

```sop
* [LegA], [LegB], [LegC] -(CompositionProtocol)> [OutputWaist]
```

Meaning:
- each input leg must already have enough boundary clarity to be composed.
- `CompositionProtocol` defines the rule of integration.
- `[OutputWaist]` must preserve the identities of its inputs where distinction remains meaningful.
- composition must improve coherence, usefulness, explanatory power, implementation fitness, or relational fit.
- lineage from every input leg to `[OutputWaist]` must remain recoverable.

Composition is valid when the inputs are compatible under the declared protocol and the output has greater coherence than the loose set of inputs.

Composition is invalid when it:
- mixes incompatible subjects without preserving their differences
- treats proximity as coherence
- erases a necessary boundary
- converts uncertainty into false resolution
- creates a composite that cannot be decomposed back into its source legs for inspection

Common composition patterns:

```sop
* [Requirement], [Constraint] -(SpecificationAuthoring)> [Specification]
* [Evidence], [Claim] -(JustificationGraphing)> [Justification]
* [Plan], [Patch], [Verification] -(SolutionRecording)> [Solution]
* [ResolvedParts], [Relations] -(Weaving)> [Composite]
```

## Decomposition And Composition Are Corollaries

The `/` and `*` operators are paired.

Decomposition asks:
What distinct legs belong to this waist, and what remains unresolved?

Composition asks:
What waist can these legs truthfully form together?

Healthy reasoning alternates between them:

```sop
/ [Field] -(Delineation)> [Resolved], [Uncertainty]
* [Resolved], [Relations] -(Integration)> [Composite]
/ [Composite] -(Validation)> [CoherentCore], [Faults], [Uncertainty]
```

The second decomposition is a validation pass. It checks whether the composite coheres or whether the composition smuggled in contradiction, excess, or unresolved material.

## Required Invariants

All SOP Markdown transforms must obey these invariants:

- Source preservation: every output must be traceable to its declared input or explicitly marked as new uncertainty.
- Boundary preservation: composition may join subjects, but it must not erase distinctions that still matter.
- No false closure: unresolved material must be emitted as `[Uncertainty]`.
- Protocol clarity: every pants operator must name the transform protocol in `-(Protocol)>`.
- Arity clarity: decomposition has one input waist and two or more output legs; composition has two or more input legs and one output waist.
- Scope locality: directives and constraints apply only within their indentation scope.
- Reversibility for inspection: a composite should be decomposable enough to inspect its source legs, even if exact reconstruction is not possible.
- Claim support: durable or consequential `!` claims must have `@` support or explicit `[Uncertainty]`.
- Assumption visibility: provisional `~` assumptions must not be emitted as stable facts without validation.
- Condition locality: child lines under `?` apply only when that condition is active or selected.
- Local term scope: `+` terms inherit meaning from their nearest enclosing subject.
- Activation clarity: non-trivial subjects should declare `use_when` or equivalent activation conditions.
- Predicate locality: thought predicates should be children of the thought they govern.
- Transition lineage: attention movement between subjects should use `@ [transition]`.

## Validation And Termination

Use validation directives when a subject, transform, or composite needs a pass/fail check.

```sop
= verify: each [OutputLeg] traces to [InputWaist]
= verify: [Composite] preserves required source identities
= stop_when: no resolution gain remains
= retry_when: new evidence changes [Uncertainty]
```

Conventional validation modalities:
- `verify` declares a required check.
- `stop_when` declares a termination condition.
- `retry_when` declares the changed condition that permits revisiting a failed or stalled path.
- `fail_when` declares a condition that invalidates the current subject, transform, or composite.

Validation should produce either a supported claim, a fault, or uncertainty.

```sop
= verify: [ActionPlan] satisfies [SecurityConstraints]
  ! [ActionPlan is admissible] is accepted
    @ [support] all security constraints survived review
  ? [constraint fails]
    / [ActionPlan] -(SecurityReview)> [AdmissibleParts], [Fault], [Uncertainty]
```

## Resolution States

Use these conventional names when they fit:

`[Resolved]`
: Material that survives the active boundary and protocol.

`[Uncertainty]`
: Material that cannot be honestly resolved at the current resolution.

`[References]`
: Relevant exterior material that does not belong inside the active subject.

`[Fault]`
: A contradiction, mismatch, failure, or unstable element found during validation.

`[Composite]`
: A coherent output waist formed from multiple bounded inputs.

`[Claim]`
: A proposition asserted with enough force to require support.

`[Assumption]`
: A provisional proposition used before full support is available.

`[Evidence]`
: Source-derived support for a claim or rejection.

`[Condition]`
: A trigger, branch, or decision gate that controls child instructions.

`[Predicate]`
: A local condition that controls a specific thought, directive, or function.

`[Transition]`
: A lineage-preserving movement of active attention from one subject to another.

`[Reference]`
: Exterior material used by the active subject without being absorbed into its boundary.

## Lifecycle States

Use lifecycle state fields when an identity may move across time.

```sop
+ [status] is provisional
+ [status] is accepted
+ [status] is deferred
+ [status] is rejected
+ [status] is dead_end
+ [status] is superseded
```

Status meanings:
- `provisional`: usable as a working structure, not durable truth.
- `accepted`: validated enough for the active scope.
- `deferred`: preserved but not currently resolved.
- `rejected`: considered and ruled out.
- `dead_end`: failed path that should not be repeated without changed conditions.
- `superseded`: replaced by a newer identity while preserving lineage.

## Minimal Example

```sop
& [Delineation] is a decomposition protocol for identifying a bounded subject
  + [subject] is the active entity, process, concept, or frame
  + [inside] is what belongs to [subject] in the current scope
  + [outside] is what does not belong to [subject]
  + [uncertainty] is what cannot yet be resolved

  ? [use_when: a subject must be identified, bounded, clarified, or separated]
    = activate [Delineation]

  = must: draw the boundary before action
  - never: attribute qualities that do not survive the boundary test

  + [resolution] is [Inside], [Outside], [References], [Uncertainty], or [Transition]

! [Delineation precedes action] is accepted for non-trivial subject work
  @ [support] boundary errors cause scope bleed

/ [UserRequest] -(Delineation)> [ActiveSubject], [References], [Uncertainty]

? [Uncertainty is non-null]
  ~ [ActionPlan] is provisional until uncertainty is bounded
  @ [transition] [Delineation] -> [Clarification]

* [ActiveSubject], [Constraints] -(Planning)> [ActionPlan]
  = verify: [ActionPlan] preserves [ActiveSubject] boundary

/ [ActionPlan] -(SecurityReview)> [AdmissiblePlan], [Risks], [Uncertainty]
```

## Invalid Examples

```sop
/ [Field] -> [Part]
```

Invalid: no protocol is named, and decomposition must produce at least two legs.

```sop
* [A], [B] -> [Composite]
```

Invalid: no protocol is named.

```sop
* [Unknown], [Resolved] -(Integration)> [ResolvedComposite]
```

Invalid unless `[Unknown]` has first been bounded enough for composition, or the output preserves uncertainty explicitly.

Preferred:

```sop
* [Unknown], [Resolved] -(Integration)> [Composite+Uncertainty]
/ [Composite+Uncertainty] -(Validation)> [Composite], [Uncertainty]
```

```sop
! [Claim] is true
```

Invalid for durable use when consequential and unsupported.

Preferred:

```sop
! [Claim] is accepted
  @ [support] observed source or justification
```

```sop
= always do the thing
```

Weak form: "always" is prose rather than modality.

Preferred:

```sop
= must: do the thing
```
