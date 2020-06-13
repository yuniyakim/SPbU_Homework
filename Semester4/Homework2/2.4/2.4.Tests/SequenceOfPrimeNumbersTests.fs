module SequenceOfPrimeNumbersTests

open NUnit.Framework
open FsUnit
open SequenceOfPrimeNumbers

let testCasesIsPrime =
    [
        -19383, false
        -4, false
        -2, false
        -1, false
        0, false
        1, false
        2, true
        3, true
        9, false
        11, true
        53, true
        91, false
        113, true
        117, false
    ] |> List.map (fun (n, res) -> TestCaseData(n, res))

[<Test>]
[<TestCaseSource("testCasesIsPrime")>]
let ssPrimeTest n res =
    isPrime(n) |> should equal res

let testCasesSequenceOfPrimeNumbers =
    [
        0, 2
        1, 3
        2, 5
        3, 7
        9, 29
        15, 53
        24, 97
        30, 127
        49, 229
    ] |> List.map (fun (n, res) -> TestCaseData(n, res))

[<Test>]
[<TestCaseSource("testCasesSequenceOfPrimeNumbers")>]
let sequenceOfPrimeNumbersTest n res =
    sequenceOfPrimeNumbers () |> Seq.item n |> should equal res
