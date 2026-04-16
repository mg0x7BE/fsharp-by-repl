type PaymentMethod =
    | Cash
    | Card of cardNumber: string
    | BankTransfer of accountNumber: string

let describePayment pm =
    match pm with
    | Cash -> "Paid with cash"
    | Card s -> $"Paid with card: {s}"
    | BankTransfer s -> $"Paid via bank transfer: {s}"

let payments = [
    Cash
    Card "1234-5678"
    BankTransfer "ACC-999"
]

let descriptions = 
    payments
    |> List.map describePayment
    
printfn $"%A{descriptions}"
