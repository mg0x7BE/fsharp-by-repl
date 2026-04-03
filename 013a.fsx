let describePerson person =
    match person with
    | (name, age) when age < 18 -> $"Child: {name}"
    | (name, age) when age < 65 -> $"Adult: {name}"
    | (name, _) -> $"Senior: {name}"

printfn $"%s{describePerson ("Alice", 10)}"
printfn $"%s{describePerson ("Bob", 35)}"
printfn $"%s{describePerson ("Carol", 70)}"
