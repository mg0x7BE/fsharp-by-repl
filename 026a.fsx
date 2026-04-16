type Student = {
   Name: string
   Courses: string list
}

let students = [
   { Name = "Alice"; Courses = ["Math"; "Physics"] }
   { Name = "Bob"; Courses = ["Math"; "Chemistry"; "Biology"] }
   { Name = "Carol"; Courses = ["Physics"; "Chemistry"] }
]

let result =
    students
    |> List.collect (fun s -> s.Courses)
    |> List.distinct
    |> List.sortBy id

printfn $"%A{result}"