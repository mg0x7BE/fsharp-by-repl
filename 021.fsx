// 021.fsx
// Why List.choose?
// Filtering and mapping in two passes is verbose when the mapping itself can fail.
// choose merges them: transform once, keep only the Some results.

// List.choose
// List.choose combines map and filter: transform elements and keep only Some results.
// It applies a function that returns Option, then keeps only the Some values.
// Syntax: List.choose (fun x -> Some value | None) list

// Example: Parse numbers from strings, keep only valid ones
let strings = ["10"; "abc"; "20"; "xyz"; "30"]

let parseNumber (str: string) =
    match System.Int32.TryParse(str) with
    | (true, num) -> Some num
    | (false, _) -> None
    
let validNumbers = List.choose parseNumber strings
// Result: [10; 20; 30] (skips "abc" and "xyz")


// Without choose, you'd need two steps:
let validNumbers2 =
    strings
    |> List.map parseNumber      // [Some 10; None; Some 20; None; Some 30]
    |> List.filter Option.isSome  // [Some 10; Some 20; Some 30]
    |> List.map Option.get        // [10; 20; 30]

// With choose - one step!


// Example: Extract ages of adults only
type Person = {
    Name: string
    Age: int
}

let people = [
    { Name = "Alice"; Age = 30 }
    { Name = "Bob"; Age = 15 }
    { Name = "Carol"; Age = 25 }
    { Name = "Dave"; Age = 12 }
]

let getAdultAge person =
    if person.Age >= 18 then
        Some person.Age
    else
        None

let adultAges = List.choose getAdultAge people
// Result: [30; 25]


// Example: Safe division on a list
let safeDivide10By x =
    if x = 0 then None
    else Some (10 / x)

let numbers = [2; 0; 5; 0; 1]
let results = List.choose safeDivide10By numbers
// Result: [5; 2; 10] (skips divisions by zero)


(*
    Your Task:
    1. Create a function called extractPositive that:
       - Takes an integer
       - Returns Some value if the number is positive (> 0)
       - Returns None otherwise

    2. Use List.choose with extractPositive on this list:
       [-5; 10; -3; 0; 7; -1; 15]

    3. Print the resulting list

    Expected output: [10; 7; 15]
*)