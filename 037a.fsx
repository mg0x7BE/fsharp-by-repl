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
    |> Map.map (fun _key salary -> if salary < 5000 then salary * 1.1 else salary)
        
(*
    Your Task:

    You have a map of employee names to their monthly salaries:

    let salaries =
        Map.ofList [
            ("Alice", 4200.0)
            ("Bob", 5800.0)
            ("Carol", 3900.0)
            ("Dave", 7200.0)
            ("Eve", 4800.0)
        ]

    1. Use Map.map to apply a 10% raise to employees earning below 5000.0.
       Those earning 5000.0 or more keep their current salary.
       Store as updatedSalaries.

    2. Use Map.filter on updatedSalaries to get only employees
       earning 5000.0 or more. Store as seniorPay.

    3. Use Map.fold on updatedSalaries to calculate the total salary bill.

    4. Use Map.exists on updatedSalaries to check if anyone earns more than 10000.0.

    5. Print each employee's updated salary using Map.iter, formatted as:
       "  Name: $XXXX.XX"

    6. Print the total salary bill and the exists result.

    Expected output:
      Alice: $4620.00
      Bob: $5800.00
      Carol: $4290.00
      Dave: $7200.00
      Eve: $5280.00
    Total salary bill: $27190.00
    Anyone above $10000? False
    Senior employees (>= $5000):
      Bob: $5800.00
      Dave: $7200.00
      Eve: $5280.00
*)