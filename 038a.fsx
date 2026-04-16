let mathSignups = [ "Alice"; "Bob"; "Carol"; "Dave"; "Eve"; "Alice" ]
let scienceSignups = [ "Bob"; "Dave"; "Frank"; "Grace"; "Bob" ]

let mathStudents = Set.ofList mathSignups
let scienceStudents = Set.ofList scienceSignups

let inBoth = Set.intersect mathStudents scienceStudents
let mathOnly = Set.difference mathStudents scienceStudents
let allStudents = Set.union mathStudents scienceStudents

let bothSubsetOfMath = Set.isSubset inBoth mathStudents

let earlyAlphabet = allStudents |> Set.filter (fun name -> name.[0] >= 'A' && name.[0] <= 'E')

let allNames =
    Set.fold (fun acc name -> acc + $"{name}, ") "" allStudents
    |> fun s -> s.TrimEnd([| ','; ' ' |])

printfn $"Math students: %A{Set.toList mathStudents}"
printfn $"Science students: %A{Set.toList scienceStudents}"
printfn $"Both courses: %A{Set.toList inBoth}"
printfn $"Math only: %A{Set.toList mathOnly}"
printfn $"All students: %A{Set.toList allStudents}"
printfn $"Both is subset of math? {bothSubsetOfMath}"
printfn $"Early alphabet (A-E): %A{Set.toList earlyAlphabet}"
printfn $"All students: {allNames}"

