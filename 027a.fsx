let numbers = [12; 7; 23; 4; 19; 8; 31; 15; 2; 27]

let (big, small) =
   numbers
   |> List.partition (fun n -> n > 15)
   
printfn $"Greater than 15: count=%A{List.length big}, sum=%A{List.sum big}"
printfn $"15 or less: count=%A{List.length small}, sum=%A{List.sum small}"