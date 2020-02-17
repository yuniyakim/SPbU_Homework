module Fibonacci

open System

let fibonacci n =
    let rec fib acc1 acc2 i =
        if n < 0 then
            None
        else if n = 0 then
            Some(0)
        else if n = i then
            Some(acc2)
        else
            fib (acc2) (acc1 + acc2) (i + 1)

    fib 0 1 1
