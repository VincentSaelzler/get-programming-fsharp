open System

//  //  // 20.1 a tour around loops
for number in 1 .. 10 do
    printfn "%d Hello!" number

for number in 10..-1..1 do
    printfn "%d Hello!" number

let customerIds = [45..99]
for customerId in customerIds do
    printfn "%d bought something!" customerId

for even in 3 .. 3 .. 10 do
    printfn "%d is an even number!" even

let r = System.Random()

let bigOrSmall() =
    let n = r.Next()
    if n > 2147000000 then "big"
    else "small"

let mutable size = "small"
while size = "small" do
    size <- bigOrSmall()
    printfn "%A" (size)

let thisr = r.Next()

// 5-20.1.3 Type System | Program Flow | Loops | Comprehensions
let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper c |]
let listOfSquares = [ for n in 1 .. 5 -> n * n ]
let seqOfStrings = seq {for i in 2 .. 4 .. 20 -> sprintf "number %d" i}
let listOfStrings = List.ofSeq seqOfStrings

// 5-20.2.3 Type System | Program Flow | Branching | Exhaustive Checking
let getCreditLimit customer =
    match customer with
    "medium", 1 -> 500
    | "good", 0 | "good", 1 -> 750
    | "good", 2 -> 1000
    | "good", years when years < 6 -> 2000
    | "good", _ -> 4000
    |_ -> 250 //if this line is commented, a compiler warning appears: "Incomplete pattern matches on this expression."
    // the compiler warning identifies overlooked possibilities to prevent runtime errors.
    // the compiler also warns if there are unreachable patterns. matching occurs from the top down.

let m1 = getCreditLimit("medium", 1)
let g0 = getCreditLimit("good", 0)
let g1 = getCreditLimit("good", 1)
let g2 = getCreditLimit("good", 2)
let g3 = getCreditLimit("good", 3)
let g9 = getCreditLimit("good", 9)
let b0 = getCreditLimit("bad", 0) // Microsoft.FSharp.Core.MatchFailureException: The match cases were incomplete