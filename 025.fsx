// 025.fsx
// Why Active Patterns?
// Regular pattern matching works on built-in types (lists, tuples, DUs).
// Active patterns let you define your OWN matching logic — extending the language.

// Active Patterns
// Active patterns let you create custom pattern matching cases.
// They make pattern matching more expressive and reusable.

// Complete Active Pattern (multi-case)
// Syntax: let (|Case1|Case2|) input = Case1 or Case2

let (|Even|Odd|) n =
    if n % 2 = 0 then Even
    else Odd

// Usage in pattern matching
let describe n =
    match n with
    | Even -> $"{n} is even"
    | Odd -> $"{n} is odd"

let result1 = describe 4  // "4 is even"
let result2 = describe 7  // "7 is odd"


// Active pattern with data
let (|DivisibleBy|_|) divisor n =
    if n % divisor = 0 then
        Some DivisibleBy
    else
        None

let checkDivisibility n =
    match n with
    | DivisibleBy 3 -> $"{n} is divisible by 3"
    | DivisibleBy 5 -> $"{n} is divisible by 5"
    | _ -> $"{n} is not divisible by 3 or 5"

let result3 = checkDivisibility 9   // "9 is divisible by 3"
let result4 = checkDivisibility 10  // "10 is divisible by 5"
let result5 = checkDivisibility 7   // "7 is not divisible by 3 or 5"


// Practical example: Parsing
let (|Int|_|) (str: string) =
    match System.Int32.TryParse(str) with
    | (true, value) -> Some value
    | (false, _) -> None

let parseInput input =
    match input with
    | Int n -> $"Valid number: {n}"
    | _ -> "Not a valid number"

let result6 = parseInput "42"   // "Valid number: 42"
let result7 = parseInput "abc"  // "Not a valid number"


// Multi-case Active Pattern
let (|Small|Medium|Large|) n =
    if n < 10 then Small
    elif n < 100 then Medium
    else Large

let categorize n =
    match n with
    | Small -> "Small number"
    | Medium -> "Medium number"
    | Large -> "Large number"

let result8 = categorize 5    // "Small number"
let result9 = categorize 50   // "Medium number"
let result10 = categorize 500 // "Large number"


(*
    Your Task:
    1. Create an active pattern called (|Positive|Zero|Negative|) that:
       - Returns Positive if number > 0
       - Returns Zero if number = 0
       - Returns Negative if number < 0
    
    2. Write a function called classifyNumber that:
       - Takes an integer
       - Uses pattern matching with your active pattern
       - Returns:
         - "Positive: {n}" for positive numbers
         - "Zero" for zero
         - "Negative: {n}" for negative numbers
    
    3. Test with: 5, 0, -3
    
    4. Print all three results
    
    Expected output:
    - Positive: 5
    - Zero
    - Negative: -3
*)