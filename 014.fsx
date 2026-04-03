// 014.fsx
// Why Records?
// Records give your data named fields — much clearer than tuples.
// They're immutable by default, so you always know your data won't change unexpectedly.

// Records
// Records are like tuples but with named fields.
// They're immutable by default and have great pattern matching support.

type Person = {
    Name: string
    Age: int
}

// Creating a record
let alice = { Name = "Alice"; Age = 30 }
let bob = { Name = "Bob"; Age = 25 }

// Accessing fields
let name = alice.Name  // "Alice"
let age = alice.Age    // 30


// Updating records (creates a NEW record, original unchanged)
let olderAlice = { alice with Age = 31 }
// alice is still { Name = "Alice"; Age = 30 }
// olderAlice is { Name = "Alice"; Age = 31 }


// Pattern matching on records
let greet person =
    match person with
    | { Age = age } when age < 18 -> $"Hi kid!"
    | { Name = name; Age = age } -> $"Hello {name}, you are {age} years old"

let greeting1 = greet alice  // "Hello Alice, you are 30 years old"
let greeting2 = greet { Name = "Tom"; Age = 15 }  // "Hi kid!"


// Records in lists
let people = [
    { Name = "Alice"; Age = 30 }
    { Name = "Bob"; Age = 25 }
    { Name = "Carol"; Age = 35 }
]

let adults = List.filter (fun p -> p.Age >= 18) people
let names = List.map (fun p -> p.Name) people  // ["Alice"; "Bob"; "Carol"]


(*
    Your Task:
    1. Define a record type called Book with fields:
       - Title: string
       - Pages: int
    
    2. Create a list of 4 books with different titles and page counts.
    
    3. Use List.filter to keep only books with more than 200 pages.
    
    4. Use List.map to extract just the titles of those books.
    
    5. Print the resulting list of titles.
    
    Example books:
    - "The Hobbit", 310 pages
    - "1984", 328 pages
    - "Animal Farm", 112 pages
    - "Brave New World", 268 pages
    
    Expected output: ["The Hobbit"; "1984"; "Brave New World"]
*)