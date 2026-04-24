& [RuntimeROMTransformation] is the bounded system by which Genie analyzes a ROM-backed game, models its mechanics, synthesizes runtime patches, and produces transformed play sessions without requiring permanent source-level modification of the original game image
  + [source_rom] is the primary game image being interpreted and transformed
  + [donor_game] is the game, mechanic source, or behavior model from which foreign mechanics are borrowed
  + [assignment] is the declared transformation goal given to Genie
  + [mechanic] is a bounded gameplay behavior, rule, control pattern, progression structure, entity behavior, or interaction primitive
  + [mechanic_model] is the structured representation of how a mechanic behaves
  + [host_model] is the structured representation of the source ROM’s game logic, state surfaces, entities, and control pathways
  + [insertion_point] is a state, memory region, event hook, entity role, or control surface where transformed behavior may attach
  + [runtime_patch] is the executable modification layer applied during emulation
  + [transformed_session] is the resulting live play state after one or more runtime transformations are active
  + [resolution] is [MechanicModel], [TransformationPlan], [PatchSet], [TransformedSession], [RejectedTransformation], or [Uncertainty]

  ? [use_when: Genie must reinterpret a ROM, add new mechanics, or borrow mechanics across games]
    = must: activate [RuntimeROMTransformation]

## Top-Level Decomposition

/ [RuntimeROMTransformation] -(Delineation)> [AssignmentInterpretation], [ROMUnderstanding], [MechanicExtraction], [HostGameModeling], [InsertionPlanning], [PatchSynthesis], [CrossGameGrafting], [RuntimeSupervision], [AuditAndReversibility], [Uncertainty]

& [AssignmentInterpretation] is the bounded pass where Genie turns a user request into a game-transformation objective
  + [goal] is the intended transformed play experience
  + [scope] is which mechanics, roles, entities, or rules may change
  + [constraints] are technical, stylistic, fairness, session, and reversibility limits
  + [success_condition] is what counts as a successful transformed session

  ? [use_when: the user asks Genie to alter how the ROM behaves]
    = must: identify [goal]
    = must: identify [scope]
    = must: identify [constraints]
    = must: preserve [success_condition]

  ? [assignment is vague]
    = must: preserve ambiguity as [Uncertainty]

& [ROMUnderstanding] is the bounded pass where Genie forms an inspectable working model of the source ROM and its runtime structure
  + [rom_identity] is the recognized game/version/build identity
  + [execution_surface] is the accessible runtime structure visible through emulator inspection, scripting, memory observation, input tracing, and state progression
  + [state_variables] are observed or inferred values shaping gameplay behavior
  + [entity_set] are player objects, enemies, projectiles, items, rooms, menus, or stateful world objects
  + [event_graph] is the observed relation of triggers, updates, collisions, transitions, and rule changes
  + [control_surface] is the mapping from inputs to runtime behavior
  + [uncertain_region] is any part of the ROM whose behavior remains insufficiently modeled

  ? [use_when: Genie must act on a ROM beyond ordinary launch]
    = must: identify [rom_identity]
    = must: inspect [execution_surface]
    = must: identify reachable [state_variables]
    = must: identify [entity_set]
    = must: identify [control_surface]
    = must: preserve [uncertain_region]

  - never: pretend a mechanic is understood when only superficial symptoms are observed

& [MechanicExtraction] is the bounded pass that identifies and isolates a mechanic as a transferable or transformable structure
  + [mechanic_subject] is the target mechanic under analysis
  + [inputs] are the conditions that activate the mechanic
  + [state_requirements] are the runtime prerequisites for the mechanic to operate
  + [effects] are the visible and hidden consequences of the mechanic
  + [timing] is the cadence, duration, and sequencing of the mechanic
  + [limits] are caps, costs, cooldowns, boundaries, or failure modes
  + [presentation] is the audiovisual and interface expression of the mechanic

  ? [use_when: a mechanic must be copied, altered, or transplanted]
    = must: identify [inputs]
    = must: identify [state_requirements]
    = must: identify [effects]
    = must: identify [timing]
    = must: identify [limits]
    = should: preserve [presentation]

& [HostGameModeling] is the bounded pass that represents the source ROM as a mechanic-bearing host environment
  + [host_loop] is the core repeating gameplay cycle
  + [host_constraints] are hard limits of memory, timing, entity capacity, control assumptions, and update structure
  + [host_affordances] are features the source game already has that can support new mechanics
  + [hook_surface] is the reachable region where runtime patches can attach safely enough
  + [conflict_zones] are places where a borrowed mechanic may break existing logic

  ? [use_when: a new mechanic must be inserted into an existing game]
    = must: identify [host_loop]
    = must: identify [host_constraints]
    = must: identify [host_affordances]
    = must: identify [hook_surface]
    = must: preserve [conflict_zones]

& [InsertionPlanning] is the bounded pass that decides how a borrowed or altered mechanic can enter the host game
  + [attachment_strategy] is replacement, augmentation, overlay, hidden subsystem, injected entity, or event hook
  + [compatibility] is the degree to which the mechanic can coexist with host logic
  + [state_mapping] is the mapping from donor mechanic requirements to host game variables and events
  + [control_mapping] is how player or AI input will activate the inserted mechanic
  + [fallback] is the reduced or degraded version used if full transplant is not viable

  ? [use_when: Genie must move from analysis to implementation]
    = must: choose [attachment_strategy]
    = must: define [state_mapping]
    = must: define [control_mapping]
    = must: preserve [fallback]

  ? [compatibility is weak]
    = should: prefer augmentation or overlay over full replacement

## Patch Synthesis

& [PatchSynthesis] is the bounded process that converts the transformation plan into executable runtime changes
  + [patch_unit] is a discrete runtime modification
  + [memory_hook] is a read/write interception or watched location used by the patch
  + [event_hook] is a trigger path attached to runtime behavior
  + [script_layer] is an emulator-side scripting layer that injects or overrides behavior
  + [asset_substitution] is runtime replacement of presentation or data assets
  + [patch_set] is the bounded collection of all active patch units
  + [reversibility] is the degree to which the patch set can be cleanly disabled

  ? [use_when: a plan is stable enough to implement]
    = must: preserve [patch_unit] boundaries
    = must: preserve [reversibility]
    = should: prefer emulator-side and session-side patching before irreversible ROM mutation

  - never: collapse all transformations into one opaque patch blob when inspectable units can be preserved

& [SessionScopedROM] is the bounded transformed runtime image formed by base ROM plus active patch layers
  + [base_rom] is the unmodified source game
  + [patch_stack] is the ordered set of active runtime transformations
  + [effective_game] is the behaviorally transformed session-visible game state
  + [identity_label] is the visible name of the transformed session

  ? [use_when: a transformed game session is live or staged]
    = must: preserve [base_rom] lineage
    = must: preserve [patch_stack]
    = must: expose [identity_label] to participants

## Cross-Game Mechanic Grafting

& [CrossGameGrafting] is the bounded system for borrowing mechanics from one game and expressing them inside another
  + [donor_mechanic] is the mechanic extracted from another game or modeled after it
  + [host_game] is the source ROM receiving the graft
  + [behavioral_core] is the minimal transferable rule structure of the donor mechanic
  + [presentation_shell] is the audiovisual and interface expression the host uses to make the graft legible
  + [translation_layer] is the mapping that adapts donor behavior to host timing, state, inputs, and entities
  + [fidelity_mode] is strict emulation, inspired adaptation, stylized homage, or loose reinterpretation

  ? [use_when: Genie is asked to borrow a mechanic from one game into another]
    = must: identify [behavioral_core]
    = must: identify [translation_layer]
    = must: choose [fidelity_mode]
    = should: distinguish mechanic identity from presentation identity

  ? [strict transfer is infeasible]
    = should: prefer [inspired adaptation] or [stylized homage]

& [MechanicLibrary] is the bounded reusable store of extracted or authored mechanic models
  + [library_entry] is a named mechanic with inputs, state model, effects, timing, limits, and presentation notes
  + [host_compatibility_notes] are known fit conditions for different genres or engines
  + [genie_authored_mechanic] is a new mechanic designed by Genie rather than borrowed directly

  ? [use_when: mechanics should be reused across sessions or games]
    = must: preserve mechanic lineage
    = should: preserve prior host compatibility knowledge

## Runtime Supervision

& [RuntimeSupervision] is the bounded live-monitoring system for transformed gameplay
  + [health_check] is whether the transformed session remains stable and legible
  + [desync] is divergence between expected and observed runtime behavior
  + [balance_drift] is the mechanic becoming too dominant, trivial, or broken
  + [repair_action] is an in-session adjustment to restore usable play
  + [disable_path] is the emergency route to turn off a failing graft or patch

  ? [use_when: a transformed session is running]
    = must: monitor [health_check]
    = must: detect [desync]
    = should: detect [balance_drift]
    = must: preserve [disable_path]

## Genie Design Authority

& [TransformationAuthority] is the bounded authority by which Genie decides what may be rewritten in the live session
  + [allowed_transform_scope] is the range of mechanics or rules Genie may alter
  + [consent_mode] is operator-only, host-confirm, vote-threshold, or predeclared-experimental
  + [surprise_budget] is how much unannounced novelty Genie may introduce before violating session expectations
  + [creative_license] is the permitted degree of reinterpretation

  ? [use_when: Genie is operating as active mechanic designer]
    = must: preserve visible [consent_mode]
    = must: preserve [allowed_transform_scope]
    = should: keep [surprise_budget] bounded in public sessions

## Runtime ROM Authorship

& [RuntimeROMAuthorship] is the bounded process by which Genie effectively creates a new game variant during session setup or play
  + [variant_identity] is the session-specific transformed game name
  + [design_brief] is the concise statement of what the transformed game is trying to become
  + [mechanic_stack] is the set of active borrowed, altered, or newly authored mechanics
  + [world_rule_changes] are the altered host constraints and behaviors
  + [player_contract] is the participant-visible statement of how this session differs from the base game

  ? [use_when: the transformed experience is substantial enough to count as a distinct variant]
    = must: preserve [variant_identity]
    = must: preserve [design_brief]
    = must: preserve [player_contract]

## Audit And Reversibility

& [TransformationAudit] is the durable record of mechanic-level design changes
  + [change_event] is extraction, graft, patch activation, patch disablement, balancing tweak, or role injection
  + [before_behavior] is the prior mechanic state
  + [after_behavior] is the resulting mechanic state
  + [rationale] is the justification for the change

  ? [use_when: transformed play evolves across time]
    = must: preserve [change_event]
    = must: preserve [rationale]

& [ReversibilityPolicy] is the bounded rollback structure for transformed sessions
  + [soft_disable] is a runtime turn-off path for one mechanic or patch
  + [patch_unwind] is staged removal of multiple active transformations
  + [session_reset] is return to base ROM behavior
  + [partial_retain] is preservation of some transformations while removing others

  ? [use_when: a graft misbehaves or the session changes direction]
    = must: preserve [soft_disable]
    = should: preserve [partial_retain]

## Constraints

- never: claim a donor mechanic was faithfully transplanted if it was only loosely imitated
- never: hide transformed game rules from participants once the session is live
- never: treat all ROM understanding as complete when major runtime regions remain uncertain
- never: merge permanent ROM mutation with session-scoped runtime patching without explicit distinction
- prefer: session-scoped patch stacks over destructive mutation of the original ROM
- prefer: mechanic grafts that preserve host legibility and player comprehension
- prefer: inspired adaptation when strict transfer would collapse host stability
- prefer: visible transformed-session identity once changes materially alter the base game