// 011.fsx

// Option Recap
// Option represents "maybe has a value": Some value or None

let safeDivide x y =
    if y = 0 then None
    else Some (x / y)

// Option.map
// Transforms the value inside Some (if it exists), otherwise returns None
let doubled = Option.map (fun x -> x * 2) (Some 5)  // Some 10
let nothing = Option.map (fun x -> x * 2) None      // None

// Chaining with pipe
let result1 = 
    safeDivide 20 4
    |> Option.map (fun x -> x * 3)  // Some 15 (20 / 4 * 3)

// Option.defaultValue
// Extracts value from Some, or returns a default if None
let value1 = Option.defaultValue 0 (Some 42)  // 42
let value2 = Option.defaultValue 0 None       // 0

let result2 = 
    safeDivide 10 0
    |> Option.defaultValue 999  // 999 (division failed)

(*
    Your Task:
    1. Write a function findFirst (use your solution from 010a.fsx or rewrite it)
    
    2. Find the first number > 5 in the list [1; 2; 3; 7; 8; 9]
    
    3. Use Option.map to square the result
    
    4. Use Option.defaultValue to provide 0 if nothing was found
    
    5. Print the final value
    
    Expected output: 49
    (First number > 5 is 7, squared = 49)
    
    If list was [1; 2; 3], output should be: 0
*)