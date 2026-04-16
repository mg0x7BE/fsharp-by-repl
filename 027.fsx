// 027.fsx
// Why List.partition?
// Sometimes you need BOTH halves - the matches AND the rest.
// partition runs the predicate once and gives you both, instead of filtering twice.

// List.partition
// List.partition splits a list into two lists based on a predicate.
// Returns a tuple: (elements that match, elements that don't match)
// Syntax: List.partition (fun x -> bool) list

// Example: Separate even and odd numbers
let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let (evens, odds) = List.partition (fun x -> x % 2 = 0) numbers
// evens: [2; 4; 6; 8; 10]
// odds: [1; 3; 5; 7; 9]


// Example: Separate adults and minors
type Person = {
    Name: string
    Age: int
}

let people = [
    { Name = "Alice"; Age = 30 }
    { Name = "Bob"; Age = 15 }
    { Name = "Carol"; Age = 25 }
    { Name = "Dave"; Age = 12 }
    { Name = "Eve"; Age = 35 }
]

let (adults, minors) = List.partition (fun p -> p.Age >= 18) people
// adults: Alice(30), Carol(25), Eve(35)
// minors: Bob(15), Dave(12)


// Example: Process both groups differently
let (passing, failing) = 
    [55; 42; 78; 30; 90; 48]
    |> List.partition (fun score -> score >= 50)

let passingAverage = 
    if List.isEmpty passing then 0.0
    else float (List.sum passing) / float (List.length passing)

let failingAverage = 
    if List.isEmpty failing then 0.0
    else float (List.sum failing) / float (List.length failing)

// passing: [55; 78; 90], average: 74.33
// failing: [42; 30; 48], average: 40.0


// Comparison with filter
// Using filter (need two passes):
let evens2 = List.filter (fun x -> x % 2 = 0) numbers
let odds2 = List.filter (fun x -> x % 2 <> 0) numbers

// Using partition (single pass, more efficient):
let (evens3, odds3) = List.partition (fun x -> x % 2 = 0) numbers


(*
    Your Task:
    1. Given this list of numbers: [12; 7; 23; 4; 19; 8; 31; 15; 2; 27]
    
    2. Use List.partition to separate them into:
       - Numbers greater than 15
       - Numbers 15 or less
    
    3. For each group:
       - Calculate the sum
       - Count how many numbers (use List.length)
    
    4. Print both results in format:
       "Greater than 15: count={count}, sum={sum}"
       "15 or less: count={count}, sum={sum}"

    Hint: the sum of all numbers is 148.
    
    Expected output:
    - Greater than 15: count=4, sum=100  (23, 19, 31, 27)
    - 15 or less: count=6, sum=48  (12, 7, 4, 8, 15, 2)
*)