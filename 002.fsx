// 002.fsx
// Why Pattern Matching & Recursion?
// Pattern matching replaces if/else chains with clear, exhaustive case handling.
// Recursion replaces loops - in functional programming, data flows through functions.

// String Operations
let name = "Alice"

// Concatenation (joining strings with +)
let hello = "Hello, " + name + "!"

// String Interpolation (Modern way, starts with $)
// Put variables inside {curly braces}
let info = $"User: {name}, Age: 30"  // "User: Alice, Age: 30"

// Pattern Matching
let describeNumber x =
    match x with
    | 0 -> "Zero"
    | n when n < 0 -> "Negative number!" // 'when' allows custom logic
    | _ -> $"Positive number: {x}"       // handling everything else

// Recursive function
// Needs 'rec' keyword to call itself
let rec factorial n =
    match n with
    | 0 | 1 -> 1
    | _ -> n * factorial (n - 1)

// Example usage
let fact5 = factorial 5  // 120


(*
    Your Task:
    Write a recursive function named countdown that:
    1. Takes a number n.
    2. If n <= 0, returns the string "Done!".
    3. Otherwise, returns a string with the number followed by a comma, 
       and calls itself recursively with (n - 1).
       
    Example output for countdown 3:
    "3, 2, 1, Done!"

    Hint: 
    - Use pattern matching with a when clause for the stop condition.
    - Use string concatenation (+) to join the number with the recursive result.
*)