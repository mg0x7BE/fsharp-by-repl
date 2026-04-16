// 033.fsx

// Advanced groupBy - Filtering After Grouping
// This is what was hard in lesson 030 - let's break it down!

type Customer = {
    Id: int
    Name: string
}

type Order = {
    OrderId: int
    Customer: Customer
    Amount: float
}

let orders = [
    { OrderId = 1; Customer = { Id = 101; Name = "Alice" }; Amount = 50.0 }
    { OrderId = 2; Customer = { Id = 102; Name = "Bob" }; Amount = 75.0 }
    { OrderId = 3; Customer = { Id = 101; Name = "Alice" }; Amount = 30.0 }
    { OrderId = 4; Customer = { Id = 103; Name = "Carol" }; Amount = 100.0 }
    { OrderId = 5; Customer = { Id = 102; Name = "Bob" }; Amount = 45.0 }
]


// GOAL: Find customers who have MORE THAN 1 order

// Step 1: Group by Customer.Id
let byCustomer = List.groupBy (fun o -> o.Customer.Id) orders

printfn "Step 1 - Grouped by customer ID:"
printfn "%A" byCustomer
// Result: [
//   (101, [Order1; Order3]);  <- Alice has 2 orders
//   (102, [Order2; Order5]);  <- Bob has 2 orders
//   (103, [Order4])           <- Carol has 1 order
// ]


// Step 2: Transform to (customerId, orderCount)
let customerOrderCounts = 
    byCustomer
    |> List.map (fun (customerId, ordersList) -> 
        (customerId, List.length ordersList))

printfn "\nStep 2 - Customer ID with order counts:"
printfn "%A" customerOrderCounts
// Result: [(101, 2); (102, 2); (103, 1)]


// Step 3: Filter to keep only customers with > 1 order
let multipleOrders = 
    customerOrderCounts
    |> List.filter (fun (customerId, count) -> count > 1)

printfn "\nStep 3 - Customers with multiple orders:"
printfn "%A" multipleOrders
// Result: [(101, 2); (102, 2)]


// Step 4: Get customer names (need to go back to original data)
let customerNames = 
    multipleOrders
    |> List.map (fun (customerId, _) ->
        // Find first order with this customer ID
        let order = List.find (fun o -> o.Customer.Id = customerId) orders
        order.Customer.Name)

printfn "\nStep 4 - Customer names:"
printfn "%A" customerNames
// Result: ["Alice"; "Bob"]


// ALL STEPS COMBINED in one pipeline:
let customersWithMultipleOrders = 
    orders
    |> List.groupBy (fun o -> o.Customer.Id)
    |> List.map (fun (customerId, ordersList) -> 
        let name = (List.head ordersList).Customer.Name  // Get name from first order
        let count = List.length ordersList
        (name, count))
    |> List.filter (fun (name, count) -> count > 1)
    |> List.map fst  // Extract just names

printfn "\nAll steps combined:"
printfn "%A" customersWithMultipleOrders
// Result: ["Alice"; "Bob"]


// Let's visualize what happens at EACH step:
let debugPipeline = 
    orders
    |> fun x -> 
        printfn "\n=== Input to groupBy ==="
        printfn "%A" x
        x
    |> List.groupBy (fun o -> o.Customer.Id)
    |> fun x -> 
        printfn "\n=== After groupBy ==="
        printfn "%A" x
        x
    |> List.map (fun (customerId, ordersList) -> 
        let name = (List.head ordersList).Customer.Name
        let count = List.length ordersList
        (name, count))
    |> fun x -> 
        printfn "\n=== After map (name, count) ==="
        printfn "%A" x
        x
    |> List.filter (fun (name, count) -> count > 1)
    |> fun x -> 
        printfn "\n=== After filter (count > 1) ==="
        printfn "%A" x
        x
    |> List.map fst
    |> fun x -> 
        printfn "\n=== After map fst (final names) ==="
        printfn "%A" x
        x


(*
    Your Task - Bringing it all together!
    
    Given these products and sales:
    
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
    
    GOAL: Find products that were sold MORE THAN ONCE (appear in multiple sales)
    
    Steps:
    1. Group sales by Product.Id
    2. Map to (productName, saleCount) where saleCount is how many times it was sold
    3. Filter to keep only products with saleCount > 1
    4. Extract just the product names
    5. Print the result
    
    Expected output: ["Laptop"; "Mouse"]
    (Laptop appears 2 times, Mouse appears 2 times, Desk and Chair appear only once)
    
    Hint: Use the combined pipeline pattern from the example above!
*)