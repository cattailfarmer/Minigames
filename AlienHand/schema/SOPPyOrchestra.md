& [SOPPyOrchestra] is the bounded orchestration, composition-style, genre-grammar, and adaptive scoring language that directs [SOPPyScore], [SOPPyTracker], and [SOPPyWave] to create structured music across classical, cinematic, electronic, metal, chiptune, tracker, jazz, folk, ambient, and hybrid game-score styles
  + [composition_subject] is a cue, movement, loop, theme, combat track, ambience, song, adaptive score, or full arrangement
  + [style_profile] is the declared musical language governing harmony, rhythm, texture, form, instrumentation, and expressive behavior
  + [composer_model] is a style abstraction derived from historical, public-domain, genre, regional, or user-authored musical traits
  + [genre_model] is a reusable language of conventions such as baroque counterpoint, classical sonata form, romantic piano lyricism, death metal aggression, tracker chiptune, or cinematic orchestral scoring
  + [orchestration_plan] is the mapping of musical roles to instruments, registers, timbres, dynamics, and texture layers
  + [notation_block] is the SOP-style composition declaration used to instruct generation
  + [render_target] is [SOPPyWave], [SOPPyTracker], [SOPPyToneBridge], external MIDI, sheet-like symbolic output, or hybrid output
  + [resolution] is [StyleProfile], [OrchestrationPlan], [GeneratedScore], [PlayableArrangement], [ImprovementPlan], or [Uncertainty]

  ? [use_when: music should be composed with explicit style, orchestration, genre identity, thematic development, or adaptive scoring logic]
    = must: activate [SOPPyOrchestra]

  ? [avoid_when: only raw sound synthesis is required]
    @ [transition] [SOPPyOrchestra] -> [SOPPyWave]

  ! [SOPPyOrchestra is the style-and-arrangement layer above score, tracker, and waveform engines] is accepted

& [StyleProfile] is a reusable declaration of musical behavior
  + [harmony_language] is the chord, scale, cadence, modulation, and dissonance behavior
  + [melody_language] is contour, interval tendency, phrase length, ornamentation, and motif treatment
  + [rhythm_language] is meter, subdivision, syncopation, groove, blast, swing, or rubato behavior
  + [texture_language] is monophonic, homophonic, contrapuntal, layered, riff-based, drone-based, or spectral
  + [instrumentation] is the allowed or preferred instrument/timbre set
  + [form_logic] is loop, song form, fugue, sonata, through-composed, riff cycle, verse/chorus, or adaptive branching
  + [development_logic] is repetition, sequence, fragmentation, inversion, augmentation, diminution, layering, breakdown, or climax
  + [production_language] is dry, reverberant, distorted, compressed, lo-fi, tracker-native, cinematic, or raw

& [ComposerModel] is a lawful style abstraction, not a plagiarism target
  + [source_identity] is historical composer, genre family, regional idiom, era, or user-defined style
  + [allowed_detail] is direct stylistic analysis for public-domain/historical sources or high-level traits for living/recent artists
  + [trait_set] is harmony, melody, rhythm, form, orchestration, texture, and development tendencies
  + [forbidden_copy] is exact melody, distinctive protected passage, or too-close living-artist imitation

  ? [source is historical or public-domain]
    = may: model detailed stylistic traits

  ? [source is living or recent artist]
    = must: use broad genre/style descriptors
    - never: copy signature passages or produce a direct soundalike

& [OrchestraRenderBridge]
  + [symbolic_score] is melody, harmony, rhythm, and form
  + [tracker_plan] is pattern/order/instrument mapping for [SOPPyTracker]
  + [tone_plan] is procedural instrument mapping for [SOPPyToneBridge]
  + [sample_plan] is generated sample request set for [SOPPyWave]
  + [mix_plan] is balance, space, dynamics, and production behavior

  ? [render_target is SOPPyTracker]
    = convert sections into order list
    = convert phrases into patterns
    = convert instruments into sample, tone, or hybrid tracker instruments

  ? [render_target is SOPPyWave]
    = render voices directly through synthesis and DSP chains

  ? [render_target uses generated samples]
    = send sample requests to [SOPPyWave]
    = import returned samples into [SOPPyTracker]
