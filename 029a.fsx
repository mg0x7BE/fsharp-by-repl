let multiplyPositive list =
   let rec loop acc remaining =
       match remaining with
       | [] -> acc
       | head :: tail ->
           if head > 0 then
               loop (head * acc) tail
           else
               loop acc tail  // skip
   loop 1 list

printfn $"%A{multiplyPositive [2; -3; 4; 0; 5; -1]}"