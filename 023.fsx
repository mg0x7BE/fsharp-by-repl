// 023.fsx
// Why List.sortBy?
// Sorting by a derived key (length, age, price) is the common case.
// sortBy lets you name the key with a lambda instead of writing a comparer.

// List.sortBy and List.sortByDescending
// List.sortBy sorts a list by a key function (ascending order).
// List.sortByDescending sorts in descending order.
// Syntax: List.sortBy (fun x -> key) list

// Example: Sort numbers (default ascending)
let numbers = [5; 2; 8; 1; 9; 3]
let sorted = List.sortBy (fun x -> x) numbers
// Result: [1; 2; 3; 5; 8; 9]

// Shorthand using id (identity function)
let sorted2 = List.sortBy id numbers  // Same as above


// Example: Sort descending
let sortedDesc = List.sortByDescending (fun x -> x) numbers
// Result: [9; 8; 5; 3; 2; 1]


// Example: Sort people by age
type Person = {
    Name: string
    Age: int
}

let people = [
    { Name = "Alice"; Age = 30 }
    { Name = "Bob"; Age = 25 }
    { Name = "Carol"; Age = 35 }
    { Name = "Dave"; Age = 28 }
]

let byAge = List.sortBy (fun p -> p.Age) people
// Result: Bob(25), Dave(28), Alice(30), Carol(35)

let byAgeDesc = List.sortByDescending (fun p -> p.Age) people
// Result: Carol(35), Alice(30), Dave(28), Bob(25)


// Example: Sort strings by length
let words = ["cat"; "elephant"; "dog"; "ant"; "bird"]
let byLength = List.sortBy (fun (w: string) -> w.Length) words
// Result: ["ant"; "cat"; "dog"; "bird"; "elephant"]


// Example: Sort with pipe
let result = 
    [10; 5; 8; 3; 7]
    |> List.filter (fun x -> x > 4)    // [10; 5; 8; 7]
    |> List.sortBy (fun x -> x)        // [5; 7; 8; 10]


(*
    Your Task:
    1. Given this list of people:
       [
         { Name = "Alice"; Age = 30 }
         { Name = "Bob"; Age = 25 }
         { Name = "Carol"; Age = 35 }
         { Name = "Dave"; Age = 25 }
         { Name = "Eve"; Age = 28 }
       ]
    
    2. Filter to keep only people aged 25 or older
    
    3. Sort by age in descending order (oldest first)
    
    4. Take only the first 3 people (use List.take)
    
    5. Extract just their names (use List.map)
    
    6. Print the resulting list of names
    
    Expected output: ["Carol"; "Alice"; "Eve"]
    (Carol is 35, Alice is 30, Eve is 28)
*)