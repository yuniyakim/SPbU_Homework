module AmountOfEvenNumbersMap

/// Defines an amount of even numbers in list using map
let amountOfEvenNumbersMap ls =
    ls |> List.map (fun x -> if x % 2 = 0 then 1 else 0) |> List.sum