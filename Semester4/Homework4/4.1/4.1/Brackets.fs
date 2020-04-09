module Brackets

open System

let checkBrackets (str: string) =
    let rec check (str: List<char>) (stack: List<char>) =
        if str = [] then
            match stack with
            | [] -> true
            | _ -> false
        else
            let strHead = List.head str
            if (strHead = '(' || strHead = '[' || strHead = '{') then check (List.tail str) (strHead :: stack)
            elif ((stack <> []) && ((strHead = ')' && List.head stack = '(') || (strHead = ']' && List.head stack = '[') || 
                        (strHead = '}' && List.head stack = '{'))) then check (List.tail str) (List.tail stack)
            else false
    check (Seq.toList str) []
