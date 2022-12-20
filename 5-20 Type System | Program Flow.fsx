
//  //  // 20.1 a tour around loops
open System

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

// 20.1.3 comprehensions
let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper c |]
let listOfSquares = [ for n in 1 .. 5 -> n * n ]