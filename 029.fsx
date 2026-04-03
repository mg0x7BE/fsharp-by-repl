// 029.fsx
// Why Accumulators?
// Simple recursion builds up a chain of pending operations (stack frames).
// The accumulator pattern processes as it goes — constant memory, no stack overflow.

// Recursion with Accumulator Pattern
// The accumulator pattern collects results as we go through the list.
// It's more efficient than simple recursion (tail-recursive = no stack overflow).

// Let's start simple: Sum numbers WITHOUT accumulator
let rec sumSimple list =
    match list with
    | [] -> 0
    | head :: tail -> head + sumSimple tail

// How it works for [1; 2; 3]:
// sumSimple [1; 2; 3]
// = 1 + sumSimple [2; 3]
// = 1 + (2 + sumSimple [3])
// = 1 + (2 + (3 + sumSimple []))
// = 1 + (2 + (3 + 0))
// = 1 + (2 + 3)
// = 1 + 5
// = 6
// Problem: Builds up stack frames (can crash on huge lists)


// Now WITH accumulator - we carry the result as we go
let sumWithAcc list =
    let rec loop acc remaining =
        match remaining with
        | [] -> acc  // No more items? Return accumulated result
        | head :: tail -> 
            let newAcc = acc + head  // Add current head to accumulator
            loop newAcc tail         // Continue with new accumulator
    loop 0 list  // Start with accumulator = 0

// How it works for [1; 2; 3]:
// sumWithAcc [1; 2; 3]
// = loop 0 [1; 2; 3]
// = loop (0 + 1) [2; 3]        = loop 1 [2; 3]
// = loop (1 + 2) [3]           = loop 3 [3]
// = loop (3 + 3) []            = loop 6 []
// = 6
// Better: Each step is the final operation (tail call)


// Example 1: Count elements (simplest accumulator example)
let countElements list =
    let rec loop count remaining =
        match remaining with
        | [] -> count  // Done? Return count
        | _ :: tail -> loop (count + 1) tail  // Add 1 and continue
    loop 0 list  // Start with count = 0

let count1 = countElements [10; 20; 30]  // 3

// Step by step for [10; 20; 30]:
// loop 0 [10; 20; 30]
// loop 1 [20; 30]     (count + 1 = 0 + 1 = 1)
// loop 2 [30]         (count + 1 = 1 + 1 = 2)
// loop 3 []           (count + 1 = 2 + 1 = 3)
// Result: 3


// Example 2: Build a new list (collect positive numbers)
let collectPositive list =
    let rec loop acc remaining =
        match remaining with
        | [] -> List.rev acc  // Reverse at end to maintain order
        | head :: tail ->
            if head > 0 then
                loop (head :: acc) tail  // (head :: acc) JOINS head to front of acc list
            else
                loop acc tail  // Skip negative, keep same acc
    loop [] list  // Start with empty accumulator list

let positive = collectPositive [-2; 3; -1; 5]
// Step by step:
// loop [] [-2; 3; -1; 5]
// loop [] [3; -1; 5]           (-2 is negative, skip)
// loop [3] [-1; 5]             (3 :: [] = [3])
// loop [3] [5]                 (-1 is negative, skip)
// loop [5; 3] []               (5 :: [3] = [5; 3])
// List.rev [5; 3] = [3; 5]
// Result: [3; 5]


// Example 3: Product (multiply all numbers)
let product list =
    let rec loop acc remaining =
        match remaining with
        | [] -> acc
        | head :: tail -> loop (acc * head) tail  // Multiply
    loop 1 list  // Start with 1 (identity for multiplication)

let result = product [2; 3; 4]  // 24 (2 * 3 * 4)


// Note about operation order:
// In (acc + head * head):
// 1. head * head is calculated first (multiplication has higher precedence)
// 2. Then result is added to acc
// Example: if acc=10 and head=3
// (acc + head * head) = (10 + 3 * 3) = (10 + 9) = 19


(*
    Your Task:
    1. Write a function called multiplyPositive that:
       - Takes a list of integers
       - Uses the accumulator pattern
       - Multiplies ONLY the positive numbers together
       - Skips negative numbers and zero
       
       Structure:
       let multiplyPositive list =
           let rec loop acc remaining =
               match remaining with
               | [] -> acc
               | head :: tail ->
                   if ??? then  // Check if head is positive
                       loop ??? tail  // Multiply head with acc
                   else
                       loop ??? tail  // Skip, keep same acc
           loop ??? list  // What initial value for multiplication?
    
    2. Test with [2; -3; 4; 0; 5; -1]
    
    3. Print the result
    
    Expected output: 40
    (Only multiply: 2 * 4 * 5 = 40, skip -3, 0, -1)
*)