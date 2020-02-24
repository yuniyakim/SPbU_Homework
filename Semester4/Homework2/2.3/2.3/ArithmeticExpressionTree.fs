module ArithmeticExpressionTree

/// Arithmetic expression tree structure
type AritmeticExpressionTree =
    | Number of int
    | Addition of AritmeticExpressionTree * AritmeticExpressionTree
    | Subtraction of AritmeticExpressionTree * AritmeticExpressionTree
    | Multiplication of AritmeticExpressionTree * AritmeticExpressionTree
    | Division of AritmeticExpressionTree * AritmeticExpressionTree

/// Calculates the result of arithmetic expression tree
let rec calculate tree =
    match tree with
    | Number number -> number
    | Addition(left, right) -> (calculate left) + (calculate right)
    | Subtraction(left, right) -> (calculate left) - (calculate right)
    | Multiplication(left, right) -> (calculate left) * (calculate right)
    | Division(left, right) -> let rightNumber = calculate right
                               if rightNumber = 0 then raise (System.DivideByZeroException())
                               (calculate left) / rightNumber
