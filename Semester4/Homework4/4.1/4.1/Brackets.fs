module Brackets

open System

let checkBrackets str =
    let strList = str |> Seq.toList
    let length = strList |> List.length
    let rec check stack acc =
        if acc < length then
            let element = List.item acc strList
            if stack = [] then false
            elif element = '(' || element = '[' || element = '{' then check (element :: stack) (acc + 1)
            elif (element = ')' && List.head stack = '(') || (element = ']' && List.head stack = '[') || 
                (element = '}' && List.head stack = '{') then check (List.tail stack) (acc + 1)
            else false
        List.isEmpty stack
    check [] 0

            //elif match List.head ls with
            //| '(' | '[' | '{' -> check (List.head ls :: stack) (acc + 1)
            //| ')' -> 
            //    if List.head stack = '(' then check (List.tail stack) (acc + 1)
            //| ']' -> 
            //    if List.head stack = '[' then check (List.tail stack) (acc + 1)
            //| '}' -> 
            //    if List.head stack = '{' then check (List.tail stack) (acc + 1)