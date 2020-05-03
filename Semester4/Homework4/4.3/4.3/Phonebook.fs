module Phonebook

open System

/// Prints menu
let printMenu () =
    printf "Menu:"
    printf "1 – exit"
    printf "2 – add contact"
    printf "3 – find number by name"
    printf "4 – find name by number"
    printf "5 – print all contacts"
    printf "6 – save data to file"
    printf "7 – read data from file"

/// Prints all the contacts
let printAllContacts (list: List<string * string>) =
    List.map (fun (name, number) -> printf "Name: %s, number: %s" name number) list

/// Adds a new contact with entered name and number
let addContact (list: List<string * string>) =
    printf "Enter name"
    let name = Console.ReadLine()
    printf "Enter number"
    let number = Console.ReadLine()
    list @ [(name, number)]

/// Looks for number by given name recursively
let rec findByNameRec (name: string) (list: List<string * string>) =
    match list with
    | [] -> ""
    | (headName, headNumber) :: _ when headName = name -> headNumber
    | _ -> findByNameRec name (List.tail list)

/// Looks for number by entered name
let findByName (list: List<string * string>) = 
    printf "Enter name"
    let name = Console.ReadLine()
    let number = findByNameRec name list
    match number with
    | "" -> printf "There's no contact with name %s" name
    | _ -> printf "The number of %s is %s" name number

//Написать программу - телефонный справочник. Она должна уметь хранить имена и номера телефонов, в интерактивном режиме осуществлять следующие операции:
//1. выйти
//2. добавить запись (имя и телефон)
//3. найти телефон по имени
//4. найти имя по телефону
//5. вывести всё текущее содержимое базы
//6. сохранить текущие данные в файл
//7. считать данные из файла