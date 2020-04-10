module SquareOfStarsList

/// Creates list with square of stars
let squareOfStarsList (n: int) =
    /// Creates a line of stars
    let rec lineOfStars (str: string) acc =
        if acc < n then lineOfStars (str + "*") (acc + 1)
        else str

    /// Creates a line of stars and spaces
    let rec line (str: string) acc =
        match acc with
        | 0 -> line "*" (acc + 1)
        | number when number = n - 1 -> (str + "*")
        | _ -> line (str + " ") (acc + 1)

    /// Fills list with lines
    let rec fillList (list: List<string>) acc =
        match acc with
        | number when number = n - 1 -> list @ [(lineOfStars "" 0)]
        | 0 -> fillList [(lineOfStars "" 0)] (acc + 1)
        | _ -> fillList (list @ [(line "" 0)]) (acc + 1)

    if n < 1 then raise (System.ArgumentOutOfRangeException())
    fillList [] 0

/// Prints square of
let rec printSquare (list: List<string>) =
    match list.Length with
    | 1 -> printfn "%s" list.Head
    | _ -> printfn "%s" list.Head
           printSquare list.Tail
