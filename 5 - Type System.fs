module Notes.Five
open System

type MMCSubtype =
    | RsMMC
    | MMCPlus
    | SecureMMC

type DiskType =
    | Solid
    | HardDisk of RPM:int * Platters:int
    | MMC of MMCSubtype * numPins:int
