module _2._1.Tests

open NUnit.Framework
open FsUnit
open AmountOfEvenNumbersFilter

let testCases = 
    [
        [], 0
        [1; 199; 203; -5; -19377; 897; 47; 3; 51; 3883; 15], 0
        [9; 21; 0; 488; -34; 17761; 964; -1963; 0], 5
    ] |> List.map (fun (ls, res) -> TestCaseData(ls, res))

[<Test>]
[<TestCaseSource("testCases")>]
let AmountOfEvenNumbersFilterTest ls res =
    amountOfEvenNumbersFilter(ls) |> should equal res
