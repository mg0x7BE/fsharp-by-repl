// 037.fsx

// Map Transformations — Map.map, Map.filter, Map.fold, Map.iter
// Just like Lists, Maps have transformation functions.
// The key difference: the lambda always receives BOTH the key AND the value.

// Sample data for all examples
let stock = Map.ofList [ ("Apples", 50); ("Bananas", 30); ("Cherries", 80); ("Dates", 15) ]


// Map.map — transforms every value, keeps all keys
// Signature: Map.map (fun key value -> newValue) map
// Note: the function gets both key and value, even if you only need the value

let doubled = stock |> Map.map (fun _key qty -> qty * 2)
// map [("Apples", 100); ("Bananas", 60); ("Cherries", 160); ("Dates", 30)]

// You can use the key too — e.g. add a label
let labeled = stock |> Map.map (fun name qty -> $"{name}: {qty} pcs")
// map [("Apples", "Apples: 50 pcs"); ("Bananas", "Bananas: 30 pcs"); ...]

// Conditional transformation — different logic based on value
let adjusted = stock |> Map.map (fun _ qty -> if qty < 30 then qty + 10 else qty)
// Dates: 15 -> 25, others unchanged


// Map.filter — keeps only entries where predicate returns true
// Signature: Map.filter (fun key value -> bool) map

let abundant = stock |> Map.filter (fun _ qty -> qty >= 50)
// map [("Apples", 50); ("Cherries", 80)]

let startsWithB = stock |> Map.filter (fun name _ -> name.StartsWith("B"))
// map [("Bananas", 30)]


// Map.fold — accumulate a result over all key-value pairs
// Signature: Map.fold (fun state key value -> newState) initialState map
// Works just like List.fold (exercise 017), but the folder receives key AND value

let totalStock = Map.fold (fun acc _ qty -> acc + qty) 0 stock
// 0 + 50 + 30 + 80 + 15 = 175

// Build a summary string
let summary =
    Map.fold (fun acc name qty -> acc + $"{name}={qty} ") "" stock
    |> fun s -> s.Trim()
// "Apples=50 Bananas=30 Cherries=80 Dates=15"

// Find the item with the highest quantity
let maxItem =
    Map.fold (fun (bestName, bestQty) name qty ->
        if qty > bestQty then (name, qty) else (bestName, bestQty)
    ) ("", 0) stock
// ("Cherries", 80)


// Map.iter — execute an action for each entry (side effects, returns unit)
// Just like List.iter, but the function gets key and value

stock |> Map.iter (fun name qty -> printfn $"  {name}: {qty}")
// Prints:
//   Apples: 50
//   Bananas: 30
//   Cherries: 80
//   Dates: 15


// Map.exists — returns true if ANY entry satisfies the predicate
let hasLargeStock = stock |> Map.exists (fun _ qty -> qty > 100)  // false
let hasApples = stock |> Map.exists (fun name _ -> name = "Apples")  // true

// Map.forall — returns true if ALL entries satisfy the predicate
let allPositive = stock |> Map.forall (fun _ qty -> qty > 0)  // true
let allAbove20 = stock |> Map.forall (fun _ qty -> qty > 20)  // false (Dates = 15)


(*
    Your Task:

    You have a map of employee names to their monthly salaries:

    let salaries =
        Map.ofList [
            ("Alice", 4200.0)
            ("Bob", 5800.0)
            ("Carol", 3900.0)
            ("Dave", 7200.0)
            ("Eve", 4800.0)
        ]

    1. Use Map.map to apply a 10% raise to employees earning below 5000.0.
       Those earning 5000.0 or more keep their current salary.
       Store as updatedSalaries.

    2. Use Map.filter on updatedSalaries to get only employees
       earning 5000.0 or more. Store as seniorPay.

    3. Use Map.fold on updatedSalaries to calculate the total salary bill.

    4. Use Map.exists on updatedSalaries to check if anyone earns more than 10000.0.

    5. Print each employee's updated salary using Map.iter, formatted as:
       "  Name: $XXXX.XX"

    6. Print the total salary bill and the exists result.

    Expected output:
      Alice: $4620.00
      Bob: $5800.00
      Carol: $4290.00
      Dave: $7200.00
      Eve: $5280.00
    Total salary bill: $27190.00
    Anyone above $10000? False
    Senior employees (>= $5000):
      Bob: $5800.00
      Dave: $7200.00
      Eve: $5280.00
*)

