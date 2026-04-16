// 036.fsx
// Why Map?
// Looking up values by name, id, or key shows up constantly in real code.
// Map gives you fast, immutable lookup without the pitfalls of mutable dictionaries.

// Map - Immutable Key-Value Collections
// Map is F#'s immutable dictionary. It stores key-value pairs
// and provides fast lookup by key. Keys must be unique.
// Unlike lists, Maps are optimized for finding values by key.

// Creating a Map from a list of tuples
let capitals =
    Map.ofList [
        ("Poland", "Warsaw")
        ("Germany", "Berlin")
        ("France", "Paris")
        ("Spain", "Madrid")
    ]

// Looking up a value by key
// Map.find throws an exception if the key doesn't exist
let capitalOfPoland = Map.find "Poland" capitals  // "Warsaw"

// Map.tryFind returns an Option - safe lookup, no exceptions
let maybeFrance = Map.tryFind "France" capitals    // Some "Paris"
let maybeItaly = Map.tryFind "Italy" capitals      // None

// Checking if a key exists
let hasGermany = Map.containsKey "Germany" capitals  // true
let hasJapan = Map.containsKey "Japan" capitals      // false


// Adding and removing entries (returns a NEW Map - immutable!)
let updated = capitals |> Map.add "Italy" "Rome"
// capitals still has 4 entries, updated has 5

let smaller = capitals |> Map.remove "Spain"
// capitals still has 4 entries, smaller has 3

// If you add a key that already exists, it overwrites the value
let corrected = capitals |> Map.add "Poland" "Kraków"
// Now "Poland" maps to "Kraków" in corrected (capitals unchanged)


// Map.count - number of entries
let size = Map.count capitals  // 4


// Building a Map from data you already have
// Common pattern: start with a list of records, build a lookup map

type Student = { Id: int; Name: string; Grade: float }

let students = [
    { Id = 1; Name = "Alice"; Grade = 4.5 }
    { Id = 2; Name = "Bob"; Grade = 3.8 }
    { Id = 3; Name = "Carol"; Grade = 4.9 }
]

// Create a Map from Id to Name
let nameById =
    students
    |> List.map (fun s -> (s.Id, s.Name))
    |> Map.ofList

let whoIs2 = Map.find 2 nameById  // "Bob"


// Iterating over a Map
// Map.toList converts back to a list of (key, value) tuples
let allCapitals = Map.toList capitals
// [("France", "Paris"); ("Germany", "Berlin"); ("Poland", "Warsaw"); ("Spain", "Madrid")]
// Note: Map sorts entries by key!


// Combining Map.tryFind with pattern matching
let describeCapital country =
    match Map.tryFind country capitals with
    | Some city -> $"{country}: {city}"
    | None -> $"{country}: unknown"

let d1 = describeCapital "Poland"   // "Poland: Warsaw"
let d2 = describeCapital "Italy"    // "Italy: unknown"


(*
    Your Task:

    1. Create a Map called inventory from this data:
       "Apples" -> 50, "Bananas" -> 30, "Oranges" -> 45, "Grapes" -> 20

    2. Write a function checkStock that:
       - Takes a product name (string) and the inventory map
       - Returns a string:
         If found with quantity > 0: "ProductName: X in stock"
         If found with quantity = 0: "ProductName: out of stock"
         If not found: "ProductName: not in our catalog"

    3. Add "Mangoes" -> 15 to the inventory (store as updatedInventory)

    4. Remove "Grapes" from updatedInventory (store as finalInventory)

    5. Print the results of checkStock for: "Apples", "Grapes", "Kiwi"
       using finalInventory

    6. Print the total number of products in finalInventory

    Expected output:
    Apples: 50 in stock
    Grapes: not in our catalog
    Kiwi: not in our catalog
    Total products: 4
*)

