// 017.fsx
// Why List.fold?
// fold is the most powerful list operation — map, filter, sum, count, reverse
// can ALL be implemented with fold. It's the Swiss Army knife of functional programming.

// List.fold
// List.fold processes a list from left to right, accumulating a result.
// It takes: initial value, folder function, and list.
// Syntax: List.fold (fun accumulator element -> newAccumulator) initialValue list

// Example: Sum all numbers
let numbers = [1; 2; 3; 4; 5]

let sum = List.fold (fun acc x -> acc + x) 0 numbers
// Step by step:
// acc=0, x=1 -> 0+1=1
// acc=1, x=2 -> 1+2=3
// acc=3, x=3 -> 3+3=6
// acc=6, x=4 -> 6+4=10
// acc=10, x=5 -> 10+5=15
// Result: 15


// Example: Count elements
let count = List.fold (fun acc _ -> acc + 1) 0 numbers  // 5


// Example: Build a string
let words = ["hello"; "world"; "from"; "fsharp"]
let sentence = List.fold (fun acc word -> acc + " " + word) "" words
// Result: " hello world from fsharp" (note the leading space)

// Better version with trimming:
let sentence2 = 
    List.fold (fun acc word -> acc + " " + word) "" words
    |> fun s -> s.Trim()
// Result: "hello world from fsharp"


// Example: Find maximum
let findMax list =
    match list with
    | [] -> None
    | head :: tail -> 
        let max = List.fold (fun acc x -> if x > acc then x else acc) head tail
        Some max

let maxNum = findMax [3; 7; 2; 9; 1]  // Some 9


(*
    Your Task:
    1. Write a function called product that:
       - Takes a list of integers
       - Uses List.fold to multiply all numbers together
       - Returns the product
       - Use 1 as the initial value (identity for multiplication)
    
    2. Test it with [2; 3; 4; 5]
    
    3. Print the result
    
    Expected output: 120
    (2 * 3 * 4 * 5 = 120)
*)