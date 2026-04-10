// 035-project-task-list.fsx

// PROJECT: Task List Manager
// Build a simple task list using immutable data and functions.
// You'll add tasks, mark them complete, remove tasks, and display the list.

// This project combines: Records, Discriminated Unions, Type aliases,
// List.map, List.filter, List.partition, List.length, pipe operator,
// pattern matching, and string formatting.


// ============================================================
// Part 1: Data Modeling
// ============================================================

// 1. Create a Discriminated Union for TaskStatus:
//    - Pending
//    - Completed

// 2. Create a record type TaskItem with fields:
//    - Id: int
//    - Description: string
//    - Status: TaskStatus

// 3. Create a type alias TaskList = TaskItem list


// ============================================================
// Part 2: Helper Functions (build these FIRST — used later)
// ============================================================

// 4. Write a function formatTask:
//    - Takes: a TaskItem
//    - Returns: string in format "[ID] Description"
//    - Example: formatTask { Id = 3; Description = "Buy milk"; Status = Pending }
//              returns "[3] Buy milk"

// 5. Write a function countByStatus:
//    - Takes: status (TaskStatus) and task list (list last, for piping)
//    - Returns: count of tasks with that status
//    - Hint: List.filter then List.length


// ============================================================
// Part 3: Core Functions
// ============================================================

// 6. Write a function addTask:
//    - Takes: description (string) and current task list (list last, for piping)
//    - Generates new ID: (List.length list) + 1
//    - Creates new task with status Pending
//    - Returns: new task list with the task appended at the end
//    - Note: the @ operator joins two lists: [1; 2] @ [3; 4] = [1; 2; 3; 4]
//      So: list @ [newTask] adds newTask at the end

// 7. Write a function completeTask:
//    - Takes: task ID (int) and current task list (list last, for piping)
//    - Changes the status of the matching task to Completed
//    - Returns: updated task list
//    - Hint: think about which List function lets you transform each element

// 8. Write a function removeTask:
//    - Takes: task ID (int) and current task list (list last, for piping)
//    - Removes the task with the matching ID
//    - Returns: new task list without that task

// 9. Write a function listTasks:
//    - Takes: task list
//    - Separates tasks into pending and completed (think: which List function
//      splits a list into two groups based on a condition?)
//    - Formats each group using formatTask (from step 4)
//    - Returns: a single formatted string
//
//    The output should look like:
//      PENDING TASKS:
//      [1] Buy groceries
//
//      COMPLETED TASKS:
//      [2] Call dentist
//      [4] Clean room
//
//    Step by step:
//    a) Split the list into pending and completed
//    b) Format each group with List.map formatTask
//    c) Build a list of all output lines: headers + formatted tasks
//    d) Join them into one string using String.concat "\n"
//       (String.concat takes a separator and a list of strings,
//        and joins them: String.concat ", " ["a"; "b"] = "a, b")
//
//    Hint: you can use @ to combine lists of strings:
//      ["HEADER:"] @ ["line1"; "line2"] @ [""] @ ["OTHER:"]
//      gives ["HEADER:"; "line1"; "line2"; ""; "OTHER:"]


// ============================================================
// Part 4: Put It All Together
// ============================================================

// 10. Build the final task list by piping an empty list through all operations.
//     Since every function takes the list as its LAST parameter,
//     you can chain them with |> into one pipeline:
//
//     let myTasks =
//         []
//         |> addTask "First thing"
//         |> addTask "Second thing"
//         |> completeTask 1
//         |> removeTask 2
//
//     Each |> passes the result of the previous step to the next function.
//
// 11. Print the final state using listTasks
// 12. Print statistics: Total, Pending, Completed


// EXAMPLE WORKFLOW:
(*
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
*)


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
