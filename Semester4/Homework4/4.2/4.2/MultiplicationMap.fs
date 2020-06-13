module MultiplicationMap

/// Multiplies every element in the list to given value
let multiplicationMap x l = List.map (fun y -> y * x) l

let multiplicationMap1 (x: int): int list -> int list = List.map (fun y -> y * x)

let multiplicationMap2 (x: int): int list -> int list = List.map (fun y -> (*) x y)

let multiplicationMap3 (x: int): int list -> int list = List.map ((*) x)

let multiplicationMap4 (): int -> int list -> int list = List.map << (*)
