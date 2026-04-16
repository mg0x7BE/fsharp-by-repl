// 026.fsx

// List.collect Revisited
// We used List.collect briefly in lesson 007, but let's explore it deeper.
// List.collect maps each element to a list, then flattens all lists into one.
// It's like "flatMap" in other languages.
// Syntax: List.collect (fun x -> list) list

// Recap from 007
let numbers = [1; 2; 3]
let ranges = List.collect (fun x -> [1 .. x]) numbers
// Result: [1; 1; 2; 1; 2; 3]


// Example: Flatten nested lists
let nestedLists = [[1; 2]; [3; 4]; [5; 6]]
let flattened = List.collect (fun x -> x) nestedLists
// Result: [1; 2; 3; 4; 5; 6]
// Same as: List.concat nestedLists


// Example: Generate multiple items per element
let words = ["cat"; "dog"; "bird"]
let letters = List.collect (fun word -> [for c in word -> c]) words
// Result: ['c'; 'a'; 't'; 'd'; 'o'; 'g'; 'b'; 'i'; 'r'; 'd']


// Example: Combining with records
type Person = {
    Name: string
    Hobbies: string list
}

let people = [
    { Name = "Alice"; Hobbies = ["reading"; "gaming"] }
    { Name = "Bob"; Hobbies = ["cooking"; "hiking"; "gaming"] }
    { Name = "Carol"; Hobbies = ["reading"] }
]

let allHobbies = List.collect (fun p -> p.Hobbies) people
// Result: ["reading"; "gaming"; "cooking"; "hiking"; "gaming"; "reading"]


// Example: Get unique hobbies
let uniqueHobbies = 
    people
    |> List.collect (fun p -> p.Hobbies)
    |> List.distinct  // Removes duplicates

// Result: ["reading"; "gaming"; "cooking"; "hiking"]


// Example: Combine with filter
let activeHobbies = 
    people
    |> List.filter (fun p -> List.length p.Hobbies > 1)
    |> List.collect (fun p -> p.Hobbies)

// Result: ["reading"; "gaming"; "cooking"; "hiking"; "gaming"]


(*
    Your Task:
    1. Given this data:
       type Student = {
           Name: string
           Courses: string list
       }
       
       let students = [
           { Name = "Alice"; Courses = ["Math"; "Physics"] }
           { Name = "Bob"; Courses = ["Math"; "Chemistry"; "Biology"] }
           { Name = "Carol"; Courses = ["Physics"; "Chemistry"] }
       ]
    
    2. Use List.collect to get all courses from all students (flattened list)
    
    3. Use List.distinct to get unique courses
    
    4. Use List.sortBy to sort them alphabetically
    
    5. Print the resulting list
    
    Expected output: ["Biology"; "Chemistry"; "Math"; "Physics"]
*)