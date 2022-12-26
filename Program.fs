module Notes.Program
open System
open Five

[<EntryPoint>]
let main args =

    printfn "%A" (Five.commentOnStorageTechnology(MultimediaCard(SecureMMC,4)))
    printfn "%A" (Five.commentOnStorageDevice {
        SizeGB = 6000
        Technology = HardDisk(5400, 2)
    } )
    printfn "%A" (Five.commentOnStorageDevice {
        SizeGB = 10000
        Technology = HardDisk(7200, 2)
    } )
    printfn "%A" (Five.commentOnStorageDevice {
        SizeGB = 10000
        Technology = HardDisk(5400, 2)
    } )

    ignore (Console.ReadLine())
    0
