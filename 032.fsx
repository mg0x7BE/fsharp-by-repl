// 032.fsx

// List.groupBy with Records
// Now let's use groupBy with real data structures (like in real projects)

type Person = {
    Name: string
    Age: int
    City: string
}

let people = [
    { Name = "Alice"; Age = 25; City = "Warsaw" }
    { Name = "Bob"; Age = 30; City = "Krakow" }
    { Name = "Carol"; Age = 25; City = "Warsaw" }
    { Name = "Dave"; Age = 35; City = "Krakow" }
    { Name = "Eve"; Age = 25; City = "Gdansk" }
]


// Example 1: Group by City
let byCity = List.groupBy (fun p -> p.City) people

// What does this return?
// Input: [Alice(Warsaw); Bob(Krakow); Carol(Warsaw); Dave(Krakow); Eve(Gdansk)]
//
// Extract key for each person (p.City):
// Alice -> "Warsaw"
// Bob -> "Krakow"
// Carol -> "Warsaw"
// Dave -> "Krakow"
// Eve -> "Gdansk"
//
// Group by key:
// "Warsaw": [Alice; Carol]
// "Krakow": [Bob; Dave]
// "Gdansk": [Eve]
//
// Result type: (string * Person list) list
// Result: [
//   ("Warsaw", [Alice; Carol]);
//   ("Krakow", [Bob; Dave]);
//   ("Gdansk", [Eve])
// ]

printfn "Grouped by city: %A" byCity


// Example 2: Count people per city
let cityCount = 
    byCity
    |> List.map (fun (city, people) -> (city, List.length people))

// Step by step:
// Input: [("Warsaw", [Alice; Carol]); ("Krakow", [Bob; Dave]); ("Gdansk", [Eve])]
//
// First tuple: ("Warsaw", [Alice; Carol])
//   city = "Warsaw"
//   people = [Alice; Carol]  <- This is a LIST of Person records
//   List.length people = 2
//   Result: ("Warsaw", 2)
//
// Second tuple: ("Krakow", [Bob; Dave])
//   city = "Krakow"
//   people = [Bob; Dave]
//   List.length people = 2
//   Result: ("Krakow", 2)
//
// Third tuple: ("Gdansk", [Eve])
//   city = "Gdansk"
//   people = [Eve]
//   List.length people = 1
//   Result: ("Gdansk", 1)
//
// Final result: [("Warsaw", 2); ("Krakow", 2); ("Gdansk", 1)]

printfn "People per city: %A" cityCount


// Example 3: Group by Age, get names from each group
let byAge = List.groupBy (fun p -> p.Age) people

// Result: [(25, [Alice; Carol; Eve]); (30, [Bob]); (35, [Dave])]

let ageNames = 
    byAge
    |> List.map (fun (age, peopleList) -> 
        let names = List.map (fun p -> p.Name) peopleList
        (age, names))

// Step by step for first group:
// Input: (25, [Alice; Carol; Eve])
//   age = 25
//   peopleList = [Alice; Carol; Eve]
//   
//   Extract names from peopleList:
//   List.map (fun p -> p.Name) [Alice; Carol; Eve]
//   = [Alice.Name; Carol.Name; Eve.Name]
//   = ["Alice"; "Carol"; "Eve"]
//   
//   Result: (25, ["Alice"; "Carol"; "Eve"])
//
// Final result: [(25, ["Alice"; "Carol"; "Eve"]); (30, ["Bob"]); (35, ["Dave"])]

printfn "Names by age: %A" ageNames


// Example 4: Get first person from each city
let firstPerCity = 
    byCity
    |> List.map (fun (city, peopleList) -> 
        let firstPerson = List.head peopleList
        (city, firstPerson.Name))

// Step by step:
// Input: [("Warsaw", [Alice; Carol]); ("Krakow", [Bob; Dave]); ("Gdansk", [Eve])]
//
// First tuple: ("Warsaw", [Alice; Carol])
//   city = "Warsaw"
//   peopleList = [Alice; Carol]
//   List.head peopleList = Alice
//   Alice.Name = "Alice"
//   Result: ("Warsaw", "Alice")
//
// Final result: [("Warsaw", "Alice"); ("Krakow", "Bob"); ("Gdansk", "Eve")]

printfn "First person per city: %A" firstPerCity


(*
    Your Task:
    
    Given these students:
    
    type Student = {
        Name: string
        Grade: int
        Subject: string
    }
    
    let students = [
        { Name = "Alice"; Grade = 85; Subject = "Math" }
        { Name = "Bob"; Grade = 92; Subject = "Physics" }
        { Name = "Carol"; Grade = 78; Subject = "Math" }
        { Name = "Dave"; Grade = 88; Subject = "Physics" }
        { Name = "Eve"; Grade = 95; Subject = "Math" }
    ]
    
    1. Group students by Subject
    
    2. Print the grouped result to see the structure
    
    3. For each subject, calculate the average grade
       Steps for one group:
       - You have: (subject, list_of_students)
       - Extract grades: List.map (fun s -> s.Grade) list_of_students
       - Calculate average: sum / count (remember to convert to float)
       - Result: (subject, average)
    
    4. Print the averages
    
    Expected output for step 2:
    [("Math", [Alice; Carol; Eve]); ("Physics", [Bob; Dave])]
    
    Expected output for step 4:
    [("Math", 86.0); ("Physics", 90.0)]
    Math: (85 + 78 + 95) / 3 = 86.0
    Physics: (92 + 88) / 2 = 90.0
*)