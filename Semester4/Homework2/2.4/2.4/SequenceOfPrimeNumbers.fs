module SequenceOfPrimeNumbers

/// Checks if a number is prime
let isPrime n =
    let sqrt = (double >> sqrt >> int) n
    [2 .. sqrt] |> List.forall (fun x -> n % x <> 0)

/// Generates an infinite sequence of prime numbers
let sequenceOfPrimeNumbers =
    0
