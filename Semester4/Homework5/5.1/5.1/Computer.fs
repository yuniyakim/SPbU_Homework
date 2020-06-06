module Computer

/// Computer's type
type Computer(name: string, os: string, infected: bool) =
    member this.Name = name
    member this.OS = os
    member val Infected = infected with get, set
