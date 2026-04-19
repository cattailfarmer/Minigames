Skills:
  + pareto_focus
    * description: The skill of identifying the vital 20% of effort, code, or features that drive 80% of results or impact, then ruthlessly prioritizing them while de-emphasizing the long tail.
    * case: Activate when task volume overwhelms, during refactoring, feature prioritization, or optimization passes where effort must yield disproportionate returns.
    * file: pareto_focus.md
  + parkinsons_timeboxing
    * description: The skill of deliberately constraining time or scope for a task to prevent work from expanding to fill all available resources, enforcing completion within artificial but realistic bounds.
    * case: Activate when planning sprints, setting deadlines, or noticing scope creep in coding or debugging sessions.
    * file: parkinsons_timeboxing.md
  + type1-type2_decision
    * description: The skill of classifying decisions as irreversible (Type 1: slow, careful analysis) versus reversible (Type 2: fast, experimental) and adjusting deliberation speed and risk tolerance accordingly.
    * case: Activate before architecture choices, library selections, or deployment strategies where decision reversibility affects tempo and safety.
    * file: type1-type2_decision.md
  + conway_mimicry
    * description: The skill of recognizing how team/organizational communication structures shape (and are mirrored by) the resulting code, module, or system architecture, then deliberately designing or refactoring to improve both.
    * case: Activate during system design reviews, monolith-to-microservices transitions, or when diagnosing tight coupling caused by team silos.
    * file: file: conway_mimicry.md
  + inversion_premortem
    * description: The skill of starting from a failed outcome as a given fact and working backwards to surface hidden assumptions, risks, and missing conditions before they manifest.
    * case: Activate before high-stakes commits, releases, or design finalization when Security flags elevated risk or Honesty detects unexamined assumptions. (Note: partial overlap with previously procreated basin; can be glued or refined.)
    * file: inversion_premortem.md
  + second-order-thinking
    * description: The skill of tracing not only immediate consequences of a code change, design decision, or optimization, but also the downstream, indirect, and long-term effects on maintainability, performance, and team velocity.
    * case: Activate when evaluating refactoring proposals, dependency additions, or performance tweaks that appear beneficial in isolation.
    * file: second-order_thinking.md
  + first-principles-decomposition
    * description: The skill of breaking a programming problem or system down to fundamental, irreducible truths (physics of data, core invariants, basic operations) before rebuilding solutions upward, avoiding cargo-cult or framework assumptions.
    * case: Activate at the start of novel feature design, when legacy code feels incomprehensible, or when existing abstractions leak.
    * file: first-principles_decomposition.md
  + feedback-loop-tuning
    * description: The skill of deliberately building, monitoring, and shortening tight feedback cycles (tests, deployments, metrics, reviews) to accelerate learning and reduce defect latency in code and process.
    * case: Activate when debugging cycles feel slow, during CI/CD improvements, or when establishing TDD/BDD habits.
    * file: feedback-loop_tuning.md
  + occams-razor-code
    * description: The skill of preferring the simplest explanation or implementation that fully accounts for observed behavior or requirements, then systematically eliminating unnecessary complexity or entities.
    * case: Activate during code review, when multiple solutions compete, or when noticing over-engineered patterns that violate simplicity.
    * file: occams_razor_code.md
  + pattern-recognition-reuse
    * description: The skill of rapidly detecting recurring structures, motifs, or "plans" in code, data, or problems, then mapping them to known solutions, design patterns, or abstractions for efficient generalization.
    * case: Activate while reading unfamiliar codebases, during algorithmic problem-solving, or when generalizing a one-off fix into a reusable component.
    * file: pattern_recognition_reuse.md
  + name: flow-control_strategy
    * description: The skill of deliberately evaluating and selecting the most appropriate control-flow mechanism (if/else, switch, early returns/guard clauses, polymorphism, state machines, recursion, loops, or exceptions) based on readability, maintainability, performance, and cognitive complexity.  
    * case: Activate when writing or refactoring branching logic, handling state-dependent behavior, processing sequences with varying conditions, or when noticing deep nesting, boolean flag proliferation, or scattered conditionals.
    * file: flow-control_strategy.md
  + name: function-signature_design
    * description: The skill of deliberately choosing the optimal parameters (number, types, order, defaults), return type (or void), and overall shape of information flow for a function or method so that its purpose is clear, coupling is minimized, cohesion is maximized, and the function composes cleanly with others.  
    * case: Activate when writing a new function/method, refactoring an existing signature, deciding whether to return a value or mutate state, grouping related parameters into objects, or when information flow feels awkward, error-prone, or overly complex.
    * file: function-signature_design.md
  + tell-dont_ask
    * description: The skill of telling an object or module to perform an action with the data it needs, rather than querying its internal state and then deciding what to do externally. Reduces coupling and encapsulation violations.
    * case: Activate when you find yourself checking object properties/flags before calling methods, or when logic about another component's state is scattered outside it.
    * file: tell-dont_ask.md
  + command-query_separation
    * description: The skill of ensuring every function/method is either a Command (performs action, changes state, returns nothing/void) or a Query (returns value, no side effects), but never both. Improves predictability and testability.
    * case: Activate when designing or refactoring function signatures that mix mutation with return values, or when debugging unexpected state changes.
    * file: command-query_separation.md
  + small_functions-single_responsibility
    * description: The skill of keeping functions/methods short (ideally <20-30 lines), focused on one clear responsibility, and easy to name without using "and".
    * case: Activate when a function grows long, contains multiple "and" verbs in its name, or requires scrolling to understand its logic.
    * file: small_functions-single_responsibility.md
  + meaningful_naming
    * description: The skill of choosing names for variables, functions, classes, and parameters that reveal intent, purpose, and constraints so the code reads like well-written prose.
    * case: Activate during writing or code review when names are vague (e.g., data, process, temp), abbreviations dominate, or the reader must infer meaning from context.
    * file: meaningful_naming.md
  + law_of_demeter
    * description: The skill of limiting direct interactions to immediate "friends" (only talk to your own methods, parameters, or directly held objects), avoiding deep chaining that creates tight coupling.
    * case: Activate when you see long method chains like obj.getA().getB().getC().doSomething(), or when changes in one module ripple unexpectedly through many others.
    * file: law_of_demeter.md
  + composition_over_inheritance
    * description: The skill of preferring object composition (has-a) over deep class inheritance (is-a) to build flexible, reusable behavior while avoiding fragile base-class problems.
    * case: Activate during class design or refactoring when inheritance hierarchies grow deep, or when you need to combine behaviors without locking into a rigid hierarchy.
    * file: composition_over_inheritance.md
  + avoid_magic_numbers_and_strings
    * description: The skill of replacing unexplained literal values (numbers, strings, booleans) with named constants or domain-specific types that explain their meaning and purpose.
    * case: Activate whenever you encounter hard-coded values like 42, "admin", or true that require comments or external knowledge to understand.
    * file: avoid_magic_numbers_and_strings.md
  + feature-based_organization
    * description: The skill of structuring the codebase by business features or domains (grouping related code together) rather than by technical layers, to improve navigation and locality of changes.
    * case: Activate when setting up or refactoring project directory structure, especially in growing monoliths or medium-to-large applications.
    * file: feature-based_organization.md
