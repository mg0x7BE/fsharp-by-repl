type Product = {
    Id: int
    Name: string
    Category: string
}

type Sale = {
    Product: Product
    Quantity: int
}

let sales = [
    { Product = { Id = 1; Name = "Laptop"; Category = "Electronics" }; Quantity = 2 }
    { Product = { Id = 2; Name = "Mouse"; Category = "Electronics" }; Quantity = 5 }
    { Product = { Id = 3; Name = "Desk"; Category = "Furniture" }; Quantity = 1 }
    { Product = { Id = 1; Name = "Laptop"; Category = "Electronics" }; Quantity = 3 }
    { Product = { Id = 4; Name = "Chair"; Category = "Furniture" }; Quantity = 2 }
    { Product = { Id = 2; Name = "Mouse"; Category = "Electronics" }; Quantity = 7 }
]

let productsWithMultipleOrders = 
    sales
    |> List.groupBy (fun p -> p.Product.Id)
    |> List.map (fun (productId, saleList) -> 
        let productName = (List.head saleList).Product.Name
        let saleCount = List.length saleList
        (productName, saleCount))
    |> List.filter (fun (productName, saleCount) -> saleCount > 1)
    |> List.map fst


printfn $"%A{productsWithMultipleOrders}" 
