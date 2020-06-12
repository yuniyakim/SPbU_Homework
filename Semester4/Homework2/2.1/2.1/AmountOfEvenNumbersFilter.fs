module AmountOfEvenNumbersFilter

/// Defines an amount of even numbers in list using filter
let amountOfEvenNumbersFilter ls =
    ls |> List.filter (fun x -> x % 2 = 0) |> List.length
