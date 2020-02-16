module PowerOfTwoListTests

open NUnit.Framework
open PowersOfTwoList

[<Test>]
let PositivePowTwoLest () =
    Assert.AreEqual(Some(2), powTwo 1)
    Assert.AreEqual(Some(32), powTwo 5)
    Assert.AreEqual(Some(1024), powTwo 10)
    Assert.AreEqual(Some(16384), powTwo 14)

[<Test>]
let ZeroPowTwoLest () =
    Assert.AreEqual(Some(1), powTwo 0)

[<Test>]
let NegativePowTwoLest () =
    Assert.AreEqual(None, powTwo -1)
    Assert.AreEqual(None, powTwo -18)
    Assert.AreEqual(None, powTwo -999)
