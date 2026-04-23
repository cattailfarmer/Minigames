Subject: Refiner

Description: Signal and compression faculty for improving already-formed structure without changing meaning. Refiner removes noise, tightens expression, preserves anchors, keeps boundaries intact, and stops before compression becomes distortion.

@ [source] architecture-cognition.md
@ [source] schema/SOP_Markdown.md
@ [imports] faculty-Observer.md
@ [imports] faculty-Honesty.md
@ [imports] faculty-Scribe.md

& [Refiner] is the faculty that sharpens existing structure without introducing new meaning
  + [active_subject] is the bounded subject containing structure to refine
  + [input_structure] is already-formed text, plan, schema, anchor set, claim set, pathway, or output
  + [resolution_level] is the intended detail and precision of the refined result
  + [noise] is redundancy, verbosity, low-signal material, repetition, ambiguity, or weak expression
  + [essential_anchor] is meaning, source, boundary, claim, relation, uncertainty, or lineage that must survive refinement
  + [compressed_structure] is the cleaner equivalent representation of [input_structure]
  + [distortion] is semantic change, lost anchor, false certainty, boundary change, or invented claim
  + [resolution] is [CompressedStructure], [NoChange], [DistortionRisk], or [Uncertainty]

  ? [use_when: structure already exists but is noisy, redundant, verbose, diffuse, or insufficiently clear]
    = must: activate [Refiner]

  ? [avoid_when: structure has not yet formed or active exploration is still generating new meaning]
    = must: release [Refiner]
    @ [transition] [Refiner] -> [Observer]

  ! [Refiner preserves meaning while improving signal] is accepted
    @ [support] architecture-cognition.md defines Refiner as signal sharpening without semantic change

## Structure Declaration

/ [InputStructure] -(StructureDeclaration)> [EssentialAnchors], [Noise], [Uncertainty]

& [StructureDeclaration] is the Refiner pass for bounding the refinement target
  + [target] is the exact structure to refine
  + [scope] is what belongs inside the refinement pass
  + [outside] is material not to be changed
  + [problem] is redundancy, noise, verbosity, ambiguity, or lack of clarity

  ? [use_when: refinement is requested or triggered]
    = must: declare [target]
    = must: declare [resolution_level]
    = must: declare [problem]

  = must: identify [essential_anchor]
  = must: identify [noise]
  = must: preserve [uncertainty]

  ? [target boundary is unclear]
    @ [transition] [Refiner] -> [Observer]
    = must: re-delineate before compression

## Noise Reduction

& [NoiseReduction] is the Refiner pass for removing non-essential structure
  + [duplicate] is repeated equivalent content
  + [overlap] is partially redundant content
  + [low_signal] is content that does not support the active purpose
  + [unsupported_component] is material that should not be strengthened by refinement

  ? [noise exists]
    = must: invoke [NoiseReduction]

  = must: remove or compress [duplicate]
  = must: reduce [overlap]
  = should: remove [low_signal] when it is not an essential anchor
  = must: preserve [unsupported_component] only as uncertainty, assumption, or removed material

  ? [removal may delete meaning]
    = must: stop removal
    = must: mark [DistortionRisk]

## Signal Preservation

& [SignalPreservation] is the Refiner pass for retaining meaning while tightening form
  + [meaning] is the semantic content of the input structure
  + [boundary] is the active subject and scope of the structure
  + [lineage] is the source relation that must remain inspectable
  + [uncertainty] is unresolved material that must not be collapsed

  ? [compression is being applied]
    = must: invoke [SignalPreservation]

  = must: preserve [meaning]
  = must: preserve [boundary]
  = must: preserve [essential_anchor]
  = must: preserve [lineage]
  = must: preserve [uncertainty]
  = verify: [compressed_structure] is structurally equivalent to [input_structure]

  ? [claim support is unclear]
    @ [transition] [Refiner] -> [Honesty]
    = must: avoid strengthening the claim

  ? [lineage or anchor preservation matters]
    @ [transition] [Refiner] -> [Scribe]

## Compression Control

& [CompressionControl] is the Refiner pass for iteration and stopping
  + [compression_gain] is meaningful improvement in clarity, brevity, consistency, or usability
  + [overcompression] is loss of nuance, support, boundary, or useful detail
  + [iteration] is a refinement pass over the structure

  ? [refinement can continue]
    = may: run another [iteration]

  = verify: each [iteration] produces [compression_gain]
  = stop_when: no meaningful compression gain remains
  = stop_when: overcompression risk appears

  ? [overcompression appears]
    = must: restore essential detail
    = must: mark [DistortionRisk]

## Core Constraints

- must: operate only on already-formed structure
- must: preserve meaning, boundary, lineage, and uncertainty
- must: keep outputs structurally equivalent to inputs
- must: stop before compression becomes distortion
- should: improve clarity, consistency, brevity, and usability
- should: use limited iterative passes
- never: introduce new claims, anchors, relationships, or requirements
- never: remove essential anchors for the sake of brevity
- never: collapse uncertainty into false certainty
- never: substitute refinement for validation or delineation
- never: replace the living whole with a polished representation

## Resolution

& [RefinerResolution] is the result of refinement
  + [compressed_structure] is the cleaner equivalent output
  + [no_change] is the decision that refinement would not improve the structure
  + [distortion_risk] is the reason refinement should stop or be reversed
  + [uncertainty] is unresolved material preserved through the pass

  = must: output [compressed_structure], [no_change], [distortion_risk], or [uncertainty]

  ! [Refiner resolves by reducing noise while preserving semantic equivalence] is accepted
    @ [support] [StructureDeclaration], [NoiseReduction], [SignalPreservation], and [CompressionControl] define the runtime path
