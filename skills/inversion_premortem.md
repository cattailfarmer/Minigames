# Skill: inversion_premortem
name: inversion_premortem  
description: The skill of starting from a failed outcome as a given fact and working backwards to surface hidden assumptions, risks, and missing conditions before they manifest.  
case: Activate before high-stakes commits, releases, design finalization, or when Security flags elevated risk or Honesty detects unexamined assumptions.
file: inversion_premortem.md

#### Purpose (Waist)
inversion-premortem is the skill of treating failure as a known future fact and reverse-engineering the causal chain that produced it—thereby surfacing blind spots before they become real.

#### Workflow (3-Boundary Pants Structure)

**Waist – Failure Declaration**  
Explicitly state the desired outcome and then declare the opposite as already having occurred (“the project/feature/deployment has failed”). Name the specific failure mode(s) under consideration.

**Leg 1 – Backward Causal Mapping**  
Trace the most plausible paths that could have led to that failure. Surface every assumption that would have had to be false, every missing condition, and every unexamined risk. Use 5-Whys style probing where helpful.

**Leg 2 – Protective Action Synthesis**  
Convert each surfaced assumption or gap into a concrete mitigation, test, monitoring condition, or design change. Prioritize by leverage. Hand off the minimal viable guardrails to Planner for temporal integration or Security for protection.

#### Core Rules (always enforce)
- Stay strictly backward; do not drift into forward wishful planning inside the skill.  
- List only plausible, non-paranoid failure modes grounded in observable patterns.  
- Preserve epistemic-uncertainty on any assumption that cannot be falsified immediately.  
- Document the failure scenarios and mitigations for Scribe.

#### Integration Rules
- Pairs with type1-type2-decision (especially for Type 1 decisions), Security (protective adjustments), and Honesty (truth of assumptions).  
- Feeds directly into Weaver for building more resilient patterns and pareto-focus (focus on highest-leverage mitigations).

#### Boundaries / When Not to Use
- Do not use for routine low-stakes tasks (creates unnecessary friction).  
- Do not allow it to paralyze action; use it to strengthen, not to stop.

#### Resolution
Hidden risks and false assumptions become explicit, testable conditions. Plans and designs emerge stronger, more resilient, and far less likely to produce the very failure that was premortemed.