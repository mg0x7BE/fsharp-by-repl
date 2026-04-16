// 003.fsx
// Why Lists?
// Lists are the most common data structure in functional programming.
// Unlike arrays, F# lists are immutable - you build new lists instead of modifying old ones.

// List literal (semicolons, not commas!)
let numbers = [1; 2; 3; 4; 5]

// Empty list
let empty = []

// Cons operator :: (adds an element to the front of a list)
let newList = 0 :: numbers  // Result: [0; 1; 2; 3; 4; 5]

// Pattern Matching
let rec sum list =
    match list with
    | [] -> 0                          // Case 1: Empty list
    | head :: tail -> head + sum tail  // Case 2: Head (first item) + Tail (rest of list)

let totalSum = sum [1; 2; 3]  // Result: 6

// The Wildcard Pattern
// If you don't need the value of a variable (e.g., the 'head'), use '_' to ignore it.
let isNotEmpty list =
    match list with
    | [] -> false
    | _ :: _ -> true   // We don't care what the elements are, just that they exist.

// Printing Results
// %A is a special formatter for "Any structure" (lists, records, etc.)
// %d is for integers, %s for strings.

let myNum = 10
printfn $"Number: %d{myNum}"             // Interpolated style (Type safe)
printfn $"Everything works: %A{numbers}" // %A prints the whole list nicely


(*
    Your Task:
    Write a recursive function named countElements that:
    1. Takes a list (of any elements).
    2. Returns the number of elements in the list (count them).
    3. Uses pattern matching: 
       - Handle the empty list [].
       - Handle the non-empty list head :: tail (or _ :: tail).

    Example: countElements [1; 2; 3; 4] -> 4
    
    Hint: 
    - Do not use List.length or other built-in functions.
    - Do it manually using recursion (add 1 for every element found).
*)