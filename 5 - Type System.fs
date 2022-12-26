module Notes.Five

type MMCType =
    | RsMMC
    | MMCPlus
    | SecureMMC

type DiskType =
    | Solid
    | HardDisk of RPM:int * Platters:int
    | MMC of MMCType * numPins:int

let main () = "doing something"