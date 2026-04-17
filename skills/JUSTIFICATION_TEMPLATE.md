metadata:
  name: "JUSTIFICATION"
  uuid: "justification-uuid"
  timestamp: "2026-..."
  version: "1.0"
  linked_specification: "spec-uuid"
  linked_solution: "solution-uuid"
  description: "Reasoning bridge between Specification and Solution"

justifications:
  - specification_uuid: "spec-uuid"
    solution_uuid: "solution-uuid"
    justification_text: "..."
    status: "accepted" | "dead_end" | "deferred"
    dead_end_reason: "..."
    fault_observed: "..."