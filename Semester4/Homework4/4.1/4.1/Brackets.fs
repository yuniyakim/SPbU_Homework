module Brackets

/// Checks if bracket sequence is correct
let checkBrackets (str: string) =
    /// Checks if symbol is an opening bracket
    let isOpeningBracket (symbol: char) =
        symbol = '(' || symbol = '[' || symbol = '{'

    /// Checks if a pair of symbols is a pair of matching brackets
    let isPairOfBrackets (firstSymbol: char) (secondSymbol: char) =
        match firstSymbol with
        | '(' -> secondSymbol = ')'
        | '[' -> secondSymbol = ']'
        | '{' -> secondSymbol = '}'
        | _ -> false

    /// Checks if brackets are balanced
    let rec check (str: List<char>) (stack: List<char>) =
        if str = [] then
            stack = []
        else
            let strHead = List.head str
            if (isOpeningBracket strHead) then check (List.tail str) (strHead :: stack)
            elif ((stack <> []) && isPairOfBrackets (List.head stack) strHead) then check (List.tail str) (List.tail stack)
            else false

    check (Seq.toList str) []
