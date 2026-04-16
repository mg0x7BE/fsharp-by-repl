// 006.fsx

// Recap: Combining List operations
// You can chain multiple operations using the pipe operator.

let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

let result = 
    numbers
    |> List.filter (fun x -> x % 2 = 0)  // Keep even numbers
    |> List.map (fun x -> x * x)         // Square them
    |> List.filter (fun x -> x > 20)     // Keep only those > 20

// Result: [36; 64; 100]


// List.sum
// Adds all elements in a list together.
let total = List.sum [1; 2; 3; 4; 5]  // 15

// You can use it after transforming a list:
let sumOfSquares = 
    [1; 2; 3; 4]
    |> List.map (fun x -> x * x)  // [1; 4; 9; 16]
    |> List.sum                    // 30


(*
    Your Task:
    Given the list: [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    
    1. Keep only odd numbers.
    2. Square each number.
    3. Sum all the results.
    4. Use the pipe operator |> to chain everything.
    
    Expected result: 165
    (1² + 3² + 5² + 7² + 9² = 1 + 9 + 25 + 49 + 81 = 165)
    
    Print the final result using printfn.
*)