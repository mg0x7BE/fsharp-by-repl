let rec applyToList f list =
    match list with
    | [] -> []
    | head :: tail -> 
        let newHead = f head
        newHead :: applyToList f tail
    
let squares = applyToList (fun x -> x * x) [1; 2; 3; 4]
printfn $"Squares: %A{squares}"

let doubled = applyToList (fun x -> x * 2) [10; 20; 30]
printfn $"Doubled: %A{doubled}"