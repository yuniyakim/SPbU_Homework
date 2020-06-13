module RounderTests

open NUnit.Framework
open FsUnit
open Rounder

[<Test>]
let simpleRounderTest () =
    let rounder = new Rounder(3)
    rounder {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    } |> should (equalWithin 0.0001) 0.048

[<Test>]
let anotherSimpleRounderTest () =
    let rounder = new Rounder(2)
    rounder {
        let! a = 3.0 / 11.0
        let! b = 5.5
        return a / b
    } |> should (equalWithin 0.001) 0.05

[<Test>]
let complexRounderTest () =
    let rounder = new Rounder(4)
    rounder {
        let! a = 2.0 / 13.0
        let! b = 3.58 * 0.147
        let! c = 13.0 / 19.0
        let! d = b / c
        return a / d
    } |> should (equalWithin 0.00001) 0.1999

[<Test>]
let anotherComplexRounderTest () =
    let rounder = new Rounder(3)
    rounder {
        let! a = 2.0 / 19.0
        let! b = 0.35 * 0.98421
        let! c = a * b
        let! d = 0.963 * 2.6137
        return d / c
    } |> should (equalWithin 0.0001) 69.917
