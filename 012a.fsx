// 012a.fsx

let safeDivide x y =
    if y = 0 then None
    else Some (x / y)
      
let result =
    safeDivide 100 2
    |> Option.bind (fun x -> safeDivide x 5)
    |> Option.map (fun x -> x + 10)
    |> Option.defaultValue 0
    
printfn $"Output: %d{result}"