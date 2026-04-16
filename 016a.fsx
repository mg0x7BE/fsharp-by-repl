let parseAge (str: string) =
    let success, value = System.Int32.TryParse str
    if success then
        if value > 0 then
            Ok value
        else
            Error "Age must be positive"
    else
        Error "Not a valid number"

let describeResult result =
    match result with
    | Ok number -> $"Valid age: {number}"
    | Error error -> $"Invalid: {error}"

let result1 = parseAge "25"
let result2 = parseAge "abc"
let result3 = parseAge "-5"

printfn $"%s{describeResult result1}"
printfn $"%s{describeResult result2}"
printfn $"%s{describeResult result3}"