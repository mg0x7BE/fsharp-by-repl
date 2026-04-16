let list1 = [1; 3; 5; 8; 9; 10]
let list2 = [1; 50; 75; 90]

let isEven x = x % 2 = 0
let isGreaterThan100 x = x > 100

let rec findFirst predicate list =
    match list with
    | [] -> None
    | head :: tail ->
        if predicate head then
            Some head
        else
            findFirst predicate tail

let printResult label result =
    match result with
    | Some value -> printfn $"{label}: {value}"
    | None -> printfn $"{label}: Not found"

printResult "First even" (findFirst isEven list1)
printResult "First > 100" (findFirst isGreaterThan100 list2)