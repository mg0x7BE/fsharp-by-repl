// 007.fsx
// Why List.collect?
// Mapping sometimes produces lists of lists - then you need to flatten them.
// List.collect does both in one step, so you avoid messy nested structures.

// List.collect (flatMap)
// Sometimes you want to transform each element into a LIST, then flatten everything.
// List.collect does both: map + flatten.

let numbers = [1; 2; 3]

// Using List.map would give us a list of lists:
let nested = List.map (fun x -> [x; x * 10]) numbers
// Result: [[1; 10]; [2; 20]; [3; 30]]

// List.collect flattens it automatically:
let flattened = List.collect (fun x -> [x; x * 10]) numbers
// Result: [1; 10; 2; 20; 3; 30]


// Another example: Generate ranges
let ranges = List.collect (fun x -> [1 .. x]) [1; 2; 3]
// For 1: [1]
// For 2: [1; 2]
// For 3: [1; 2; 3]
// Result: [1; 1; 2; 1; 2; 3]


// List.concat
// Flattens a list of lists without transformation.
let listOfLists = [[1; 2]; [3; 4]; [5; 6]]
let flat = List.concat listOfLists  // [1; 2; 3; 4; 5; 6]


(*
    Your Task:
    Given the list: [2; 3; 4]
    
    1. For each number n, generate a list from 1 to n (use [1 .. n]).
    2. Flatten all results into a single list.
    3. Filter to keep only even numbers.
    4. Use pipe |> to chain operations.
    
    Expected result: [2; 2; 2; 4]
    
    Explanation:
    - For 2: [1; 2] -> keep 2
    - For 3: [1; 2; 3] -> keep 2
    - For 4: [1; 2; 3; 4] -> keep 2, 4
    - Combined: [2; 2; 2; 4]
    
    Print the final result using printfn.
*)