// 004.fsx
// Why Higher-Order Functions?
// Passing functions as arguments lets you write reusable, composable code.
// Instead of repeating logic, you parameterize behavior itself.

// Higher-Order Functions
// Functions can take other functions as parameters.
let applyTwice f x = f (f x)

let increment n = n + 1
let result = applyTwice increment 5  // 7 (5 -> 6 -> 7)

// Anonymous Functions (Lambdas)
// A lambda is a function without a name. 
// Instead of defining a named function like this:
//      let double x = x * 2
//      let res = double 5
//
// You can write it inline:
let res = (fun x -> x * 2) 5

// Lambda Syntax: 
// fun parameter -> expression

// Examples:
// fun x -> x * 2           // Multiplies by 2
// fun x -> x + 10          // Adds 10
// fun x y -> x + y         // Adds two numbers
// fun name -> "Hi " + name // Concatenates strings

// Using lambda with HOF
let result2 = applyTwice (fun x -> x * 2) 3  // 12 (3 -> 6 -> 12)

// Common List Functions
// Lambdas are often used with lists.
let doubled = List.map (fun x -> x * 2) [1; 2; 3]          // [2; 4; 6]
let evens = List.filter (fun x -> x % 2 = 0) [1; 2; 3; 4]  // [2; 4]


(*
    Your Task:
    Write a function named applyToList that:
    1. Takes a function f (transforming int -> int).
    2. Takes a list of integers.
    3. Returns a new list where every element has been transformed by f.
    
    Constraint:
    - Do NOT use List.map.
    - Implement it manually using recursion and pattern matching.

    Example: 
    applyToList (fun x -> x * x) [1; 2; 3; 4] 
    -> Result: [1; 4; 9; 16]
*)