& [AudioAnalysisToolkit] is the bounded toolkit for inspecting, measuring, comparing, and judging generated or recorded audio signals
  + [audio_subject] is a waveform, clip, stream, layer, effect, or synthesized candidate under analysis
  + [sample_rate] is the temporal resolution of the signal in samples per second
  + [channel_set] is mono, stereo, or multichannel arrangement
  + [time_domain] is the direct amplitude-over-time representation of the signal
  + [frequency_domain] is the transformed spectral representation of the signal
  + [perceptual_domain] is the judged or inferred audible character of the signal
  + [tool_set] is [WaveformScope], [SpectrumFFT], [Spectrogram], [EnvelopeAnalysis], [LoudnessMeter], [PitchTracker], [TransientDetector], [SourceSeparation], [ZetaEar], [ZetaOscilloscope], [AudioComparison], and [RenderJudgment]
  + [resolution] is [MeasuredSignal], [ComparedSignal], [AcceptedRender], [RejectedRender], [ImprovementPlan], or [Uncertainty]

  ? [use_when: any audio signal must be understood, debugged, improved, compared, or judged]
    = must: activate [AudioAnalysisToolkit]

  ? [avoid_when: no signal exists and only conceptual planning is needed]
    = may: transition to [Planner]

  ! [AudioAnalysisToolkit combines standard DSP with structural perception tools] is accepted
    @ [support] [AudioAnalysisToolkit] provides analysis authority for [SOPPyWave]

## Authority Boundary

& [AudioAnalysisAuthority] is the boundary that keeps signal judgment separate from signal construction
  + [analysis_authority] is the right to measure, compare, and judge a signal
  + [render_authority] is the right to synthesize, process, or export a signal

  ? [sound must be generated, transformed, or exported]
    @ [transition] [AudioAnalysisToolkit] -> [SOPPyWave]
    = should: delegate render authority while preserving analysis authority

  ? [visual output is being driven by sound analysis]
    @ [transition] [AudioAnalysisToolkit] -> [SOPPyVFX]
    = may: provide bounded analysis traces for visual coupling

  - never: let render convenience overrule measured signal truth

## Intake

/ [audio_subject] -(SignalIntake)> [Metadata], [TimeSignal], [Uncertainty]

& [SignalIntake] is the first pass for bounding the signal under inspection
  + [metadata] is sample rate, bit depth, duration, channels, source, and render method
  + [time_signal] is the imported waveform data
  + [fault] is clipping, corruption, silence, truncation, or unsupported format

  = must: inspect [metadata]
  = must: preserve [time_signal]
  = must: detect obvious [fault]

  ? [fault exists]
    = must: emit [Uncertainty]

## Standard DSP Tools

& [WaveformScope] is the time-domain visibility tool
  + [contour] is the visible envelope and local motion of amplitude
  + [symmetry] is positive/negative balance
  + [clipping] is flattened peaks from amplitude overflow
  + [dc_offset] is persistent displacement from zero center

  ? [use_when: direct signal shape matters]
    = must: inspect [contour]
    = must: detect [clipping]
    = must: detect [dc_offset]

& [SpectrumFFT] is the frequency decomposition tool
  + [bin] is a bounded frequency region
  + [harmonic] is an integer-multiple partial
  + [noise_floor] is residual broadband energy
  + [resonance_peak] is concentrated energy at a band

  ? [use_when: tonal balance or frequency content matters]
    = must: transform [time_domain] -> [frequency_domain]
    = must: identify [resonance_peak]
    = must: identify [noise_floor]

& [Spectrogram] is the time-varying frequency visibility tool
  + [frame] is a short temporal analysis window
  + [onset] is rapid energy emergence
  + [decay] is energy dissipation over time
  + [motion] is changing spectral structure

  ? [use_when: sound evolves through time]
    = must: inspect [onset]
    = must: inspect [decay]
    = must: inspect [motion]

& [EnvelopeAnalysis] is the amplitude-shape tool
  + [attack] is rise time
  + [hold] is sustained plateau
  + [release] is fall time
  + [dynamic_range] is soft-to-loud span

  ? [use_when: impact, punch, softness, or decay matters]
    = must: measure [attack]
    = must: measure [release]
    = must: estimate [dynamic_range]

& [LoudnessMeter] is the perceived level tool
  + [peak] is maximum instantaneous level
  + [rms] is average power estimate
  + [lufs] is perceptual loudness measure

  ? [use_when: mix balance or normalization matters]
    = must: inspect [peak]
    = should: inspect [lufs]

& [PitchTracker] is the dominant pitch estimation tool
  + [fundamental] is lowest perceived stable tone
  + [drift] is movement of perceived pitch
  + [stability] is confidence of tracked tone

  ? [use_when: tonal cues, alarms, pings, or notes matter]
    = must: estimate [fundamental]
    = must: preserve [stability]

& [TransientDetector] is the sudden-event detection tool
  + [transient] is a rapid attack event such as click, hit, or impact
  + [density] is count of transient events over time

  ? [use_when: impacts or rhythmic events matter]
    = must: identify [transient]
    = should: estimate [density]

## Structural / Experimental Tools

& [ZetaEar] is the log-domain resonance and structural listening tool
  + [log_signal] is the transformed signal in logarithmic time or scale
  + [phasor_field] is the rotating contribution field of components
  + [structural_resonance] is coherent recurring energy pattern
  + [anomaly] is unexpected singularity, instability, or mismatch

  ? [use_when: resonance character, logarithmic structure, or novelty matters]
    = must: transform [audio_subject] into [log_signal]
    = must: inspect [structural_resonance]
    = should: detect [anomaly]

  - never: use [ZetaEar] as the sole loudness or clipping authority

& [ZetaOscilloscope] is the complex-plane waveform geometry tool
  + [trajectory] is the moving plotted path of the transformed signal
  + [loop] is repeated stable motion
  + [spray] is incoherent scattered motion
  + [attractor] is recurring geometric convergence

  ? [use_when: visual structural comparison or complexity judgment matters]
    = must: map signal into [trajectory]
    = should: classify [loop], [spray], or [attractor]

  - never: treat visual elegance alone as sound quality

## Comparison And Judgment

& [AudioComparison] is the pairwise or setwise evaluation tool
  + [candidate] is a signal under review
  + [reference] is the target or comparison signal
  + [distance] is measured difference across selected metrics
  + [match] is acceptable closeness under current purpose

  ? [use_when: selecting among renders]
    = must: compare [candidate] to [reference]
    = must: preserve metric basis
    = may: rank candidates

& [RenderJudgment] is the final decision layer
  + [clarity] is recognizability of intended cue
  + [impact] is strength of effect
  + [coherence] is fit with game or product style
  + [fatigue_risk] is annoyance under repetition
  + [masking_risk] is interference with other sounds

  ? [use_when: deciding keep, revise, or reject]
    = must: inspect [clarity]
    = must: inspect [coherence]
    = should: inspect [fatigue_risk]
    = should: inspect [masking_risk]

  ? [signal satisfies purpose]
    = must: emit [AcceptedRender]

  ? [signal fails but is repairable]
    = must: emit [ImprovementPlan]

  ? [signal materially fails]
    = must: emit [RejectedRender]

## Game Audio Presets

& [BattleshipPreset] is the profile for naval tactical game sounds
  + [sonar_ping] prioritizes clean onset, tonal identity, elegant decay
  + [missile_hit] prioritizes transient force, debris tail, low mud
  + [water_splash] prioritizes broadband burst and ripple decay
  + [ui_lockon] prioritizes short clarity and repeat comfort

  ? [use_when: analyzing battleship game assets]
    = should: invoke [SpectrumFFT]
    = should: invoke [EnvelopeAnalysis]
    = should: invoke [ZetaEar]
    = may: invoke [ZetaOscilloscope]

## Constraints

- never: confuse visualized transforms with direct audible truth
- never: optimize one metric while destroying intended game feel
- never: hide uncertainty when the signal purpose is unclear
- never: confuse analysis authority with waveform construction authority
- prefer: smallest tool set that resolves the active subject
- prefer: standard DSP first, structural tools second, judgment last
