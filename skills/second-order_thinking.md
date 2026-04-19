# Skill: second-order_thinking
name: second-order_thinking  
description: The skill of tracing not only immediate consequences of a code change, design decision, or optimization, but also the downstream, indirect, and long-term effects on maintainability, performance, team velocity, and system health.  
case: Activate when evaluating refactoring proposals, dependency additions, performance tweaks, architectural choices, or any change that appears beneficial in isolation.
file: second-order_thinking.md

#### Purpose (Waist)
second-order_thinking is the skill of expanding awareness beyond first-order effects to include cascading, delayed, and systemic consequences, preventing short-term wins that create long-term debt or fragility.

#### Workflow (3-Boundary Pants Structure)

**Waist – Change Declaration**  
Explicitly name the proposed change (code edit, refactor, new dependency, optimization, etc.) and declare the obvious first-order benefit or intent.

**Leg 1 – First-Order Mapping**  
Clearly articulate the immediate, direct effects: what improves right now, what cost is paid upfront, and what is expected in the short term.

**Leg 2 – Second-Order & Systemic Exploration**  
Trace downstream ripples: How does this affect future maintenance? Team onboarding? Performance in edge cases? Coupling? Technical debt accumulation? Team velocity over months? System resilience? Surface both positive and negative second- and third-order effects. Hand off synthesized insights to inversion-premortem (for risk surfaces) or Planner (for temporal path adjustment).

#### Core Rules (always enforce)
- Always start with first-order effects before moving to second-order; do not skip or collapse layers.  
- Ground exploration in observable patterns and plausible causal chains, not speculation.  
- Balance positive and negative second-order effects without bias.  
- Preserve epistemic-uncertainty on effects that are distant or highly context-dependent.  
- Document key second-order findings for Scribe.

#### Integration Rules
- Pairs with pareto-focus (focus effort on highest-leverage second-order risks), inversion-premortem (test failure modes), and type1-type2-decision (weigh reversibility of long-term consequences).  
- Feeds richer causal maps into Weaver for coherent long-term patterns and Planner for temporal coherence.

#### Boundaries / When Not to Use
- Do not use for trivial, low-impact changes where second-order effects are negligible.  
- Do not allow it to cause analysis paralysis on urgent, time-sensitive fixes.

#### Resolution
Decisions and changes are evaluated with temporal depth. Short-term gains are weighed against long-term systemic health, leading to more sustainable code, healthier architectures, and better team velocity over time.