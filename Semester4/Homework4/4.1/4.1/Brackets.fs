module Brackets

open System

let isClosingBracket (bracket: char) =
    bracket = ')' || bracket = ']' || bracket = '}'

let checkBrackets (str: string) =
    let rec check (str: List<char>) (stack: List<char>) =
        if str = [] then
            match stack with
            | [] -> true
            | _ -> false
        else
            let strHead = List.head str
            let stackHead = List.head stack
            if (strHead = '(' || strHead = '[' || strHead = '{') then check (List.tail str) (strHead :: stack)
            elif ((strHead = ')' && stackHead = '(') || (strHead = ']' && stackHead = '[') || 
                        (strHead = '}' && stackHead = '{')) then check (List.tail str) (List.tail stack)
            else false
            //match strHead with
            //| '(' | '[' | '{' -> check (List.tail str) (strHead :: stack)
            //| ')' when stackHead = '(' -> check (List.tail str) (List.tail stack)
            //| ']' when stackHead = '[' -> check (List.tail str) (List.tail stack)
            //| '}' when stackHead = '{' -> check (List.tail str) (List.tail stack)
    check (Seq.toList str) []



    //let strList = str |> Seq.toList
    //let length = strList |> List.length
    //let rec check stack acc =
    //    if acc < length then
    //        let element = List.item acc strList
    //        if stack = [] then false
    //        elif element = '(' || element = '[' || element = '{' then check (element :: stack) (acc + 1)
    //        elif (element = ')' && List.head stack = '(') || (element = ']' && List.head stack = '[') || 
    //            (element = '}' && List.head stack = '{') then check (List.tail stack) (acc + 1)
    //        else false
    //    List.isEmpty stack
    //check [] 0

            //elif match List.head ls with
            //| '(' | '[' | '{' -> check (List.head ls :: stack) (acc + 1)
            //| ')' -> 
            //    if List.head stack = '(' then check (List.tail stack) (acc + 1)
            //| ']' -> 
            //    if List.head stack = '[' then check (List.tail stack) (acc + 1)
            //| '}' -> 
            //    if List.head stack = '{' then check (List.tail stack) (acc + 1)