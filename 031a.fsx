let decades =
    [10; 15; 20; 25; 30; 35; 40]
    |> List.groupBy (fun x -> x / 10)

let decadesCounted =
    decades
    |> List.map (fun (decade, numbers) -> (decade, List.length numbers))

printfn $"%A{decades}"
printfn $"%A{decadesCounted}"
