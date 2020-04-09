module _4._1.Tests

open NUnit.Framework
open FsUnit
open Brackets

let testCases = 
    [
        "([([{()}[]])])", true
        "[{}([{[]{}}])]", true
        "", true
        "()", true
        "[{}]", true
        "[}", false
        "[())]", false
        "[[{((", false
        "[}", false
        "]", false
        "(", false
        "1", false
        "(2)", false
    ] |> List.map (fun (ls, res) -> TestCaseData(ls, res))

[<Test>]
[<TestCaseSource("testCases")>]
let bracketsTest ls res =
    checkBrackets ls |> should equal res
