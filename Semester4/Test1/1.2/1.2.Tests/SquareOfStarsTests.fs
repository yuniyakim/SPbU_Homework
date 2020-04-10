module StarsSquareTests

open NUnit.Framework
open FsUnit
open SquareOfStarsList

let testCases = 
    [
        1, ["*"]
        2, ["**"; "**"]
        3, ["***"; "* *"; "***"]
        4, ["****"; "*  *"; "*  *"; "****"]
        5, ["*****"; "*   *"; "*   *"; "*   *"; "*****"]
    ] |> List.map (fun (n, res) -> TestCaseData(n, res))

[<Test>]
[<TestCaseSource("testCases")>]
let starsSquareTests n res =
    squareOfStarsList(n) |> should equal res

[<Test>]
let invalidNumberStarsSquareTest () =
    (fun () -> squareOfStarsList(0) |> ignore) |> should throw typeof<System.ArgumentOutOfRangeException>
    (fun () -> squareOfStarsList(-1) |> ignore) |> should throw typeof<System.ArgumentOutOfRangeException>
    (fun () -> squareOfStarsList(-2) |> ignore) |> should throw typeof<System.ArgumentOutOfRangeException>
    (fun () -> squareOfStarsList(-5) |> ignore) |> should throw typeof<System.ArgumentOutOfRangeException>
