module Notes.Program
open System
open Five

[<EntryPoint>]
let main args =
    // technology
    printfn "%A" (commentOnStorageTechnology(MultimediaCard(SecureMMC,4)))

    // device
    printfn "%A" (commentOnStorageDevice {
        SizeGB = 6000
        Technology = HardDisk(5400, 2)
    } )
    printfn "%A" (commentOnStorageDevice {
        SizeGB = 10000
        Technology = HardDisk(7200, 2)
    } )
    printfn "%A" (commentOnStorageDevice {
        SizeGB = 10000
        Technology = HardDisk(5400, 2)
    } )

    // devices
    printfn "no drives: %A" (commentOnStorageDevices [] )

    printfn "single ssd: %A" (commentOnStorageDevices [
        { SizeGB = 2000; Technology = SolidState }
    ] )

    printfn "my pc: %A" (commentOnStorageDevices [
        { SizeGB = 128; Technology = SolidState }; { SizeGB = 2000; Technology = SolidState }
    ] )

    printfn "bad drives: %A" (commentOnStorageDevices [
        { SizeGB = 256; Technology = SolidState }
        { SizeGB = 128; Technology = SolidState }
        { SizeGB = 10000; Technology = HardDisk(5400, 2) }
        { SizeGB = 32 ; Technology = MultimediaCard(SecureMMC,4)}
        { SizeGB = 32 ; Technology = MultimediaCard(RsMMC,4)}
        { SizeGB = 2000; Technology = HardDisk(5400, 2) }
    ] )

    printfn "good drives: %A" (commentOnStorageDevices [
        { SizeGB = 256; Technology = SolidState }
        { SizeGB = 128; Technology = SolidState }
        { SizeGB = 10000; Technology = HardDisk(5400, 2) }
    ] )



    ignore (Console.ReadLine())
    0
