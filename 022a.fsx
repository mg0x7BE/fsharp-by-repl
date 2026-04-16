// 022a.fsx

let numbers = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12]

let result = 
    numbers
    |> List.groupBy (fun x -> x % 3)
    |> List.map (fun (remainder, nums) -> (remainder, List.sum nums))
    |> List.sortBy fst  // Optional: sorts by remainder (first element of tuple)

printfn $"%A{result}"