type TaskStatus =
    | Pending
    | Completed

type TaskItem =
    { Id: int
      Description: string
      Status: TaskStatus }

type TaskList = TaskItem list

let formatTask (task: TaskItem) =
    $"[{task.Id}] {task.Description}"

let countByStatus (status: TaskStatus) (tasks: TaskList) =
    tasks
    |> List.filter (fun x -> x.Status = status)
    |> List.length

let addTask description (tasks: TaskList) =
    let newId = List.length tasks + 1
    tasks @ [{ Id = newId; Description = description; Status = Pending }]

let completeTask (id: int) (tasks: TaskList) =
    let complete tsk =
        if tsk.Id = id then { tsk with Status = Completed } else tsk
    tasks |> List.map complete

let removeTask (id: int) (tasks: TaskList) =
    tasks |> List.filter (fun x -> x.Id <> id)

let listTasks (tasks: TaskList) =
    let pending, completed =
        tasks |> List.partition (fun t -> t.Status = Pending)

    let lines =
        ["PENDING TASKS:"]
        @ (pending |> List.map formatTask)
        @ [""]
        @ ["COMPLETED TASKS:"]
        @ (completed |> List.map formatTask)

    String.concat "\n" lines

let myTasks =
    []
    |> addTask "Buy groceries"
    |> addTask "Call dentist"
    |> addTask "Finish project"
    |> addTask "Clean room"
    |> completeTask 2
    |> completeTask 4
    |> removeTask 3

printfn $"{listTasks myTasks}"
printfn ""
printfn "Statistics:"
printfn $"Total tasks: %d{List.length myTasks}"
printfn $"Pending: %d{countByStatus Pending myTasks}"
printfn $"Completed: %d{countByStatus Completed myTasks}"

