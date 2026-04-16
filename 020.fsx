// 020.fsx
// Why Sequences?
// Lists compute everything upfront. Sequences are lazy - they compute on demand.
// This means you can work with huge or even infinite data without running out of memory.

// Sequences (seq)
// Sequences are lazy evaluated collections - elements are computed only when needed.
// They can represent infinite collections or large datasets efficiently.
// Lists are eager (computed immediately), sequences are lazy (computed on demand).

// Creating sequences
let numbers = seq { 1 .. 10 }  // Sequence from 1 to 10
let evens = seq { 2 .. 2 .. 20 }  // Even numbers: 2, 4, 6, ..., 20

// Sequences work with the same functions as lists
let doubled = Seq.map (fun x -> x * 2) numbers
let filtered = Seq.filter (fun x -> x > 5) numbers


// Converting between types
let listToSeq = [1; 2; 3] |> List.toSeq
let seqToList = seq { 1 .. 5 } |> Seq.toList  // [1; 2; 3; 4; 5]


// Infinite sequence (this would crash with a list!)
let infiniteNumbers = Seq.initInfinite (fun i -> i)
let first10 = infiniteNumbers |> Seq.take 10 |> Seq.toList  // [0; 1; 2; ...; 9]


// Practical example: Generate sequence and process
let squares =
    seq { 1 .. 100 }
    |> Seq.map (fun x -> x * x)
    |> Seq.filter (fun x -> x % 2 = 0)  // Even squares
    |> Seq.take 5  // First 5 only
    |> Seq.toList  // [4; 16; 36; 64; 100]


// Seq.sum, Seq.reduce work the same as List versions
let total = seq { 1 .. 10 } |> Seq.sum  // 55


(*
    Your Task:
    1. Create a sequence of numbers from 1 to 50

    2. Use Seq.filter to keep only numbers divisible by 3

    3. Use Seq.map to square each number

    4. Use Seq.take to get only the first 4 results

    5. Convert to a list and print

    Expected output: [9; 36; 81; 144]
    (Numbers divisible by 3: 3, 6, 9, 12, ...
     Squared: 9, 36, 81, 144, ...)
*)