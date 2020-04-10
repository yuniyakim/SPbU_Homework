module ConcurrentStackTests

open System.Threading
open NUnit.Framework
open FsUnit
open ConcurrentStack

[<Test>]
let singlePushAndTryPopTest () =
    let stack = new ConcurrentStack<int>()
    stack.Push(1)
    stack.TryPop() |> should equal (1 |> Some)

[<Test>]
let tryPopFromEmptyStackTest () =
    let stack = new ConcurrentStack<bool>()
    stack.TryPop() |> should equal None

[<Test>]
let pushAndTryPopTests () =
    let stack = new ConcurrentStack<string>()
    stack.Push("")
    stack.Push("1")
    stack.Push("2")
    stack.TryPop() |> should equal ("2" |> Some)
    stack.TryPop() |> should equal ("1" |> Some)
    stack.TryPop() |> should equal ("" |> Some)
    stack.TryPop() |> should equal None
    stack.Push("2")
    stack.Push("3")
    stack.TryPop() |> should equal ("3" |> Some)
    stack.TryPop() |> should equal ("2" |> Some)
    stack.Push("1")
    stack.TryPop() |> should equal ("1" |> Some)
    stack.TryPop() |> should equal None

[<Test>]
let parallelStackTests () =
    let stack = new ConcurrentStack<int>()
    let mutable n = 0
    Async.Start (async { while n < 10 do stack.Push(n)})
    Async.Start (async { while n < 10 do stack.Push(n + 10)})
    Thread.Sleep(500)
    Async.Start (async { while n < 10 do n <- n + 1})
    stack.TryPop() |> should not' (equal None)
    stack.TryPop() |> should not' (equal None)
    stack.TryPop() |> should not' (equal None)
