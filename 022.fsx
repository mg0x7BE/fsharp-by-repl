// 022.fsx

// List.groupBy
// List.groupBy groups elements by a key function.
// Returns a list of (key, group) tuples where group is a list of elements with that key.
// Syntax: List.groupBy (fun x -> key) list

// Example: Group numbers by even/odd
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

let grouped = List.groupBy (fun x -> x % 2 = 0) numbers
// Result: [(false, [1; 3; 5; 7; 9]); (true, [2; 4; 6; 8; 10])]


// Example: Group people by age range
type Person = {
    Name: string
    Age: int
}

let people = [
    { Name = "Alice"; Age = 25 }
    { Name = "Bob"; Age = 35 }
    { Name = "Carol"; Age = 28 }
    { Name = "Dave"; Age = 42 }
    { Name = "Eve"; Age = 31 }
]

let getAgeGroup person =
    if person.Age < 30 then "20s"
    elif person.Age < 40 then "30s"
    else "40s+"

let byAgeGroup = List.groupBy getAgeGroup people
// Result: 
// [("20s", [{Name="Alice"; Age=25}; {Name="Carol"; Age=28}]); 
//  ("30s", [{Name="Bob"; Age=35}; {Name="Eve"; Age=31}]); 
//  ("40s+", [{Name="Dave"; Age=42}])]


// Example: Count items in each group
let wordLengths = ["cat"; "dog"; "elephant"; "ant"; "bird"; "lion"]

let byLength = 
    wordLengths
    |> List.groupBy (fun word -> word.Length)
    |> List.map (fun (length, words) -> (length, List.length words))
// Result: [(3, 3); (8, 1); (4, 2)]
// 3 words with length 3, 1 word with length 8, 2 words with length 4


(*
    Your Task:
    1. Given this list of numbers: [1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12]
    
    2. Group them by divisibility by 3 (key: x % 3)
       This will create groups for remainders: 0, 1, and 2
    
    3. For each group, calculate the sum of numbers in that group
       Use List.map with the grouped result
    
    4. Print the result as a list of (remainder, sum) tuples
    
    Expected output: [(0, 30); (1, 22); (2, 26)]
    
    Explanation:
    - Remainder 0: [3; 6; 9; 12] -> sum = 30
    - Remainder 1: [1; 4; 7; 10] -> sum = 22
    - Remainder 2: [2; 5; 8; 11] -> sum = 26
*)