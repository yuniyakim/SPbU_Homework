module ConcurrentStack

/// Concurrent Stack
type ConcurrentStack<'a>() =
    let mutable stack : List<'a> = []

    /// Pushes value into stack
    member this.Push value =
        lock stack (fun () -> 
            stack <- value :: stack)

    /// Tries to pop element from stack
    member this.TryPop() =
        lock stack (fun () ->
            match stack with
            | [] -> None
            | head :: newStack ->
                stack <- newStack
                Some(head))
