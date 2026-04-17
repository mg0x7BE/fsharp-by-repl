// 040.fsx
// Why String Processing?
// Real-world data arrives as text - CSV lines, user input, log entries.
// Knowing how to split, trim, and reassemble strings is essential.

// String Processing - Split, Trim, Join, and Replace
// F# strings are .NET strings, so you use .NET methods directly.
// These methods are called with dot syntax on string values.

// Splitting a string into parts
// .Split takes a char (or char array) as the delimiter
let csv = "Alice,Bob,Carol,Dave"
let names = csv.Split(',')
// [| "Alice"; "Bob"; "Carol"; "Dave" |]  - returns a string ARRAY

// You can split on multiple characters
let messy = "one;two,three;four"
let parts = messy.Split([| ','; ';' |])
// [| "one"; "two"; "three"; "four" |]

// Splitting on a string delimiter (e.g. " - ")
// Use StringSplitOptions to control behavior
let title = "F# - The Fun Language"
let titleParts = title.Split(" - ")
// [| "F#"; "The Fun Language" |]


// Trimming whitespace
// .Trim() removes leading and trailing spaces (and tabs, newlines)
let padded = "   hello   "
let trimmed = padded.Trim()       // "hello"

// Trim only one side
let leftTrimmed = padded.TrimStart()   // "hello   "
let rightTrimmed = padded.TrimEnd()    // "   hello"


// String.concat - join a sequence of strings with a separator
// This is an F# function (not a .NET method), so it works in pipelines!
let joined = [| "Alice"; "Bob"; "Carol" |] |> String.concat ", "
// "Alice, Bob, Carol"

let withDashes = [ "2025"; "04"; "17" ] |> String.concat "-"
// "2025-04-17"


// .Replace - replace all occurrences of a substring
let greeting = "Hello World World"
let fixed' = greeting.Replace("World", "F#")
// "Hello F# F#"


// .ToUpper and .ToLower - change case
let shout = "hello".ToUpper()    // "HELLO"
let quiet = "HELLO".ToLower()    // "hello"


// .Contains - check if a string contains a substring
let hasFun = "F# is fun".Contains("fun")     // true
let hasJava = "F# is fun".Contains("Java")   // false


// .Length - number of characters in a string
let len = "Hello".Length    // 5


// Combining Split, Trim, and pipeline
// Common pattern: split a CSV line, trim each part, collect results
let rawLine = " Alice , Bob , Carol "
let cleanNames =
    rawLine.Split(',')
    |> Array.map (fun s -> s.Trim())
// [| "Alice"; "Bob"; "Carol" |]


// Combining everything - parsing a simple key=value config line
let configLine = "  server = localhost  "
let keyValue =
    let parts = configLine.Split('=') |> Array.map (fun s -> s.Trim())
    (parts[0], parts[1])
// ("server", "localhost")


(*
    Your Task:

    Given this data:

    let data = "  John:28:Developer , Jane:34:Designer , Bob:45:Manager , Alice:31:Developer  "

    1. Split by ',' to get individual person strings.
       Then trim each one.

    2. For each person string, split by ':' to get name, age, and role.
       Parse age to int using int (e.g. int "28" gives 28).
       Store results as an array of tuples: (string * int * string)
       Hint: after splitting "John:28:Developer" by ':' you get
       a 3-element array. Use parts[0], parts[1], parts[2].

    3. Use Array.filter to find all developers (role = "Developer").

    4. Use Array.map to extract just the names from the full array.

    5. Use String.concat to join the names with " and ".

    6. Find the oldest person using Array.maxBy.
       Hint: Array.maxBy works like List.sortBy - give it a function
       that returns the value to compare. It returns the whole element.

    Expected output:
    People: [|("John", 28, "Developer"); ("Jane", 34, "Designer"); ("Bob", 45, "Manager");
              ("Alice", 31, "Developer")|]
    Developers: [|("John", 28, "Developer"); ("Alice", 31, "Developer")|]
    All names: John and Jane and Bob and Alice
    Oldest: Bob (45)
*)

