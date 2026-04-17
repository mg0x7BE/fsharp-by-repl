let temperatures = [| 22.1; 18.4; 25.7; 30.2; 15.8; 28.3; 19.6 |]

let numDays = temperatures.Length

let temperaturesF = temperatures |> Array.map (fun c -> c * 9.0 / 5.0 + 32.0)

let hotDays = temperatures |> Array.filter (fun c -> c > 25.0)

let temperaturesSorted = Array.sort temperatures

let firstBelow20 = temperatures |> Array.tryFind (fun c -> c < 20.0)

let avgTemperature =
    let sum = Array.fold (fun acc n -> acc + n) 0.0 temperatures
    sum / float temperatures.Length

let labels = Array.init 7 (fun i -> $"Day %d{i + 1}")

printfn $"Days: %d{numDays}"
printfn $"Fahrenheit: %A{temperaturesF}"
printfn $"Hot days: %A{hotDays}"
printfn $"Sorted: %A{temperaturesSorted}"
printfn $"First below 20: %A{firstBelow20}"
printfn $"Average: %.2f{avgTemperature}"

Array.zip labels temperatures
|> Array.iter (fun (label, temp) -> printfn $"{label}: {temp}C")
