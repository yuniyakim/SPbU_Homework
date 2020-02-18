module FindPositionOfNumberTests

open NUnit.Framework
open FindPositionOfNumber

[<Test>]
let EmptyListFindPositionOfNumberTest () =
    Assert.AreEqual(None, findPositionOfNumber [] 9)

[<Test>]
let NoNumberFindPositionOfNumberTest () =
    Assert.AreEqual(None, findPositionOfNumber [24; -9; 0] 1624)
    Assert.AreEqual(None, findPositionOfNumber [0; 0; 0; 0; 0; 0] 1)

[<Test>]
let FindPositionOfNumberTest () =
    Assert.AreEqual(Some(1), findPositionOfNumber [-144; 18; -144; 0; -2; 34] -144)
    Assert.AreEqual(None, findPositionOfNumber [18; -84; 0; 199; 10; 10; 93; 0] 5)
    Assert.AreEqual(None, findPositionOfNumber [15; 0; 15; 0; 15; 0; 15; 15; 98] 9)
