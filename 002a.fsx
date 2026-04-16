let rec countdown n =
    match n with
    | x when x <= 0 -> "Done!"
    | _ -> $"{n}, " + countdown (n - 1)
    

countdown 15