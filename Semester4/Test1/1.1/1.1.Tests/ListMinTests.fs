module ListMinTests

open NUnit.Framework
open FsUnit
open ListMin

let testCases =
    [
        [1; 199; 203; -5; -19377; 897; 47; 3; 51; 3883; 15], -19377
        [156], 156
        [0; 1; 3; 5; 7; -9; -1; -3; -5; -9; -7], -9
        [9; 21; 0; 488; 34; 17761; 964; 1963; 3], 0
    ] |> List.map (fun (ls, res) -> TestCaseData(ls, res))

[<Test>]
[<TestCaseSource("testCases")>]
let listMinTests ls res =
    listMin(ls) |> should equal res

[<Test>]
let emptyListMinTests () =
    (fun () -> listMin([]) |> ignore) |> should throw typeof<System.ArgumentException>