module NetTests

open NUnit.Framework
open System
open Computer
open Net
open FsUnit

let compare (computer1: Computer) (computer2: Computer) =
    if computer1.Name = computer2.Name && computer1.OS = computer2.OS && computer1.Infected = computer2.Infected
    then 1
    else 0

let computers1 =
    [
        new Computer("first", "Windows", false)
        new Computer("second", "Windows", false)
        new Computer("third", "Windows", false)
        new Computer("fourth", "Windows", true)
    ]

let matrix1 =
    [
        [false; false; true; false]
        [false; false; true; true]
        [true; true; false; false]
        [false; true; false; false]
    ]

let computers2 =
    [
        new Computer("first", "MacOS", false)
        new Computer("second", "MacOS", false)
        new Computer("third", "MacOS", false)
        new Computer("fourth", "MacOS", true)
    ]

let matrix2 =
    [
        [false; true; true; true]
        [true; false; true; true]
        [true; true; false; true]
        [true; true; true; false]
    ]

let computers3 =
    [
        new Computer("first", "Windows", false)
        new Computer("second", "MacOS", false)
        new Computer("third", "Linux", false)
        new Computer("fourth", "Windows", false)
        new Computer("fifth", "Linux", true)
    ]

let matrix3 =
    [
        [false; false; true; true; false]
        [false; false; false; false; true]
        [true; false; false; false; false]
        [true; false; false; false; true]
        [false; true; false; true; false]
    ]

[<Test>]
let ``Check 1.0 possibility after 1 step`` () =
    let net = new Net(computers1, matrix1)
    net.Start(1, 0, new Random())
    (net.Computers.Item 0).Infected |> should be False
    (net.Computers.Item 1).Infected |> should be True
    (net.Computers.Item 2).Infected |> should be False
    (net.Computers.Item 3).Infected |> should be True

[<Test>]
let ``Check 1.0 possibility after 2 steps`` () =
    let net = new Net(computers1, matrix1)
    net.Start(2, 0, new Random())
    (net.Computers.Item 0).Infected |> should be False
    (net.Computers.Item 1).Infected |> should be True
    (net.Computers.Item 2).Infected |> should be True
    (net.Computers.Item 3).Infected |> should be True

[<Test>]
let ``Check 1.0 possibility after 3 steps`` () =
    let net = new Net(computers1, matrix1)
    net.Start(3, 0, new Random())
    (net.Computers.Item 0).Infected |> should be True
    (net.Computers.Item 1).Infected |> should be True
    (net.Computers.Item 2).Infected |> should be True
    (net.Computers.Item 3).Infected |> should be True

[<Test>]
let ``Check 0.0 possibility after 1 step`` () =
    let net = new Net(computers2, matrix2)
    net.Start(1, 0, new Random())
    (net.Computers.Item 0).Infected |> should be False
    (net.Computers.Item 1).Infected |> should be False
    (net.Computers.Item 2).Infected |> should be False
    (net.Computers.Item 3).Infected |> should be True

[<Test>]
let ``Check 0.0 possibility after 2 steps`` () =
    let net = new Net(computers2, matrix2)
    net.Start(2, 0, new Random())
    (net.Computers.Item 0).Infected |> should be False
    (net.Computers.Item 1).Infected |> should be False
    (net.Computers.Item 2).Infected |> should be False
    (net.Computers.Item 3).Infected |> should be True

[<Test>]
let ``Check 0.0 possibility after 3 steps`` () =
    let net = new Net(computers2, matrix2)
    net.Start(3, 0, new Random())
    (net.Computers.Item 0).Infected |> should be False
    (net.Computers.Item 1).Infected |> should be False
    (net.Computers.Item 2).Infected |> should be False
    (net.Computers.Item 3).Infected |> should be True

[<Test>]
let ``Check 0.0 possibility after 50 steps`` () =
    let net = new Net(computers2, matrix2)
    net.Start(50, 0, new Random())
    (net.Computers.Item 0).Infected |> should be False
    (net.Computers.Item 1).Infected |> should be False
    (net.Computers.Item 2).Infected |> should be False
    (net.Computers.Item 3).Infected |> should be True

[<Test>]
let ``Check different possibilities after 1 step`` () =
    let net = new Net(computers3, matrix3)
    net.Start(1, 0, new Random())
    (net.Computers.Item 0).Infected |> should be False
    (net.Computers.Item 1).Infected |> should be False
    (net.Computers.Item 2).Infected |> should be False
    (net.Computers.Item 3).Infected |> should be True
    (net.Computers.Item 4).Infected |> should be True


[<Test>]
let ``Check different possibilities after 2 steps`` () =
    let net = new Net(computers3, matrix3)
    net.Start(2, 0, new Random())
    (net.Computers.Item 0).Infected |> should be True
    (net.Computers.Item 1).Infected |> should be False
    (net.Computers.Item 2).Infected |> should be False
    (net.Computers.Item 3).Infected |> should be True
    (net.Computers.Item 4).Infected |> should be True


[<Test>]
let ``Check different possibilities after 100 steps`` () =
    let net = new Net(computers3, matrix3)
    net.Start(100, 0, new Random())
    (net.Computers.Item 0).Infected |> should be True
    (net.Computers.Item 1).Infected |> should be False
    (net.Computers.Item 2).Infected |> should be True
    (net.Computers.Item 3).Infected |> should be True
    (net.Computers.Item 4).Infected |> should be True
