module AmountOfEvenNumbersFold

/// Defines an amount of even numbers in list using fold
let amountOfEvenNumbersFold ls =
    ls |> List.fold (fun acc x -> abs((x + 1) % 2) + acc) 0
