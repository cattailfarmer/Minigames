# Skill: inference-delineation
name: inference-delineation
description: Compact, forward-pass optimized delineation process for precise boundary drawing and quality attribution during inference.
case: Use at the start of any reasoning step, skill application, or output generation to individuate entities cleanly and prevent bleed or scope mismatch. Run as lightweight internal checkpoints.
file: inference-delineation.md
source: core-delineation

## Workflow (3-Boundary Pants – inference optimized)

### Waist – Identity Recognition
Fully recognize and individuate the entity by enveloping its entire visible surface and outer contour (all observable boundaries, attributes, and context).

### Leg 1 – Boundary Drawing
Draw the precise line: explicitly state what is inside vs. outside the entity in the current scope and respect.

### Leg 2 – Quality Attribution & Normalization
Attribute only the intrinsic, source-derived qualities that survive the boundary test.  
Apply Paul-Elder standards (clarity, accuracy, precision, relevance, depth, fairness).  
Normalize: Adjust content, detail, language, and structure to exactly match the identified scope and context (brief/high-level for indexes; detailed/operational for dedicated files). Maintain brevity and relevance for efficiency.

## Core Rules (always enforce in forward pass)
- Ensure self-containment: include minimal definitions/summaries so the output stands alone.  
- Identify scope and context before generating.  
- Output boundary: declare active lattice when relevant; keep token use minimal.

## Integration Note
This version is optimized for sequential forward-pass use (quick attention checkpoints). The authoritative source remains core-delineation.