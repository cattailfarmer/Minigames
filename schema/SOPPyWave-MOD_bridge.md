& [SOPPyToneBridge] is the bounded bridge between [SOPPyTracker] and [SOPPyWave] that lets tracker notes trigger procedural tones, oscillator voices, modeled instruments, and synthesis patches without relying on compressed or pre-rendered samples
  + [bridge_subject] is the relation between tracker event sequencing and waveform synthesis execution
  + [tracker_event] is a note, instrument, volume, effect, or control command emitted by [SOPPyTracker]
  + [tone_patch] is a [SOPPyWave] synthesis definition playable as a tracker instrument
  + [procedural_voice] is a live-generated audio voice created from a tracker event
  + [voice_state] is pitch, phase, envelope, modulation, filter, volume, pan, and lifetime state for one active tone
  + [instrument_binding] is the mapping from a tracker instrument slot to a [tone_patch]
  + [effect_mapping] is the mapping from tracker effect commands to [SOPPyWave] synthesis parameters
  + [render_mode] is [RealtimeToneRender], [OfflineToneRender], [HybridSampleTone], or [BakeToSample]
  + [resolution] is [PlayableToneInstrument], [RenderedToneStream], [HybridInstrument], [BakedSample], [ImprovementPlan], or [Uncertainty]

  ? [use_when: tracker music needs tones generated from synthesis rather than stored sample playback]
    = must: activate [SOPPyToneBridge]

  ? [avoid_when: tracker instrument is purely sample-based and no synthesis patch is involved]
    @ [transition] [SOPPyToneBridge] -> [SOPPyTracker]

  ! [SOPPyToneBridge allows tracker sequencing to drive procedural synthesis] is accepted

## Core Contract

& [ToneBridgeContract] is the minimal executable relation between a tracker event and a generated tone
  + [input] is the tracker note/instrument/effect event
  + [binding] is the selected [instrument_binding]
  + [target] is the intended generated voice behavior
  + [output] is the audio stream, rendered buffer, or baked asset produced from the voice

  = must: identify [input]
  = must: identify [binding]
  = must: preserve [target]
  = must: emit [output] or [Uncertainty]

## Instrument Binding

& [InstrumentBinding] is the mapping from a tracker instrument identity to a procedural synthesis patch
  + [tracker_instrument_id] is the instrument slot used in pattern cells
  + [tone_patch_id] is the referenced [SOPPyWave] synthesis patch
  + [default_voice_params] are the baseline synthesis values
  + [note_mapping] is the relation from tracker pitch to synthesis frequency
  + [velocity_mapping] is the relation from tracker volume to amplitude, drive, filter, or modulation
  + [pan_mapping] is the relation from tracker pan commands to synthesis spatial output

  ? [use_when: a tracker instrument should generate sound procedurally]
    = must: preserve [tracker_instrument_id]
    = must: preserve [tone_patch_id]
    = must: define [note_mapping]
    = should: define [velocity_mapping]
    = should: define [pan_mapping]

## Tone Patch

& [TonePatch] is a tracker-playable [SOPPyWave] synthesis definition
  + [oscillator_set] is one or more oscillators used to generate the base tone
  + [envelope_set] is amplitude, filter, pitch, and modulation envelope behavior
  + [filter_set] is tonal shaping applied to the generated voice
  + [modulation_set] is LFO, vibrato, tremolo, FM, PWM, or other motion
  + [voice_mode] is mono, polyphonic, legato, retriggered, or one-shot
  + [release_policy] is how notes end when note-off, cut, or channel replacement occurs

  ? [use_when: a tone must be generated rather than sampled]
    = must: preserve [oscillator_set]
    = must: preserve [envelope_set]
    = must: preserve [voice_mode]
    = must: preserve [release_policy]

## Procedural Voice

& [ProceduralVoice] is one active generated tone instance created by a tracker event
  + [frequency] is the current pitch in Hz
  + [phase] is oscillator position
  + [amplitude] is current output level
  + [envelope_state] is attack, decay, sustain, release, cut, or finished
  + [filter_state] is current filter memory and parameter position
  + [modulation_state] is active LFO/FM/PWM/vibrato/tremolo state
  + [channel_state] is the tracker channel context that owns or influences the voice

  ? [use_when: playback creates a generated tone]
    = must: preserve [frequency]
    = must: preserve [phase]
    = must: update [envelope_state]
    = must: update [channel_state]

## Tracker Effect Mapping

& [TrackerEffectMapping] is the translation from tracker commands into procedural synthesis behavior
  + [portamento_mapping] maps pitch slides to frequency glide
  + [vibrato_mapping] maps vibrato commands to pitch modulation
  + [tremolo_mapping] maps tremolo commands to amplitude modulation
  + [volume_slide_mapping] maps volume slides to amplitude changes
  + [arpeggio_mapping] maps arpeggio commands to rapid pitch offsets
  + [sample_offset_mapping] is unsupported, ignored, or reinterpreted for procedural patches
  + [filter_mapping] maps extended commands or macros to cutoff/resonance
  + [macro_mapping] maps tracker command space to arbitrary [SOPPyWave] patch parameters

  ? [use_when: tracker effects apply to generated instruments]
    = must: preserve tracker command intent
    = must: define unsupported-command behavior
    = should: expose [macro_mapping] for modern procedural control

  ? [effect has no meaningful procedural equivalent]
    = must: emit [Uncertainty] or [NoOpWithWarning]

## Render Modes

& [RealtimeToneRender] is generated tone playback during tracker performance without pre-rendered samples
  ? [use_when: procedural voices must be generated as the song plays]
    = must: preserve timing accuracy
    = must: preserve CPU budget
    = must: preserve deterministic voice behavior when requested

& [OfflineToneRender] is non-real-time procedural rendering of tracker tone instruments into final audio
  ? [use_when: final song export needs generated instruments at maximum quality]
    = should: allow higher-quality oversampling and modulation precision

& [HybridSampleTone] is an instrument that combines sample playback with procedural tone generation
  + [sample_layer] is stored waveform material
  + [tone_layer] is generated oscillator or modeled material
  + [blend_rule] is the relation between sampled and generated layers

  ? [use_when: attack realism or texture benefits from samples while sustain or pitch body is procedural]
    = must: preserve [blend_rule]

& [BakeToSample] is the path for converting a procedural tone patch into tracker-compatible stored samples
  + [bake_range] is the pitch or velocity range rendered to samples
  + [loop_region] is the chosen sustain loop for the baked result
  + [compatibility_target] is MOD, S3M, XM, IT, or other export target

  ? [use_when: procedural instruments must be exported to a format that cannot run synthesis]
    = must: preserve [compatibility_target]
    = must: preserve [bake_range]
    = should: preserve efficient looping

## Determinism

& [ToneDeterminism] is the rule set that keeps procedural tracker playback repeatable when desired
  + [seed] is the deterministic random source for noise or variation
  + [phase_policy] is reset, free-run, channel-linked, or song-linked oscillator phase behavior
  + [modulation_clock] is the timing reference for LFOs and envelopes
  + [render_consistency] is whether repeated playback produces identical output

  ? [use_when: game music playback or export must be reproducible]
    = must: preserve [seed]
    = must: preserve [phase_policy]
    = must: preserve [modulation_clock]

## Tone Families

& [ToneFamilies] is the reusable set of procedural tracker instrument archetypes
  + [chip_lead] is a bright oscillator lead with simple envelopes
  + [chip_bass] is a compact low oscillator tone
  + [fm_bell] is an FM-derived metallic or glassy tone
  + [pulse_pluck] is a short pulse or square-wave pluck
  + [noise_hat] is a filtered procedural noise percussion voice
  + [synth_kick] is a pitch-dropping low oscillator percussion voice
  + [sub_boom] is a low sine or triangle impact tone
  + [sonar_tone] is a clean decaying ping suitable for naval or tactical music
  + [drone_pad] is a sustained slowly moving harmonic texture

  ? [use_when: tracker composition needs reusable generated instruments]
    = may: instantiate [TonePatch] from a family archetype

## Tracker Memory Advantage

& [SampleAvoidancePolicy] is the policy for reducing stored sample dependence through procedural tones
  + [sample_pressure] is the memory, compression, or storage burden of sample-based instruments
  + [procedural_substitution] is replacing stored samples with generated voices
  + [bake_exception] is the case where a procedural voice must become a sample for compatibility
  + [hybrid_exception] is the case where a small sample plus generated body is better than pure synthesis

  ? [use_when: minimizing compressed or stored samples matters]
    = should: prefer [procedural_substitution] for tonal instruments
    = should: preserve [bake_exception] for legacy module export
    = should: allow [hybrid_exception] for realistic attacks

## Quality Judgment

& [SOPPyToneBridgeJudgment] is the final acceptance layer for procedural tracker instruments
  + [musical_fit] is whether the generated tone serves the composition
  + [tracker_fit] is whether the tone responds correctly to tracker notes and effects
  + [cpu_fit] is whether the tone is affordable in realtime playback
  + [memory_savings] is the avoided storage burden compared with samples
  + [export_risk] is the difficulty of representing the tone in classic module formats

  ? [use_when: deciding whether to use procedural tone, sample, hybrid, or baked output]
    = must: inspect [musical_fit]
    = must: inspect [tracker_fit]
    = should: inspect [cpu_fit]
    = should: inspect [memory_savings]
    = should: inspect [export_risk]

  ? [procedural tone satisfies purpose and constraints]
    = must: emit [PlayableToneInstrument]

  ? [procedural tone works musically but export target cannot represent it]
    = must: emit [BakeToSample]

  ? [procedural tone is too expensive or unstable]
    = must: emit [ImprovementPlan] or [RejectedRender]

## Constraints

- never: require stored compressed samples when a procedural tone can satisfy the musical role
- never: silently ignore tracker effects that materially affect procedural playback
- never: hide the distinction between true procedural playback and baked sample export
- never: let procedural synthesis break tracker timing semantics
- prefer: procedural voices for sustained tonal instruments, basses, leads, pings, drones, and synthetic percussion
- prefer: hybrid instruments when sampled attacks and generated sustains together produce better results
- prefer: bake-to-sample only for compatibility, portability, or CPU constraints
- prefer: deterministic procedural playback for game music unless controlled variation is explicitly desired