module ReverseList

open System

let reverseList ls =
    let rec reverse ls acc =
        if ls = [] then
            acc
        else 
            reverse 
                (List.tail ls)
                (List.head ls :: acc)
    reverse ls []