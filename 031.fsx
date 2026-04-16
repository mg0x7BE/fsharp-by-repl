// 031.fsx

// Understanding List.groupBy - Step by Step
// groupBy splits a list into groups based on a key function.
// Result: list of tuples (key, list_of_items_with_that_key)

// Let's start VERY simple

// Example 1: Group numbers by even/odd
let numbers = [1; 2; 3; 4; 5; 6]

let grouped = List.groupBy (fun x -> x % 2) numbers

// What does this return? Let's see step by step:
// Input: [1; 2; 3; 4; 5; 6]
// 
// For each number, calculate key (x % 2):
// 1 % 2 = 1 (odd)
// 2 % 2 = 0 (even)
// 3 % 2 = 1 (odd)
// 4 % 2 = 0 (even)
// 5 % 2 = 1 (odd)
// 6 % 2 = 0 (even)
//
// Group by key:
// Key 1 (odd): [1; 3; 5]
// Key 0 (even): [2; 4; 6]
//
// Result: [(1, [1; 3; 5]); (0, [2; 4; 6])]
//         ^^^ tuple 1      ^^^ tuple 2
//         key, list        key, list

printfn "Grouped by even/odd: %A" grouped
// Output: [(1, [1; 3; 5]); (0, [2; 4; 6])]


// Example 2: Extract data from grouped result
let (odds, evens) = 
    match grouped with
    | [(oddKey, oddList); (evenKey, evenList)] -> (oddList, evenList)
    | _ -> ([], [])

printfn "Odds: %A" odds    // [1; 3; 5]
printfn "Evens: %A" evens  // [2; 4; 6]


// Example 3: Count items in each group
let counts = 
    grouped
    |> List.map (fun (key, items) -> (key, List.length items))

// Step by step:
// Input: [(1, [1; 3; 5]); (0, [2; 4; 6])]
// 
// First tuple: (1, [1; 3; 5])
//   key = 1
//   items = [1; 3; 5]
//   List.length items = 3
//   Result: (1, 3)
//
// Second tuple: (0, [2; 4; 6])
//   key = 0
//   items = [2; 4; 6]
//   List.length items = 3
//   Result: (0, 3)
//
// Final result: [(1, 3); (0, 3)]

printfn "Counts: %A" counts  // [(1, 3); (0, 3)]


// Example 4: Group strings by length
let words = ["cat"; "dog"; "bird"; "ant"; "elephant"]
let getLength (s: string) = s.Length
let byLength = List.groupBy getLength words

// Step by step:
// "cat".Length = 3
// "dog".Length = 3
// "bird".Length = 4
// "ant".Length = 3
// "elephant".Length = 8
//
// Groups:
// Key 3: ["cat"; "dog"; "ant"]
// Key 4: ["bird"]
// Key 8: ["elephant"]
//
// Result: [(3, ["cat"; "dog"; "ant"]); (4, ["bird"]); (8, ["elephant"])]

printfn "Grouped by length: %A" byLength


(*
    Your Task - SIMPLE groupBy practice:
    
    Given this list of numbers: [10; 15; 20; 25; 30; 35; 40]
    
    1. Use List.groupBy to group them by: x / 10
       (This groups them into "decades": 10s, 20s, 30s, 40s)
       
       Hint: 10 / 10 = 1, 15 / 10 = 1, 20 / 10 = 2, etc.
    
    2. Print the grouped result to see the structure
    
    3. Use List.map to transform each group into:
       (decade, count_of_numbers)
       
       Example: if key is 1 and list is [10; 15], result should be (1, 2)
    
    4. Print the counts
    
    Expected output for step 2:
    [(1, [10; 15]); (2, [20; 25]); (3, [30; 35]); (4, [40])]
    
    Expected output for step 4:
    [(1, 2); (2, 2); (3, 2); (4, 1)]
*)