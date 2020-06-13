module InterpreterTests

open NUnit.Framework
open Interpreter
open FsUnit

[<Test>]
let ``One variable expression`` () =
    betaReduction (Variable('x')) |> should equal (Variable('x'))

[<Test>]
let ``One application expression`` () =
    betaReduction (Application(Variable('x'), Variable('y'))) |> should equal (Application(Variable('x'), Variable('y')))

[<Test>]
let ``One abstraction expression`` () =
    betaReduction (Abstraction('x', Variable('x'))) |> should equal (Abstraction('x', Variable('x')))

[<Test>]
let ``Simple expression`` () =
    betaReduction (Application(Abstraction('x', Application(Variable('x'), Variable('y'))), Abstraction('z', Variable('z'))))
        |> should equal (Variable('y'))

[<Test>]
let ``Another simple expression`` () =
    betaReduction (Application(Application(Abstraction('x', Variable('z')), Variable('x')), Application(Abstraction('y', Variable('w')), Variable('y'))))
        |> should equal (Application(Variable('z'), Variable('w')))
