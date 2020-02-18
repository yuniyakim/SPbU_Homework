module PowersOfTwoList

open System

let powTwo n =
    let rec pow acc i =
        if n < 0 then
            -1
        else if n = 0 then
            1
        else if n = i then
            acc * 2
        else
            pow (acc * 2) (i + 1)

    pow 1 1

let powersOfTwoList n m =
    let rec powersOfTwo acc i =
        if n < 0 || m < 0 then
            None
        else if n =0 && m = 0 then
            Some([1])
        else if i = m + n then
            powersOfTwo ((powTwo i) :: acc) (i - 1)
        else if i = n then
            Some((powTwo i) :: acc)
        else
            powersOfTwo ((List.head acc / 2) :: acc) (i - 1)

    powersOfTwo ([]) (m + n)
