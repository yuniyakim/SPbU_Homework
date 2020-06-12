module AmountOfEvenNumbersMap

/// Defines an amount of even numbers in list using map
let amountOfEvenNumbersMap ls =
    ls |> List.map (fun x -> abs((x + 1) % 2)) |> List.sum