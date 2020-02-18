module FindPositionOfNumber

open System

let findPositionOfNumber ls n =
    let rec findPositionOfNumberInList ls i =
        if ls = [] then
            None
        else if List.head ls = n then
            Some(i)
        else 
            findPositionOfNumberInList (List.tail ls) (i + 1)

    findPositionOfNumberInList ls 1
