//////// 5-22   Type System - Null
//////// 5-22.1 Type System - Null . C# / VB
//////// - main problem: C#/VB make it hard to prevent things like
//////// - string x = null
//////// - var length = x.Length
//////// 5-22.2 Type System - Null .  F#
//////// 5-22.2.1 Type System - Null .  F# . Mandatory by Default
//////// 5-22.2.2 Type System - Null .  F# . The Option Type
let aNumber:int = 10
let maybeANumber: int option = Some 10

let calcPrem score =
    match score with
    | Some 0 -> 250
    | Some score when score < 0 -> 400
    | Some score when score > 0 -> 150
    | None ->
        printfn "no score; using default"
        300


let calcScore = calcPrem(Some 250)
let noScore = calcPrem None

type Driver = {
    Name : string
    Score : int option
    YearPassed : int
}

let vince = {Name = "vince"; Score = Some -19; YearPassed = 1988 }
let beth = {Name = "b"; Score = None; YearPassed = 1992}
let drivers = [ vince; beth]

let calcPerson driver = 
    match driver.Score with
    | Some 0 -> 250
    | Some score when score < 0 -> 400
    | Some score when score > 0 -> 150
    | None ->
        printfn "no score; using default"
        300

let calcVince = calcPerson vince
let calcb = calcPerson beth

//////// 5-22.3   Type System - Null .  Option Module
//////// 5-22.3.1 Type System - Null .  Option Module . Mapping

let describe score =
    match score with
    | score when score >= 0 -> "safe"
    | score when score < 0 -> "dangerous"


let description driver =
    match driver.Score with
    | Some score -> Some (describe score)
    | None  -> None

let dv = description vince
let db = description beth

// these do eactly the same thing
let fulldmap driver =  driver.Score |> Option.map (fun s -> describe s)
let shortdmap driver = driver.Score |> Option.map describe

// this is similar but take in any int option (it isn't tied to a driver score)
// critical concept, because tons of code can all be written in the describe
// function without regard to dealing with null values. then wrap it in an option.map
// the option.map will return none if the input is none, ortherwise do the code
// this is called lifting a function
let optionalDescribe = Option.map describe

let dmapv = fulldmap vince
let sdmv = shortdmap beth

let vod = optionalDescribe vince.Score
let bod = optionalDescribe beth.Score

//////// 5-22.3.2 Type System - Null . Option Module . Binding
let tooManyDrivers = [ vince; beth; vince]

let getScore driver = driver.Score

// just use tryExactlyOne
// let getSingleOrNone incomingList =
//     match incomingList with
//     | [] -> None
//     | [ item ] ->  Some item
//     | _ -> failwith "list has more than one item"

let nameMatchesDriver name driver = driver.Name = name

let tryFindDriverByName drivers name =
    drivers
    |> List.filter (nameMatchesDriver name)
    // |> getSingleOrNone
    |> List.tryExactlyOne

let maybeVince = tryFindDriverByName drivers "vince"

let maybevscore =
    tryFindDriverByName drivers "vince"
    //|> Option.map getScore
    |> Option.bind getScore

//////// 5-22.3.3 Type System - Null . Option Module . Filtering
let dhighscore =
    beth.Score
    |> Option.filter (fun s -> s < 199) //returns the score if it exists, AND is less than 199

let foo = Seq.exactlyOne