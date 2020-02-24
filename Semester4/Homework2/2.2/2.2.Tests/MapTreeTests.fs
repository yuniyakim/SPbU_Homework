module MapTreeTests

open NUnit.Framework
open FsUnit
open MapTree

[<Test>]
let MapEmptyTreeTest () =
    let res = 
        match mapTree (fun x -> x * 12648) Empty with
        | Empty -> true
        | _ -> false
    res |> should equal true

[<Test>]
let MapSimpleTreeTest () =
    mapTree (fun x -> x * x) (Node(5, Empty, Empty)) |> should equal (Node(25, Empty, Empty))
    mapTree (fun x -> x * -10) (Node(-3, Node(6, Empty, Empty), Empty)) |> should equal (Node(30, Node(-60, Empty, Empty), Empty))
    mapTree (fun x -> x * 2) (Node(0, Empty, Node(33, Empty, Empty))) |> should equal (Node(0, Empty, Node(66, Empty, Empty)))

[<Test>]
let MapHugeTreeTest () =
    mapTree (fun x -> x * x * x) (Node(1, 
                                        Node(-11, 
                                            Node(-3, 
                                                Node(5, 
                                                    Empty, 
                                                    Node(-7, 
                                                        Node(10, Empty, Empty), 
                                                        Node(8, Empty, Empty))), 
                                                Empty), 
                                            Node(5, 
                                                Empty, 
                                                Node(6, 
                                                    Node(9, Empty, Empty), 
                                                    Node(-8, Empty, Empty)))), 
                                        Node(4, 
                                            Node(-4,
                                                Empty,
                                                Node(0, 
                                                    Node(-1, 
                                                        Node(1, Empty, Empty), 
                                                        Node(-5, Empty, Empty)),
                                                    Empty)), 
                                            Node(3, 
                                                Node(-2, 
                                                    Node(-6, Empty, Empty), 
                                                    Node(-2, Empty, Empty)),
                                                Empty)))) 
    |> should equal (Node(1, 
                            Node(-1331, 
                                Node(-27, 
                                    Node(125, 
                                        Empty, 
                                        Node(-343, 
                                            Node(1000, Empty, Empty), 
                                            Node(512, Empty, Empty))), 
                                    Empty), 
                                Node(125, 
                                    Empty, 
                                    Node(216, 
                                        Node(729, Empty, Empty), 
                                        Node(-512, Empty, Empty)))), 
                            Node(64, 
                                Node(-64,
                                    Empty,
                                    Node(0, 
                                        Node(-1, 
                                            Node(1, Empty, Empty), 
                                            Node(-125, Empty, Empty)),
                                        Empty)), 
                                Node(27, 
                                    Node(-8, 
                                        Node(-216, Empty, Empty), 
                                        Node(-8, Empty, Empty)),
                                    Empty))))
