namespace Common

[<AbstractClass; Sealed>]
type Constants private () =
    static member val NumPredictions = 5 with get