open System

//////// 5-20.1   Type System - Program Flow . Loops
//////// 5-20.1.1 Type System - Program Flow . Loops . For Loops
for number in 1 .. 10 do
    printfn "%d Hello!" number

for number in 10..-1..1 do
    printfn "%d Hello!" number

let customerIds = [45..99]
for customerId in customerIds do
    printfn "%d bought something!" customerId

for even in 3 .. 3 .. 10 do
    printfn "%d is an even number!" even

//////// 5-20.1.2 Type System - Program Flow . Loops . While Loops
let r = System.Random()
let thisr = r.Next()

let bigOrSmall() =
    let n = r.Next()
    if n > 2147000000 then "big"
    else "small"

let mutable size = "small"
while size = "small" do
    size <- bigOrSmall()
    printfn "%A" (size)

//////// 5-20.1.3 Type System - Program Flow . Loops . Comprehensions
let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper c |]
let listOfSquares = [ for n in 1 .. 5 -> n * n ]
let seqOfStrings = seq {for i in 2 .. 4 .. 20 -> sprintf "number %d" i}
let listOfStrings = List.ofSeq seqOfStrings

//////// 5-20.2   Type System - Program Flow . Branching
//////// 5-20.2.1 Type System - Program Flow . Branching . Priming Exercise
//////// 5-20.2.2 Type System - Program Flow . Branching . Pattern Matching
let getCreditLimit customer =
    match customer with
    "medium", 1 -> 500
    | "good", 0 | "good", 1 -> 750
    | "good", 2 -> 1000
    | "good", _ -> 250

//////// 5-20.2.3 Type System - Program Flow . Branching . Exhaustive Checking
let getCreditLimitExhaustive customer =
    match customer with
    "medium", 1 -> 500
    //| _ -> 0 // compiler will warn of unreachable code
    | "good", 0 | "good", 1 -> 750
    | "good", 2 -> 1000
    | "good", years when years < 6 -> 2000
    | "good", _ -> 4000
    | _ -> 250 //if this line is commented, a compiler warning appears: "Incomplete pattern matches on this expression."

let m1 = getCreditLimit("medium", 1)
let g0 = getCreditLimit("good", 0)
let g1 = getCreditLimit("good", 1)
let g2 = getCreditLimit("good", 2)
let g3 = getCreditLimit("good", 3)
let g9 = getCreditLimit("good", 9)
let b0 = getCreditLimit("bad", 0) // Microsoft.FSharp.Core.MatchFailureException: The match cases were incomplete

//////// 5-20.2.4 Type System - Program Flow . Branching . Guards
let getCreditLimitGuards customer =
    match customer with
    | "good", years when years < 6 -> 2000
    | _ -> 0

let theCostOfGuards str =
    match str with // according to the book, there should be no compiler error! perhaps improvements in the language since then?
    | str when str = "Apparently the only possibility" -> "the result"

//////// 5-20.2.5 Type System - Program Flow . Branching . Nested Patterns
let nestedMatch customer =
    match customer with
    | "good", _ -> 500
    | "bad", years ->
        match years with // adds complexity; avoid unless there are lots of possibilities
        | 1 -> 250
        | _ -> 50
    | _ -> 100

//////// 5-20.3   Type System - Program Flow . Flexible Pattern Matching
//////// 5-20.3.1 Type System - Program Flow . Flexible Pattern Matching . Collections
type Customer = {
    Balance : int
    Name: string 
}

let customers = [
    {Balance = 1; Name = "Vince"};
    {Balance = 4; Name = "Bethany"};
    {Balance = 3; Name = "Nana"};
]

// NON pattern matching example
let handleCustomers  customers =
    let length = List.length customers
    if length = 0 then failwith "No customers"
    elif length = 1 then customers.[0].Name
    elif length = 2 then string (customers.[0].Balance + customers.[1].Balance)
    else string length

let custOutput = handleCustomers customers

// it is impossible to try and access a value in a list that doesn't exist
// because the compiler is doing both the length check and expanding the values of the list
let handleCustomersPM customers =
    match customers with
    | [] -> failwith "no customers supplied"
    | [ customer ] -> printfn "single customer name is %s" customer.Name
    | [ first; second ] -> printfn "two customers balance =%d" (first.Balance + second.Balance)
    | customers -> printfn "%d customers supplied" (List.length customers)

let nothing = handleCustomersPM customers

//////// 5-20.3.2 Type System - Program Flow . Flexible Pattern Mathing . Records
let getStatus customer =
    match customer with
    | { Balance = 0 } -> "they are broke"
    | { Name = "Bethany" } -> "the best"
    | { Name = name; Balance = 50} -> sprintf "%s is rich!" name // notice how name is bound!
    | { Name = name} -> sprintf "%s is a normal customer" name

getStatus {Name = "Vince"; Balance = 0 }
getStatus {Name = "Bethany"; Balance = 1 }
getStatus {Name = "Bob"; Balance = 50 }
getStatus {Name = "Bob"; Balance = 49 }

let handleRecordsInCollection customers =
    match customers with
    | [ { Name = "Tanya" }; {Balance = 25}; _ ] -> "Matches"
    | _ -> "No Match"

handleRecordsInCollection [{Name = "Tanya"; Balance = 0 }; { Name = "Vince"; Balance = 25}; { Name = "Vince"; Balance = 0}]

//////// 5-20.4 Type System - Program Flow . When Not to Match
let customerName = "Vince"
if customerName = "Vince" then printfn "If/Then is Easier" //returns unit and implicitly missing the default branch

match customerName with
    | "Vince" -> printfn "Matching is Harder"
    | _ -> () // annoying additional line required