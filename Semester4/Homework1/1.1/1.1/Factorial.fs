module Factorial

open System

let factorial n =
    let rec fact acc i =
        if n < 0 then
            None
        else if n = 0 then
            Some(1)
        else if i = n then
            Some(acc * i)
        else
            fact
                (acc * i)
                (i + 1)
    fact 1 1