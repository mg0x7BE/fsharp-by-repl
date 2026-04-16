let list = [2; 3; 4]

let result1 =
    list
    |> List.map (fun x -> [1 .. x])
    |> List.collect (fun x -> x)
    |> List.filter (fun x -> x % 2 = 0)
    
printfn $"%A{result1}"

// alternative:

let result2 =
    list
    |> List.collect (fun x -> [1 .. x])  // map + flatten in one step
    |> List.filter (fun x -> x % 2 = 0)
    
printfn $"%A{result2}"