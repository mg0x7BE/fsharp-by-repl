// 009.fsx
// Why Function Composition?
// Composition (>>) lets you build new functions by chaining existing ones -
// like LEGO bricks. The result is a new function, not an immediate value.

// Function Composition
// You can combine functions using the >> operator (forward composition).
// (f >> g) x is the same as g(f(x))

let add10 x = x + 10
let double x = x * 2

// Compose functions
let add10ThenDouble = add10 >> double

let result1 = add10ThenDouble 5  // (5 + 10) * 2 = 30


// You can chain multiple compositions
let square x = x * x
let subtract5 x = x - 5

let pipeline = square >> add10 >> double
let result2 = pipeline 3  // (3² + 10) * 2 = (9 + 10) * 2 = 38


// Composition vs Pipe
// Pipe (|>) applies a VALUE to functions:
let result3 = 5 |> add10 |> double  // 30

// Composition (>>) creates a NEW FUNCTION:
let myFunc = add10 >> double
let result4 = myFunc 5  // 30


// Practical example with lists
let removeNegatives = List.filter (fun x -> x >= 0)
let squareAll = List.map (fun x -> x * x)
let sumAll = List.sum
let processNumbers = removeNegatives >> squareAll >> sumAll

let numbers = [-2; -1; 0; 1; 2; 3]
let result5 = processNumbers numbers  // (0² + 1² + 2² + 3²) = 0 + 1 + 4 + 9 = 14

(*
    Your Task:
    1. Create three functions:
       - filterEvens: filters a list to keep only even numbers
       - squareAll: squares all numbers in a list
       - sumAll: sums all numbers in a list
    
    2. Compose these three functions using >> into a single function called processEvens.
    
    3. Apply processEvens to the list [1; 2; 3; 4; 5; 6; 7; 8; 9; 10].
    
    4. Print the result.
    
    Expected result: 220
    (2² + 4² + 6² + 8² + 10² = 4 + 16 + 36 + 64 + 100 = 220)
*)