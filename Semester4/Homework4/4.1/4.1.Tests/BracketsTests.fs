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
        "[]", true
        "{}", true
        "([{[]}])", true
        "[}", false
        "[())]", false
        "[[{((", false
        "[}", false
        "]", false
        "(", false
        "1", false
        "(2)", false
    ] |> List.map (fun (str, res) -> TestCaseData(str, res))

[<Test>]
[<TestCaseSource("testCases")>]
let bracketsTest str res =
    checkBrackets str |> should equal res
