let csvData =
    """ProductName,Category,Price,Quantity
Laptop,Electronics,999.99,5
Mouse,Electronics,25.50,15
Desk,Furniture,299.99,3
Chair,Furniture,150.00,8
Monitor,Electronics,350.00,6
Keyboard,Electronics,75.00,12
Table,Furniture,450.00,2"""


type Price = float
type Quantity = int

type SalesRecord =
    { ProductName: string
      Category: string
      Price: Price
      Quantity: Quantity }

let parseLine (line: string) =
    let s = line.Split(',')
    let productName = s[0]
    let category = s[1]

    let price =
        match System.Double.TryParse(s[2], System.Globalization.CultureInfo("en-US")) with
        | true, value -> Some value
        | false, _ -> None

    let quantity =
        match System.Int32.TryParse s[3] with
        | true, value -> Some value
        | false, _ -> None

    match (price, quantity) with
    | (Some p, Some q) -> 
        Some { ProductName = productName; Category = category; Price = p; Quantity = q }
    | _ -> None

let parseCSV lines =
    lines
    |> List.tail
    |> List.choose parseLine

let salesData =
    csvData.Split('\n')
    |> Array.toList
    |> parseCSV

let totalRevenue (records : SalesRecord list) =
    records
    |> List.sumBy (fun sr -> sr.Price * float sr.Quantity)

let mostExpensiveProduct =
    salesData
    |> List.sortByDescending (fun s -> s.Price)
    |> List.head

let totalRevenuePerCategory =
    salesData
    |> List.groupBy (fun f -> f.Category)
    |> List.map (fun (category, salesRecord) -> (category, totalRevenue salesRecord, List.length salesRecord))
    |> List.map (fun (category, totalRevenue, productCount) ->  $"  {category}: ${totalRevenue:F2} ({productCount} products)")
    |> String.concat "\n"
    
let top3ProductsByRevenue =
    salesData
    |> List.map (fun sr -> sr.ProductName, sr.Price * float sr.Quantity)
    |> List.sortByDescending snd
    |> List.take 3
 
let top3ProductsFormatted =
    let counter = ["1"; "2"; "3"]
    top3ProductsByRevenue
    |> List.zip counter
    |> List.map (fun (number, (productName, productPrice)) ->  $"  {number}. {productName}: ${productPrice:F2}")
    |> String.concat "\n"
    
printfn $"Total Revenue: ${totalRevenue salesData:F2}"
printfn $"Most Expensive: {mostExpensiveProduct.ProductName} (${mostExpensiveProduct.Price:F2})\n"
printfn "Revenue by Category:"
printfn $"{totalRevenuePerCategory}"
printfn ""
printfn "Top 3 Products by Revenue:"
printfn $"{top3ProductsFormatted}"

(* OUTPUT:

Total Revenue: $11382,42
Most Expensive: Laptop ($999,99)

Revenue by Category:
  Electronics: $8382,45 (4 products)
  Furniture: $2999,97 (3 products)

Top 3 Products by Revenue:
  1. Laptop: $4999,95
  2. Monitor: $2100,00
  3. Chair: $1200,00

*)
