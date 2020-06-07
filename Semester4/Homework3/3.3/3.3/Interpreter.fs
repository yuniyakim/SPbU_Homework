module Interpreter

/// Labmda term
type Term =
    | Variable of char
    | Application of Term * Term
    | Abstraction of char * Term

/// Beta reduction
let betaReduction (expression: Term) =
    /// Checks if variable is free
    let rec isFree expression variable =
        match expression with
        | Variable var -> var = variable
        | Application(term1, term2) -> isFree term1 variable || isFree term2 variable
        | Abstraction(var, term) -> var <> variable && isFree term variable

    /// Substitute variable with another variable
    let rec substitution oldVariable newVariable expression =
        match expression with
        | Variable var when var = oldVariable -> newVariable
        | Variable _ -> expression
        | Application(term1, term2) -> Application(substitution oldVariable newVariable term1, substitution oldVariable newVariable term2)
        | Abstraction(var, _) when var = oldVariable -> expression
        | Abstraction(var, term) when not (isFree newVariable var) -> Abstraction(var, substitution oldVariable newVariable term)
        | Abstraction(var, term) -> let newVar = List.head (List.filter (not << isFree newVariable) ['a'..'z'])
                                    Abstraction(newVar, substitution oldVariable newVariable (substitution var (Variable newVar) term))

    /// Recursive beta reduction
    let rec betaReductionRec (expression: Term) =
        match expression with
        | Variable _ -> expression
        | Application(Abstraction(var, insideTerm), outsideTerm) -> betaReductionRec (substitution var outsideTerm insideTerm)
        | Application(term1, term2) -> Application(betaReductionRec term1, betaReductionRec term2)
        | Abstraction(var, term) -> Abstraction(var, betaReductionRec term)

    betaReductionRec expression
