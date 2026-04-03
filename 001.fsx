// 001.fsx
// Why Functions & Pipes?
// Functions are the building blocks of F#. Pipes (|>) let you read code
// left-to-right like a sentence, instead of nesting parentheses.

// Function definition
let add x y = x + y

// Calling it
let result = add 5 3 // result = 8

// Function with explicit type annotations (optional, but useful to know)
let multiply (x: int) (y: int) : int = x * y

// Values (immutable by default)
let name = "John"
let age = 25
let pi = 3.14

// Using functions (Standard way)
let doubled = multiply 4 2

// Using the Pipe operator |> (Passes the result of the left side to the function on the right)
// x |> f is the same as f x
let pipedResult = 5 |> add 3 // computes (5 + 3) -> 8
let chained = 5 |> add 3 |> multiply 2 // computes (5 + 3), then multiplies result by 2 -> 16


(*
    Your Task:
    1. Write a function named subtract that subtracts two numbers (the second from the first).
    2. Next, write a function named square that squares a number (multiplies the number by itself).
    3. Finally, use both functions: calculate the square of the result of 10 - 3.
*)