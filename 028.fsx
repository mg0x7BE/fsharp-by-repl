// 028.fsx
// Why List.zip?
// Parallel lists (names + ages, keys + values) are awkward to process apart.
// zip pairs them up so you can use every list operation you already know.

// List.zip and List.unzip
// List.zip combines two lists into a list of tuples.
// List.unzip splits a list of tuples into two lists.
// IMPORTANT: Both lists must have the SAME length, or List.zip will throw an exception!

// List.zip
let names = ["Alice"; "Bob"; "Carol"]
let ages = [30; 25; 35]

let combined = List.zip names ages
// Result: [("Alice", 30); ("Bob", 25); ("Carol", 35)]


// List.unzip (reverse of zip)
let people = [("Alice", 30); ("Bob", 25); ("Carol", 35)]
let (names2, ages2) = List.unzip people
// names2: ["Alice"; "Bob"; "Carol"]
// ages2: [30; 25; 35]


// Example: Working with zipped data
let scores1 = [85; 90; 78]
let scores2 = [88; 92; 80]

let combined2 = List.zip scores1 scores2
// Result: [(85, 88); (90, 92); (78, 80)]

let averages = 
    combined2
    |> List.map (fun (s1, s2) -> (s1 + s2) / 2)
// Result: [86; 91; 79]


// Practical example: Pairing students with grades
type Student = {
    Name: string
    Grade: int
}

let studentNames = ["Alice"; "Bob"; "Carol"]
let grades = [85; 92; 78]

let students = 
    List.zip studentNames grades
    |> List.map (fun (name, grade) -> { Name = name; Grade = grade })

// Result: [
//   { Name = "Alice"; Grade = 85 }
//   { Name = "Bob"; Grade = 92 }
//   { Name = "Carol"; Grade = 78 }
// ]


(*
    Your Task:
    1. You have two lists:
       let products = ["Laptop"; "Mouse"; "Keyboard"; "Monitor"]
       let prices = [999.99; 25.50; 75.00; 299.99]
    
    2. Use List.zip to combine them into tuples
    
    3. Use List.filter to keep only products with price > 50
    
    4. Use List.map to create strings in format: "{product}: ${price}"
       Hint: To format float with 2 decimal places, use: $"{price:F2}"

    5. Print the resulting list
    
    Expected output:
    ["Laptop: $999.99"; "Keyboard: $75.00"; "Monitor: $299.99"]
*)