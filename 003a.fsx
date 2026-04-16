let rec countElements list =
    match list with
    | [] -> 0
    | _ :: tail -> 1 + countElements tail

let total = countElements [1; 2; 3; 4]
printfn $"calculated amount: %A{total}"