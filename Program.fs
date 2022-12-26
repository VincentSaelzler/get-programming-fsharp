module Notes.Program
open System
open Five

[<EntryPoint>]
let main args =
    printfn "%A" (Five.main())
    ignore (Console.ReadLine())
    0
