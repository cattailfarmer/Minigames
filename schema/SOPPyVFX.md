& [SOPPyVFX] is the bounded Python visual effects, animation, rendering, procedural art, scene composition, and analysis-coupled visual generation system for sprites, particles, shaders, backgrounds, UI motion, cinematic feedback, and live game presentation
  + [visual_subject] is a sprite, animation, effect, background, material, scene layer, UI element, camera event, rendered frame sequence, or visual processing chain under generation or transformation
  + [intent] is the declared purpose, appearance, motion, emphasis, readability target, and stylistic constraint of the desired visual result
  + [frame_buffer] is the image, layer stack, or sequence of rendered frames produced, transformed, or preserved by the system
  + [render_space] is pixel space, world space, screen space, UI space, logics space, or composited hybrid space
  + [resolution] is the pixel dimensions and density of the visual artifact or runtime output
  + [frame_rate] is the temporal rate of frame change for animation or simulation
  + [palette] is the bounded color field, ramps, gradients, and accent rules allowed within the active style
  + [layer_stack] is the ordered arrangement of background, midground, gameplay objects, effects, overlays, UI, and post-process contributions
  + [render_mode] is [OfflineAssetRender], [RuntimeEffect], [LiveComposite], [ShaderDriven], [ProceduralGeneration], [BatchVariation], or [AnalysisCoupledRender]
  + [source_set] is [ShapeSource], [SpriteSource], [TextureSource], [TileSource], [ParticleSource], [ProceduralField], [InputDrivenMotion], and [HybridSource]
  + [process_set] is [SilhouetteShaping], [PaletteMapping], [MaterialLayering], [ParticleSystem], [AnimationSystem], [ShaderStage], [LightingStage], [DistortionStage], [CameraFX], [SceneComposition], [UIFX], [PostProcessStage], and [PerformanceBudget]
  + [artifact_set] is [SpriteArtifact], [SpriteSheet], [AnimationClip], [EffectPreset], [MaterialPreset], [ScenePreset], [LayerPlan], [VariationSet], [AnalysisTrace], and [ImprovementPlan]
  + [resolution_path] is [RenderedVisual], [LiveEffect], [AcceptedRender], [TransformChain], [VariationSet], [RejectedRender], [ImprovementPlan], or [Uncertainty]

  ? [use_when: a visual game artifact, animation, effect, or scene presentation must be generated, transformed, composed, or iteratively refined]
    = must: activate [SOPPyVFX]

  ? [avoid_when: only conceptual art direction exists and no bounded visual artifact must yet be built]
    @ [transition] [SOPPyVFX] -> [Planner]
    = may: defer implementation while preserving intent

  ! [SOPPyVFX is the actuation layer for visual intention] is accepted
    @ [support] [SOPPyVFX] may consume analysis traces from [AudioAnalysisToolkit] or [SOPPyWave]

## Tool Realization

& [SOPPyVFXTooling] is the bounded Python tool realization layer for [SOPPyVFX]
  + [image_stack] is Pillow-, NumPy-, or OpenCV-style image construction and transformation
  + [procedural_stack] is noise-, geometry-, and field-generation tooling for procedural assets
  + [animation_stack] is frame-sequence and timeline tooling for sprite or UI animation
  + [gpu_stack] is shader-capable runtime tooling such as pygame, moderngl, or equivalent render hosts
  + [export_stack] is sprite-sheet, atlas, frame-sequence, and metadata emission tooling
  + [budget_guard] is profiling, frame-cost estimation, and graceful fallback handling

  ? [render_mode is OfflineAssetRender or BatchVariation]
    = should: prefer [image_stack], [procedural_stack], and [export_stack]

  ? [render_mode is RuntimeEffect], [LiveComposite], or [ShaderDriven]
    = should: prefer [gpu_stack]
    = must: preserve [budget_guard]

  ? [analysis-coupled correction is active]
    = should: invoke [VisualAnalysisToolkit]

## Core Contract

& [SOPPyVFXContract] is the minimal executable shape of a valid visual generation or transformation request
  + [input] is the source image, geometry, procedural recipe, state data, motion signal, or scene context entering the system
  + [constraints] are the declared limits on performance cost, readability, palette, size, frame budget, layering, camera relation, or style
  + [target] is the intended visible result
  + [verification] is the post-render or live-runtime check that the result serves its role

  = must: identify [input]
  = must: identify [target]
  = must: identify [render_mode]
  = must: preserve [constraints]
  = must: emit [verification] path or [Uncertainty]

  ? [input is absent and generation is intended]
    = must: construct [input] from [source_set]

  ? [target is visually unclear]
    = must: emit [Uncertainty]

## Intent Declaration

/ [visual_subject] -(IntentDeclaration)> [TargetAppearance], [MotionIntent], [ReadabilityConstraints], [References], [Uncertainty]

& [IntentDeclaration] is the pass that turns a vague visual idea into bounded renderable intent
  + [target_appearance] is the intended shape language, color behavior, material feel, density, intensity, and atmosphere
  + [motion_intent] is the intended timing, force, easing, direction, persistence, and decay of visible change
  + [readability_constraints] are pixel scale, distance legibility, screen occupancy, interface separation, multiplayer visibility, and clutter limits
  + [references] are style anchors, prior assets, exemplar effects, palette precedents, or user-described comparisons
  + [uncertainty] is unresolved aesthetic, spatial, or technical ambiguity

  = must: identify [target_appearance]
  = must: identify [motion_intent]
  = must: identify [readability_constraints]
  = should: preserve [references]
  = must: preserve [uncertainty]

  ? [intent is style-rich but technically underspecified]
    = should: infer ordinary defaults
    = must: mark inferred defaults as [assumption]

  ? [intent is technically precise but aesthetically vague]
    = must: preserve aesthetic ambiguity as [uncertainty]

## Render Modes

& [OfflineAssetRender] is non-runtime generation for durable visual artifacts such as sprites, backgrounds, icon sets, and animation sheets
  ? [use_when: the artifact can be rendered ahead of time]
    = must: prefer determinism, reproducibility, and export clarity

& [RuntimeEffect] is frame-evolving visual generation bound to gameplay state or simulation
  ? [use_when: the effect must react live to game conditions]
    = must: preserve predictable runtime cost

& [LiveComposite] is the dynamic layering of multiple active visual contributions into one scene presentation
  ? [use_when: separate layers, effects, and UI must coexist in time]
    = must: preserve layer order and separation

& [ShaderDriven] is GPU or equivalent programmable transformation of rendered visual fields
  ? [use_when: per-pixel or screen-space transformation is more appropriate than sprite animation]
    = must: preserve parameter control and performance awareness

& [ProceduralGeneration] is rule-driven creation of textures, particles, patterns, or visual fields from declared structure
  ? [use_when: repetition, variation, runtime adaptability, or style coherence favors construction over stored assets]
    = must: preserve bounded randomness and controllable seeds

& [BatchVariation] is controlled generation of many related visual candidates
  ? [use_when: families of explosions, splashes, icons, or backgrounds are needed]
    = must: preserve family resemblance
    = must: vary only declared degrees of freedom

& [AnalysisCoupledRender] is visual generation guided by immediate measurement and iterative correction
  ? [use_when: the output must converge toward clarity, prominence, motion quality, or style targets through analysis]
    = must: invoke [VisualAnalysisToolkit] after each admissible pass
    = should: prefer the smallest coherent change that improves fit

## Source Set

& [ShapeSource] is a primitive geometric or contour-derived generation source
  + [primitive] is circle, line, arc, rectangle, polygon, spline, burst, ring, cone, ribbon, or custom contour
  + [stroke] is edge thickness or line treatment
  + [fill] is solid, gradient, noise-filled, or material-based interior
  + [deformation] is controlled warping or irregularization

  ? [use_when: crisp silhouettes, UI marks, tactical overlays, or procedural effect seeds are needed]
    = must: declare [primitive]

& [SpriteSource] is an image or sprite asset entering transformation or composition
  + [sprite] is the source bitmap or bounded visual frame
  + [pivot] is the anchor point for motion or rotation
  + [trim] is preserved or removed transparent margin
  + [alpha] is the transparency field

  ? [use_when: stored 2D assets are transformed or reused]
    = must: preserve source lineage

& [TextureSource] is a repeated or bounded image field used for materials, fills, noise, or backgrounds
  + [texture] is the image field
  + [tileability] is seamless repeat compatibility
  + [scale] is mapping density
  + [orientation] is mapped directional relation

  ? [use_when: materials, surface detail, or patterned fills are needed]
    = should: preserve intended [tileability]

& [TileSource] is grid-aligned art intended for modular map or board composition
  + [tile] is a bounded cell-sized visual asset
  + [autotile_rule] is the neighbor-sensitive composition behavior
  + [grid_relation] is the tile’s alignment to gameplay space

  ? [use_when: board games, strategy maps, or modular scenes are built]
    = must: preserve [grid_relation]

& [ParticleSource] is a seed element emitted repeatedly into a simulated effect field
  + [particle] is the emitted visual unit
  + [spawn_rate] is particles per interval
  + [lifetime] is visible persistence
  + [velocity] is starting motion vector
  + [drag] is motion slowdown
  + [rotation] is angular behavior
  + [size_curve] is scale change through lifetime
  + [color_curve] is color or alpha change through lifetime

  ? [use_when: sparks, smoke, water spray, debris, glow motes, snow, or magical fields are needed]
    = must: preserve [lifetime]
    = should: preserve [size_curve]

& [ProceduralField] is a generated image field from noise, rules, simulation, or mathematical structure
  + [noise_type] is value, Perlin, simplex, Worley, FBM, cellular, curl, or custom field
  + [seed] is the deterministic variation anchor
  + [threshold] is a boundary rule for discrete extraction
  + [flow] is directional or field-driven motion pattern

  ? [use_when: clouds, water, fog, terrain masks, distortions, or animated fields are needed]
    = must: declare [seed]

& [InputDrivenMotion] is a visual source driven by gameplay, control input, audio, or physical state
  + [driver] is the source state
  + [mapping] is the relation from state to visual change
  + [responsiveness] is temporal closeness between cause and visible effect

  ? [use_when: UI, gameplay feedback, or reactive VFX are state-coupled]
    = must: preserve explainable [mapping]

& [HybridSource] is a composed source formed from multiple source types
  ? [use_when: no single source adequately expresses the target visual]
    = must: preserve identity of major contributors

## Visual Primitive Shaping

& [SilhouetteShaping] is the process that establishes readable contour and mass before detail
  + [contour] is the outer edge or visible boundary
  + [mass] is the felt visual weight distribution
  + [negative_space] is the empty region that clarifies the subject
  + [read_distance] is the expected viewing scale

  ? [use_when: a new sprite, icon, effect, or object must be recognizable]
    = must: establish [contour]
    = must: preserve [read_distance]
    = should: preserve [negative_space]

  - never: add internal detail before silhouette readability survives

& [PaletteMapping] is the controlled assignment of color, ramps, highlights, and emissive accents
  + [base_ramp] is the main tonal progression
  + [accent_color] is the emphasis hue for critical information
  + [temperature] is the warm-cool balance of the image
  + [value_range] is the light-dark span
  + [contrast_budget] is the bounded visual intensity available before clutter emerges

  ? [use_when: color is carrying readability, style, or emotional identity]
    = must: preserve [contrast_budget]
    = should: distinguish informational accents from atmospheric color

## Material Layering

& [MaterialLayering] is the composition of base surfaces, highlights, wear, glow, distortion, and overlays into one coherent material expression
  + [base_material] is the underlying surface identity
  + [specular_behavior] is highlight response
  + [roughness_equivalent] is the felt softness or sharpness of reflection
  + [emissive_layer] is self-lit contribution
  + [damage_layer] is crack, scorch, rust, wetness, or wear overlay

  ? [use_when: ships, metal, water, holograms, glass, energy, or interface materials need defined surface logic]
    = must: preserve major material identity
    = should: keep layers semantically distinct

## Particle System

& [ParticleSystem] is bounded emission and simulation of many small visual units
  + [emitter] is the spatial source of particles
  + [burst] is a one-time dense emission
  + [continuous_emission] is ongoing particle release
  + [inherit_velocity] is borrowed motion from parent object
  + [collision_rule] is interaction with surfaces or fields
  + [fade_rule] is alpha or visibility decline
  + [sorting] is depth or layer handling among particles

  ? [use_when: motion-rich ephemeral effects are needed]
    = must: preserve [sorting]
    = should: preserve [inherit_velocity] when parent motion matters

## Animation System

& [AnimationSystem] is the bounded control of visual change through time
  + [keyframe] is a declared state at a specific time
  + [inbetween] is interpolated movement between keyframes
  + [easing] is the rate curve of change
  + [loop] is repeated sequence
  + [state_transition] is motion between semantic states
  + [secondary_motion] is subordinate follow-through motion
  + [frame_hold] is deliberate stillness within motion

  ? [use_when: sprites, UI, particles, or objects must move through deliberate time structure]
    = must: preserve intended [easing]
    = should: preserve [secondary_motion]
    = should: distinguish [loop] from one-shot motion

## Sprite Sheet Animation

& [SpriteSheetAnimation] is frame-based animation using discrete rendered images
  + [frame_count] is number of frames in the sequence
  + [frame_timing] is duration assigned per frame
  + [atlas_layout] is the spatial arrangement of frames
  + [smear] is intentionally stretched or exaggerated transition drawing

  ? [use_when: handcrafted frame identity is more important than continuous transform math]
    = must: preserve [frame_timing]
    = should: use [smear] when speed must feel stronger than strict realism

## Skeletal Animation

& [SkeletalAnimation] is hierarchical transform animation of connected parts
  + [bone] is a transform-bearing structural node
  + [rig] is the connected set of bones and controls
  + [skin] is the visual geometry attached to the rig
  + [constraint] is a relation limiting motion

  ? [use_when: modular articulated motion is needed]
    = must: preserve hierarchy integrity
    = should: preserve deformation readability

## Shader Stage

& [ShaderStage] is programmable per-pixel, per-vertex, or screen-space transformation
  + [shader_type] is material, particle, screen-space, distortion, lighting, or post-process shader
  + [uniform_set] is the runtime parameter set feeding the shader
  + [mask] is the bounded region where the shader applies
  + [blend_mode] is additive, alpha, multiply, screen, overlay, min, max, or custom composition rule
  + [time_driver] is the temporal input to animation logic

  ? [use_when: runtime appearance or transformation is cheaper or richer in shader form]
    = must: declare [blend_mode]
    = must: preserve [mask] boundary when selective application matters

## Lighting Stage

& [LightingStage] is simulated or stylized illumination shaping scene readability and mood
  + [key_light] is primary emphasis light
  + [fill_light] is secondary softening light
  + [rim_light] is contour-separating edge light
  + [ambient_field] is baseline scene illumination
  + [shadow_rule] is how occlusion reduces visible light

  ? [use_when: depth, drama, separation, or material readability is affected by illumination]
    = should: preserve gameplay readability over purely cinematic mood

## Distortion Stage

& [DistortionStage] is spatial or sampling deformation of underlying visual content
  + [refraction] is displacement by a refractive field
  + [heat_haze] is shimmering local displacement
  + [shockwave] is radial distortion burst
  + [pixelation] is reduced sampling granularity
  + [glitch] is discontinuous displacement, color split, or temporal misalignment

  ? [use_when: energy, impact, damage, heat, water, or digital instability must be shown]
    = must: preserve target readability when the effect is informationally adjacent

## Camera FX

& [CameraFX] is bounded transformation of the viewer frame rather than only world objects
  + [shake] is rapid camera offset or rotation
  + [zoom_pulse] is brief scale change
  + [tilt] is angular viewer motion
  + [focus_shift] is depth or attention redirection
  + [freeze_frame] is momentary time hold for emphasis
  + [hit_stop] is extremely short motion arrest to increase felt impact

  ? [use_when: impact, tension, arrival, damage, or emphasis must affect whole-frame perception]
    = must: preserve player comfort and clarity
    = should: keep [shake] bounded by event importance

## UIFX

& [UIFX] is visual feedback coupled to interface meaning and user interaction
  + [hover] is a rollover response
  + [press] is an activation response
  + [selection] is state-confirming emphasis
  + [cooldown] is time-based readiness display
  + [warning] is urgency-bearing visible cue
  + [notification] is informational arrival effect

  ? [use_when: interface state must be felt, not only read]
    = must: preserve informational clarity
    = should: minimize fatigue under repetition

## Scene Composition

& [SceneComposition] is the bounded organization of visible parts into one coherent field
  + [background] is distant or low-priority scene support
  + [midground] is active playable or interactable field
  + [foreground] is front-layer framing or emphasis content
  + [focal_region] is where user attention should land first
  + [depth_cue] is any relation that separates nearer and farther content
  + [parallax] is differential movement across depth layers
  + [occlusion_logic] is visibility blocking relation among layers

  ? [use_when: multiple visual parts must coexist without confusion]
    = must: declare [focal_region]
    = must: preserve [occlusion_logic]
    = should: use [parallax] when depth improves orientation

## Background System

& [BackgroundSystem] is the bounded generation of low-competition scene support behind gameplay
  + [horizon] is the distant structural boundary
  + [atmosphere] is fog, haze, tint, or air perspective
  + [support_pattern] is repeated low-salience structure
  + [motion_level] is the amount of visible background change permitted before distraction

  ? [use_when: a scene needs atmosphere without fighting the active subject]
    = must: preserve low competition with gameplay foreground
    = should: preserve [motion_level] within distraction limits

## Post Process Stage

& [PostProcessStage] is final whole-frame transformation applied after composition
  + [color_grade] is overall scene color shaping
  + [bloom] is high-value light spread
  + [vignette] is edge darkening or focus framing
  + [chromatic_aberration] is channel separation near edges
  + [film_grain] is texture overlay
  + [scanline] is display-style pattern overlay
  + [tone_map] is high-to-display-range compression
  + [outline_pass] is whole-scene edge emphasis

  ? [use_when: global presentation identity or polish depends on full-frame treatment]
    = must: preserve gameplay legibility
    = should: avoid redundant stacking of strong full-frame effects

## Motion Fields

& [MotionField] is the bounded representation of direction, speed, force, and flow across visible elements
  + [vector] is local motion direction and magnitude
  + [flow_map] is spatially varying motion direction field
  + [drag] is motion loss through time
  + [impact_direction] is the visible directional implication of a hit or force event

  ? [use_when: effects must feel physically or stylistically directional]
    = must: preserve [impact_direction] when gameplay feedback depends on it

## Event Feedback

& [EventFeedback] is the visible response to gameplay state changes
  + [hit_confirm] is confirmation that an attack or action connected
  + [miss_confirm] is confirmation that an attempt failed
  + [critical_event] is a high-importance game state change
  + [charge_state] is buildup toward a release event
  + [cooldown_state] is visual recovery after use

  ? [use_when: gameplay communication is carried partly by visible effect]
    = must: distinguish [hit_confirm] from [miss_confirm]
    = must: preserve priority of [critical_event] over ordinary effects

## Multi-Screen Composition

& [DualScreenPresentation] is the bounded composition subject for different screens showing different but related game states
  + [screen_role] is the semantic job of a given display
  + [cross_screen_relation] is the justified relation between visual states across displays
  + [attention_split] is the user’s divided perceptual burden
  + [handoff] is the movement of attention or state between screens

  ? [use_when: multiple displays show different game states or player views]
    = must: preserve [screen_role]
    = must: preserve clear [cross_screen_relation]
    = should: limit unnecessary simultaneous peak intensity on all screens

## Performance Budget

& [PerformanceBudget] is the bounded runtime cost guard for visual generation and composition
  + [fill_rate_cost] is pixel-processing load
  + [draw_call_cost] is submission and batching overhead
  + [simulation_cost] is CPU or GPU update burden
  + [memory_cost] is storage and bandwidth burden
  + [overdraw] is repeated rendering of obscured pixels
  + [fallback] is the lower-cost substitute path

  ? [use_when: the effect or scene exists at runtime]
    = must: inspect [fill_rate_cost]
    = must: inspect [simulation_cost]
    = should: inspect [overdraw]
    = should: preserve [fallback]

  - never: let ornamental VFX silently break the frame budget of gameplay-critical scenes

## Visual Analysis Toolkit

& [VisualAnalysisToolkit] is the bounded toolkit for inspecting, comparing, and judging generated or rendered visuals
  + [observed_frame] is the frame or sequence under inspection
  + [contour] is visible boundary structure
  + [contrast] is meaningful difference in value, hue, motion, or density
  + [prominence] is what stands out first
  + [separation] is what keeps adjacent visual roles from collapsing together
  + [pattern] is repeated structure or cadence
  + [direction] is implied or explicit motion tendency
  + [noise] is non-contributing visual activity or clutter
  + [coherence] is style and purpose fit across parts

  ? [use_when: a result must be judged beyond raw render completion]
    = must: inspect [contour]
    = must: inspect [contrast]
    = must: inspect [prominence]
    = must: inspect [separation]
    = should: inspect [noise]
    = should: inspect [coherence]

  ? [motion exists]
    = should: inspect [direction] and timing quality

## Analysis Coupling

& [AnalysisCoupling] is the feedback bridge from generated visuals into measurement and refinement
  + [analysis_trace] is the recorded results from [VisualAnalysisToolkit]
  + [mismatch] is the distance between intended and observed result
  + [repair_step] is the next justified visual change

  ? [use_when: visual output must converge toward a declared target]
    = must: pass [frame_buffer] to [VisualAnalysisToolkit]
    = must: preserve [analysis_trace]
    = should: identify [mismatch]
    = should: emit [repair_step]

## Preset Authoring

& [PresetAuthoring] is the durable capture of visual configurations for reuse
  + [preset_name] is the retrievable identity of the asset or effect family
  + [parameter_state] is the active value set for all relevant controls
  + [usage_context] is gameplay VFX, UI animation, background generation, material styling, or cinematic feedback

  ? [use_when: an effect or style should be reused]
    = must: preserve [parameter_state]
    = should: preserve [usage_context]

## Game FX Production

& [GameVFXProduction] is the bounded subject for generating durable game-facing visual effects
  + [event_subject] is hit confirm, splash, trail, explosion, cursor claim, handoff cue, or UI alert
  + [effect_family] is the coherent set of related visual artifacts serving one game identity
  + [variation_budget] is the declared amount of acceptable candidate spread

  ? [use_when: a game needs sprites, particles, screen cues, or UI effects]
    = must: preserve [effect_family]
    = should: invoke [BatchVariation] only across declared dimensions
    = should: invoke [VisualAnalysisToolkit] before final acceptance

## Variation Engine

& [VariationEngine] is controlled mutation of a visual plan into nearby alternatives
  + [mutation_space] is the set of allowed varying parameters
  + [mutation_depth] is the magnitude of change
  + [family_anchor] is the preserved identity of the visual family
  + [selection_score] is the measured or judged desirability of a candidate

  ? [use_when: many related sprites, impacts, flashes, or backgrounds are needed]
    = must: preserve [family_anchor]
    = must: constrain [mutation_space]
    = should: invoke [VisualAnalysisToolkit] for candidate ranking

## Export

& [SpriteArtifact] is the durable emitted visual artifact
  + [format] is png, webp, sprite sheet, texture atlas, shader preset, or frame sequence
  + [alpha_policy] is premultiplied, straight, or opaque-only export behavior
  + [metadata] is the attached descriptive record for the artifact

  ? [use_when: output must become a durable asset]
    = must: declare [format]
    = should: preserve [metadata]

## Battleship Presets

& [BattleshipVFXPresets] is the preset family for naval tactical game presentation
  + [sonar_ping] is a ring-based or shader-based scan pulse with disciplined contrast and low clutter
  + [missile_trail] is a directional thrust or contrail effect with clear origin-to-target motion
  + [water_splash] is a spray, plume, and ripple effect with readable center point
  + [impact_flash] is a brief high-prominence confirmation event
  + [sink_event] is a larger layered composition using debris, foam, smoke, and camera emphasis
  + [ui_lockon] is a repeatable tactical indicator with low fatigue risk
  + [fog_of_war] is a bounded concealment layer preserving strategic clarity

  ? [use_when: a battleship-style game needs cohesive visual presentation]
    = should: preserve board readability above spectacle
    = should: distinguish [impact_flash] from [water_splash]
    = may: invoke [DualScreenPresentation] when multiple displays show different player states

## AlienHand Presets

& [AlienHandUIPresets] is the preset family for multi-user same-machine platform identity and feedback
  + [foreign_cursor] is a cursor or pointer identity distinct from local player control
  + [control_conflict] is a visible cue for simultaneous or competing input
  + [screen_claim] is a signal that a display belongs to a specific player state
  + [handoff_glow] is a transition cue when control or focus shifts

  ? [use_when: the platform must communicate multiple independent agencies on one machine]
    = should: preserve player differentiation without visual overload

## Quality Judgment

& [SOPPyVFXJudgment] is the final acceptance layer for generated or processed visuals
  + [clarity] is recognizability of intended role
  + [readability] is successful perception at intended size and speed
  + [coherence] is fit with the surrounding visual system
  + [impact] is felt emphasis appropriate to the event
  + [noise_risk] is clutter or unnecessary attention capture
  + [fatigue_risk] is annoyance under repetition
  + [performance_risk] is runtime cost threatening stable presentation

  ? [use_when: deciding whether a visual result is acceptable]
    = must: inspect [clarity]
    = must: inspect [readability]
    = must: inspect [coherence]
    = must: inspect [performance_risk]

  ? [result satisfies purpose and constraints]
    = must: emit [AcceptedRender]

  ? [result fails but is correctable]
    = must: emit [ImprovementPlan]

  ? [result materially fails]
    = must: emit [RejectedRender]

## Constraints

- never: mistake detail density for readability
- never: let post-process identity erase gameplay clarity
- never: allow spectacle to collapse layer separation
- never: optimize one asset in isolation while breaking scene coherence
- never: treat a renderer choice as justification for an effect that lacks gameplay purpose
- prefer: silhouette first, motion second, detail third
- prefer: the smallest coherent visual system that fully communicates the event
- prefer: bounded variation over noisy randomness when family identity matters
- prefer: analysis-coupled refinement for signature effects and shared style anchors
