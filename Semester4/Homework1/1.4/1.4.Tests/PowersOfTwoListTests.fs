module PowerOfTwoListTests

open NUnit.Framework
open PowersOfTwoList

[<Test>]
let PositivePowTwoTest () =
    Assert.AreEqual(2, powTwo 1)
    Assert.AreEqual(32, powTwo 5)
    Assert.AreEqual(1024, powTwo 10)
    Assert.AreEqual(16384, powTwo 14)

[<Test>]
let ZeroPowTwoTest () =
    Assert.AreEqual(1, powTwo 0)

[<Test>]
let NegativePowTwoTest () =
    Assert.AreEqual(-1, powTwo -1)
    Assert.AreEqual(-1, powTwo -18)
    Assert.AreEqual(-1, powTwo -999)

[<Test>]
let NegativeArgsPowersOfTwoTest () =
    Assert.AreEqual(None, powersOfTwoList -1 6)
    Assert.AreEqual(None, powersOfTwoList 287 -18)
    Assert.AreEqual(None, powersOfTwoList -64 -2)

[<Test>]
let ZeroArgsPowersOfTwoTest () =
    Assert.AreEqual(Some[1], powersOfTwoList 0 0)

[<Test>]
let PositiveArgsPowersOfTwoTest () =
    Assert.AreEqual(Some([32; 64; 128; 256]), powersOfTwoList 5 3)
    Assert.AreEqual(Some([1; 2; 4; 8; 16; 32; 64; 128; 256; 512; 1024; 2048]), powersOfTwoList 0 11)
    Assert.AreEqual(Some([8; 16; 32; 64]), powersOfTwoList 3 3)
