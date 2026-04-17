metadata:
  name: "SPECIFICATION"
  uuid: "spec-uuid-here"
  timestamp: "2026-..."
  version: "1.0"
  description: "Clear description of this specification version"
  previous: "previous-spec-uuid"   # null on first version
  author: " System / User"

prerequisite_justifications:
  input_file: "prereq-justif-uuid.yaml"
  summary: "Downstream feedback required reworking the specification because..."
  affected_uuids:
    - old-uuid: "new-uuid"
  changes_triggered:
    - "Requirement X was removed because..."
    - "New atomic requirement Y was added because..."

specification: |
  # Verbose original specification text here
  Terms:
    - ...
  Behaviors:
    - ...

change_log: []                               # Populated when prerequisite justifications trigger a rework of the specification

justified: |
  # The fully justified, cleaned, and normalized version of the specification
  # after applying any prerequisite justifications