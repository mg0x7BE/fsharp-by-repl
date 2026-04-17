// 039.fsx
// Why Arrays?
// Lists are great for pipelines, but arrays give you O(1) indexed access
// and are the go-to type when working with .NET libraries.

// Arrays - Mutable, Fixed-Size, Indexed Collections
// Arrays look like lists but use [| ... |] syntax.
// Unlike lists, arrays support fast random access by index
// and their elements CAN be mutated in place.

// Creating arrays
let names = [| "Alice"; "Bob"; "Carol"; "Dave" |]
let nums = [| 1; 2; 3; 4; 5 |]
let empty: int array = [||]

// Indexed access with [index] - zero-based, O(1)
let first = names[0]       // "Alice"
let third = names[2]       // "Carol"
let last = names[3]        // "Dave"

// Array.length - like List.length
let len = Array.length names    // 4
// You can also use the .Length property:
let len2 = names.Length         // 4


// Familiar friends - Array versions of List functions
// Almost every List.xxx has an Array.xxx counterpart.

let doubled = nums |> Array.map (fun n -> n * 2)
// [| 2; 4; 6; 8; 10 |]

let evens = nums |> Array.filter (fun n -> n % 2 = 0)
// [| 2; 4 |]

let total = nums |> Array.sum
// 15

let totalDoubled = nums |> Array.sumBy (fun n -> n * 2)
// 30

let sorted = [| 3; 1; 4; 1; 5 |] |> Array.sort
// [| 1; 1; 3; 4; 5 |]

let sortedByLen = [| "Banana"; "Fig"; "Cherry" |] |> Array.sortBy (fun s -> s.Length)
// [| "Fig"; "Banana"; "Cherry" |]

let found = nums |> Array.tryFind (fun n -> n > 3)
// Some 4

let folded = nums |> Array.fold (fun acc n -> acc + n) 0
// 15


// Mutation - arrays are mutable! Use <- to change an element.
let scores = [| 10; 20; 30 |]
scores[1] <- 99
// scores is now [| 10; 99; 30 |]
// This changes the array IN PLACE - no new array is created.
// Use mutation sparingly in F# - prefer map/filter when possible.


// Array.init - create an array by computing each element from its index
let squares = Array.init 5 (fun i -> (i + 1) * (i + 1))
// [| 1; 4; 9; 16; 25 |]

let zeros = Array.create 4 0
// [| 0; 0; 0; 0 |]


// Converting between arrays and lists
let fromList = [1; 2; 3] |> Array.ofList
// [| 1; 2; 3 |]

let toList = [| 4; 5; 6 |] |> Array.toList
// [4; 5; 6]


// Slicing - get a sub-array with [start..end] (inclusive on both ends)
let letters = [| "a"; "b"; "c"; "d"; "e" |]
let middle = letters[1..3]      // [| "b"; "c"; "d" |]
let fromTwo = letters[2..]      // [| "c"; "d"; "e" |]
let upToTwo = letters[..2]      // [| "a"; "b"; "c" |]


// Printing arrays - %A works, just like lists
printfn $"%A{doubled}"     // [|2; 4; 6; 8; 10|]


(*
    Your Task:

    Given this data:

    let temperatures = [| 22.1; 18.4; 25.7; 30.2; 15.8; 28.3; 19.6 |]

    1. Find the number of days (Array.length).

    2. Use Array.map to convert each temperature to Fahrenheit.
       Formula: f = c * 9.0 / 5.0 + 32.0

    3. Use Array.filter on the original Celsius array to get "hot days"
       (temperatures above 25.0).

    4. Use Array.sort on the original array to get temperatures in order.

    5. Use Array.tryFind to find the first temperature below 20.0.

    6. Use Array.fold to compute the average temperature.
       Hint: fold to get the sum, then divide by float of the length.

    7. Use Array.init to create an array of 7 day labels:
       [| "Day 1"; "Day 2"; ... "Day 7" |]
       Hint: Array.init takes a count and a function (fun i -> ...).
       Use $"Day %d{i + 1}" to build each string.

    8. Use Array.zip to pair the day labels with the original temperatures.
       Then print each pair.

    Expected output:
    Days: 7
    Fahrenheit: [|71.78; 65.12; 78.26; 86.36; 60.44; 82.94; 67.28|]
    Hot days: [|25.7; 30.2; 28.3|]
    Sorted: [|15.8; 18.4; 19.6; 22.1; 25.7; 28.3; 30.2|]
    First below 20: Some 18.4
    Average: 22.87
    Day 1: 22.1C
    Day 2: 18.4C
    Day 3: 25.7C
    Day 4: 30.2C
    Day 5: 15.8C
    Day 6: 28.3C
    Day 7: 19.6C
*)

