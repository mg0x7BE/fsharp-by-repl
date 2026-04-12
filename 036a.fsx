
let inventory = [("Apples", 50); ("Bananas", 30); ("Oranges", 45); ("Grapes", 20)] |> Map.ofList

let checkStock (product: string) (inv: Map<string, int>) =
    match Map.tryFind product inv with
    | Some qty when qty > 0 -> $"{product}: %d{qty} in stock"
    | Some _ -> $"{product}: out of stock"
    | None -> $"{product}: not in our catalog"

let updatedInventory = inventory |> Map.add "Mangoes" 15

let finalInventory = updatedInventory |> Map.remove "Grapes"

["Apples"; "Grapes"; "Kiwi"]
|> List.iter (fun p -> finalInventory |> checkStock p |> printfn "%s")

printfn $"Total products: {Map.count finalInventory}"
