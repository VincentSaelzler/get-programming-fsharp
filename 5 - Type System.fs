module Notes.Five
open System

type MMCType =
    | RsMMC
    | MMCPlus
    | SecureMMC

type DiskType =
    | Solid
    | HardDisk of RPM:int * Platters:int
<<<<<<< HEAD
    | MMC of MMCType * numPins:int


// module Five





=======
    | MMC of MMCSubtype * numPins:int
>>>>>>> 4d2b01b10ef6d1f89f2f6b09f111200a83b1687f
