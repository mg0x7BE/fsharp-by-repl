// 016.fsx
// Why Result?
// Option tells you "something or nothing", but not WHY it failed.
// Result carries an error message, so callers know exactly what went wrong.

// Result Type
// Result is a built-in type for operations that can fail with an error message.
// Result has two cases:
//   - Ok value (success)
//   - Error message (failure)

// Example: Safe division with error message
let divide x y =
    if y = 0 then
        Error "Cannot divide by zero"
    else
        Ok (x / y)

let result1 = divide 10 2   // Ok 5
let result2 = divide 10 0   // Error "Cannot divide by zero"


// Pattern matching on Result
let describeResult result =
    match result with
    | Ok value -> $"Success: {value}"
    | Error msg -> $"Failed: {msg}"

let desc1 = describeResult result1  // "Success: 5"
let desc2 = describeResult result2  // "Failed: Cannot divide by zero"


// Chaining Results with pattern matching
let divideAndDouble x y =
    match divide x y with
    | Ok value -> Ok (value * 2)
    | Error msg -> Error msg

let result3 = divideAndDouble 10 2  // Ok 10 (10 / 2 = 5, 5 * 2 = 10)
let result4 = divideAndDouble 10 0  // Error "Cannot divide by zero"


(*
    Your Task:
    1. Write a function parseAge that:
       - Takes a string
       - If string is a valid positive integer (> 0), returns Ok with the number
       - If string is not a number, returns Error "Not a valid number"
       - If number is <= 0, returns Error "Age must be positive"
       - Hint: Use System.Int32.TryParse which returns (bool * int) tuple
    
    2. Test it with these strings:
       - "25"
       - "abc"
       - "-5"
    
    3. For each test, use pattern matching to print:
       - "Valid age: {number}" for Ok
       - "Invalid: {error}" for Error
    
    Expected output:
    - Valid age: 25
    - Invalid: Not a valid number
    - Invalid: Age must be positive
    
    Hint for TryParse:
    let (success, value) = System.Int32.TryParse("25")
    if success then ... else ...
*)