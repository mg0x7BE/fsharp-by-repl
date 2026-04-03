type Book = {
    Title: string
    Pages: int
}

let books = [
    {Title = "The Hobbit"; Pages = 310}
    {Title = "1984"; Pages = 328}
    {Title = "Animal Farm"; Pages = 112}
    {Title = "Brave New World"; Pages = 268}
]

let largeBooks =
    books
    |> List.filter (fun b -> b.Pages > 200)
    |> List.map (fun b -> b.Title)

printfn $"%A{largeBooks}"
    