// 008.fsx
// Why Partial Application?
// Instead of writing new wrapper functions, you "configure" existing ones
// by fixing some arguments. This makes code shorter and more expressive.

// Partial Application
// In F#, functions are curried by default.
// This means you can "partially apply" them by providing fewer arguments than expected.

let add x y = x + y

// Full application
let result1 = add 5 3  // 8

// Partial application (provide only first argument)
let add5 = add 5       // add5 is now a function waiting for the second argument
let result2 = add5 3   // 8
let result3 = add5 10  // 15


// Practical example with List.map
let numbers = [1; 2; 3; 4; 5]

// Instead of:
let doubled1 = List.map (fun x -> x * 2) numbers

// You can create a helper function:
let multiplyBy n x = n * x
let double = multiplyBy 2  // Partially applied!
let doubled2 = List.map double numbers  // [2; 4; 6; 8; 10]


// Another example
let greet prefix name = prefix + " " + name

let sayHello = greet "Hello"
let sayHi = greet "Hi"

let greeting1 = sayHello "Alice"  // "Hello Alice"
let greeting2 = sayHi "Bob"       // "Hi Bob"


(*
    Your Task:
    1. Create a function multiply that takes two parameters: x and y, and returns x * y.
    2. Create a partially applied function triple by applying multiply with 3.
    3. Use List.map with triple to multiply each number in [1; 2; 3; 4; 5] by 3.
    4. Print the result.
    
    Expected result: [3; 6; 9; 12; 15]
*)