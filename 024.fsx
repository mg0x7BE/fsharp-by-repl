// 024.fsx
// Why Type Aliases?
// A raw `string` or `int` tells you nothing about what it represents.
// Aliases give types meaningful names - EmailAddress, UserId, Celsius.

// Type Aliases
// Type aliases create new names for existing types.
// They make code more readable and self-documenting.
// Syntax: type NewName = ExistingType

// Example: Make primitive types more meaningful
type UserId = int
type EmailAddress = string
type Age = int

let userId: UserId = 42
let email: EmailAddress = "user@example.com"
let age: Age = 30


// Example: Domain modeling
type ProductId = int
type Price = float
type Quantity = int

type OrderLine = {
    ProductId: ProductId
    Quantity: Quantity
    Price: Price
}

let orderLine = {
    ProductId = 101
    Quantity = 5
    Price = 29.99
}


// Note: Type aliases don't provide type safety!
// These are all interchangeable:
let id1: UserId = 42
let id2: int = 42
let id3: UserId = id2  // Works! UserId and int are the same type


// Example: Function signatures become clearer
type Temperature = float

let celsiusToFahrenheit (c: Temperature) : Temperature =
    c * 9.0 / 5.0 + 32.0

let temp = celsiusToFahrenheit 25.0  // 77.0


// Combining with records
type PersonId = int
type PersonName = string

type Person = {
    Id: PersonId
    Name: PersonName
    Age: Age
}

let people = [
    { Id = 1; Name = "Alice"; Age = 30 }
    { Id = 2; Name = "Bob"; Age = 25 }
]


(*
    Your Task:
    1. Define type aliases:
       - BookId as int
       - BookTitle as string
       - PageCount as int

    2. Define a Book record type with fields:
       - Id: BookId
       - Title: BookTitle
       - Pages: PageCount

    3. Create a list of 3 books with different page counts

    4. Write a function called isLongBook that:
       - Takes a Book
       - Returns true if Pages > 300
       - Returns false otherwise

    5. Filter the list to keep only long books

    6. Print the titles of long books

    Expected output (depends on your data):
    If you have books with 350, 200, and 450 pages,
    output should show titles of books with 350 and 450 pages.
*)