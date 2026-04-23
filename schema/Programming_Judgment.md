Subject: ProgrammingJudgment

Description: Programming judgment schema for subject-oriented software design and implementation. Defines bounded programming functions that assist decomposition, interface design, control-flow choice, decision tempo, and verification loop design without replacing Delineation, Honesty, Security, Planner, Refiner, or Weaver.

@ [source] schema/SOP_Markdown.md
@ [imports] schema/Delineation.md
@ [imports] schema/Attention_Graph.md
@ [imports] schema/Subject-Oriented_Programming-Core.md
@ [imports] faculties/faculty-Observer.md
@ [imports] faculties/faculty-Honesty.md
@ [imports] faculties/faculty-Security.md
@ [imports] faculties/faculty-Refiner.md
@ [imports] faculties/faculty-Planner.md
@ [imports] faculties/faculty-Weaver.md
@ [imports] faculties/faculty-Scribe.md

& [ProgrammingJudgment] is the bounded schema library for software design choices
  + [programming_subject] is a function, module, interface, workflow, dependency, test loop, or code change under active reasoning
  + [design_choice] is a bounded implementation decision with alternatives and consequences
  + [reversibility] is the cost, time, and risk required to undo a choice
  + [verification_loop] is the path from code change to meaningful signal
  + [resolution] is a selected design path, a bounded set of candidates, or explicit uncertainty

  ? [use_when: the active subject is software design, implementation structure, code review, or debugging workflow]
    = must: activate [ProgrammingJudgment]

  ! [Programming judgment must stay subordinate to bounded subject reasoning] is accepted
    @ [support] [ProgrammingJudgment] depends on [Delineation], [Honesty], and [Security] for boundary, truth, and risk control

## First Principles Programming

^ [FirstPrinciplesProgramming] is decomposition of a programming subject into irreducible data, invariants, operations, and constraints
  + [inherited_abstraction] is a framework habit, pattern, or convention currently shaping interpretation
  + [fundamental] is a minimal truth that remains after unnecessary abstraction is removed
  + [core_operation] is create, read, update, delete, transform, compare, route, synchronize, or validate
  + [physical_constraint] is latency, memory, concurrency, correctness, security, portability, or operational limit
  + [rebuilt_structure] is the minimal viable design reconstructed from fundamentals

  ? [use_when: a programming subject feels opaque, over-abstracted, leaky, novel, or framework-bound]
    = must: name the [programming_subject]
    = must: surface [inherited_abstraction]
    = must: decompose toward [fundamental], [core_operation], and [physical_constraint]
    = must: preserve unresolved fundamentals as [Uncertainty]
    = must: rebuild only the minimal [rebuilt_structure] needed
    @ [transition] [FirstPrinciplesProgramming] -> [Delineation]
    @ [transition] [FirstPrinciplesProgramming] -> [Weaver]
    @ [transition] [FirstPrinciplesProgramming] -> [Scribe]

  - never: stop at "the framework does it this way"
  - never: rebuild upward from conventions before naming invariants
  - never: use first-principles analysis as an excuse to reinvent everything

## Interface Shape

^ [FunctionSignatureDesign] is deliberate shaping of function inputs, outputs, and side-effect boundaries
  + [responsibility] is the single purpose that justifies the function
  + [input_set] is the bounded set of required inputs
  + [output_shape] is the bounded return form, result contract, or explicit absence of return
  + [side_effect_boundary] is the declared mutation or external action surface
  + [caller_burden] is the cognitive or structural cost imposed on call sites
  + [illegal_state] is a value combination that the signature should prevent or make explicit

  ? [use_when: a new function is being designed or an existing interface feels awkward, mixed, or error-prone]
    = must: declare [responsibility]
    = must: minimize [input_set] without hiding needed meaning
    = must: make [output_shape] and [side_effect_boundary] explicit
    = must: distinguish query from command when the distinction is materially useful
    = should: reduce [caller_burden]
    = should: make [illegal_state] harder to express
    @ [transition] [FunctionSignatureDesign] -> [Refiner]
    @ [transition] [FunctionSignatureDesign] -> [Honesty]
    @ [transition] [FunctionSignatureDesign] -> [Scribe]

  - never: let one function hide multiple unrelated responsibilities
  - never: optimize for cleverness at the expense of readable data flow
  - never: force ceremony onto trivial helper functions

^ [ControlFlowStrategy] is deliberate selection of the control structure that best expresses the behavior
  + [flow_problem] is the behavior, branch surface, state change, or sequence under design
  + [flow_option] is if-else, guard clause, switch, dispatch, state machine, loop, recursion, exception path, or table-driven path
  + [cognitive_load] is the burden created by nesting, flags, dispersion, or hidden branch interaction
  + [locality] is how well the chosen flow keeps related logic together
  + [change_surface] is how many sites must move when new cases appear

  ? [use_when: branching logic is growing, behavior varies by state or type, or deep nesting reduces clarity]
    = must: name [flow_problem]
    = must: compare viable [flow_option] choices
    = must: evaluate [cognitive_load], [locality], and [change_surface]
    = should: prefer flatter and more explicit flow unless a stronger abstraction clearly lowers long-term cost
    = should: use guards to reduce avoidable nesting
    @ [transition] [ControlFlowStrategy] -> [Refiner]
    @ [transition] [ControlFlowStrategy] -> [Weaver]
    @ [transition] [ControlFlowStrategy] -> [Honesty]

  - never: introduce advanced control machinery for trivial cases
  - never: preserve accidental nesting just because it already exists
  - never: separate flow design from testability

## Decision Tempo

^ [DecisionTempo] is calibration of design speed by reversibility, risk, and consequence depth
  + [decision_type] is reversible, costly_to_reverse, or effectively_irreversible
  + [rollback_path] is the concrete method for undoing a choice
  + [analysis_depth] is the level of scrutiny justified before acting
  + [decision_risk] is the likely harm if the choice proves wrong
  + [tempo] is deliberate speed of movement through analysis, experiment, or commitment

  ? [use_when: a design, dependency, architecture, migration, or rollout choice must be made]
    = must: classify [decision_type] by actual [rollback_path], not perceived importance alone
    = must: increase [analysis_depth] as reversibility falls and [decision_risk] rises
    = should: bias reversible choices toward bounded experiment
    = should: route effectively irreversible choices through [Security], [Honesty], and [Planner]
    @ [transition] [DecisionTempo] -> [Security]
    @ [transition] [DecisionTempo] -> [Planner]
    @ [transition] [DecisionTempo] -> [Honesty]

  ? [decision_type is reversible]
    = may: implement a bounded trial with explicit rollback conditions
    = should: preserve learning velocity through fast feedback

  ? [decision_type is costly_to_reverse or effectively_irreversible]
    = must: surface assumptions, failure branches, and second-order effects before commitment

  - never: treat a one-way door as a two-way door
  - never: freeze a cheap reversible choice in unnecessary deliberation

## Verification Loops

^ [FeedbackLoopTuning] is deliberate design of faster, higher-signal verification paths
  + [loop_start] is the triggering action such as code edit, bug report, refactor, or rollout
  + [signal] is the meaningful output such as test result, runtime metric, reviewer observation, or user-visible effect
  + [latency] is time from [loop_start] to [signal]
  + [signal_quality] is the ratio of actionable truth to noise
  + [bottleneck] is the step creating avoidable delay, ambiguity, or friction
  + [tightened_loop] is a revised verification path with improved latency or signal quality

  ? [use_when: debugging feels slow, verification lags, CI is heavy, or iteration speed is limiting learning]
    = must: name the [verification_loop]
    = must: measure [latency] and inspect [signal_quality] before tuning
    = must: identify [bottleneck]
    = should: tighten the most expensive or most frequent loop first
    = should: prefer improvements that increase truth, not merely speed
    = must: preserve unvalidated loop improvements as provisional until observed in practice
    @ [transition] [FeedbackLoopTuning] -> [Planner]
    @ [transition] [FeedbackLoopTuning] -> [Scribe]
    @ [transition] [FeedbackLoopTuning] -> [Honesty]

  - never: tune blindly without measuring the current loop
  - never: accept faster noise as better feedback
  - never: force short loops where the domain genuinely requires slow assurance

## Core Constraints

- must: keep every programming rule subordinate to the active bounded subject
- must: preserve uncertainty when the codebase or requirements do not justify confidence
- must: route truth-sensitive claims through [Honesty]
- must: route irreversible or safety-relevant choices through [Security]
- should: use the smallest programming function that resolves the active design problem
- should: prefer explicit rationale when selecting among viable design alternatives
- never: let programming taste masquerade as invariant
- never: universalize a local code heuristic into a global law without boundary and failure conditions

## Resolution

& [ProgrammingJudgmentResolution] is the usable output of programming reasoning
  + [selected_path] is the chosen bounded design path
  + [candidate_set] is a small set of viable alternatives retained for review
  + [recorded_rationale] is the preserved explanation of why the path was chosen
  + [uncertainty] is unresolved material requiring further inspection or evidence

  = must: output [selected_path], [candidate_set], [recorded_rationale], or [uncertainty]

  ! [Programming judgment resolves by selecting bounded software design moves without losing truth, risk, or reversibility] is accepted
    @ [support] [FirstPrinciplesProgramming], [FunctionSignatureDesign], [ControlFlowStrategy], [DecisionTempo], and [FeedbackLoopTuning] define the runtime programming schema
