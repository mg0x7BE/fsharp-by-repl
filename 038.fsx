// 038.fsx
// Why Set?
// Membership tests, deduplication, and set operations (union, intersect)
// are awkward on lists. Set makes them fast and expressive.

// Set - Immutable Collections of Unique Values
// Set is F#'s immutable collection where every element is unique.
// Sets automatically remove duplicates and keep elements sorted.
// Use Sets when you care about membership, uniqueness, and set algebra
// (union, intersection, difference).

// Creating a Set from a list - duplicates are removed automatically
let fruits = Set.ofList [ "Banana"; "Apple"; "Cherry"; "Apple"; "Banana" ]
// set ["Apple"; "Banana"; "Cherry"]  - sorted, no duplicates!

// Compare with a list: the list keeps everything
let fruitList = [ "Banana"; "Apple"; "Cherry"; "Apple"; "Banana" ]
// ["Banana"; "Apple"; "Cherry"; "Apple"; "Banana"] - 5 items, original order

// Shorthand syntax: set [...]
let numbers = set [ 3; 1; 4; 1; 5; 9; 2; 6; 5 ]
// set [1; 2; 3; 4; 5; 6; 9]

// Empty set
let empty: Set<int> = Set.empty


// Basic operations - just like Map, everything returns a NEW Set (immutable!)
let colors = set [ "Red"; "Green"; "Blue" ]

let withYellow = colors |> Set.add "Yellow"      // set ["Blue"; "Green"; "Red"; "Yellow"]
let withoutRed = colors |> Set.remove "Red"       // set ["Blue"; "Green"]
let hasGreen = colors |> Set.contains "Green"     // true
let hasBlack = colors |> Set.contains "Black"     // false
let size = Set.count colors                        // 3
let isEmpty = Set.isEmpty colors                   // false
let emptyCheck = Set.isEmpty Set.empty<int>        // true

// Adding an element that already exists - no change (it's already unique)
let same = colors |> Set.add "Red"
// set ["Blue"; "Green"; "Red"] - identical to colors


// Set algebra - this is what makes Sets special!
let teamA = set [ "Alice"; "Bob"; "Carol"; "Dave" ]
let teamB = set [ "Carol"; "Dave"; "Eve"; "Frank" ]

// Union - everyone from EITHER team (combined membership)
let allPeople = Set.union teamA teamB
// set ["Alice"; "Bob"; "Carol"; "Dave"; "Eve"; "Frank"]

// Intersect - only people on BOTH teams
let onBoth = Set.intersect teamA teamB
// set ["Carol"; "Dave"]

// Difference - in first set but NOT in second (asymmetric!)
let onlyA = Set.difference teamA teamB    // in A but not in B
// set ["Alice"; "Bob"]

let onlyB = Set.difference teamB teamA    // in B but not in A
// set ["Eve"; "Frank"]
// Note: difference is NOT symmetric! The order of arguments matters.


// Subset and superset checks
let small = set [ "Carol"; "Dave" ]
let big = set [ "Alice"; "Bob"; "Carol"; "Dave"; "Eve" ]

let isSmallSubset = Set.isSubset small big     // true - every element of small is in big
let isBigSuperset = Set.isSuperset big small   // true - big contains every element of small
let isBigSubset = Set.isSubset big small       // false - big has elements not in small


// Transformations - same pattern as List and Map
let nums = set [ 1; 2; 3; 4; 5; 6; 7; 8 ]

let evens = nums |> Set.filter (fun n -> n % 2 = 0)
// set [2; 4; 6; 8]

let total = Set.fold (fun acc n -> acc + n) 0 nums
// 36

// Set.map - transforms elements. WARNING: may shrink the set if mapping creates duplicates!
let modulo3 = nums |> Set.map (fun n -> n % 3)
// set [0; 1; 2]  - 8 elements mapped, but only 3 unique results!

// Set.iter - side effects, just like List.iter and Map.iter
nums |> Set.iter (fun n -> printf $"{n} ")
// Prints: 1 2 3 4 5 6 7 8

printfn ""  // newline after the printf above


// Converting back to a list (result is sorted, since Sets are sorted)
let backToList = Set.toList fruits
// ["Apple"; "Banana"; "Cherry"]


(*
    Your Task:

    Two course enrollment lists (with accidental duplicate sign-ups):

    let mathSignups = [ "Alice"; "Bob"; "Carol"; "Dave"; "Eve"; "Alice" ]
    let scienceSignups = [ "Bob"; "Dave"; "Frank"; "Grace"; "Bob" ]

    1. Convert both lists to Sets: mathStudents and scienceStudents.

    2. Find students enrolled in BOTH courses. Store as inBoth.

    3. Find students enrolled in math ONLY (not in science). Store as mathOnly.

    4. Find ALL unique students across both courses. Store as allStudents.

    5. Check if inBoth is a subset of mathStudents.

    6. Use Set.filter on allStudents to get names that start with
       a letter in the range 'A'..'E'. Store as earlyAlphabet.

    7. Use Set.fold on allStudents to build a comma-separated string
       of all student names.
       Hint: you can fold with a trailing separator and trim it at the end,
       just like the summary example in 037:
         Map.fold (fun acc name qty -> acc + $"...") "" stock |> fun s -> s.Trim()

    8. Print all results. Use Set.toList where needed for display.

    Expected output:
    Math students: ["Alice"; "Bob"; "Carol"; "Dave"; "Eve"]
    Science students: ["Bob"; "Dave"; "Frank"; "Grace"]
    Both courses: ["Bob"; "Dave"]
    Math only: ["Alice"; "Carol"; "Eve"]
    All students: ["Alice"; "Bob"; "Carol"; "Dave"; "Eve"; "Frank"; "Grace"]
    Both is subset of math? True
    Early alphabet (A-E): ["Alice"; "Bob"; "Carol"; "Dave"; "Eve"]
    All students: Alice, Bob, Carol, Dave, Eve, Frank, Grace
*)

