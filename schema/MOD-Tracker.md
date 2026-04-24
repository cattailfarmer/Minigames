& [SOPPyTracker] is the bounded module-tracker composition, sequencing, instrument control, pattern playback, and music authoring system for tracker-style game music, sample-based arrangement, effect-command sequencing, and module import/export with optional synthesis tie-ins to [SOPPyWave]
  + [music_subject] is a tracker module, song, pattern set, instrument bank, sample bank, playback session, arrangement, or composition artifact under authorship or playback
  + [intent] is the declared musical role, mood, energy, pacing, technical target, and stylistic constraint of the composition or playback system
  + [module_format] is MOD, S3M, XM, IT, internal tracker format, or translated hybrid representation
  + [tracker_state] is the currently loaded module, playback cursor, tempo state, active voices, and effect-command context
  + [timeline] is the ordered song structure formed by positions, patterns, rows, ticks, and time-derived playback
  + [instrument_bank] is the bounded collection of instruments available to the module
  + [sample_bank] is the bounded collection of sampled or generated wave assets available for note triggering
  + [pattern_set] is the bounded collection of note/effect grids used by the composition
  + [channel_set] is the bounded set of simultaneous tracker channels or voices
  + [render_mode] is [TrackerPlayback], [OfflineRender], [PatternEdit], [LivePatternJam], [ImportTranslate], [ExportModule], or [AnalysisCoupledComposition]
  + [artifact_set] is [TrackerModule], [PatternArtifact], [InstrumentPreset], [SampleArtifact], [SongRender], [PlaybackState], [ArrangementPlan], [VariationSet], [TranslationReport], and [ImprovementPlan]
  + [resolution] is [PlayableModule], [PatternSequence], [InstrumentBank], [RenderedSong], [AcceptedComposition], [RejectedRender], [ImprovementPlan], or [Uncertainty]

  ? [use_when: tracker-style game music must be composed, edited, played back, translated, or tied to generated sample content]
    = must: activate [SOPPyTracker]

  ? [avoid_when: only raw waveform generation is required and no pattern sequencing or note/event logic is needed]
    @ [transition] [SOPPyTracker] -> [SOPPyWave]
    = may: delegate sound creation downward

  ! [SOPPyTracker is the sequencing and composition layer above sample generation] is accepted

## Core Contract

& [SOPPyTrackerContract] is the minimal executable shape of a valid tracker composition or playback request
  + [input] is a module file, pattern draft, instrument/sample bank, live edit stream, or song design brief entering the system
  + [constraints] are the declared limits on format, channel count, memory, sample size, platform target, timing model, and stylistic boundaries
  + [target] is the intended playable or renderable musical result
  + [verification] is the playback, render, or structural check that confirms the module behaves as intended

  = must: identify [input]
  = must: identify [target]
  = must: identify [render_mode]
  = must: preserve [constraints]
  = must: emit [verification] path or [Uncertainty]

  ? [input is absent and original composition is intended]
    = must: construct the song from [pattern_set], [instrument_bank], and [sample_bank]

  ? [target is unclear]
    = must: emit [Uncertainty]

## Intent Declaration

/ [music_subject] -(IntentDeclaration)> [MusicalRole], [TrackerConstraints], [References], [Uncertainty]

& [IntentDeclaration] is the pass that turns a vague music goal into a bounded tracker composition target
  + [musical_role] is title theme, battle music, menu loop, exploration bed, alert cue, victory jingle, ambient loop, or hybrid role
  + [tracker_constraints] are format, channel count, loop length, memory budget, sample resolution, compatibility target, and complexity limits
  + [references] are genre anchors, prior songs, soundtrack precedents, instrument references, or user-described emotional targets
  + [uncertainty] is unresolved musical or technical ambiguity

  = must: identify [musical_role]
  = must: identify [tracker_constraints]
  = should: preserve [references]
  = must: preserve [uncertainty]

  ? [intent is emotional but not structurally specific]
    = should: infer candidate tempo, density, and harmonic mood
    = must: mark them as [assumption]

## Module Model

& [TrackerModule] is the bounded durable music artifact formed by order list, patterns, instruments, samples, and playback settings
  + [module_name] is the durable title identity of the composition
  + [order_list] is the ordered sequence of pattern references making up the song form
  + [pattern_count] is the number of addressable patterns
  + [restart_position] is the playback return location after end
  + [global_tempo] is the module’s timing baseline
  + [global_speed] is the tracker tick speed or row advancement basis
  + [master_volume] is the module-wide output scaling
  + [format_capabilities] are the playable features supported by the chosen module type

  ? [use_when: a complete song artifact is being authored or loaded]
    = must: preserve [order_list]
    = must: preserve [pattern_count]
    = must: preserve format-specific [format_capabilities]

## Format Families

& [MODFamily] is the bounded set of classic pattern-tracker forms and their capability models
  + [mod] is the classic ProTracker-style sample module with relatively constrained channels and effects
  + [s3m] is the Scream Tracker module family with richer channel logic and effect behavior
  + [xm] is the FastTracker extended module family with more advanced instruments and envelopes
  + [it] is the Impulse Tracker family with more advanced effect and instrument expression
  + [internal_hybrid] is the system’s native representation that may exceed any one target format while remaining translatable

  ? [use_when: compatibility and feature support matter]
    = must: preserve explicit distinction between source representation and export target

  - never: claim exact fidelity to a target format when the internal representation exceeds or alters target behavior

## Song Form

& [SongForm] is the bounded macro-structure of a tracker composition
  + [intro] is the opening region
  + [loop_body] is the repeating central gameplay section
  + [variation_region] is a changed pass preserving main identity
  + [breakdown] is reduced-intensity contrast
  + [climax] is peak-intensity region
  + [outro] is the ending or loop handoff
  + [cue_variant] is a short derived variation for game-state changes

  ? [use_when: a module needs macro-shape beyond isolated patterns]
    = must: preserve intended loop logic
    = should: preserve contrast between regions

## Order List

& [OrderList] is the bounded ordered sequence of pattern references controlling song traversal
  + [position] is one entry in the play order
  + [pattern_ref] is the pattern played at a given position
  + [jump] is explicit movement to another order position
  + [break] is a forced move to a new pattern row or position
  + [loop_rule] is the intended repeat behavior of the module

  ? [use_when: arranging patterns into a song]
    = must: preserve [position] identity
    = must: preserve [loop_rule]

## Pattern System

& [PatternSet] is the bounded collection of tracker note/effect grids
  + [pattern] is a rectangular note/effect event matrix
  + [row] is a vertical time slice across all channels
  + [tick] is a finer-grained playback subdivision under a row
  + [cell] is one channel’s event slot at one row
  + [row_count] is the pattern length in rows

  ? [use_when: tracker composition or playback occurs]
    = must: preserve [row_count]
    = must: preserve row/channel addressing

& [PatternAuthoring] is the bounded process of writing note, instrument, volume, and effect data into patterns
  + [note_event] is a pitch-bearing trigger
  + [instrument_event] is an instrument selection or change
  + [volume_event] is a direct volume column or equivalent control
  + [effect_event] is a tracker command affecting playback behavior
  + [empty_cell] is deliberate silence or no-op

  ? [use_when: patterns are being edited or generated]
    = must: preserve explicit distinction between [note_event], [instrument_event], and [effect_event]
    = should: preserve sparse efficiency rather than filling cells with redundant state

## Channel Model

& [ChannelSet] is the bounded simultaneous voice structure of the tracker
  + [channel] is one independent event lane in the pattern grid
  + [channel_role] is drums, bass, lead, harmony, texture, fx, noise, or utility role
  + [pan_position] is left-right spatial placement
  + [default_volume] is the baseline channel loudness
  + [mute_state] is enabled or silenced playback
  + [priority] is the relative claim on limited voice resources

  ? [use_when: arranging polyphony or tracker playback routing]
    = must: preserve [channel_role]
    = should: preserve stable role identity across the song

## Note Model

& [TrackerNote] is the bounded representation of note-level musical intent inside the grid
  + [pitch] is the semitone target or note symbol
  + [octave] is the register band
  + [note_off] is release or stop instruction
  + [note_cut] is immediate silence
  + [note_delay] is delayed activation within the row/tick structure
  + [retrigger] is repeated triggering under one row region

  ? [use_when: melodic or percussive events are authored]
    = must: preserve note identity separately from sample identity

## Instrument System

& [InstrumentBank] is the bounded collection of playable tracker instruments
  + [instrument] is the playable unit combining note mapping, sample references, envelopes, and playback behavior
  + [instrument_id] is the addressable identity
  + [note_map] is the mapping from pitch regions to sample choices
  + [volume_envelope] is the shaped level response through time
  + [pan_envelope] is the stereo position behavior through time
  + [pitch_envelope] is pitch movement through time
  + [new_note_action] is how overlapping notes on one instrument behave
  + [fadeout] is post-note amplitude decline behavior

  ? [use_when: sample playback must behave as an instrument rather than only a raw sample trigger]
    = must: preserve [note_map]
    = should: preserve envelope and note-action behavior

## Sample Bank

& [SampleBank] is the bounded collection of waveform assets available to instruments or direct note triggering
  + [sample] is a discrete waveform asset
  + [sample_id] is the addressable identity
  + [root_note] is the nominal pitch anchor
  + [fine_tune] is pitch adjustment
  + [loop_start] is the repeat entry point
  + [loop_end] is the repeat exit point
  + [loop_mode] is no loop, forward loop, ping-pong loop, or bounded hybrid behavior
  + [sample_rate] is the native playback rate reference
  + [bit_depth] is the stored waveform resolution
  + [trim] is silence removal or bounded sample shortening
  + [normalization] is output level alignment

  ? [use_when: instrument playback or sample authoring occurs]
    = must: preserve [root_note]
    = must: preserve [loop_mode]
    = should: preserve memory-aware sample sizing

## Sample Authoring

& [SampleAuthoring] is the bounded process of creating, editing, slicing, looping, and shaping tracker-usable samples
  + [recorded_source] is recorded audio entering the bank
  + [generated_source] is waveform material produced by [SOPPyWave]
  + [slice] is a bounded extracted region of a longer waveform
  + [crossfade_loop] is a smoothed loop transition strategy
  + [transient_region] is the attack-rich portion of the sound
  + [body_region] is the sustaining middle of the sound
  + [tail_region] is the decaying or noisy ending of the sound

  ? [use_when: tracker samples are being created or prepared]
    = must: preserve clear source lineage
    = should: distinguish [transient_region], [body_region], and [tail_region]

  ? [generated_source is active]
    @ [transition] [SampleAuthoring] -> [SOPPyWave]
    = may: request custom waveform generation, resynthesis, or FX rendering for the sample

## SOPPyWave Tie-In

& [SOPPyWaveIntegration] is the bounded bridge through which tracker instruments and samples can be created, processed, or refined by [SOPPyWave]
  + [wave_request] is the declared request sent to [SOPPyWave]
  + [generated_sample] is the returned waveform artifact
  + [fx_chain] is the processing chain applied before tracker import
  + [render_profile] is the sample-targeted rendering constraint set
  + [roundtrip] is the movement from tracker intent to waveform generation and back into the sample bank

  ? [use_when: a tracker module needs new synthetic samples, transformed instrument layers, or procedurally generated content]
    = must: preserve [wave_request]
    = must: preserve [render_profile]
    = must: preserve [roundtrip]
    = should: align generated output to tracker memory and looping constraints

  ? [sample must be tracker-efficient]
    = should: constrain duration, bit depth, and bandwidth before importing back into [SampleBank]

## Effect Command System

& [EffectCommandSystem] is the bounded family of row/tick-level playback transformations typical of tracker music
  + [portamento] is glide toward pitch target
  + [vibrato] is cyclic pitch modulation
  + [tremolo] is cyclic volume modulation
  + [arpeggio] is rapid pitch cycling implying harmony
  + [volume_slide] is stepwise volume movement
  + [pitch_slide] is stepwise pitch movement
  + [sample_offset] is playback start position shift
  + [pattern_jump] is movement to another order position
  + [pattern_break] is movement to a new pattern row
  + [retrig] is repeated note retrigger under one row
  + [note_cut] is forced silencing
  + [tempo_change] is timing adjustment
  + [pan_slide] is stereo motion
  + [global_volume_change] is module-wide level shift
  + [format_specific_effect] is a command only valid in certain module families

  ? [use_when: tracker playback behavior is authored or parsed]
    = must: preserve command identity and parameter value
    = must: preserve format-specific differences where relevant
    = should: normalize to an internal effect representation during editing or translation

## Tick Engine

& [TickEngine] is the bounded playback interpreter that advances rows, ticks, voices, and effect states through time
  + [tick_clock] is the timing mechanism for effect progression
  + [row_advance] is movement to the next row
  + [effect_state] is any command whose meaning persists across ticks
  + [voice_state] is the current note, sample position, volume, pitch, panning, and envelope state of an active channel
  + [mix_frame] is the current mixed audio output slice

  ? [use_when: tracker playback is active]
    = must: preserve [effect_state]
    = must: preserve [voice_state]
    = must: correctly apply row-level and tick-level logic in sequence

## Playback Engine

& [TrackerPlayback] is the bounded runtime system that interprets a module and renders audible output
  + [play_cursor] is the current order, row, and tick location
  + [voice_allocator] is the mechanism assigning active samples/notes to playback voices
  + [interpolation_mode] is nearest, linear, spline, or format-appropriate resampling strategy
  + [mix_bus] is the summed audio field
  + [loop_state] is whether playback is in normal run, looping, or ending state
  + [seek] is movement to another timeline position
  + [solo_mode] is single-channel or single-pattern focused listening

  ? [use_when: module playback or preview is required]
    = must: preserve [play_cursor]
    = must: preserve [loop_state]
    = should: preserve faithful or declared interpolation behavior

## Composition Modes

& [PatternEdit] is the bounded authoring mode focused on one pattern or region at a time
  ? [use_when: direct row/channel editing is active]
    = must: preserve local edit context

& [LivePatternJam] is the bounded interactive improvisation mode where notes, pattern fills, and effect gestures are entered in time
  + [record_quantization] is the rule for placing live input onto rows/ticks
  + [overwrite_mode] is whether new input replaces or layers over existing cells
  + [step_entry] is grid-entry without live transport dependence

  ? [use_when: tracker authoring occurs interactively]
    = must: preserve edit reversibility
    = should: preserve deterministic quantization rules

& [AnalysisCoupledComposition] is the bounded composition mode where the module is iteratively judged and refined through playback analysis
  + [analysis_trace] is the structural or audio analysis record of the current song state
  + [mismatch] is the distance between intended and observed result
  + [repair_step] is the next justified pattern, instrument, or sample change

  ? [use_when: the composition should converge through repeated listening and structural inspection]
    = must: preserve [analysis_trace]
    = may: invoke [AudioAnalysisToolkit] on rendered playback
    = may: invoke [SOPPyWave] for sample replacement or refinement

## Translation And Import

& [ImportTranslate] is the bounded process of loading external module formats into the internal representation
  + [source_module] is the incoming MOD/S3M/XM/IT file
  + [translated_module] is the internal hybrid representation
  + [capability_gap] is any feature mismatch between source and internal model
  + [warning_set] is the bounded list of translation losses, assumptions, or unsupported effects

  ? [use_when: an existing tracker song must be loaded]
    = must: preserve source lineage
    = must: preserve [warning_set]
    = should: preserve exact source data when possible even if playback uses normalized internal interpretation

& [ExportModule] is the bounded process of converting the internal representation into a target tracker format or rendered audio artifact
  + [target_format] is MOD, S3M, XM, IT, wav render, stem render, or internal package
  + [downgrade_rule] is the policy for features unsupported by the target format
  + [compatibility_report] is the record of what changed during export

  ? [use_when: a composition must leave the internal system]
    = must: declare [target_format]
    = must: preserve [compatibility_report]
    = should: prefer explicit downgrade over silent truncation

## Game Music Integration

& [GameMusicRole] is the bounded relation between a tracker module and its gameplay use
  + [menu_theme] is the title or navigation loop
  + [battle_theme] is conflict or high-intensity gameplay music
  + [exploration_loop] is traversal or calm gameplay music
  + [warning_sting] is a short alert-oriented cue
  + [victory_jingle] is a short success cue
  + [adaptive_variant] is a module or pattern variant bound to game state

  ? [use_when: composition targets gameplay usage]
    = must: preserve role-appropriate loop logic
    = should: preserve memorability and clarity under repetition

& [AdaptiveTrackerMusic] is the bounded system for switching orders, patterns, channels, or instrument layers in response to game state
  + [state_trigger] is the game condition causing a music change
  + [transition_rule] is how playback moves to a new region or variation
  + [intensity_layer] is an added or muted channel group controlling energy
  + [seam_boundary] is the safe location for musically coherent transition

  ? [use_when: the module must respond to gameplay]
    = must: preserve [state_trigger]
    = must: preserve [transition_rule]
    = should: prefer musically coherent [seam_boundary]

## Tracker UI Surface

& [TrackerEditorSurface] is the bounded editing interface for working with modules
  + [pattern_grid] is the visible row/channel note table
  + [instrument_panel] is the instrument editing surface
  + [sample_editor] is the waveform and loop-edit surface
  + [order_editor] is the song arrangement list
  + [channel_meter] is the real-time view of active playback channels
  + [scope_view] is a waveform or per-channel visual monitor
  + [effect_reference] is the command lookup and edit guide

  ? [use_when: a human edits the tracker system]
    = should: preserve immediate audible preview
    = should: preserve focused navigation between pattern, sample, and order views

## Sample Efficiency

& [TrackerMemoryDiscipline] is the bounded constraint system for keeping modules practical for game and tracker use
  + [memory_budget] is the maximum total sample storage target
  + [voice_budget] is the target simultaneous playback complexity
  + [loop_efficiency] is reuse gained through looping rather than long raw samples
  + [bandwidth_limit] is the chosen upper-frequency or fidelity limit for economy
  + [reuse_strategy] is multi-note reuse, shared drum bank, or transformed resampling rather than unique large samples

  ? [use_when: modules must stay compact or retro-compatible]
    = must: preserve [memory_budget]
    = should: prefer [reuse_strategy]
    = should: prefer efficient looping and shorter samples when musically acceptable

## Genre / Style Presets

& [TrackerPresetFamily] is the bounded family of reusable authoring profiles for game-music tracker composition
  + [amiga_chiptune] is low-memory rhythmic sample-driven style
  + [industrial_s3m] is gritty drum-heavy tracker style with aggressive effects
  + [fantasy_xm] is melodic sample-rich adventure style
  + [combat_loop] is high-energy repeatable battle pattern architecture
  + [naval_tension] is restrained sonar-like, metallic, suspense-oriented game music
  + [boss_rush] is dense high-intensity pattern-driven combat music
  + [menu_glass] is light clean interface-oriented music

  ? [use_when: the user wants a strong initial style scaffold]
    = may: prefill tempo, channel roles, sample style, and effect-command tendencies

## SOPPyWave Sample Families

& [SOPPyWaveSampleFamilies] is the bounded set of common generated sample targets requested from [SOPPyWave] for tracker use
  + [kick_sample] is a compact low transient drum sample
  + [snare_sample] is a transient-noise plus body percussion sample
  + [hat_sample] is a short high-noise cymbal sample
  + [bass_wave] is a loopable low-end tone source
  + [lead_wave] is a harmonically shaped melodic sample
  + [pad_loop] is a sustained loopable atmospheric source
  + [fx_rise] is a transition or anticipation effect
  + [impact_stab] is a short dramatic hit
  + [sonar_pluck] is a ping-like sample suitable for naval or tactical game cues

  ? [use_when: tracker instruments should be synthesized instead of only imported from recordings]
    = may: issue sample-sized render requests to [SOPPyWave]
    = should: preserve loopability and tracker memory awareness

## Audio Analysis Tie-In

& [TrackerAudioReview] is the bounded listening and measurement layer for rendered modules
  + [mix_clarity] is whether channels remain distinguishable
  + [loop_fatigue] is annoyance risk under repeated gameplay looping
  + [bass_balance] is low-end adequacy without muddiness
  + [melodic_prominence] is recognizability of the leading line
  + [tracker_identity] is whether the piece still feels tracker-native rather than arbitrarily DAW-like

  ? [use_when: a module render must be judged]
    = may: invoke [AudioAnalysisToolkit]
    = should: preserve [tracker_identity]

## Quality Judgment

& [SOPPyTrackerJudgment] is the final acceptance layer for tracker modules, renders, and authoring outputs
  + [playability] is whether the module interprets correctly and reliably
  + [musical_coherence] is whether the song structure, harmony, rhythm, and texture fit together
  + [format_coherence] is whether the composition respects the chosen tracker format or declared hybrid behavior
  + [loop_quality] is whether repetition remains satisfying in gameplay
  + [sample_fit] is whether the sample/instrument bank suits the composition
  + [translation_risk] is the loss or instability introduced by import/export conversion

  ? [use_when: deciding whether a module or render is acceptable]
    = must: inspect [playability]
    = must: inspect [musical_coherence]
    = must: inspect [loop_quality]
    = should: inspect [sample_fit]
    = should: inspect [translation_risk]

  ? [result satisfies purpose and constraints]
    = must: emit [AcceptedComposition]

  ? [result fails but is repairable]
    = must: emit [ImprovementPlan]

  ? [result materially fails]
    = must: emit [RejectedRender]

## Constraints

- never: confuse the tracker sequencing subject with raw waveform synthesis; route sample creation downward to [SOPPyWave] when needed
- never: silently discard unsupported format features during import or export
- never: optimize sample fidelity so aggressively that tracker identity and memory discipline collapse
- never: blur note, instrument, and effect semantics into one opaque event representation without preserving original meaning
- prefer: internal hybrid representation for editing, with explicit compatibility reports for format-specific export
- prefer: compact, loopable, reusable samples for tracker-native composition
- prefer: musically coherent order-list structure over mere pattern accumulation
- prefer: [SOPPyWaveIntegration] when synthesized samples can improve identity, cohesion, or efficient reuse