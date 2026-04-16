// 012.fsx
// Why Option.bind?
// When a transformation itself returns an Option, map gives you Option<Option<T>>.
// bind flattens that - failures short-circuit, happy paths chain cleanly.

// Option.bind
// Use when your transformation function ALSO returns an Option
// This prevents getting Option<Option<T>>

let safeDivide x y =
    if y = 0 then None
    else Some (x / y)


// Without Option.bind (ugly nesting):
let result1 = 
    match safeDivide 20 2 with
    | Some x -> safeDivide x 2  // Some 5
    | None -> None


// With Option.bind (clean):
let result2 = 
    safeDivide 20 2
    |> Option.bind (fun x -> safeDivide x 2)  // Some 5


// Chaining multiple operations
let result3 = 
    safeDivide 100 2   // Some 50
    |> Option.bind (fun x -> safeDivide x 5)   // Some 10
    |> Option.bind (fun x -> safeDivide x 2)   // Some 5

let result4 = 
    safeDivide 100 0   // None (fails here)
    |> Option.bind (fun x -> safeDivide x 5)   // None (skipped)
    |> Option.bind (fun x -> safeDivide x 2)   // None (skipped)


// Combining map and bind
let result5 = 
    safeDivide 20 4    // Some 5
    |> Option.map (fun x -> x + 10)            // Some 15 (just transform)
    |> Option.bind (fun x -> safeDivide x 3)   // Some 5 (divide again)


(*
    Your Task:
    1. Use safeDivide function (copy from examples above)
    
    2. Start by dividing 100 by 2 using safeDivide
    
    3. Then divide result by 5 using Option.bind
    
    4. Then add 10 using Option.map
    
    5. Use Option.defaultValue to get 0 if any step failed
    
    6. Print the result
    
    Expected output: 20
    (100 / 2 = 50, then 50 / 5 = 10, then 10 + 10 = 20)
*)