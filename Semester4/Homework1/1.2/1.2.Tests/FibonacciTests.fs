module Fibonacci.Tests

open NUnit.Framework
open Fibonacci

[<Test>]
let SomePositiveNumbersFibonacciTest () =
    Assert.AreEqual(Some(1), fibonacci 1)
    Assert.AreEqual(Some(1), fibonacci 2)
    Assert.AreEqual(Some(2), fibonacci 3)
    Assert.AreEqual(Some(8), fibonacci 6)
    Assert.AreEqual(Some(55), fibonacci 10)
    Assert.AreEqual(Some(17711), fibonacci 22)

[<Test>]
let ZeroFibonacciTest () =
    Assert.AreEqual(Some(0), fibonacci 0)

[<Test>]
let SomeNegativeNumbersFibonacciTest () =
    Assert.AreEqual(None, fibonacci -1)
    Assert.AreEqual(None, fibonacci -126485)
    Assert.AreEqual(None, fibonacci -16) 