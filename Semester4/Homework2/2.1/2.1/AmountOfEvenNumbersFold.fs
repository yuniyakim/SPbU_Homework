module AmountOfEvenNumbersFold

/// Defines an amount of even numbers in list using fold
let amountOfEvenNumbersFold ls =
    let func acc x =
        if x % 2 = 0 then
            acc + 1
        else 
            acc
    ls |> List.fold func 0
