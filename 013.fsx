// 013.fsx
// Why Tuples?
// Tuples let you group values without defining a new type.
// Perfect for returning multiple values from a function.

// Tuples
// A tuple groups multiple values together into one value.
// Values can be of different types.

let person = ("Alice", 30)          // string * int
let point = (3.5, 7.2)              // float * float
let triple = ("Bob", 25, true)      // string * int * bool


// Accessing tuple elements with fst and snd (only for 2-element tuples)
let name = fst person   // "Alice"
let age = snd person    // 30


// Destructuring (works for any tuple size)
let (n, a) = person              // n = "Alice", a = 30
let (x, y) = point               // x = 3.5, y = 7.2
let (name2, age2, active) = triple  // name2 = "Bob", age2 = 25, active = true


// Pattern matching on tuples
let describePoint point =
    match point with
    | (0, 0) -> "Origin"
    | (x, 0) -> $"On X-axis at {x}"
    | (0, y) -> $"On Y-axis at {y}"
    | (x, y) -> $"Point at ({x}, {y})"

let result1 = describePoint (0, 0)   // "Origin"
let result2 = describePoint (5, 0)   // "On X-axis at 5"
let result3 = describePoint (3, 4)   // "Point at (3, 4)"

// Pattern matching on tuples with guards
let classifyPoint (x, y) =
    match (x, y) with
    | (a, b) when a = 0 && b = 0 -> "Origin"
    | (a, b) when b = 0 -> $"On X-axis at {a}"
    | (a, b) when a = 0 -> $"On Y-axis at {b}"
    | (a, b) -> $"Point at ({a}, {b})"

let result4 = classifyPoint (5, 0)  // "On X-axis at 5"

// Tuples in functions
let addPair (a, b) = a + b
let sum = addPair (3, 5)  // 8


(*
    Your Task:
    1. Create a function called describePerson that:
       - Takes a tuple of (string, int) representing (name, age)
       - Uses pattern matching to return:
         - "Child: {name}" if age < 18
         - "Adult: {name}" if age >= 18 and age < 65
         - "Senior: {name}" if age >= 65
    
    2. Test it with:
       - ("Alice", 10)
       - ("Bob", 35)
       - ("Carol", 70)
    
    3. Print all three results.
    
    Expected output:
    - Child: Alice
    - Adult: Bob
    - Senior: Carol
*)