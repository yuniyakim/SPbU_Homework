module Factorial.Tests

open NUnit.Framework
open Factorial

[<Test>]
let SomePositiveNumbersFactorialTest () =
    Assert.AreEqual(Some(1), factorial 1)
    Assert.AreEqual(Some(2), factorial 2)
    Assert.AreEqual(Some(24), factorial 4)
    Assert.AreEqual(Some(3628800), factorial 10)
    Assert.AreEqual(Some(479001600), factorial 12)

[<Test>]
let ZeroFactorialTest () =
    Assert.AreEqual(Some(1), factorial 0)

[<Test>]
let SomeNegativeNumbersFactorialTest () =
    Assert.AreEqual(None, factorial -1)
    Assert.AreEqual(None, factorial -126485)
    Assert.AreEqual(None, factorial -16)