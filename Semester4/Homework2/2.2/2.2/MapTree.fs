module MapTree

/// Tree structure
type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | Empty

/// Applies func to every value in tree
let rec mapTree func tree = 
    match tree with
    | Node(head, left, right) -> Node(func head, mapTree func left, mapTree func right)
    | Empty -> Empty
