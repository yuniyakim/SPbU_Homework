module _2._1.Tests

open NUnit.Framework
open FsUnit
open FsCheck
open AmountOfEvenNumbersFilter
open AmountOfEvenNumbersFold
open AmountOfEvenNumbersMap

let testCases = 
    [
        [], 0
        [1; 199; 203; -5; -19377; 897; 47; 3; 51; 3883; 15], 0
        [0], 1
        [0; 1; 3; 5; 7; 9; -1; -3; -5; -7; -9], 1
        [9; 21; 0; 488; -34; 17761; 964; -1963; 0], 5
    ] |> List.map (fun (ls, res) -> TestCaseData(ls, res))

[<Test>]
[<TestCaseSource("testCases")>]
let AmountOfEvenNumbersFilterTest ls res =
    amountOfEvenNumbersFilter(ls) |> should equal res

[<Test>]
[<TestCaseSource("testCases")>]
let AmountOfEvenNumbersFoldTest ls res =
    amountOfEvenNumbersFold(ls) |> should equal res

[<Test>]
[<TestCaseSource("testCases")>]
let AmountOfEvenNumbersMapTest ls res =
    amountOfEvenNumbersMap(ls) |> should equal res

[<Test>]
let AmountOfEvenNumbersFilterAndFoldTest () =
    Check.Quick (fun (ls: List<int>) -> (amountOfEvenNumbersFilter ls) = (amountOfEvenNumbersFold ls))

[<Test>]
let AmountOfEvenNumbersFoldAndMapTest () =
    Check.Quick (fun (ls: List<int>) -> (amountOfEvenNumbersFold ls) = (amountOfEvenNumbersMap ls))
