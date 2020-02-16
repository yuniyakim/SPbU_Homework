module PowersOfTwoList

open System

let powTwo power =
    let rec pow acc i =
        if power < 0 then
            None
        else if power = 0 then
            Some(1)
        else if power = i then
            Some(acc)
        else
            pow
                (acc * 2)
                (i + 1)
    pow 1 1

let powersOfTwoList n m =
    let rec powersOfTwo ls acc i =
        
    powersOfTwo
        ([])
        (2)
        (1)
