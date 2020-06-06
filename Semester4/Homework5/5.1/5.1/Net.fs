module Net

open System
open Computer

/// Computer net's type
type Net(computers: List<Computer>, matrix: List<List<bool>>) =
    /// Amount of comuters in the net
    let amount = List.length computers

    /// One step of infection
    let step (random: Random) =
        List.iter (fun (computer: Computer) -> if computer.JustInfected then computer.JustInfected <- false) computers

        for i in 0 .. amount - 1 do
            if not (computers.Item i).Infected then
                for j in 0 .. amount - 1 do
                    if (matrix.Item i).Item j && (computers.Item j).Infected && not (computers.Item j).JustInfected &&
                       random.NextDouble() < (computers.Item i).Possibility
                    then (computers.Item i).Infected <- true
                         (computers.Item i).JustInfected <- true

    /// Current state of computers
    let state =
        for i in 0 .. amount - 1 do
            let computer = computers.Item i
            printfn "Name: %s, OS: %s, is infected: %b" computer.Name computer.OS computer.Infected

    /// Starts infection
    member this.Start (stepAmount: int, frequency: int, random: Random) =
        for i in 1 .. stepAmount do
            step(random)
            if frequency <> 0 && i % frequency = 0 then state
        state
