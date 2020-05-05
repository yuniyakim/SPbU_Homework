module StringNumbersTests

open NUnit.Framework
open FsUnit
open StringNumbers

let stringNumbers = new StringNumbers()

[<Test>]
let simpleSomeStringNumbersTest () =
    stringNumbers {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    } |> should equal (Some(3))

[<Test>]
let simpleNoneStringNumbersTest () =
    stringNumbers {
        let! x = "1"
        let! y = "a"
        let z = x + y
        return z
    } |> should equal (None)

[<Test>]
let complexSomeStringNumbersTest () =
    stringNumbers {
        let! a = "1"
        let! b = "2"
        let! c = "147"
        let d = a + b + c
        let! e = "30"
        return d / e
    } |> should equal (Some(5))

[<Test>]
let complexNoneStringNumbersTest () =
    stringNumbers {
        let! a = "1"
        let! b = "2"
        let c = a + b
        let! d = "O"
        let e = c + d
        return e
    } |> should equal (None)
