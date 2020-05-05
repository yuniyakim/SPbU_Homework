module MultiplicationMapTests

open NUnit.Framework
open FsCheck
open MultiplicationMap

let test1 (x: int) (l: int list) = multiplicationMap x l = multiplicationMap1 x l
let test2 (x: int) (l: int list) = multiplicationMap x l = multiplicationMap2 x l
let test3 (x: int) (l: int list) = multiplicationMap x l = multiplicationMap3 x l
let test4 (x: int) (l: int list) = multiplicationMap x l = (multiplicationMap4 ()) x l

[<Test>]
let multiplicationMapTest1 () =
    Check.QuickThrowOnFailure test1

[<Test>]
let multiplicationMapTest2 () =
    Check.QuickThrowOnFailure test2

[<Test>]
let multiplicationMapTest3 () =
    Check.QuickThrowOnFailure test3

[<Test>]
let multiplicationMapTest4 () =
    Check.QuickThrowOnFailure test4
