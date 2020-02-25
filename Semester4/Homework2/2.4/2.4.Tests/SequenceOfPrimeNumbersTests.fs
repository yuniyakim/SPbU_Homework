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
let IsPrimeTest n res =
    isPrime(n) |> should equal res
