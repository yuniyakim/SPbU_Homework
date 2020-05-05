module Rounder

open System

type Rounder(accuracy: int) =
    member this.Bind(x: float, f) =
        f <| Math.Round(x, accuracy)
    member this.Return(x: float) =
        Math.Round(x, accuracy)
