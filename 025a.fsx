let (|Positive|Zero|Negative|) number =
    if number > 0 then Positive
    elif number = 0 then Zero
    else Negative
    
let classifyNumber i =
    match i with
    | Positive -> $"Positive: {i}"
    | Zero -> $"Zero"
    | Negative -> $"Negative: {i}"
    
printfn $"%A{classifyNumber 5}"
printfn $"%A{classifyNumber 0}"
printfn $"%A{classifyNumber -3}"
