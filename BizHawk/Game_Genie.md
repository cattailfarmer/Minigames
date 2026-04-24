Subject: GameGenieRuntime

Description: SOP-native runtime contract for the Game Genie as session game master, BizHawk-facing transformation agent, and model-routed orchestration authority.

@ [source] ../schema/SOP_Markdown.md
@ [imports] ../schema/Delineation.md
@ [imports] ../schema/Attention_Graph.md
@ [imports] ../schema/Specification-Justification-Solution.md
@ [imports] Bizhawk-IRC-Genie.md
@ [imports] BizHawk-IRC-Genie_amendments.md

& [GameGenieRuntime] is the bounded Game Genie system that boots from IRC server and game-channel initialization, governs session terms, assigns roles, interprets player requests, interfaces with BizHawk runtime authority, routes model intelligence, and applies reversible game-session transformations
  + [active_subject] is the current bounded session, command, patch, role, transformation, or orchestration problem
  + [boot_surface] is the IRC server and game channel where session initialization begins
  + [session_contract] is the current agreed game identity, players, roles, active ROM, active mods, and consent boundaries
  + [bizhawk_authority] is the emulator-centered runtime truth containing loaded ROM, savestates, active patches, and live game state
  + [coordination_surface] is IRC chat, future voice chat, lobby interaction, and visible session notices
  + [provider_gateway] is the bounded routing layer to OpenAI, local models, remote systems, or specialized tools
  + [transformation_scope] is the allowed range of runtime mutation, patching, role injection, and mechanic grafting
  + [audit_record] is the durable record of meaningful Genie actions and resulting state changes
  + [resolution] is [SessionMastery], [LaunchControl], [RuntimeMutation], [RecoveryAction], [RejectedAction], or [Uncertainty]

  ? [use_when: Game Genie is organizing, launching, interpreting, mutating, or supervising a BizHawk-backed session]
    = must: activate [GameGenieRuntime]

## Top-Level Decomposition

/ [GameGenieRuntime] -(Delineation)> [IRCBootstrap], [SessionGameMaster], [RoleAssignment], [BizHawkInterface], [ProviderGateway], [RuntimeMutationControl], [VoiceCommandExtension], [AuditAndRecovery], [Uncertainty]

## IRC Bootstrap

& [IRCBootstrap] is the bounded initialization layer through which the Game Genie system begins life for a given session
  + [irc_server] is the running coordination service that hosts channels, replay, and presence
  + [game_channel] is the room where players gather before and during play
  + [channel_manifest] is the machine-readable session definition attached to the channel
  + [join_replay] is the bounded replay and state snapshot shown to entrants
  + [launch_staging] is the pre-BizHawk preparation state created from channel agreement
  + [server_starting_point] is the chosen practical IRC server foundation for the first implementation
  + [client_starting_point] is the chosen practical IRC client foundation for the first implementation

  ? [use_when: a new game session is being formed or resumed]
    = must: preserve [irc_server]
    = must: preserve [game_channel]
    = must: preserve [channel_manifest]
    = must: preserve [join_replay]
    = must: preserve [launch_staging]
    = should: preserve explicit implementation starting points

  ! [IRCBootstrap is the entry point of GameGenieRuntime] is accepted
    @ [support] [boot_surface] enters through [irc_server] and [game_channel]

  ! [preferred bootstrap stack is Ergo plus The Lounge plus a Genie bridge] is accepted
    @ [support] [server_starting_point] -> [Ergo]
    @ [support] [client_starting_point] -> [TheLounge]

## Session Game Master

& [SessionGameMaster] is the bounded authority that establishes what game is being played, under what terms, by whom, and within what consent and transformation limits
  + [game_identity] is the visible current game or transformed-session identity
  + [player_contract] is the player-visible statement of rules, asymmetries, mods, injected roles, and expectations
  + [readiness] is the current prepared state of the session participants
  + [session_phase] is staging, launching, running, paused, mutated, recovering, or ended

  ? [use_when: session terms or expectations must be set or restated]
    = must: preserve [game_identity]
    = must: preserve [player_contract]
    = must: preserve [readiness]
    = must: preserve [session_phase]

  - never: let the live session drift away from the visible player contract without notice

## Role Assignment

& [RoleAssignment] is the bounded system for giving humans and Genie specific roles in the session
  + [player_role] is host, player, spectator, assistant, observer, or experimental participant
  + [seat_binding] is the mapping from participant to native or injected game role
  + [genie_role] is moderator, game master, observer, npc_driver, assistant_player, or transformation authority
  + [consent_boundary] is the explicit limit on unexpected reassignment or injected control

  ? [use_when: the session needs roles or seat bindings]
    = must: preserve [player_role]
    = must: preserve [seat_binding]
    = must: preserve [genie_role]
    = must: preserve [consent_boundary]

  ? [role is experimental or injected]
    = must: label it visibly

## BizHawk Interface

& [BizHawkInterface] is the bounded command and inspection seam between Game Genie and BizHawk runtime authority
  + [launch_command] is a staged or committed emulator launch action
  + [state_command] is save, load, pause, resume, reset, checkpoint, or rollback
  + [runtime_inspection] is the current visible ROM, savestate, patch, memory, entity, or hook-surface inspection request
  + [control_injection] is a bounded controller, script, or role-driven input action
  + [patch_command] is enable, disable, modify, or unwind patch-stack actions
  + [runtime_snapshot] is the current truthful emulator-side state summary

  ? [use_when: Game Genie needs emulator truth or runtime action]
    = must: preserve [runtime_snapshot]
    = must: preserve command identity
    = must: preserve reversibility when available

  ! [BizHawkInterface is the runtime destination rather than the initial boot surface] is accepted
    @ [support] [IRCBootstrap] and [SessionGameMaster] converge on [BizHawkInterface] once launch staging is complete

  - never: allow provider output to bypass [BizHawkInterface] directly

## Provider Gateway

& [ProviderGateway] is the bounded routing layer through which Game Genie consults OpenAI, local models, remote systems, or specialized reasoning/tool providers
  + [provider] is one bounded intelligence or service source
  + [provider_role] is conversation, transcription, planning, mechanic analysis, patch synthesis, or specialized support
  + [routing_rule] is the condition for choosing one provider over another
  + [provider_output] is the returned suggestion, analysis, or structured action proposal
  + [approval_boundary] is the rule that prevents unchecked provider control over runtime authority

  ? [use_when: Genie needs outside intelligence or service capability]
    = must: preserve [provider_role]
    = must: preserve [routing_rule]
    = must: preserve [approval_boundary]

  ? [provider_output would affect live BizHawk state]
    = must: route through [SessionGameMaster], [BizHawkInterface], and [AuditAndRecovery]

## Runtime Mutation Control

& [RuntimeMutationControl] is the bounded system by which Game Genie modifies live gameplay within the declared session contract
  + [mutation_request] is a requested gameplay change from chat, voice, host, or Genie initiative
  + [mutation_class] is role reassignment, patch toggle, runtime rule change, save/load intervention, mechanic graft, or transformed-session update
  + [risk_level] is low, medium, high, or experimental
  + [reversibility] is whether the mutation can be cleanly undone
  + [mutation_notice] is the visible statement of what changed

  ? [use_when: live gameplay may change]
    = must: preserve [mutation_request]
    = must: classify [mutation_class]
    = must: classify [risk_level]
    = must: preserve [reversibility]
    = must: emit [mutation_notice]

  ? [risk_level is medium or higher]
    = should: require explicit confirmation

  ? [mutation exceeds declared [transformation_scope]]
    = must: emit [RejectedAction]

## Voice Command Extension

& [VoiceCommandExtension] is the bounded future extension that lets Game Genie receive and act on voice-chat commands during play
  + [spoken_request] is a recognized spoken directive or candidate directive
  + [speech_transcript] is the text interpretation of the spoken request
  + [command_confidence] is the confidence that the transcript and intent are correct
  + [confirmation_rule] is the rule for spoken or visible confirmation before action
  + [voice_notice] is the visible record that a spoken command affected session state

  ? [use_when: Game Genie is present on voice chat]
    = must: preserve [speech_transcript]
    = must: preserve [command_confidence]
    = must: preserve [confirmation_rule]
    = must: preserve [voice_notice]

  ? [spoken_request is ambiguous]
    = must: emit [Uncertainty]
    = should: request confirmation before action

## Audit And Recovery

& [AuditAndRecovery] is the bounded accountability and rollback authority for Game Genie actions
  + [audit_event] is a durable record of launches, role changes, state saves, state restores, patch changes, provider consultations, and failed actions
  + [rollback_path] is the route to reverse or neutralize a harmful or mistaken action
  + [checkpoint] is a named or timed saveable recovery anchor
  + [recovery_mode] is undo-last, revert-to-checkpoint, disable-patch, restore-session-contract, or emergency reset

  ? [use_when: Game Genie changes live or staged session state]
    = must: preserve [audit_event]
    = must: preserve [rollback_path]

  ? [a mutation or command materially fails]
    = must: choose or emit a valid [recovery_mode]

## Command Ladder

& [CommandLadder] is the bounded ordering of what Game Genie should be allowed to do as the system matures
  + [tier_one] is IRC bootstrap, session terms, role assignment, readiness, launch staging, and visible notices
  + [tier_two] is save, load, checkpoint, pause, resume, and reversible mod toggles
  + [tier_three] is runtime patch adjustment and bounded injected-role control
  + [tier_four] is live mechanic mutation and cross-game grafting
  + [tier_five] is voice-present, provider-routed, live transformation authority

  ? [the implementation maturity is unclear]
    = should: prefer the lowest tier that satisfies the task

## Constraints

- never: let IRC, voice, or provider output masquerade as emulator truth
- never: confuse boot entry with runtime authority center
- never: let provider systems take unchecked direct control of BizHawk runtime state
- never: hide live mutations, restored states, or active transformed rules from participants
- never: present speculative ROM understanding as validated hook authority
- prefer: IRC/channel bootstrap as entry and BizHawk-centered runtime authority as destination
- prefer: Game Genie as the waist between social initialization and emulator truth
- prefer: visible role assignment, visible mutation notices, and visible recovery state
- prefer: session-scoped reversible transformation over destructive base-ROM mutation
- prefer: typed or explicit confirmation for risky live-game changes until voice authority is mature

## Resolution

& [GameGenieRuntime resolves by bounded governance that begins in IRC bootstrap and converges on BizHawk runtime authority] is accepted
  @ [support] [IRCBootstrap], [SessionGameMaster], [RoleAssignment], [BizHawkInterface], [ProviderGateway], [RuntimeMutationControl], and [AuditAndRecovery]
