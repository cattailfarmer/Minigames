& [SOPPyWave] is the bounded Python audio synthesis, processing, analysis-coupled rendering, and live signal transformation system for procedural sound design, exported waveform creation, and real-time effects processing
  + [audio_subject] is a declared sound, signal, effect chain, performance input, rendered buffer, stream, or layered audio artifact under generation or transformation
  + [intent] is the declared purpose, character, behavior, and constraints of the target sound or processing result
  + [sample_buffer] is the discrete array of audio samples produced, transformed, or preserved by the system
  + [sample_rate] is the temporal resolution in samples per second
  + [bit_depth] is the quantization resolution of stored output
  + [channel_set] is mono, stereo, or multichannel signal arrangement
  + [render_mode] is [OfflineRender], [StreamingRender], [LiveFX], [Resynthesis], [BatchVariation], or [AnalysisCoupledRender]
  + [signal_path] is the ordered chain from source through modulation, filtering, dynamics, spatialization, and output
  + [source_set] is [OscillatorSource], [NoiseSource], [SampleSource], [InputSource], [FeedbackSource], and [HybridSource]
  + [process_set] is [EnvelopeShaping], [FilterBank], [DynamicsControl], [DistortionStage], [DelayStage], [ReverbStage], [PitchStage], [ModulationStage], [SpatialStage], [GranularStage], [SpectralStage], [LooperStage], and [RoutingStage]
  + [artifact_set] is [WaveArtifact], [Preset], [EffectChain], [RenderPlan], [VariationSet], [PerformancePatch], [AnalysisTrace], and [ImprovementPlan]
  + [resolution] is [RenderedSignal], [LivePatch], [AcceptedRender], [TransformChain], [VariationSet], [RejectedRender], [ImprovementPlan], or [Uncertainty]

  ? [use_when: sound must be synthesized, transformed, layered, exported, performed through, or iteratively refined]
    = must: activate [SOPPyWave]

  ? [avoid_when: only conceptual sound planning exists and no signal path must yet be built]
    @ [transition] [SOPPyWave] -> [Planner]
    = may: defer waveform construction

  ! [SOPPyWave is the actuation layer for audio intention] is accepted
    @ [support] [SOPPyWave] closes the loop between sound intent, waveform realization, and analysis-guided refinement
    @ [support] [SOPPyWave] is judged by [AudioAnalysisToolkit] and may emit traces for [SOPPyVFX]

## Tool Realization

& [SOPPyWaveTooling] is the bounded Python tool realization layer for [SOPPyWave]
  + [array_dsp] is NumPy- and SciPy-style sample and transform processing
  + [file_io] is waveform import/export tooling such as soundfile or wave-compatible writers
  + [analysis_stack] is librosa-, torchaudio-, or equivalent analysis support when needed
  + [fx_stack] is pedalboard-, pydub-, or equivalent effect-chain tooling
  + [live_io] is sounddevice-, pyaudio-, or equivalent low-latency stream handling
  + [safety_wrapper] is bounded gain, limiter, bypass, and fault handling around performer-facing paths

  ? [render_mode is OfflineRender or Resynthesis]
    = should: prefer [array_dsp] and [file_io]

  ? [render_mode is LiveFX or StreamingRender]
    = should: prefer [live_io]
    = must: preserve [safety_wrapper]

  ? [analysis-coupled correction is active]
    = should: invoke [analysis_stack]
    @ [support] [SOPPyWaveTooling] -> [AudioAnalysisToolkit]

## Core Contract

& [SOPPyWaveContract] is the minimal executable shape of a valid render or processing request
  + [input] is the source signal, synthesis recipe, or live audio stream entering the system
  + [constraints] are the declared limits on latency, distortion, CPU, dynamic range, export format, or style
  + [target] is the intended audible result
  + [verification] is the post-render or live-monitoring check for success

  = must: identify [input]
  = must: identify [target]
  = must: identify [render_mode]
  = must: preserve [constraints]
  = must: emit [verification] path or [Uncertainty]

  ? [input is absent and synthesis is intended]
    = must: construct [input] from [source_set]

  ? [target is unclear]
    = must: emit [Uncertainty]

## Intent Declaration

/ [audio_subject] -(IntentDeclaration)> [TargetCharacter], [TechnicalConstraints], [References], [Uncertainty]

& [IntentDeclaration] is the pass that turns a vague audio idea into bounded renderable intent
  + [target_character] is the intended timbre, motion, weight, aggression, softness, atmosphere, clarity, or role
  + [technical_constraints] are duration, sample rate, latency, CPU budget, mono/stereo requirements, headroom, and export format
  + [references] are comparable sounds, prior presets, exemplar effects, or user-described anchors
  + [uncertainty] is unresolved sonic or technical ambiguity

  = must: identify [target_character]
  = must: identify [technical_constraints]
  = should: preserve [references]
  = must: preserve [uncertainty]

  ? [intent is style-rich but technically underspecified]
    = should: infer ordinary defaults
    = must: mark inferred defaults as [assumption]

  ? [intent is technically specific but sonically vague]
    = must: preserve aesthetic ambiguity as [uncertainty]

## Render Modes

& [OfflineRender] is non-real-time sound construction for exported files, sample libraries, and deterministic artifact production
  ? [use_when: latency is irrelevant and sound may be rendered ahead of time]
    = must: prefer maximal precision and reproducibility

& [StreamingRender] is chunked audio rendering for ongoing output without strict performer feedback constraints
  ? [use_when: audio must continue in time but live instrumental feel is not primary]
    = must: preserve chunk continuity

& [LiveFX] is low-latency signal transformation for instrument, microphone, controller, or line input
  + [latency_budget] is the maximum admissible delay before performer feel degrades
  + [monitor_path] is the route from input to heard output
  + [stability] is freedom from dropouts, runaway feedback, and CPU starvation

  ? [use_when: guitar, bass, vocal, or live input must be processed in real time]
    = must: preserve [latency_budget]
    = must: preserve [monitor_path]
    = must: verify [stability]

& [Resynthesis] is analysis-guided reconstruction of an existing sound into a controllable generated form
  ? [use_when: an input sound should become a new playable or mutable synthesis subject]
    = must: preserve major audible anchors
    = should: allow transformed reinterpretation

& [BatchVariation] is controlled generation of many related candidate sounds
  ? [use_when: multiple gameplay variants, humanization, or preset exploration is desired]
    = must: preserve family resemblance
    = must: vary only declared degrees of freedom

& [AnalysisCoupledRender] is render generation guided by immediate measurement and iterative correction
  ? [use_when: the generated sound must converge toward declared targets through analysis]
    = must: invoke [AudioAnalysisToolkit] after each admissible pass
    = should: prefer the smallest parameter change that improves fit

## Signal Intake

/ [input] -(SignalIntake)> [SignalMetadata], [SourceSignal], [Faults], [Uncertainty]

& [SignalIntake] is the pass for importing or receiving source material
  + [signal_metadata] is sample rate, channels, duration, bit depth, source origin, and normalization state
  + [source_signal] is the time-domain sample stream or buffer
  + [faults] are silence, clipping, corruption, unsupported format, denormal instability, or missing input device

  = must: inspect [signal_metadata]
  = must: preserve [source_signal]
  = must: detect obvious [faults]

  ? [faults materially block processing]
    = must: emit [Uncertainty]

## Source Set

& [OscillatorSource] is a generated periodic or quasi-periodic source
  + [waveform] is sine, square, triangle, saw, pulse, supersaw, custom table, or procedural curve
  + [frequency] is the base rate of oscillation
  + [phase] is the initial or evolving angular position
  + [detune] is slight deviation for thickening or beating
  + [drift] is slow instability that mimics analog behavior

  ? [use_when: tonal or controllable synthetic content is needed]
    = must: declare [waveform]
    = must: declare [frequency]

& [NoiseSource] is a stochastic or pseudo-stochastic source
  + [noise_type] is white, pink, brown, blue, violet, filtered, burst, crackle, or shaped noise
  + [band_shape] is the spectral contour imposed on the noise
  + [grain] is the felt texture density

  ? [use_when: impacts, air, splash, hiss, debris, surf, or texture is needed]
    = must: declare [noise_type]

& [SampleSource] is a pre-recorded audio clip or excerpt used as source material
  + [sample] is the loaded waveform
  + [start_point] is the entry offset
  + [end_point] is the exit offset
  + [loop_region] is the bounded repeatable section

  ? [use_when: realism, reuse, or resynthesis anchors are needed]
    = must: preserve source lineage

& [InputSource] is a live or streaming external signal
  + [device] is microphone, line-in, guitar interface, USB input, or virtual bus
  + [input_gain] is pre-processing amplification
  + [impedance_context] is the electrical suitability for instrument or line level
  + [noise_profile] is hum, hiss, room noise, or pickup noise attached to the input

  ? [use_when: instrument or live performer audio enters the system]
    = must: inspect [device]
    = must: preserve safe [input_gain]
    = should: inspect [impedance_context]

& [FeedbackSource] is a source derived from delayed or recirculated system output
  + [feedback_amount] is the proportion returned to the input of a process stage
  + [stability_limit] is the bound beyond which self-excitation becomes unsafe or unusable
  + [tone_loss] is cumulative filtering or distortion within repeated loops

  ? [use_when: echo, resonator, howl, shimmer, or self-growing textures are desired]
    = must: preserve [stability_limit]

& [HybridSource] is a composed source that mixes multiple source types into one controllable entry signal
  ? [use_when: no single source adequately expresses the target sound]
    = must: preserve identity of major source contributors

## Control Signals

& [ControlSignal] is a non-audio or low-rate signal used to shape another signal over time
  + [lfo] is a low-frequency oscillator for cyclic motion
  + [envelope] is a bounded temporal amplitude or parameter shape
  + [step_sequence] is discrete parameter motion across time steps
  + [trigger] is an event that starts or alters a process
  + [macro] is one control bound to many parameters

  ? [use_when: sound behavior changes through time]
    = must: preserve source-target modulation mapping

## Envelope Shaping

& [EnvelopeShaping] is amplitude or parameter evolution imposed over time
  + [attack] is rise time from silence or baseline to peak
  + [decay] is fall time from peak to sustain
  + [sustain] is the maintained level during hold
  + [release] is post-trigger fade
  + [curve] is linear, exponential, logarithmic, spline, or custom contour

  ? [use_when: an event or gesture needs temporal shape]
    = must: declare [attack]
    = must: declare [release]
    = should: declare [curve]

## Filter Bank

& [FilterBank] is the bounded set of spectral shaping processes
  + [filter_type] is low-pass, high-pass, band-pass, notch, comb, shelf, peak, all-pass, or morphing filter
  + [cutoff] is the central or boundary frequency
  + [resonance] is emphasis near the cutoff or center
  + [slope] is attenuation steepness
  + [tracking] is parameter following another signal or control

  ? [use_when: timbre must be brightened, darkened, narrowed, hollowed, or animated]
    = must: declare [filter_type]
    = must: declare [cutoff]

## Dynamics Control

& [DynamicsControl] is level-dependent amplitude management
  + [compressor] is downward dynamic range control
  + [expander] is reduction of low-level material
  + [gate] is threshold-based attenuation of quiet signal
  + [limiter] is peak ceiling enforcement
  + [sidechain] is one signal controlling another’s dynamics

  ? [use_when: level stability, punch, sustain, or cleanup matters]
    = must: preserve headroom
    = should: inspect attack and release interaction

## Distortion Stage

& [DistortionStage] is nonlinear signal shaping for saturation, clipping, wavefolding, or tone aggression
  + [drive] is input push into nonlinearity
  + [transfer_curve] is the mathematical shape of clipping or saturation
  + [bias] is asymmetry applied before or during distortion
  + [oversampling] is increased internal sample rate to reduce aliasing
  + [post_tone] is corrective filtering after distortion

  ? [use_when: warmth, grit, edge, sustain, fuzz, or destructive texture is desired]
    = must: preserve controllable [drive]
    = should: preserve [oversampling] when harsh aliasing matters

  ? [render_mode is LiveFX and CPU budget is tight]
    = may: reduce [oversampling]
    = must: preserve stable performance

## Delay Stage

& [DelayStage] is repeated time-offset signal reintroduction
  + [delay_time] is the repeat interval
  + [feedback] is the recirculation amount
  + [mix] is dry/wet proportion
  + [sync] is temporal locking to external tempo
  + [diffusion] is spread or blur within repeats

  ? [use_when: echo, slapback, space, rhythm, or feedback texture is desired]
    = must: preserve runaway safety in feedback configurations

## Reverb Stage

& [ReverbStage] is simulated or algorithmic space persistence
  + [predelay] is silence before the reverberant field begins
  + [room_size] is perceived enclosure scale
  + [decay_time] is reverb tail duration
  + [damping] is frequency-dependent tail loss
  + [early_reflections] are initial boundary returns
  + [late_field] is dense tail energy

  ? [use_when: placement in space or grandeur is required]
    = must: preserve intelligibility when signal role is informational

## Pitch Stage

& [PitchStage] is frequency transposition, shifting, harmonization, or glide
  + [transpose] is static pitch change
  + [glide] is continuous movement between pitches
  + [harmonizer] is added pitch-derived voices
  + [formant_compensation] is vocal/instrument body correction during shift

  ? [use_when: doubling, harmonies, detuned width, or transformed identity is desired]
    = should: preserve artifact awareness when shifting aggressively

## Modulation Stage

& [ModulationStage] is parameter motion that animates signal character
  + [tremolo] is amplitude modulation
  + [vibrato] is pitch modulation
  + [chorus] is delayed detuned thickening
  + [flanger] is short comb-like moving delay
  + [phaser] is moving all-pass phase coloration
  + [ring_mod] is multiplication by another oscillator
  + [auto_filter] is moving spectral emphasis

  ? [use_when: motion, shimmer, swirl, instability, or thickness is desired]
    = must: keep modulation depth within intended perceptual bounds

## Spatial Stage

& [SpatialStage] is image placement across stereo or multichannel space
  + [pan] is left-right positioning
  + [width] is apparent lateral spread
  + [depth] is perceived foreground-background placement
  + [mid_side_balance] is center-versus-edge energy relation

  ? [use_when: multiple sources or effects must occupy different perceived locations]
    = should: preserve mono compatibility when portability matters

## Granular Stage

& [GranularStage] is sound construction from many micro-fragments
  + [grain_size] is fragment duration
  + [density] is fragment count over time
  + [spray] is stochastic variation in placement or pitch
  + [window] is grain amplitude contour

  ? [use_when: clouds, shimmer, smearing, time-stretch, or surreal texture is desired]
    = must: preserve grain continuity relative to intent

## Spectral Stage

& [SpectralStage] is frequency-domain manipulation beyond ordinary filters
  + [freeze] is held spectral slice
  + [morph] is movement between spectra
  + [mask] is selective spectral preservation
  + [resynth] is reconstructed waveform from altered spectral content

  ? [use_when: unusual transformation, spectral matching, or analysis-driven redesign is needed]
    = should: preserve major audible anchors unless destruction is intended

## Looper Stage

& [LooperStage] is bounded capture and replay of performed or incoming audio
  + [loop_length] is the captured repeat duration
  + [overdub] is layered addition onto an existing loop
  + [undo_depth] is reversible loop edit history
  + [quantization] is temporal alignment aid

  ? [use_when: repeated performance layers or phrase construction are desired]
    = should: preserve reversible workflow

## Routing Stage

& [RoutingStage] is explicit signal path topology management
  + [serial] is one process feeding the next
  + [parallel] is one source feeding multiple paths combined later
  + [send_return] is auxiliary bus processing
  + [split_band] is frequency-region-specific routing
  + [crossfade] is controlled movement between alternate paths

  ? [use_when: chain topology materially affects outcome]
    = must: declare route order
    = must: preserve feedback safety when loops exist

## Guitar FX Processing

& [GuitarFXProcessor] is the live instrument processing subject within [SOPPyWave]
  + [instrument_input] is the electric guitar, bass, pickup-equipped instrument, or reamped signal entering the chain
  + [pickup_character] is single-coil, humbucker, piezo, or mixed source identity
  + [touch_dynamics] is performer-dependent variation in attack and sustain
  + [amp_voice] is the simulated or implied amplifier character
  + [cabinet_voice] is the speaker and enclosure coloration
  + [pedal_chain] is the ordered set of effect modules forming the performer-facing patch
  + [noise_management] is hum reduction, gate behavior, and idle suppression
  + [latency_budget] is the maximum admissible delay before player feel is degraded

  ? [use_when: the system must operate as a guitar effects processor]
    = must: activate [LiveFX]
    = must: preserve [latency_budget]
    = must: preserve [touch_dynamics]
    = should: preserve [pickup_character]

  ? [input is high-impedance instrument source]
    = should: preserve suitable front-end handling
    = should: avoid premature tone dulling

## Amp Voice

& [AmpVoice] is the amplifier-style nonlinear and spectral shaping layer
  + [preamp_gain] is front-stage drive amount
  + [tone_stack] is bass, mid, treble, presence, or custom EQ contour
  + [power_amp_sag] is compression and response softness under load
  + [breakup] is transition from clean to distortion
  + [response] is fast, spongy, tight, scooped, mid-forward, or compressed behavior

  ? [use_when: guitar tone needs amplifier identity]
    = must: preserve intended clean/crunch/high-gain boundary

## Cabinet Voice

& [CabinetVoice] is speaker and enclosure coloration, optionally by convolution or modeled filtering
  + [speaker_size] is the nominal driver dimension
  + [enclosure_type] is open-back, closed-back, combo, stack, or direct path
  + [mic_position] is virtual capture relation to cone and edge
  + [impulse_response] is measured cabinet response used by convolution

  ? [use_when: raw amp-like distortion must become realistic or stylized guitar output]
    = should: preserve [impulse_response] lineage when convolution is used

## Pedal Families

& [PedalFamilies] is the conventional guitarist-facing organization of live effect modules
  + [boost] is level lift with minimal coloration
  + [overdrive] is soft clipping and tone push
  + [distortion] is firmer clipping and compression
  + [fuzz] is strongly nonlinear saturation with texture-heavy behavior
  + [wah] is foot or auto-controlled moving band emphasis
  + [compressor_pedal] is performance-level smoothing and sustain
  + [chorus_pedal] is width and modulation thickening
  + [delay_pedal] is repeat-based space or rhythm
  + [reverb_pedal] is room or hall expansion
  + [looper_pedal] is phrase capture and replay
  + [pitch_pedal] is octave, harmony, or detune processing

  ? [use_when: user thinks in guitarist workflow rather than DSP primitives]
    = may: translate [PedalFamilies] into internal [process_set]

## Safety And Stability

& [LiveSafety] is the protection subject for performer-facing audio processing
  + [feedback_runaway] is uncontrolled self-amplifying loop
  + [sudden_peak] is unexpected loud event that may damage ears or gear
  + [dropout] is discontinuity from CPU overload or buffer underrun
  + [denormal_slowdown] is performance collapse from pathological tiny floating-point values
  + [safe_bypass] is controlled disengagement preserving output continuity

  ? [use_when: real-time monitoring or performance is active]
    = must: detect [feedback_runaway]
    = must: detect [sudden_peak]
    = must: preserve [safe_bypass]
    = should: preserve CPU margin against [dropout]

  - never: allow uncontrolled feedback without explicit intent
  - never: emit unclamped destructive output on patch load
  - never: ignore performer monitoring path stability

## Preset Authoring

& [PresetAuthoring] is the durable capture of synthesis or effect configurations
  + [preset_name] is the retrievable identity of the patch
  + [parameter_state] is the current value set for all relevant controls
  + [macro_map] is a higher-level exposed performance control surface
  + [usage_context] is game sound design, live guitar, ambient processing, UI audio, or experimental synthesis

  ? [use_when: a configuration should be reused or shared]
    = must: preserve [parameter_state]
    = should: preserve [usage_context]

## Variation Engine

& [VariationEngine] is controlled mutation of a render plan or preset into nearby alternatives
  + [mutation_space] is the permitted set of varying parameters
  + [mutation_depth] is the magnitude of allowed change
  + [family_anchor] is the preserved identity of the sound family
  + [selection_score] is the measured or judged desirability of a candidate

  ? [use_when: many related sounds or patch options are needed]
    = must: preserve [family_anchor]
    = must: constrain [mutation_space]
    = should: invoke [AudioAnalysisToolkit] for candidate ranking

## Export

& [WaveArtifact] is the durable emitted audio file or buffer artifact
  + [format] is wav, flac, aiff, raw buffer, or stream packet
  + [normalization] is the selected output level strategy
  + [dither] is optional quantization-noise treatment at export
  + [metadata] is the attached descriptive record for the render

  ? [use_when: output must leave the active runtime chain]
    = must: declare [format]
    = should: preserve [metadata]

## Analysis Coupling

& [AnalysisCoupling] is the feedback bridge from generated audio into measurement and refinement
  + [analysis_trace] is the recorded results from [AudioAnalysisToolkit]
  + [mismatch] is the distance between intended and measured result
  + [repair_step] is the next justified parameter or topology change

  ? [use_when: output quality must converge through iteration]
    = must: pass [sample_buffer] to [AudioAnalysisToolkit]
    = must: preserve [analysis_trace]
    = should: identify [mismatch]
    = should: emit [repair_step]

  ? [ZetaEar or ZetaOscilloscope are active]
    = may: use them as structural comparison tools
    - never: let them replace clipping, loudness, or latency checks

## Game FX Production

& [GameAudioProduction] is the bounded subject for generating durable sound effects for game events
  + [event_subject] is hit, miss, lock-on, splash, alarm, ambience, or UI cue
  + [asset_family] is the coherent set of related renders for one game identity
  + [variation_budget] is the declared amount of acceptable candidate spread

  ? [use_when: a game needs exportable sound effects rather than only live processing]
    = must: prefer [OfflineRender] or [BatchVariation]
    = must: preserve [asset_family]
    = should: invoke [AudioAnalysisToolkit] before final acceptance

## Battleship Presets

& [BattleshipAudioPresets] is the preset family for naval tactical game sound design
  + [sonar_ping] is a clean transient tone with controlled decay and subtle echo
  + [missile_launch] is a short thrust burst with rising or falling pressure contour
  + [water_splash] is a broadband burst with filtered ripple tail
  + [impact_boom] is transient-heavy low-mid event with debris texture
  + [ui_lockon] is a short repeatable tonal cue with low fatigue risk

  ? [use_when: sound assets for a battleship-style game are being built]
    = may: prefer [OfflineRender]
    = should: use [BatchVariation] for repeated events
    = should: invoke [AnalysisCoupledRender] for key signature sounds

## Guitar Presets

& [GuitarPresetFamily] is the preset family for instrument processing and performance patches
  + [clean_glass] is bright articulate low-drive tone with spacious modulation or reverb
  + [edge_breakup] is lightly saturated dynamic touch-sensitive response
  + [mid_gain_crunch] is focused rock rhythm tone
  + [high_gain_lead] is compressed singing sustain with controlled noise
  + [shoegaze_wash] is reverb-forward diffuse ambient expansion
  + [doom_fuzz] is heavy low-rich nonlinear saturation
  + [octave_swell] is volume-shaped harmonized atmospheric texture
  + [lofi_warble] is bandwidth-limited unstable nostalgic coloration

  ? [use_when: performer-facing patches are being authored]
    = may: expose macro controls for gain, tone, space, and modulation

## Quality Judgment

& [SOPPyWaveJudgment] is the final acceptance layer for generated or processed audio
  + [clarity] is recognizability of intended role
  + [coherence] is fit with surrounding system or performance context
  + [playability] is responsiveness under live input
  + [fatigue_risk] is annoyance or harshness under repetition
  + [masking_risk] is interference with neighboring sounds
  + [artifact_risk] is undesirable clicks, zipper noise, aliasing, pumping, or glitching

  ? [use_when: deciding whether a patch or render is acceptable]
    = must: inspect [clarity]
    = must: inspect [coherence]
    = must: inspect [artifact_risk]

  ? [render_mode is LiveFX]
    = must: inspect [playability]

  ? [result satisfies purpose and constraints]
    = must: emit [AcceptedRender]

  ? [result fails but is correctable]
    = must: emit [ImprovementPlan]

  ? [result materially fails or is unsafe]
    = must: emit [RejectedRender]

## Constraints

- never: confuse conceptual sound description with a valid signal path
- never: let experimental transforms replace ordinary DSP safety checks
- never: allow live performance features to violate stable monitoring requirements
- never: optimize timbral novelty at the cost of unbounded latency in [LiveFX]
- never: treat tool availability alone as sufficient justification for adding a process stage
- prefer: the smallest coherent signal path that achieves the intended audible result
- prefer: clear source lineage when presets, samples, or analysis traces are reused
- prefer: reversible parameter changes during interactive design and live patch editing
