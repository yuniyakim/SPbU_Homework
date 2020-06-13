module ArithmeticExpressionTreeTests

open NUnit.Framework
open FsUnit
open ArithmeticExpressionTree

[<Test>]
let DivisionByZeroArithmeticExpressionTreeTest () =
    (fun () -> calculate (Division(Number 10, Number 0)) |> ignore) |> should throw typeof<System.DivideByZeroException>

[<Test>]
let NumberArithmeticExpressionTreeTest () =
    calculate (Number 3158941) |> should equal 3158941

[<Test>]
let AdditionArithmeticExpressionTreeTest () =
    calculate (Addition(Number -19, Number 8)) |> should equal -11

[<Test>]
let SubtractionArithmeticExpressionTreeTest () =
    calculate (Subtraction(Number 296, Number -4)) |> should equal 300

[<Test>]
let MultiplicationArithmeticExpressionTreeTest () =
    calculate (Multiplication(Number 0, Number -92131)) |> should equal 0

[<Test>]
let DivisionArithmeticExpressionTreeTest () =
    calculate (Division(Number 125, Number -5)) |> should equal -25

[<Test>]
let SimpleArithmeticExpressionTreeTest () =
    calculate (Subtraction
                  (Division
                      (Multiplication
                          (Addition(Number 11, Number -5),
                          Number -4),
                      Addition
                          (Number 7,
                          Subtraction(Number 2, Number 7))),
                  (Addition
                      (Multiplication
                          (Number 3, 
                          Subtraction(Number 8, Number 16)),
                      Division
                          (Number -225,
                          Multiplication(Number 5, Number 9))))))
    |> should equal 17
