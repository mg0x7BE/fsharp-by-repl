let mathSignups = [ "Alice"; "Bob"; "Carol"; "Dave"; "Eve"; "Alice" ]
let scienceSignups = [ "Bob"; "Dave"; "Frank"; "Grace"; "Bob" ]

let mathStudents = mathSignups |> set
let scienceStudents = scienceSignups |> set

let inBoth = Set.intersect mathStudents scienceStudents
let mathOnly = Set.difference mathStudents scienceStudents
let allStudents = Set.union mathStudents scienceStudents

let earlyAlphabet =
    allStudents
    |> Set.filter (fun s -> s.StartsWith "A")

let allStudentsStr =
    Set.fold (fun acc student -> acc + $"{student} ") "" allStudents
    |> fun s -> s.Trim()

printfn $"Math students: %A{Set.toList mathStudents}"
printfn $"Science students: %A{Set.toList scienceStudents}"
printfn $"Both courses: %A{Set.toList inBoth}"
printfn $"Math only: %A{Set.toList mathOnly}"
printfn $"All students: %A{Set.toList allStudents}"
printfn $"Both is subset of math? {Set.isSubset inBoth mathStudents}"
printfn $"Starts with A: %A{Set.toList earlyAlphabet}"
printfn $"All students: {allStudentsStr}"
