module PhonebookTests

open NUnit.Framework
open Phonebook
open FsUnit

let path = "..\..\..\4.3.txt"
let list = readFromFile path []

[<Test>]
let ``Check readFromFile`` () =
    list |> should contain ("name1", "111")
    list |> should contain ("name2", "222")
    list |> should contain ("name3", "333")
    list |> should contain ("name4", "444")

[<Test>]
let ``Check findByNumberRec`` () =
    findByNumberRec "111" list |> should equal "name1"
    findByNumberRec "222" list |> should equal "name2"
    findByNumberRec "333" list |> should equal "name3"
    findByNumberRec "444" list |> should equal "name4"
    findByNumberRec "0" list |> should equal ""

[<Test>]
let ``Check findByNameRec`` () =
    findByNameRec "name1" list |> should equal "111"
    findByNameRec "name2" list |> should equal "222"
    findByNameRec "name3" list |> should equal "333"
    findByNameRec "name4" list |> should equal "444"
    findByNameRec "name" list |> should equal ""

[<Test>]
let ``Check saveToFile`` () =
    let temp = list @ [("name5", "555")] @ [("name6", "666")]
    saveToFile path temp

    let newList = readFromFile path []
    newList |> should contain ("name1", "111")
    newList |> should contain ("name2", "222")
    newList |> should contain ("name3", "333")
    newList |> should contain ("name4", "444")
    newList |> should contain ("name5", "555")
    newList |> should contain ("name6", "666")

    saveToFile path list

[<Test>]
let ``Check checkNameExists`` () =
    checkNameExists "name1" list |> should be True
    checkNameExists "name2" list |> should be True
    checkNameExists "name3" list |> should be True
    checkNameExists "name4" list |> should be True
    checkNameExists "name" list |> should be False

[<Test>]
let ``Check checkNumberExists`` () =
    checkNumberExists "111" list |> should be True
    checkNumberExists "222" list |> should be True
    checkNumberExists "333" list |> should be True
    checkNumberExists "444" list |> should be True
    checkNumberExists "0" list |> should be False
