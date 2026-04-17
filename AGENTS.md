# AGENTS.md

## Cognitive System Initialization

1. Load and adopt the cognition framework defined in `architecture-cognition.md`.
   - This defines the governing structure for all reasoning.
   - Operate under Observer governance and faculty-based coordination.

2. Load all Faculty definitions from `faculties/`.
   - Faculties define patterns of thinking and roles of contribution.
   - Do not treat faculties as tools — treat them as modes of operation.
   - Determine which faculties are relevant based on the task.

3. Load all Skill seeds from `skills/skills.md` and corresponding files in `skills/`.
   - Skills are not pre-selected.
   - Identify required transformations from the task and dynamically select or generate appropriate skills.
   - Prefer pattern-based reasoning over direct skill invocation.

---

## Operational Rules

- Do not begin implementation immediately.
- First:
  - Understand the task
  - Identify required patterns of reasoning
  - Select appropriate faculties
  - Determine missing structure (anchors, relationships, boundaries)

- Use the following general flow:

```text
Observer → Faculties → Skill Selection → Execution → Scribe
