module StringNumbers

open System

/// Workflow for string numbers
type StringNumbers() =
    member this.Bind(x: string, f) =
        match Int32.TryParse(x) with
        | true, number -> f <| number
        | _ -> None
    member this.Return(x) =
        Some(x)
