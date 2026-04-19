# Skill: feedback-loop_tuning
name: feedback-loop_tuning
description: The skill of deliberately building, monitoring, and shortening tight feedback cycles (tests, deployments, metrics, reviews) to accelerate learning and reduce defect latency in code and process.  
case: Activate when debugging cycles feel slow, during CI/CD improvements, when establishing TDD/BDD habits, or when team velocity or quality metrics are lagging.
file: feedback-loop_tuning.md

#### Purpose (Waist)
feedback-loop-tuning is the skill of treating feedback speed and quality as a primary lever for system improvement, systematically shortening the time between action and meaningful signal so learning compounds faster than defects or debt.

#### Workflow (3-Boundary Pants Structure)

**Waist – Loop Identification**  
Explicitly name the current feedback loop(s) under consideration (e.g., “code change → test run → deployment → production metric” or “bug report → fix → verification”) and declare the existing latency or weakness.

**Leg 1 – Measurement & Diagnosis**  
Quantify the current loop: time from trigger to signal, signal quality (noise vs. actionable insight), frequency, and failure modes. Identify bottlenecks (manual steps, slow tests, delayed metrics, review delays, etc.).

**Leg 2 – Tightening & Optimization**  
Design and implement targeted reductions: automate tests, add fast unit/smoke tests, improve CI/CD pipeline, introduce feature flags, real-time metrics, or pair programming reviews. Set explicit targets for new loop duration. Monitor the improved loop and iterate. Hand off results to Planner for sustained temporal integration or Scribe for recording.

#### Core Rules (always enforce)
- Measure before optimizing — never tune blindly.  
- Prioritize shortening the *most expensive* or *most frequent* loops first (pareto-focus integration).  
- Ensure tightened loops actually deliver higher-quality signals, not just faster noise.  
- Preserve epistemic-uncertainty on any assumed improvement until empirically validated.  
- Document before/after metrics for living memory.

#### Integration Rules
- Pairs with parkinsons-timeboxing (constrain loop time deliberately), pareto-focus (focus on highest-impact loops), and second-order-thinking (watch for downstream effects of faster loops).  
- Feeds faster learning directly into Weaver for resilient process patterns and inversion-premortem for risk detection in new loops.

#### Boundaries / When Not to Use
- Do not use when the domain requires deliberate slow, high-ceremony verification (e.g., safety-critical or regulated systems where speed must yield to assurance).  
- Do not sacrifice signal quality for raw speed.

#### Resolution
Feedback cycles become dramatically shorter and higher-signal. Defects are caught earlier, learning accelerates, technical debt grows more slowly, and overall system and team velocity improve sustainably through compounding tight loops.