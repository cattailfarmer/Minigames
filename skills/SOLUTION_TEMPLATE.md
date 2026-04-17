metadata:
  name: "SOLUTION_SPECIFICATION"
  uuid: "new-uuid-for-this-solution"
  timestamp: "2026-..."
  version: "1.0"
  description: "Implementation details for Specification UUID: ..."
  solution_for: "original-spec-uuid"          # Specification this solves
  justified_by: "justification-uuid"          # The justification framework used
  previous_solution: "prior-solution-uuid"    # For iteration history
  status: "implemented"                       # "implemented" | "partial" | "failed" | "deprecated"

solution:
  implemented_data_elements:
    - uuid: "..."
      description: "..."
      table_name: "..."
      fields: [...]
  implemented_use_cases:
    - uuid: "..."
      description: "..."
      endpoints: [...]
      logic: "..."
  scaffold_details:
    tables: [...]
    views: [...]
    relationships: [...]
  leftovers_resolved:
    - uuid: "..."
      resolution: "..."

change_log:
  - transform: "..."
    justification: "..."