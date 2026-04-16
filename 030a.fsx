type OrderStatus =
    | Pending
    | Shipped
    | Delivered
    | Cancelled

type Customer = {
    Id: int
    Name: string
    Email: string
}

type Order = {
    Id: int
    Customer: Customer
    Status: OrderStatus
    Amount: float
    Items: string list
}

// Sample data
let orders = [
    { Id = 1; Customer = { Id = 101; Name = "Alice"; Email = "alice@example.com" }; 
      Status = Delivered; Amount = 150.50; Items = ["Laptop Case"; "Mouse"] }
    { Id = 2; Customer = { Id = 102; Name = "Bob"; Email = "bob@example.com" }; 
      Status = Pending; Amount = 299.99; Items = ["Keyboard"; "Monitor Stand"; "USB Cable"] }
    { Id = 3; Customer = { Id = 101; Name = "Alice"; Email = "alice@example.com" }; 
      Status = Delivered; Amount = 75.00; Items = ["Mouse Pad"] }
    { Id = 4; Customer = { Id = 103; Name = "Carol"; Email = "carol@example.com" }; 
      Status = Cancelled; Amount = 500.00; Items = ["Laptop"; "Charger"] }
    { Id = 5; Customer = { Id = 102; Name = "Bob"; Email = "bob@example.com" }; 
      Status = Shipped; Amount = 125.75; Items = ["Headphones"] }
    { Id = 6; Customer = { Id = 104; Name = "Dave"; Email = "dave@example.com" }; 
      Status = Delivered; Amount = 89.99; Items = ["Webcam"; "Microphone"] }
]

let avgOrderAmount =
    let filteredOrders =
        orders
        |> List.filter (fun x -> x.Status = Delivered || x.Status = Shipped)
        |> List.map (fun x -> x.Amount)
    List.sum filteredOrders / float (List.length filteredOrders)
 
printfn $"Average order value (Delivered/Shipped): ${avgOrderAmount:F2}"

