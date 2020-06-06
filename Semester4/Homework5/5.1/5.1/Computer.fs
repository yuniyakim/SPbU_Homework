module Computer

/// Computer's type
type Computer(name: string, os: string, infected: bool) =
    member this.Name = name
    member this.OS = os
    member this.Possibility =
        match os with
        | "Windows" -> 1.0
        | "Linux" -> 0.5
        | "MacOS" -> 0.0
        | _ -> 0.7
    member val Infected = infected with get, set
    member val JustInfected = false with get, set
