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
- **035: PROJECT — TODO List Manager (CLI)**

### Block 2: Practical F# (~036-050) — PLANNED
- 036-037: Map (dictionary-like data structure)
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

**CRITICAL RULE: Tasks may ONLY use concepts that have already been taught in previous exercises
or in the teaching section of the current exercise. Never require the student to know something
that hasn't been introduced yet. The progression list above is the single source of truth
for what the student knows at any given exercise number.**
