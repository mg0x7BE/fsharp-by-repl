// 005.fsx

// Recap: List.map
// List.map applies a function to every element in a list.
// Syntax: List.map (fun x -> ...) [list]

let numbers = [1; 2; 3; 4; 5]
let doubled = List.map (fun x -> x * 2) numbers  // [2; 4; 6; 8; 10]

// You can also use named functions
let square x = x * x
let squared = List.map square numbers  // [1; 4; 9; 16; 25]


// Recap: List.filter
// List.filter keeps only elements that match a condition (return true).
// Syntax: List.filter (fun x -> condition) [list]

let evens = List.filter (fun x -> x % 2 = 0) numbers  // [2; 4]
let greaterThanThree = List.filter (fun x -> x > 3) numbers  // [4; 5]


// Combining with Pipe |>
// The pipe operator passes the result from the left to the function on the right.
let result = 
    numbers
    |> List.filter (fun x -> x % 2 = 0)  // Keep evens: [2; 4]
    |> List.map (fun x -> x * x)         // Square them: [4; 16]

// This is equivalent to:
// let temp = List.filter (fun x -> x % 2 = 0) numbers
// let result = List.map (fun x -> x * x) temp


(*
    Your Task:
    Given the list: [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    
    1. Filter to keep only numbers greater than 5.
    2. Then multiply each remaining number by 3.
    3. Use the pipe operator |> to chain the operations.
    
    Expected result: [18; 21; 24; 27; 30]
    
    Print the final result using printfn.
*)