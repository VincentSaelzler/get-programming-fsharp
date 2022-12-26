module Notes.Five
open System

type MMCType =
    | RsMMC
    | MMCPlus
    | SecureMMC

type DiskType =
    | Solid
    | HardDisk of RPM:int * Platters:int
    | MMC of MMCType * numPins:int


// module Five





