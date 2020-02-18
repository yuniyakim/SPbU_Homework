module ReverseListTests

open NUnit.Framework
open ReverseList

[<Test>]
let ReverseListTest () =
    Assert.AreEqual(["something"], reverseList ["something"])
    Assert.AreEqual([3; 2; 1], reverseList [1; 2; 3])
    Assert.AreEqual([0; -2; 44; 9], reverseList [9; 44; -2; 0])
    Assert.AreEqual(["one"; "two"; "three"; "four"; "five"; "one"; "six"], reverseList ["six"; "one"; "five"; "four"; "three"; "two"; "one"])

[<Test>]
let ReverseEmptyListTest () =
    Assert.AreEqual([], [])
