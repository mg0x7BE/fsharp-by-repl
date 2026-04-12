# F# Exercises — Instructions for Claude

## What This Repo Is

A structured F# learning path: numbered .fsx exercises from basics to advanced topics.
Each "block" of exercises covers a theme and ends with a mini-project that integrates learned concepts.

## File Conventions

- **Exercise file**: `NNN.fsx` (e.g. `017.fsx`) — teaching material + task
- **Solution file**: `NNNa.fsx` (e.g. `017a.fsx`) — user's answer
- **Project file**: `NNN-project-name.fsx` (e.g. `034-project-csv-parser.fsx`) — larger exercise
- All files are F# scripts (.fsx), executed via F# Interactive in JetBrains Rider (Ctrl+\)
- Numbering: 3-digit zero-padded, sequential (001, 002, ..., 035, 036, ...)

## Exercise File Structure

```fsharp
// NNN.fsx

// Topic Name
// Brief explanation of the concept

// Example 1: ...
let example1 = ...

// Example 2: ...
let example2 = ...

(*
    Your Task:
    1. Do this...
    2. Then do that...

    Expected output: ...

    Hint: ...
*)
```

Key rules:
- Start with `// NNN.fsx` header comment
- Teaching section comes first with practical, runnable examples
- Task is inside a block comment `(* ... *)`
- Include expected output so the user can verify their solution
- Include hints when the exercise introduces something new or tricky
- Language: English

## Solution File Style

- Minimal, clean code — no teaching comments
- Use pipe operator `|>` where natural
- Use `printfn $"%A{...}"` for structured data (lists, tuples, records)
- Use `printfn $"%d{...}"` or `$"%s{...}"` for simple values
- Use `:F2` format specifier for currency/float display
- Prefer idiomatic F# (pattern matching without redundant guards, `if/else` for simple conditions)
- End with printing the result

## Progression Design

The exercises follow a learning path organized in blocks. Each block ends with a mini-project.

### Block 1: Fundamentals (001-035) — COMPLETED
- 001: Functions, pipe operator
- 002: Strings, pattern matching, recursion
- 003: Lists, cons operator, recursive processing
- 004: Higher-order functions, lambdas
- 005: List.map, List.filter, pipe chaining
- 006: List.sum, multi-step pipelines
- 007: List.collect (flatMap), List.concat
- 008: Partial application, currying
- 009: Function composition (>>)
- 010: Option type (Some/None)
- 011: Option.map, Option.defaultValue
- 012: Option.bind
- 013: Tuples, destructuring
- 014: Records
- 015: Discriminated Unions
- 016: Result type (Ok/Error)
- 017: List.fold
- 018: List.reduce
- 019: Combining records, DUs, options, lists
- 020: Sequences (seq, lazy evaluation)
- 021: List.choose
- 022: List.groupBy
- 023: List.sortBy, List.sortByDescending
- 024: Type aliases
- 025: Active Patterns
- 026: List.collect (advanced)
- 027: List.partition
- 028: List.zip, List.unzip
- 029: Recursion with accumulator pattern (tail recursion)
- 030: Real-world data processing (combining everything)
- 031-033: groupBy deep dive (step-by-step, with records, filtering after grouping)
- **034: PROJECT — CSV Sales Data Analyzer**
- **035: PROJECT — Task List Manager**

### Block 2: Practical F# (~036-050) — IN PROGRESS
- 036: Map basics (Map.ofList, find, tryFind, add, remove, count)
- 037: Map transformations (Map.map, Map.filter, Map.fold)
- 038: Set
- 039: Array operations
- 040-041: String processing (split, join, trim, regex basics)
- 042-044: Result chaining, Railway Oriented Programming
- 045: Modules and namespaces
- 046: Combining new concepts (practice)
- **~047: PROJECT — e.g. contact book, config parser, or inventory system**

### Block 3: Real-World F# (~048-065) — PLANNED
- ~048: Advanced pattern matching (as patterns, AND/OR patterns)
- ~049-050: Recursive data structures (trees)
- ~051-053: Async/Task
- ~054: File I/O
- ~055: Basic .NET interop
- ~056: Combining everything (practice)
- **~057: PROJECT — e.g. CLI tool with file processing + async HTTP**

Target: ~60-65 exercises total. After that, start a real project.

## How to Create New Exercises

When asked to create the next exercise(s):

1. Check the last exercise number and continue sequentially
2. Introduce ONE new concept per exercise (unless it's a combining/project exercise)
3. Teaching examples should be simple and runnable independently
4. Tasks should be achievable in ~5-30 lines of solution code
5. Build on previously learned concepts — use them naturally in examples
6. For projects: combine 3-5 recently learned concepts into a realistic scenario
7. Always verify expected output by calculating manually
8. Match the style and tone of existing exercises exactly

**IMPORTANT: Only create the exercise file (NNN.fsx), NEVER commit a solution file (NNNa.fsx)
to the repo.** Solution files are written by the user as their answer.
You may temporarily create a solution file to verify expected output via `dotnet fsi`,
but you MUST delete it before finishing. The repo should only contain exercise files
and user-written solutions.

**CRITICAL RULE: Tasks may ONLY use concepts that have already been taught in previous exercises
or in the teaching section of the current exercise. Never require the student to know something
that hasn't been introduced yet. The progression list above is the single source of truth
for what the student knows at any given exercise number.**

## Extra Rules for Project Exercises (NNN-project-*.fsx)

Project exercises are multi-step tasks that combine several concepts. They require extra care:

1. **Top-down order**: Steps must be ordered so the code compiles when written top to bottom.
   If function A uses function B, then B must be defined in an earlier step than A.
2. **Hints next to their steps**: Each hint belongs directly under the step it relates to —
   never collected at the bottom of the file, disconnected from context.
3. **Hard steps need sub-steps**: If a step requires combining 3+ operations (e.g. partition,
   then map, then concatenate strings), break it into labeled sub-steps (a, b, c, ...).
4. **Explain unfamiliar patterns inline**: If the project uses a pattern not explicitly taught
   before (e.g. let-shadowing, list concatenation with `@`, `String.concat`), add a short
   explanation or note right where it's needed — don't assume the student will figure it out.
5. **Example workflow must be correct**: If you show a usage example, mentally execute it
   step by step and verify the expected output matches. Watch out for:
   - Function parameter order (is the list last, for piping?)
   - Prepend (`::`) vs append (`@`) — does the output order match?
6. **Prefer pipeline chaining over let-shadowing**: Both work in .fsx, but pipelines
   are more idiomatic and concise:
   ```fsharp
   // Works, but verbose:
   let tasks = []
   let tasks = addTask "A" tasks
   let tasks = addTask "B" tasks

   // Preferred — one pipeline:
   let tasks =
       []
       |> addTask "A"
       |> addTask "B"
   ```
   Design all functions so the "state" parameter (list, record, etc.) is last,
   enabling `|>` chaining.
7. **Keep the expected output simple**: Don't require complex string formatting beyond
   what was taught.

## Hint Calibration & Difficulty Scaling

Hints should guide thinking, not give away answers. Follow these rules:

### What counts as "already known"
If a concept was taught in a previous exercise (check the progression list), the student
knows it. **Do not hint at things the student already knows.** Examples:
- After exercise 005: student knows `List.map`, `List.filter`, lambdas, pipe operator.
  Don't hint "use List.filter" for a filtering task — just describe *what* to filter.
- After exercise 014: student knows record syntax, `{ record with Field = value }`.
  Don't show the syntax again — just say "update the field".

### Hint levels (choose the right one for each step)

1. **No hint needed** — the step uses only well-practiced concepts.
   Just describe *what* to do, not *how*.
   Example: "Remove the task with the matching ID" (student knows List.filter)

2. **Conceptual nudge** — the step combines known concepts in a new way.
   Name the approach but don't give code.
   Example: "Think about which List function lets you transform each element"

3. **Pattern hint** — the step uses a concept taught recently (last 3-5 exercises)
   or requires a non-obvious combination. Show the pattern abstractly.
   Example: "You can use @ to combine string lists: [\"A\"] @ [\"B\"; \"C\"]"

4. **Inline explanation** — the step uses something NOT previously taught
   (new operator, new .NET API, unfamiliar pattern). Explain it with a small example.
   Example: "String.concat joins a list of strings with a separator:
   String.concat \", \" [\"a\"; \"b\"] = \"a, b\""

**NEVER give level-4 detail for concepts the student already knows.**
**NEVER give the exact solution code as a "hint".** If your hint is copy-pasteable
as the answer, it's not a hint — it's the solution. Rewrite it.

### Difficulty scaling by exercise number

- **Exercises 001-010**: Heavy hints. Student is learning fundamentals.
  Show patterns, give code fragments. It's OK to be explicit.
- **Exercises 011-025**: Moderate hints. Student knows basics.
  Hint at *which* function to use, but not *how* to use it.
- **Exercises 026+**: Light hints. Only for new/tricky concepts.
  For anything previously taught, just describe the goal.
- **Projects**: Hints only where multiple concepts combine in a new way,
  or where a new pattern (not previously taught) is introduced.
  Individual steps that use a single known concept need NO hint.

### Project difficulty

Projects should be **harder than regular exercises**, not easier.
Each project is the capstone of its block. It should require the student to:
- Recall and combine concepts without being told which ones to use
- Figure out the implementation of straightforward steps on their own
- Only receive help on the genuinely novel or complex parts

If a project step can be solved with a single well-known List function,
it doesn't need a hint. Period.

## Self-Review Checklist (MANDATORY)

After writing any exercise, you MUST mentally walk through it as if you were the student.
Go step by step and verify each of the following. If any check fails, fix the exercise
before presenting it.

### Correctness checks:
1. **Execute the example workflow mentally** — start from the initial value and trace
   every operation. Does the final state match the expected output exactly?
2. **Does the code compile in .fsx?** — no forward
   references to functions not yet defined, no missing type annotations that cause
   ambiguity.
3. **Are function signatures consistent?** — if you say "takes X and Y", does the
   example call the function with X and Y in that order? Is the list/state always last?
4. **Do List operations produce the right order?** — `::` prepends (reverses order),
   `@` appends (preserves order). Which one did you use, and does the output match?

### Concept checks:
5. **For every operator, function, or pattern used in the task** — was it taught in a
   previous exercise OR explained in this exercise's teaching section/hints?
   Check the progression list. Common things that are easy to forget:
   - `@` (list concatenation) — not taught by default
   - `String.concat` — not taught by default
   - `{ record with Field = value }` — taught in 014 (Records)
   - `List.head`, `List.tail` — taught in 003 (Lists)
   - `sprintf` / `String.Format` — not taught
     If something wasn't taught, either add an inline explanation or remove it.

6. **Is the step order top-down?** — read the steps in order. If the student writes code
   from step 1 to step N, will it compile at every intermediate step? If step 7 calls
   a function from step 9, the order is wrong.

7. **Are hints sufficient for the hardest step?** — identify the single hardest step.
   Does it have a hint? If it requires combining 3+ operations, is it broken into
   sub-steps?

### Difficulty checks:
8. **Is any hint giving away the answer?** — for each hint, ask: can the student
   copy-paste this directly as their solution? If yes, rewrite it as a conceptual
   nudge or remove it entirely.
9. **Is any hint redundant?** — does it explain a concept the student already knows
   (check the progression list)? If the concept was taught 10+ exercises ago,
   the student doesn't need a reminder. Remove the hint.
10. **Is the difficulty appropriate for the exercise number?** — compare with nearby
    exercises. A project should feel like a step up, not a step down. An exercise
    at number 035 should not hand-hold like exercise 005.
