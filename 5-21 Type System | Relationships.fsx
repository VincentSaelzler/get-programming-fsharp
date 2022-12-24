//////// 5-21   Type System - Relationships
//////// 5-21.1 Type System - Relationships . Composition
type Disk = {SizeGB:int}
type Computer = {
    Manufacturer:string
    Disks: Disk list
}

let myComputer = {
    Manufacturer = "Dell"
    Disks = [ {SizeGB = 5}; {SizeGB = 3}; {SizeGB = 4} ]
}

//////// 5-21.2 Type System - Relationships . Discriminated Unions
type DiskDU =
    | HardDisk of RPM:int * Platters:int
    | SolidState
    | MMC of NumberOfPins:int

//////// 5-21.2.1 Type System - Relationships . Discriminated Unions . Create Instances
let hdd = HardDisk(7200, 1)
let slowhdd = HardDisk(5400, 1)
let hddExplicit = HardDisk(RPM = 7200, Platters = 1)
let ssd = SolidState
let mmc = MMC(20)

//////// 5-21.2.2 Type System - Relationships . Discriminated Unions . Access Instances

let seek disk =
    match disk with
    | HardDisk (5400,_) -> "serching slowly and loudly"
    | HardDisk (_,_) -> "serching loudly"
    | SolidState -> "got it already"
    | MMC _ -> "searching slowly but quietly"

seek hdd
seek slowhdd
seek ssd
seek mmc

let describe disk =
    match disk with
    | SolidState -> "newfangled ssd"
    | MMC 1 -> "i have one pin"
    | MMC pins when pins < 5 -> "mmc with fewer than 5"
    | MMC pins -> sprintf "mmc with %d" pins
    | HardDisk (5400, _) -> "slow hdd"
    | HardDisk (_, 7) -> "seven spindles babyy"
    | HardDisk _ -> "hdd"

describe SolidState
describe (MMC 1)
describe (MMC 4)
describe (MMC 5)
describe (HardDisk (5400, 1))
describe (HardDisk (7200, 7))
describe (HardDisk (7200, 8))

//////// 5-21.3   Type System - Relationships . Discriminated Union Tips
//////// 5-21.3.1 Type System - Relationships . Discriminated Union Tips . Nesting
type MMCSubtype =
    | RsMMC
    | MMCPlus
    | SecureMMC

type DiskType =
    | Solid
    | HardDisk of RPM:int * Platters:int
    | MMC of MMCSubtype * numPins:int

let describeNested mmcd =
    match mmcd with
    | MMC (MMCPlus, 3) -> "mmcplus disk with 3 pins"
    | MMC (SecureMMC, 6) -> "secure mmc disk with 6 pins"

describeNested(MMC (MMCPlus, 3))
describeNested(MMC (SecureMMC, 6))

//////// 5-21.3.2 Type System - Relationships . Discriminated Union Tips . Shared Fields
type DiskRecord = {
    Vendor:string
    SizeGB:int
    Type: DiskType
}

type ComputerRecord = {
    Manufacturer:string
    Disks:DiskRecord list
}

let ryzen = {
    Manufacturer = "AMD"
    Disks = [
        { Vendor = "ADATA"; SizeGB = 2000; Tech = Solid } // record + DU
        { Vendor = "WD"; SizeGB = 8000; Tech = HardDisk(7200, 2) } // record + DU (with args)
        { Vendor = "SanDisk"; SizeGB = 128; Tech = MMC(RsMMC, 2) } // record + DU (with args + nested DU)
    ]
}

// so this works, but note how inconvenient it is to have to reference disks each time
// having a separate function to deal with the disk related stuff makes more sense
let describeRyzenDisk (ryzen: ComputerRecord) =
    match ryzen with
    | { Manufacturer = manufacturer } when manufacturer <> "AMD" -> "should be AMD"
    | { Disks = [] } -> "the computer needs a disk"
    | { Disks = disks } when List.exists (fun disk -> disk.Vendor = "ADATA") disks  -> "watch out for that adata brand!"
    | { Disks = disks } when List.exists (fun disk ->
        match disk.Tech with
        ) disks -> "is the capacity worth 5400 RPM?"
    | _ -> "no comments"


// let commentOnDisk disk =
//     match disk with
//     | {Vendor} = "ADATA"

let commentOnTech tech =



// let commentOnDisks =



let intel = describeRyzenDisk {
    Manufacturer = "Intel"
    Disks = []
}

let noDisk = describeRyzenDisk {
    Manufacturer = "AMD"
    Disks = []
}

let adata = describeRyzenDisk {
    Manufacturer = "AMD"
    Disks = [
        { Vendor = "ADATA"; SizeGB = 2000; Tech = Solid } // record + DU
        { Vendor = "WD"; SizeGB = 8000; Tech = HardDisk(7200, 2) } // record + DU (with args)
        { Vendor = "SanDisk"; SizeGB = 128; Tech = MMC(RsMMC, 2) } // record + DU (with args + nested DU)
    ]
}

let slowrpm = describeRyzenDisk {
    Manufacturer = "AMD"
    Disks = [
        { Vendor = "Samsung"; SizeGB = 2000; Tech = Solid } // record + DU
        { Vendor = "WD"; SizeGB = 8000; Tech = HardDisk(5400, 2) } // record + DU (with args)
        { Vendor = "SanDisk"; SizeGB = 128; Tech = MMC(RsMMC, 2) } // record + DU (with args + nested DU)
    ]
}