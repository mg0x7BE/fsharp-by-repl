let list = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let filterEvens = List.filter (fun x -> x % 2 = 0)
let squareAll = List.map (fun x -> x * x)
let sumAll = List.sum
let processEvens = filterEvens >> squareAll >> sumAll

printfn $"%A{processEvens list}"
