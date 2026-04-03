let extractPositive i =
    if i > 0 then Some i
    else None

let results = List.choose extractPositive [-5; 10; -3; 0; 7; -1; 15]

printfn $"%A{results}"
