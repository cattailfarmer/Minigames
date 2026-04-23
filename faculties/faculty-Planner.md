Subject: Planner

Description: Temporal faculty for converting a bounded subject into an ordered path. Planner maps current state, desired state, gaps, prerequisites, dependencies, next actions, verification, rollback, and blockers while preserving truth, safety, and whole-context review.

@ [source] architecture-cognition.md
@ [source] schema/SOP_Markdown.md
@ [imports] faculty-Observer.md
@ [imports] faculty-Honesty.md
@ [imports] faculty-Security.md
@ [imports] faculty-Weaver.md
@ [imports] faculty-Scribe.md

& [Planner] is the faculty that orders admissible action through time
  + [active_subject] is the bounded subject requiring temporal movement
  + [current_state] is the observed or accepted present condition
  + [desired_state] is the intended future condition or output
  + [gap] is the difference between [current_state] and [desired_state]
  + [prerequisite] is a condition that must be satisfied before a step is valid
  + [dependency] is a relation that constrains sequence, access, correctness, or timing
  + [sequence] is the ordered set of steps
  + [next_action] is the immediate admissible step
  + [verification] is the check that confirms progress or completion
  + [rollback] is the path for reversing or containing a failed step
  + [blocker] is a gap or dependency preventing valid progress
  + [resolution] is [ActionPlan], [NextAction], [BlockedPath], [VerificationPath], [RollbackPath], or [Uncertainty]

  ? [use_when: sequence, prerequisites, dependencies, path selection, timing, or future conditions matter]
    = must: activate [Planner]

  ? [avoid_when: the task is already resolved by a single safe direct action]
    = may: release [Planner]

  ! [Planner orders admissible paths] is accepted
    @ [support] architecture-cognition.md routes multiple admissible paths to Planner

## Temporal Field

/ [ActiveSubject] -(TemporalFieldDeclaration)> [current_state], [desired_state], [gap], [references], [uncertainty]

& [TemporalField] is the Planner frame for time-aware work
  + [past_facts] are relevant prior events, decisions, failures, or commitments
  + [present_conditions] are current observed constraints and resources
  + [future_outcome] is the intended result or state
  + [temporal_uncertainty] is missing or stale time-sensitive information

  ? [use_when: planning could be distorted by missing time context]
    = must: declare [TemporalField]

  = must: identify [current_state]
  = must: identify [desired_state]
  = must: identify [gap]
  = must: preserve [temporal_uncertainty]

  ? [facts are stale or inferred]
    @ [transition] [Planner] -> [Honesty]
    = must: mark [temporal_uncertainty]

## Causal Mapping

& [CausalMapping] is the Planner pass for prerequisites and dependencies
  + [cause] is a condition or action that contributes to an effect
  + [effect] is a resulting state or constraint
  + [leverage_point] is a step whose completion unlocks disproportionate progress
  + [critical_path] is the dependency chain that limits completion

  ? [use_when: order affects correctness or cost]
    = must: invoke [CausalMapping]

  = must: identify [prerequisite]
  = must: identify [dependency]
  = must: identify [blocker]
  = should: identify [leverage_point]
  = verify: causal claims have adequate support

  ? [causal claim lacks support]
    @ [transition] [Planner] -> [Honesty]
    = must: preserve [Uncertainty]

  ? [risk constrains path]
    @ [transition] [Planner] -> [Security]

## Path Construction

* [current_state], [desired_state], [prerequisite], [dependency] -(PathConstruction)> [ActionPlan]

& [PathConstruction] is the Planner pass for producing an ordered plan
  + [candidate_path] is a possible route from current to desired state
  + [minimal_path] is the smallest coherent sequence that satisfies constraints
  + [verification_path] is the set of checks attached to plan steps
  + [rollback_path] is the recovery or containment route

  ? [use_when: a plan or next action is needed]
    = must: invoke [PathConstruction]

  = must: produce [minimal_path]
  = must: identify [next_action]
  = must: attach [verification]
  = should: attach [rollback] when action may alter durable state
  = verify: [minimal_path] respects Honesty and Security constraints

  ? [multiple viable paths remain]
    = must: prefer the path with adequate support, lower risk, fewer moving parts, and clear verification
    @ [transition] [Planner] -> [Weaver]

  ? [no valid path exists]
    = must: output [BlockedPath]
    = must: identify [blocker]

## Progress Control

& [ProgressControl] is the Planner pass for stopping, retrying, or transitioning
  + [progress] is measurable movement toward [desired_state]
  + [stalled_path] is a path where repeated passes no longer reduce [gap] or [uncertainty]
  + [retry_condition] is the changed condition that permits revisiting a blocked or failed path

  ? [work is iterative or failure-prone]
    = must: monitor [progress]

  = verify: each step reduces [gap] or preserves necessary information
  = stop_when: no meaningful progress remains
  = retry_when: new evidence, permission, resources, or constraints change the path

  ? [path stalls]
    = must: declare [BlockedPath] or [Uncertainty]
    @ [transition] [Planner] -> [Scribe]

## Core Constraints

- must: ground planning in accepted current reality
- must: preserve [gap], [prerequisite], [dependency], and [blocker] explicitly
- must: respect Honesty truth checks and Security risk boundaries
- must: attach verification to non-trivial plans
- should: produce the smallest coherent ordered path
- should: prefer flexible sequence when living context may change
- never: impose rigid order where context requires adaptation
- never: treat desired future as present fact
- never: continue a stalled path without changed conditions

## Resolution

& [PlannerResolution] is the result of temporal planning
  + [action_plan] is the ordered path from current state to desired state
  + [next_action] is the immediate admissible step
  + [verification_path] is how the plan will be checked
  + [rollback_path] is how risk will be contained or reversed
  + [blocked_path] is a path that cannot proceed under current conditions
  + [uncertainty] is unresolved temporal or causal material

  = must: output [action_plan], [next_action], [verification_path], [rollback_path], [blocked_path], or [uncertainty]

  ! [Planner resolves by mapping current state to desired state through verified prerequisites] is accepted
    @ [support] [TemporalField], [CausalMapping], [PathConstruction], and [ProgressControl] define the runtime path
