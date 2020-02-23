module AmountOfEvenNumbersFilter

let amountOfEvenNumbersFilter ls =
    ls |> List.filter (fun x -> x % 2 = 0) |> List.length 