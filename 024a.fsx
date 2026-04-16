type BookId = int
type BookTitle = string
type PageCount = int

type Book = {
   Id: BookId
   Title: BookTitle
   Pages: PageCount
}

let books = [
   {Id = 1; Title = "1984"; Pages = 328}
   {Id = 2; Title = "Brave New World"; Pages = 311}
   {Id = 3; Title = "Limes inferior"; Pages = 226}
]

let isLongBook (b: Book) : bool =
   b.Pages > 300
   
let filteredBooks =
   books
   |> List.filter isLongBook
   |> List.map (fun b -> b.Title)
   
printfn $"%A{filteredBooks}"