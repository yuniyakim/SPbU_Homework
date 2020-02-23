module AmountOfEvenNumbersFold

/// Defines an amount of even numbers in list using fold
let amountOfEvenNumbersFold ls =
    ls |> List.fold (fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0
