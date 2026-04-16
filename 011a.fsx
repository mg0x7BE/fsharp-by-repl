let list1 = [1; 2; 3; 7; 8; 9]
let isGreaterThan5 x = x > 5
let square x = x * x

let rec findFirst predicate list =
    match list with
    | [] -> None
    | head :: tail ->
        if predicate head then
            Some head
        else
            findFirst predicate tail
            
let result =
    findFirst isGreaterThan5 list1
    |> Option.map square
    |> Option.defaultValue 0
   
printfn $"%A{result}"
    