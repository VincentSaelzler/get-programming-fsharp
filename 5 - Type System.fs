module Notes.Five

type MMCType =
    | RsMMC
    | MMCPlus
    | SecureMMC

type StorageTechnology =
    | SolidState
    | HardDisk of RPM:int * Platters:int
    | MultimediaCard of MMCType * numPins:int

type StorageDevice = {
    SizeGB:int
    Technology:StorageTechnology
}

let commentOnMMCType mmcType =
    match mmcType with
    | SecureMMC -> false, "using it to be secure"
    | RsMMC -> true, "why would you use reduced size?"
    | MMCPlus -> true, "the extra size is worthless. use an ssd"

let commentOnStorageTechnology storageTechnology =
    match storageTechnology with
    | SolidState -> false, "SSDs are good"
    | HardDisk(_,_) ->  true, "don't use hard drives"
    | MultimediaCard(mmcType,_) -> commentOnMMCType mmcType 

let commentOnStorageDevice storageDevice =
    match storageDevice with
    | {Technology = HardDisk(5400,_); SizeGB = sizeGB} when sizeGB >= 8000-> false, "using an 8TB+ NAS drive is ok" 
    | {Technology = technology } -> commentOnStorageTechnology technology