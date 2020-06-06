module Phonebook

open System
open System.IO

/// Prints menu
let printMenu =
    printfn "Menu:"
    printfn "1 – exit"
    printfn "2 – add contact"
    printfn "3 – find number by name"
    printfn "4 – find name by number"
    printfn "5 – print all contacts"
    printfn "6 – save data to file"
    printfn "7 – read data from file"

/// Prints all the contacts
let printAllContacts (list: List<string * string>) =
    List.map (fun (name, number) -> printfn "Name: %s, number: %s" name number) list

/// Checks if contact with given name exists
let rec checkNameExists (name: string) (list: List<string * string>) =
    match list with
    | [] -> false
    | (headName, _) :: _ when headName = name -> true
    | _ -> checkNameExists name (List.tail list)

/// Checks if contact with given number exists
let rec checkNumberExists (number: string) (list: List<string * string>) =
    match list with
    | [] -> false
    | (_, headNumber) :: _ when headNumber = number -> true
    | _ -> checkNumberExists number (List.tail list)

/// Adds a new contact with entered name and number
let addContact (list: List<string * string>) =
    printfn "Enter name"
    let name = Console.ReadLine()
    if (checkNameExists name list) then 
        printfn "Contact with name %s already exists" name
        list
    else 
        printfn "Enter number"
        let number = Console.ReadLine()
        if (checkNumberExists number list) then 
            printfn "Contact with number %s already exists" number
            list
        else list @ [(name, number)]

/// Looks for number by given name recursively
let rec findByNameRec (name: string) (list: List<string * string>) =
    match list with
    | [] -> ""
    | (headName, headNumber) :: _ when headName = name -> headNumber
    | _ -> findByNameRec name (List.tail list)

/// Looks for number by entered name
let findByName (list: List<string * string>) =
    printfn "Enter name"
    let name = Console.ReadLine()
    let number = findByNameRec name list
    match number with
    | "" -> printfn "There's no contacts with name %s" name
    | _ -> printfn "The number of %s is %s" name number

/// Looks for name by given number recursively
let rec findByNumberRec (number: string) (list: List<string * string>) =
    match list with
    | [] -> ""
    | (headName, headNumber) :: _ when headNumber = number -> headName
    | _ -> findByNameRec number (List.tail list)

/// Looks for name by entered number
let findByNumber (list: List<string * string>) =
    printfn "Enter number"
    let number = Console.ReadLine()
    let name = findByNumberRec number list
    match name with
    | "" -> printfn "There's no contacts with number %s" number
    | _ -> printfn "Number %s belongs to %s" number name

/// Reads data from file
let readFromFile (path: string) (list: List<string * string>) =
    let file = Seq.map (fun (str: string) -> (Array.get (str.Split(" ")) 0, Array.get (str.Split(" ")) 1)) (File.ReadAllLines(path))
    printfn "Data from file is uploaded"
    Seq.toList file

/// Reads data from entered path
let readData (list: List<string * string>) =
    printfn "Enter path to read data from"
    let path = Console.ReadLine()
    readFromFile path list

/// Saves data to file
let saveToFile (path: string) (list: List<string * string>) =
    let newList = List.map (fun (name, number) -> name + " " + number + " ") list
    File.WriteAllLines(path, List.toArray newList)
    printfn "Data is saved to file"

/// Saves data to entered path
let saveData (list: List<string * string>) =
    printfn "Enter path to save data to"
    let path = Console.ReadLine()
    saveToFile path list

/// Starts program
let start () =
    /// Starts phonebook
    let rec startPhonebook (list: List<string * string>) =
        printfn "Choose command"
        match Console.ReadLine() with
        | "1" -> printfn "Phonebook was closed"
        | "2" -> addContact list |> ignore
                 startPhonebook list
        | "3" -> findByName list
                 startPhonebook list
        | "4" -> findByNumber list
                 startPhonebook list
        | "5" -> printAllContacts list |> ignore
                 startPhonebook list
        | "6" -> saveData list
                 startPhonebook list
        | "7" -> readData list |> ignore
                 startPhonebook list
        | _ -> printfn "Wrong command"

    printMenu
    startPhonebook []

//Написать программу - телефонный справочник. Она должна уметь хранить имена и номера телефонов, в интерактивном режиме осуществлять следующие операции:
//1. выйти
//2. добавить запись (имя и телефон)
//3. найти телефон по имени
//4. найти имя по телефону
//5. вывести всё текущее содержимое базы
//6. сохранить текущие данные в файл
//7. считать данные из файла