
type TaskStatus =
    | Pending
    | Completed

type TaskItem = {
    Id: int
    Description: string
    Status: TaskStatus
}

type TaskList = TaskItem list

let formatTask (task : TaskItem) =
    $"[{task.Id}] {task.Description}"

let countByStatus (status : TaskStatus) (tasks : TaskList) =
    tasks
    |> List.filter (fun x -> status = x.Status)
    |> List.length
    
let addTask description (tasks : TaskList) =
    let newId = List.length tasks + 1
    tasks @ [{Id = newId; Description = description; Status = Pending}]

let completeTask (id : int) (tasks : TaskList) =
    let complete tsk =
        if tsk.Id = id then { tsk with Status = Completed } else tsk
    tasks
    |> List.map complete

let removeTask (id : int) (tasks : TaskList) =
    tasks
    |> List.filter (fun x -> x.Id <> id)

let listTasks (tasks: TaskList) =
    let pending, completed =
        tasks
        |> List.partition (fun t -> t.Status = Pending)
    
    let lines =
      ["PENDING TASKS:"]
      @ (pending |> List.map formatTask)
      @ [""]
      @ ["COMPLETED TASKS:"]
      @ (completed |> List.map formatTask)
      
    String.concat "\n" lines


let myTasks =
    []
    |> addTask "Buy groceries"       // Id 1
    |> addTask "Call dentist"        // Id 2
    |> addTask "Finish project"      // Id 3
    |> addTask "Clean room"          // Id 4
    |> completeTask 2                // Complete "Call dentist"
    |> completeTask 4                // Complete "Clean room"
    |> removeTask 3                  // Remove "Finish project"

printfn "%s" (listTasks myTasks)
printfn ""
printfn "Statistics:"
printfn $"Total tasks: %d{List.length myTasks}"
printfn $"Pending: %d{countByStatus Pending myTasks}"
printfn $"Completed: %d{countByStatus Completed myTasks}"


// EXPECTED OUTPUT:
(*
PENDING TASKS:
[1] Buy groceries

COMPLETED TASKS:
[2] Call dentist
[4] Clean room

Statistics:
Total tasks: 3
Pending: 1
Completed: 2
*)
