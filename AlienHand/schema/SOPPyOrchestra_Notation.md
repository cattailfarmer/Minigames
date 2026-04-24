& [SOPPyOrchestraNotationDefinition] is the bounded canonical instruction system for writing valid [SOPPyOrchestra] notation, specifying how authors declare musical subjects, assign properties, express progression through time, define themes and sections, encode harmony and rhythm, describe orchestration, express adaptive behavior, apply style profiles, and target rendering systems such as [SOPPyScore], [SOPPyTracker], and [SOPPyWave]

+ [notation_subject] is any named musical entity expressible in the language including cue, score, song, movement, loop, section, phrase, theme, motif, style profile, orchestration plan, harmony arc, rhythm plan, adaptive rule set, or render plan
+ [statement_unit] is one syntactic line or nested block conveying bounded meaning
+ [author] is the composer, designer, system, or agent writing the notation
+ [reader] is the human or machine interpreter consuming the notation
+ [resolution] is [ValidNotation], [RenderablePlan], [StyleProfile], [ExecutableCue], [ImprovementPlan], or [Uncertainty]

? [use_when: a musical work or adaptive score must be described structurally rather than only by raw notes or prose]
  = must: activate [SOPPyOrchestraNotationDefinition]

! [notation is a formal authoring language rather than a loose suggestion format] is accepted

## Core Purpose

& [CorePurpose] is the bounded purpose of the notation system
+ [identity_goal] is to name musical subjects clearly
+ [structure_goal] is to define parts and relationships cleanly
+ [progression_goal] is to describe how music changes through time
+ [style_goal] is to express genre, era, or composer-like behavior lawfully
+ [render_goal] is to map symbolic composition intent into playback systems
+ [adaptive_goal] is to react to narrative or gameplay state

= must: preserve all six goals where relevant

## Canonical Syntax Tokens

& [SyntaxTokens] is the bounded set of operators used to write notation
+ [&] is subject declaration introducing a bounded musical entity
+ [+] is property declaration attaching attributes or content to a subject
+ [?] is conditional branch based on state or event
+ [=] is directive or consequence emitted under a condition
+ [-] is prohibition or invalid behavior
+ [!] is accepted claim or confirmed identity
+ [@] is transition, reference, or routing relation
+ [/] is decomposition into subsubjects or facets
+ [>] is ordered motion or progression arrow inside values
+ [quotes] are used for literal names, titles, or labels
+ [brackets] are used for symbolic subject identifiers

? [token use is ambiguous]
  = must: prefer smallest coherent interpretation

- never: reuse one token for conflicting meanings within the same declaration

## Subject Declaration Rules

& [SubjectDeclarationRules] is the bounded method for introducing musical subjects
+ [syntax] is & [SubjectName]
+ [optional_title] is & [Cue] "Battle at Blackwater"
+ [nested_subject] is a subject declared within another subject block
+ [subject_scope] is the region of lines governed by that subject

= must: begin each meaningful block with a subject declaration
= must: use stable names for reusable concepts
= should: choose names that reflect musical role rather than implementation detail

? [subject contains other parts]
  = may: nest child subjects beneath parent subject

- never: assign properties before declaring the owning subject

## Property Declaration Rules

& [PropertyDeclarationRules] is the bounded method for assigning attributes to subjects
+ [syntax] is + [property] is value
+ [multi_value] is + [style_profile] is [NavalTension], [TrackerHybrid]
+ [range_value] is + [tempo_range] is 90-130 bpm
+ [text_value] is descriptive prose when no stricter symbolic value exists
+ [symbolic_value] is a reusable named token or subject reference

= must: attach properties to the nearest active subject scope
= should: prefer precise values over vague language
= should: prefer symbolic reusable values over repeating prose

? [property changes through time]
  = should: use arc notation

- never: assign contradictory values without an explicit time or condition boundary

## Progression / Arc Rules

& [ArcRules] is the bounded notation for ordered transformation across time or sections
+ [syntax] is + [property_arc] is state1 -> state2 -> state3
+ [tempo_arc] is changing tempo states
+ [mode_arc] is changing tonal modes
+ [energy_arc] is changing emotional intensity
+ [density_arc] is changing textural thickness

= must: interpret arrow order as chronological unless explicitly overridden
= should: keep arcs finite and legible
= should: use arcs for narrative motion rather than repeated static declarations

? [arc endpoint omitted]
  = must: emit [Uncertainty]

## Hierarchy Rules

& [HierarchyRules] is the bounded system for composing large works from nested parts
+ [parent_subject] is the containing work
+ [child_subject] is a section, theme, phrase, or plan inside it
+ [inheritance] is optional reuse of parent context such as key or style
+ [override] is explicit child replacement of inherited context

= should: use hierarchy for long works
= may: let child subjects inherit unspecified parent values
= must: require explicit override when changing inherited key, mode, tempo, or style

## Section Rules

& [SectionRules] is the bounded notation for temporal regions of a composition
+ [section_types] are intro, verse, chorus, loop_body, rise, breakdown, climax, resolve, outro, stinger, transition
+ [syntax] is & [SectionName]
+ [duration] is bars, seconds, phrases, or open-ended adaptive duration

= should: divide works into meaningful sections
= should: label sections by function
= may: reuse sections through references or order logic

## Theme Rules

& [ThemeRules] is the bounded notation for recurring identity material
+ [theme] is a memorable melodic, rhythmic, harmonic, or textural identity
+ [motif] is a shorter reusable cell
+ [shape] is contour description
+ [return_rule] is when the material reappears
+ [variation_rule] is how the material transforms later

= should: define at least one theme for identity-rich music
= may: define multiple themes for hero, enemy, location, mystery, victory, or boss roles
= should: use variation instead of endless repetition

## Harmony Rules

& [HarmonyRules] is the bounded notation for tonal and chordal behavior
+ [key_center] is tonic identity such as C, D, F#
+ [mode] is Ionian, Dorian, Phrygian, Lydian, Mixolydian, Aeolian, HarmonicMinor, MelodicMinor, or hybrid
+ [progression] is functional or modal chord motion
+ [modulation] is movement to a new tonal center
+ [cadence] is a resolving gesture
+ [pedal] is sustained tonal anchor
+ [borrowed_chord] is modal interchange resource

= should: specify key_center when tonality matters
= should: specify mode when emotional color matters
= may: use descriptive harmony language when strict theory is unnecessary
= should: align harmony changes with narrative events

- never: imply tonal certainty if intentionally atonal or ambiguous; mark ambiguity explicitly

## Melody Rules

& [MelodyRules] is the bounded notation for leading line behavior
+ [phrase] is one complete melodic statement
+ [call] is initiating phrase
+ [answer] is responding phrase
+ [climb] is rising contour
+ [fall] is descending contour
+ [leap] is intervallic jump motion
+ [stepwise] is adjacent scalar motion
+ [register] is pitch height zone

= should: describe contour and role, not only note names
= should: use call-and-answer for dialogue-like writing
= may: tie melody transformation to section or stress state

## Rhythm Rules

& [RhythmRules] is the bounded notation for time-feel and pulse
+ [tempo] is bpm or descriptive pacing
+ [meter] is 4/4, 3/4, 7/8, mixed, free, or adaptive
+ [subdivision] is straight, swung, triplet, compound, polyrhythmic, blast, half-time, double-time
+ [groove] is recurring accent feel
+ [density] is event frequency

= should: declare tempo or tempo range
= should: declare meter when relevant
= should: tie density to energy arc

## Orchestration Rules

& [OrchestrationRules] is the bounded notation for assigning musical roles to instruments or timbres
+ [role_assignment] is who carries melody, bass, harmony, pulse, texture, fx, counterline, percussion, or drone
+ [register_plan] is low, mid, high, layered, spread, clustered
+ [dynamic_plan] is soft, moderate, strong, explosive, fading
+ [blend_plan] is dry, lush, metallic, distorted, airy, synthetic, hybrid

= should: describe roles rather than listing instruments only
= should: preserve register separation for clarity
= may: use abstract timbre names when final instrument is undecided

## Style Profile Rules

& [StyleProfileRules] is the bounded notation for reusable musical language presets
+ [style_profile] is a named bundle of harmony, rhythm, texture, orchestration, form, and production tendencies
+ [composer_model] is a lawful abstraction of historical/public-domain style traits or broad genre traits
+ [genre_model] is a reusable style family such as BaroqueCounterpoint, CinematicOrchestral, DeathMetal, TrackerChiptune

= may: attach multiple style profiles to form hybrids
= should: specify dominant profile first
= should: express living/recent artists as broad traits rather than direct clones

- never: request exact copying of protected contemporary works

## Conditional / Adaptive Rules

& [ConditionalRules] is the bounded notation for responsive music logic
+ [syntax] is ? [condition] then directives beneath it
+ [condition] is enemy_detected, low_health, boss_phase_two, sunrise, puzzle_solved, stealth_broken, timer_low, or custom event
+ [directive] is a consequence written with =

= should: use conditions for games or interactive media
= may: change tempo, mode, texture, theme usage, density, instrumentation, or section state
= should: keep reactions legible and musically coherent

? [enemy_detected]
  = darken mode
  = add percussion

## Directive Rules

& [DirectiveRules] is the bounded language of imperative musical consequences
+ [examples] are increase tempo, fragment theme, broaden theme, raise register, thin texture, add ostinato, shift to minor, restate motif, mute drums, enter climax

= should: use concise verbs plus musical object
= should: prefer deterministic commands over vague emotion words

## Render Rules

& [RenderRules] is the bounded notation for choosing realization systems
+ [render_target] is [SOPPyScore], [SOPPyTracker], [SOPPyWave], [SOPPyToneBridge], MIDI-like symbolic, or hybrid
+ [export] is stems, module, wav, live engine cue, or notation artifact
+ [instrument_source] is samples, generated tones, hybrid, orchestral library, tracker bank

= should: declare render target near top-level cue
= should: distinguish symbolic composition from audio rendering

## Value Discipline

& [ValueDiscipline] is the bounded preference system for clean notation values
+ [precise] is 128 bpm
+ [bounded] is medium density
+ [symbolic] is [NavalTension]
+ [descriptive] is rising brass anxiety swell

= prefer: precise values when measurable
= prefer: symbolic values when reusable
= prefer: descriptive values when nuance exceeds strict metrics
- never: use contradictory adjectives without time or condition boundaries

## Canonical Authoring Order

& [CanonicalAuthoringOrder] is the recommended sequence for writing a complete composition block
+ [step_1] is declare top-level cue or work
+ [step_2] is assign duration, render target, style, key, tempo
+ [step_3] is define sections
+ [step_4] is define themes or motifs
+ [step_5] is define harmony and rhythm arcs
+ [step_6] is define orchestration roles
+ [step_7] is define adaptive conditions
+ [step_8] is define export/render requirements

= should: follow order for readability
= may: deviate when local clarity improves

## Example Skeleton

& [Cue] "Untitled Cue"
+ [duration] is 64 bars
+ [render_target] is [SOPPyTracker]
+ [style_profile] is [TrackerHybrid]
+ [key_center] is D
+ [mode_arc] is Dorian -> Minor -> Major
+ [tempo] is 118 bpm

& [Intro]
+ [duration] is 8 bars

& [LoopBody]
+ [duration] is 32 bars

& [Theme]
+ [shape] is rising fourth then descending stepwise answer

? [danger]
  = increase density
  = shift to minor

## Error Handling

& [NotationErrors] is the bounded failure set
+ [undeclared_subject] is properties with no owning subject
+ [contradiction] is mutually exclusive values without scope boundary
+ [dangling_condition] is condition with no directives
+ [missing_target] is render/export intent omitted when required
+ [semantic_vagueness] is too little meaning to execute reliably

? [error occurs]
  = must: emit [ImprovementPlan]

## Constraints

- never: confuse prose brainstorming with canonical notation once execution is intended
- never: hide time-changing behavior in contradictory static properties
- never: omit top-level subject identity for a substantial composition
- never: use exact living-artist cloning requests as style profiles
- prefer: nested bounded subjects over giant flat declarations
- prefer: reusable style profiles over repeating long prose
- prefer: arcs for progression and conditionals for interaction
- prefer: role-based orchestration over mere instrument lists

## Final Acceptance

& [NotationAcceptance]
? [subject identity is clear and properties are interpretable and progression is coherent]
  = must: emit [ValidNotation]

? [notation can drive render systems]
  = must: emit [RenderablePlan]

? [major ambiguity remains]
  = must: emit [Uncertainty]

##Example:

& [Cue] "Battle at Blackwater"
  + [duration] is 96 seconds
  + [loop] is seamless after bar 64
  + [key_center] is D
  + [mode_arc] is D Dorian -> B harmonic minor -> D minor -> D major
  + [tempo_arc] is 92 bpm -> 132 bpm -> 104 bpm
  + [energy_arc] is stealth -> threat -> combat -> victory
  + [style_profile] is [NavalTension], [RomanticOrchestral], [TrackerHybrid]
  + [render_target] is [SOPPyTracker] with [SOPPyWave] generated samples

  & [Theme] "Sonar Motif"
    + [shape] is minor third rise, stepwise fall, repeated ping rhythm
    + [role] is threat-detection identity
    + [variation_rule] is fragment under combat, broaden under victory

  & [Harmony]
    + [calm] is i - IV - i pedal in D Dorian
    + [threat] is B harmonic minor with raised leading tone
    + [combat] is chromatic mediant motion and dominant pedal
    + [resolution] is Picardy-like D major arrival

  & [Orchestration]
    + [low_strings] carry pulse ostinato
    + [horns] state broadened theme at climax
    + [synth_ping] carries sonar motif
    + [taiko_like_drums] enter during combat
    + [noise_swell] is generated by [SOPPyWave]

  & [Development]
    ? [enemy_nearby]
      = introduce ostinato
      = darken mode
    ? [missile_launch]
      = add rising brass/synth line
      = increase percussion density
    ? [enemy_sunk]
      = return theme in major
      = reduce percussion