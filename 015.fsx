// 015.fsx
// Why Discriminated Unions?
// DUs model data that can be "one thing OR another" — like payment methods or shapes.
// The compiler ensures you handle ALL cases, so you can't forget one.

// Discriminated Unions (DUs)
// DUs let you define a type that can be ONE OF several possible cases.
// Each case can carry different data.

type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float
    | Triangle of baseLength: float * height: float

// Creating instances
let circle = Circle 5.0
let rect = Rectangle (10.0, 20.0)
let triangle = Triangle (6.0, 8.0)


// Pattern matching on DUs
let area shape =
    match shape with
    | Circle r -> 3.14 * r * r
    | Rectangle (w, h) -> w * h
    | Triangle (b, h) -> 0.5 * b * h

let area1 = area circle      // ~78.5
let area2 = area rect        // 200.0
let area3 = area triangle    // 24.0


// DUs can represent simple enums too
type Status =
    | Active
    | Inactive
    | Pending

let currentStatus = Active

let describe status =
    match status with
    | Active -> "System is running"
    | Inactive -> "System is stopped"
    | Pending -> "System is waiting"


// DUs in lists
let shapes = [
    Circle 3.0
    Rectangle (5.0, 10.0)
    Triangle (4.0, 6.0)
]

let totalArea = 
    shapes
    |> List.map area
    |> List.sum


(*
    Your Task:
    1. Define a DU called PaymentMethod with three cases:
       - Cash
       - Card of cardNumber: string
       - BankTransfer of accountNumber: string
    
    2. Create a function called describePayment that:
       - Takes a PaymentMethod
       - Returns a string description:
         - "Paid with cash" for Cash
         - "Paid with card: {cardNumber}" for Card
         - "Paid via bank transfer: {accountNumber}" for BankTransfer
    
    3. Create a list of 3 different payments using all three methods.
    
    4. Use List.map with describePayment to get descriptions.
    
    5. Print all descriptions.
    
    Expected output (as a list):
    ["Paid with cash"; "Paid with card: 1234-5678"; "Paid via bank transfer: ACC-999"]
*)
