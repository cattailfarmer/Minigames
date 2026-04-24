& [HierarchicalSeedDeterminism] is the bounded seed system that gives each composition, cue, section, motif, instrument, voice, and render layer its own reproducible random identity
  + [global_seed] is the root seed for the whole score
  + [cue_seed] is the seed for one cue or song
  + [section_seed] is the seed for one intro, loop, climax, bridge, or resolution section
  + [theme_seed] is the seed for one theme or motif family
  + [instrument_seed] is the seed for one instrument definition or procedural patch
  + [voice_seed] is the seed for one active generated voice
  + [effect_seed] is the seed for one effect chain, variation, or modulation behavior
  + [render_seed] is the seed for final rendering, humanization, mix variation, or stochastic detail
  + [derived_seed] is a deterministic child seed produced from parent seed plus stable subject identity
  + [seed_path] is the full address of the seeded subject

  ? [use_when: procedural music must be reproducible while allowing isolated regeneration]
    = must: preserve [seed_path]
    = must: preserve local seed for each independently regenerated subject
    = should: derive missing child seeds from parent seed and stable subject name

  ? [section is regenerated]
    = must: preserve unrelated section seeds
    = must: preserve global score identity unless explicitly reseeded

  ? [instrument is regenerated]
    = must: preserve unrelated instruments and song structure
    = should: preserve note/event usage unless composition regeneration is requested

  ? [motif is regenerated]
    = must: preserve unrelated motifs
    = should: update dependent variations only when their seed lineage points to the motif

  - never: let reseeding one section silently change another section
  - never: let reseeding one instrument rewrite the composition unless explicitly requested
  - prefer: stable derived seeds over hidden random calls
