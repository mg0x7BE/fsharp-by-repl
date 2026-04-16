let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

let result = 
    numbers
    |> List.filter (fun x -> x > 5)
    |> List.map (fun x -> x * 3)

printfn $"Result: %A{result}"