let salaries =
    Map.ofList [
        ("Alice", 4200.0)
        ("Bob", 5800.0)
        ("Carol", 3900.0)
        ("Dave", 7200.0)
        ("Eve", 4800.0)
    ]
    
let updatedSalaries =
    salaries
    |> Map.map (fun _ salary -> if salary < 5000 then salary * 1.1 else salary)
  
let seniorPay =
    updatedSalaries
    |> Map.filter (fun _ salary -> salary >= 5000)
    
let totalBill =
    updatedSalaries
    |> Map.fold (fun acc _ salary -> acc + salary) 0.

let over10k =
    updatedSalaries
    |> Map.exists (fun _ salary -> salary > 10000)


updatedSalaries |> Map.iter (fun name salary -> printfn $"  {name}: ${salary:F2}")

printfn $"Total salary bill: ${totalBill:F2}"
printfn $"Anyone above $10000? {over10k}"
printfn $"Senior employees (>= $5000):"
seniorPay |> Map.iter (fun name salary -> printfn $"  {name}: ${salary:F2}")