& [GenieIRCPlatform] is the bounded multiplayer chat-and-emulation coordination platform that combines IRC channels, persistent conversation memory, AI channel operators, BizHawk launch orchestration, ROM-defined lobbies, gameplay mod control, and multi-PC session coordination
  + [platform_subject] is the combined system formed by IRC chat, channel memory, Genie operator logic, BizHawk orchestration, and multiplayer session management
  + [resolution] is [ChannelService], [GenieOperator], [EmulatorOrchestrator], [SessionLobby], [ModControl], [PlayerCoordination], [AuditRecord], or [Uncertainty]

  ? [use_when: users gather in channels to coordinate emulator-backed game sessions with chat-driven mods and AI assistance]
    = must: activate [GenieIRCPlatform]

## Top-Level Decomposition

/ [GenieIRCPlatform] -(Delineation)> [GenieIRCServer], [GenieOperatorSystem], [GenieHawkOrchestrator], [SessionLobbySystem], [ModControlSystem], [AuditAndSafety], [Uncertainty]

& [GenieIRCServer] is the bounded IRC-compatible communication and channel memory service
  + [channel] is the main unit of conversation, metadata, membership, and game-session association
  + [message_log] is the persistent record of channel conversation and system events
  + [replay_window] is the bounded chunk of prior channel conversation retrievable on join or request
  + [channel_topic] is the visible short-form channel description
  + [channel_manifest] is structured metadata attached to the channel beyond the ordinary IRC topic
  + [join_context] is the summarized or chunked replay shown to a newly joined participant
  + [operator] is the privileged identity with channel governance authority
  + [irc_compatibility] is the degree to which standard IRC clients can interoperate with the service

  ? [use_when: conversation, lobby presence, replay, or channel-defined game context is needed]
    = must: preserve IRC-like semantics for channels, nicks, joins, parts, and topics
    = must: preserve [message_log]
    = must: support bounded [replay_window]
    = should: allow standard IRC clients to participate even if advanced features require extensions

& [GenieOperatorSystem] is the bounded AI operator layer present in each configured channel
  + [genie] is the AI agent assigned as channel operator and orchestration authority
  + [genie_role] is moderation, summarization, emulator launch control, lobby coordination, and game-state assistance
  + [command_surface] is the set of chat commands or natural-language requests the Genie can interpret
  + [operator_policy] is the authority boundary for the Genie inside the channel
  + [tool_permissions] is the set of allowed actions the Genie may trigger outside chat

  ? [use_when: a channel needs an active AI operator]
    = must: assign one [genie] per active game channel
    = must: preserve visible operator identity
    = must: preserve explicit [tool_permissions]
    = must: distinguish Genie speech, summaries, commands, and system notices

& [GenieHawkOrchestrator] is the bounded emulator orchestration service that launches BizHawk, loads ROMs, configures session state, and coordinates emulator-backed gameplay
  + [rom] is the game image associated with the channel or session
  + [bizhawk_instance] is a launched emulator runtime controlled by the system
  + [launch_profile] is the declared runtime configuration for a given ROM and session
  + [mod_profile] is the declared set of gameplay modifications, patches, scripts, or runtime behaviors for the session
  + [session_state] is the current emulator session lifecycle state
  + [host_node] is the machine acting as primary session authority
  + [client_node] is any participating machine joining the session
  + [input_bridge] is the system by which player or AI control reaches the emulator
  + [state_sync] is the method used to keep participating nodes aligned

  ? [use_when: emulator-backed play must be launched, modified, or coordinated]
    = must: preserve explicit launch configuration
    = must: preserve ROM/session association
    = must: preserve auditable mod and patch application
    = should: separate emulator control from IRC transport concerns

& [SessionLobbySystem] is the bounded multiplayer coordination layer through which players gather, declare readiness, and enter a shared game session
  + [lobby] is the channel-level pre-game and in-game coordination surface
  + [player] is a human participant mapped to nick, client, and session role
  + [spectator] is a participant without active gameplay authority
  + [ready_state] is whether a participant is prepared to launch or continue the session
  + [session_roster] is the active set of players, AI participants, and observers
  + [seat_map] is the mapping from player identities to game slots, controller ports, injected roles, or NPC control assignments
  + [handoff] is the reassignment of control between participants or Genie roles

  ? [use_when: multiple participants must join one emulator-backed session]
    = must: preserve [session_roster]
    = must: preserve [ready_state]
    = must: preserve [seat_map]

& [ModControlSystem] is the bounded chat-driven gameplay modification layer
  + [mod_request] is a user or Genie proposal to alter gameplay behavior, rules, participants, scripts, or runtime state
  + [mod_policy] is the set of allowed modification categories for the session
  + [runtime_patch] is an in-session change to memory, script behavior, inputs, or game logic
  + [prelaunch_patch] is a change applied before session start
  + [approval_rule] is the required channel consensus or operator approval needed before a mod activates
  + [mod_lineage] is the record of what changed, when, and why

  ? [use_when: the channel uses chat to define gameplay mods]
    = must: preserve [mod_request]
    = must: preserve [approval_rule]
    = must: preserve [mod_lineage]
    = should: distinguish reversible and irreversible changes

& [AuditAndSafety] is the bounded accountability and risk-control layer
  + [audit_record] is the durable record of joins, commands, ROM loads, mod changes, launches, control assignments, and failures
  + [permission_boundary] is the limit of what Genie and users may cause the host or clients to do
  + [rollback] is the recovery path for failed mod or launch actions
  + [unsafe_action] is any action that risks host integrity, data loss, unfair surprise, or uncontrolled runtime behavior
  + [user_visibility] is whether participants can clearly see current ROM, mods, Genie actions, and session state

  ? [use_when: actions affect machines, sessions, or participant trust]
    = must: preserve [audit_record]
    = must: preserve [permission_boundary]
    = must: preserve [user_visibility]
    = should: preserve [rollback]

## Channel Model

& [GameChannel] is the bounded IRC channel form used as a persistent game lobby and session control room
  + [channel_name] is the IRC-visible identity of the room
  + [topic] is the short visible description
  + [manifest] is the structured extended metadata describing ROM, launch profile, mod policy, and lobby behavior
  + [genie_presence] is the assigned AI operator identity
  + [log_policy] is the retention, replay, and visibility policy for messages and system events
  + [session_binding] is the relation from channel to one active or staged emulator session

  ? [use_when: a channel is intended to host emulator-backed gameplay]
    = must: preserve [manifest]
    = must: preserve [genie_presence]
    = must: preserve [session_binding]

& [ChannelManifest] is the durable structured metadata for a game channel
  + [rom_id] is the selected ROM identity
  + [rom_source] is the declared source or registry entry for the ROM
  + [core_profile] is the emulator/core settings required for this channel
  + [mod_policy] is which mod categories are allowed
  + [join_replay_policy] is how prior chat is replayed to new entrants
  + [launch_rule] is the condition under which Genie may launch the session
  + [seat_policy] is how players and injected roles are assigned
  + [agent_policy] is what in-game roles Genie may assume
  + [sync_policy] is how multi-PC synchronization is achieved

  ? [use_when: channel behavior must be machine-readable]
    = must: preserve [rom_id]
    = must: preserve [launch_rule]
    = must: preserve [mod_policy]
    = must: preserve [agent_policy]

## Chat Logging And Replay

& [ChatLogging] is the bounded persistent message and event capture system
  + [log_entry] is a message, join, part, nick change, Genie action, launch event, mod change, or system notice
  + [chunk] is a bounded slice of the prior log suitable for replay
  + [summary_chunk] is a condensed representation of prior discussion
  + [continuity_marker] is the point from which replay resumes or references current state
  + [current_conversation] is the recent live conversational context relevant to a joining user

  ? [use_when: channel continuity or auditability matters]
    = must: persist [log_entry]
    = must: support replay as [chunk] or [summary_chunk]
    = should: separate human chat from system control notices

& [JoinReplay] is the bounded replay path shown when a participant enters a channel
  + [replay_mode] is [RecentChunks], [SummaryFirst], [OnDemandFullChunks], or [StateOnly]
  + [replay_limit] is the maximum amount of history automatically surfaced
  + [request_more] is the explicit user path to ask for additional prior chunks
  + [state_snapshot] is the current ROM, mod set, roster, and session status shown alongside replay

  ? [use_when: a new user wants the current conversation context]
    = must: provide [state_snapshot]
    = must: provide bounded replay rather than flooding the user
    = should: allow progressive expansion via [request_more]

  ? [channel is very active]
    = should: prefer [SummaryFirst] followed by recent raw chunks

## Genie Operator

& [GenieOperator] is the bounded AI channel operator identity
  + [operator_state] is idle, summarizing, staging launch, running session, mediating mod requests, or controlling in-game roles
  + [speech_mode] is ordinary chat reply, structured system notice, moderation action, or launch control output
  + [authority] is the allowed action scope inside channel and orchestration systems
  + [persona] is the visible social style of the Genie
  + [memory_scope] is the bounded conversation and session memory the Genie can rely on

  ? [use_when: the AI must serve as visible operator and assistant]
    = must: distinguish channel chat from authoritative system actions
    = must: preserve explicit [authority]
    = must: preserve bounded [memory_scope]

& [GenieAuthority] is the action boundary for the Genie
  + [moderation_authority] is channel-level governance power
  + [launch_authority] is the ability to stage or start emulator sessions
  + [mod_authority] is the ability to approve, reject, or apply certain gameplay changes
  + [roster_authority] is the ability to assign seats and roles
  + [npc_authority] is the ability to control NPCs or extra characters when allowed by policy
  + [override_authority] is the ability to perform non-native or rule-breaking participant injection when explicitly enabled

  ? [use_when: a Genie action affects gameplay or participant expectations]
    = must: check channel policy before execution
    = must: emit visible system notice before and after significant actions

  - never: silently change ROM, mods, seats, or injected-role policy without visible notice

## Emulator Launch And Session Flow

& [LaunchWorkflow] is the bounded path from idle channel to live emulator session
  + [staged_launch] is a prepared but not yet started session
  + [launch_check] is validation of ROM, profile, participants, and required assets
  + [launch_commit] is the point at which Genie starts the BizHawk session
  + [failure_state] is any blocked or failed launch attempt

  ? [use_when: a session is about to start]
    = must: validate [rom]
    = must: validate [launch_profile]
    = must: validate [session_roster]
    = must: surface current [mod_profile]
    = must: preserve [failure_state] when launch cannot proceed

& [BizHawkSession] is the bounded runtime session managed by the orchestrator
  + [session_id] is the unique identity of the running session
  + [host_instance] is the primary BizHawk runtime
  + [joined_clients] are participating remote or local players
  + [runtime_mods] are active gameplay modifications
  + [control_map] is the mapping from humans and Genie roles to emulator inputs or scripted actions
  + [sync_status] is the current health of multiplayer synchronization
  + [save_state_policy] is the allowed use of state save/load operations

  ? [use_when: a game is actively running]
    = must: preserve [control_map]
    = must: preserve [sync_status]
    = must: preserve visible [runtime_mods]

## Multiplayer Coordination

& [MultiplayerJoin] is the bounded path by which multiple PCs join one session
  + [join_request] is the player request to enter the session
  + [node_capability] is the client’s emulator, version, assets, and connectivity suitability
  + [seat_assignment] is the player’s bound role in the session
  + [sync_handshake] is the compatibility and state alignment process before active participation

  ? [use_when: a client joins an active or staged session]
    = must: validate [node_capability]
    = must: perform [sync_handshake]
    = must: preserve [seat_assignment]

& [SeatInjection] is the bounded mechanism for assigning participants beyond a game’s native player model
  + [native_slot] is a player slot the game directly supports
  + [injected_slot] is a non-native role added by scripting, memory manipulation, AI control, or input virtualization
  + [npc_takeover] is Genie or user control of an ordinarily non-player-controlled character
  + [extra_player] is a participant present beyond the game’s original supported count
  + [fairness_mode] is whether the session is strict-native, experimental, cooperative-chaos, or unrestricted

  ? [use_when: the session intentionally exceeds native player support or assigns AI to normally non-player roles]
    = must: preserve explicit consent and visibility
    = must: preserve session-mode labeling
    = should: separate native support from experimental injection

  ? [session is public or casually joined]
    = should: require clearer notice before [injected_slot] or [npc_takeover] behaviors activate

## Mod Control

& [ChatDrivenMods] is the bounded system for proposing and applying changes through channel conversation
  + [proposal] is a structured or informal mod request originating in chat
  + [parsed_change] is the machine-interpreted form of the requested modification
  + [approval_state] is pending, approved, rejected, applied, reverted, or blocked
  + [scope] is prelaunch-only, runtime-safe, runtime-risky, or session-defining
  + [reversibility] is whether the change can be cleanly undone

  ? [use_when: users define mods in channel during gameplay or staging]
    = must: parse [proposal] into [parsed_change]
    = must: preserve [approval_state]
    = must: preserve [scope]
    = must: preserve [reversibility]

& [ModApprovalRules] is the bounded governance policy for activating requested changes
  + [operator_only] is Genie-only approval
  + [host_confirm] is host approval required
  + [vote_threshold] is channel consensus threshold
  + [emergency_block] is immediate refusal of unsafe or destabilizing changes

  ? [use_when: a mod request affects session behavior]
    = must: route request through one active approval rule
    = should: make the current rule visible in channel state

## In-Game Genie Participation

& [GenieGameRole] is the bounded form of Genie participation inside gameplay
  + [observer_role] is non-participating monitoring
  + [npc_driver] is control of non-player characters
  + [assistant_player] is control of an auxiliary player character
  + [rule_breaking_role] is intentionally non-native or scripted participation beyond original game rules
  + [behavior_profile] is passive, playful, competitive, helper, director, or chaos-agent
  + [control_surface] is the interface by which Genie acts through emulator control or scripting

  ? [use_when: Genie is asked to act inside the game]
    = must: preserve explicit role labeling
    = must: preserve [behavior_profile]
    = must: preserve visible notice when Genie enters or leaves active control

  ? [role is [rule_breaking_role]]
    = must: require explicit enablement from channel/session policy
    = should: mark session as experimental

## State Visibility

& [SessionStateSnapshot] is the bounded current-state summary visible to any participant
  + [active_rom] is the current game identity
  + [active_mods] is the current mod set
  + [active_roster] is the current human and Genie participants
  + [launch_state] is idle, staged, running, paused, failed, or ended
  + [recent_actions] is the small recent set of material Genie or system actions

  ? [use_when: a user joins or asks what is happening]
    = must: surface [active_rom]
    = must: surface [active_mods]
    = must: surface [active_roster]
    = must: surface [launch_state]

## Audit And Recovery

& [AuditRecord] is the durable record of meaningful system and gameplay coordination events
  + [event_type] is chat, moderation, replay, ROM bind, launch, join, seat change, mod apply, save-state action, Genie role change, or failure
  + [actor] is user, Genie, system service, or host
  + [timestamp] is event time
  + [before_state] is relevant prior state
  + [after_state] is relevant resulting state

  ? [use_when: state changes matter later]
    = must: preserve [actor]
    = must: preserve [event_type]
    = must: preserve [timestamp]

& [RecoveryPath] is the bounded rollback and failure-handling system
  + [launch_recovery] is the path after a failed start
  + [sync_recovery] is the path after multiplayer desync
  + [mod_revert] is reversal of an applied change
  + [operator_recovery] is fallback when Genie fails or disconnects

  ? [use_when: an operation materially fails]
    = must: preserve fallback behavior
    = should: restore visible consistent state

## Constraints

- never: treat unstructured channel chatter as an irreversible control command without confirmation
- never: hide the current ROM, active mods, or Genie role from participants
- never: merge ordinary chat replay with authoritative system state so completely that users cannot distinguish them
- never: let experimental injected-role features appear as native supported behavior without labeling
- prefer: channel manifest as authoritative machine-readable session definition
- prefer: bounded replay chunks plus current state snapshot rather than flooding full logs on join
- prefer: explicit role and seat visibility whenever humans and Genie both participate
- prefer: reversible mod application when runtime safety is uncertain