let result =
    [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    |> List.filter (fun x -> x % 2 = 1)
    |> List.map (fun x -> x * x)
    |> List.sum
    
printfn $"{result}"