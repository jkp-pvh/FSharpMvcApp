namespace FSharpWebAppFromTemplate.ViewModel
open System.Collections.Generic

type EmployeeViewModel(id:int, firstName:string, compensations:List<EmployeeCompensationViewModel>, predictedCompensations:List<PredictedCompensationViewModel>) = 

    new (id:int, firstName:string, compensations:List<EmployeeCompensationViewModel>) = EmployeeViewModel(id, firstName, compensations, List<PredictedCompensationViewModel>())

    new(id:int, firstName:string) = EmployeeViewModel(id, firstName, List<EmployeeCompensationViewModel>())
    
    member val public Id = id with get, set
    member val public FirstName = firstName with get, set
    member val public Compensations = compensations
    member val public PredictedCompensations = predictedCompensations

and EmployeeCompensationViewModel(value:int, compensationType:string) = 
    member val public Value = value with get, set
    member val public Type = compensationType with get, set

    member public this.UnitsPre
        with get() = match this.Type with
            | "Salary" | "Bonus" | "Hourly" -> "$"
            | "Commission" -> ""

    //todo: figure out how to implement this property on the EmployeeCompensation record type. (logic should go in business layer)
    member public this.UnitsPost 
        with get() = match this.Type with 
            //todo: string constants
            | "Salary" -> " per year"
            | "Bonus" -> "" //todo: string.Empty
            | "Hourly" -> " per hour"
            | "Commission" -> "%"

and PredictedCompensationViewModel(label:string) =
    member val public Label = label with get, set
    member val public Headers = Array.create 5 "a" with get
    member val public Values = Array.create 5 "b" with get

