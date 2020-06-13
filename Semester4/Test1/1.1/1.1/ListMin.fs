module ListMin

/// Defines minimum of two numbers
let min number1 number2 = 
    if number1 < number2 then number1
    else number2

/// Defines minimum in list
let listMin (list: List<int>) =
    if list = [] then raise (System.ArgumentException())
    List.fold min System.Int32.MaxValue list
