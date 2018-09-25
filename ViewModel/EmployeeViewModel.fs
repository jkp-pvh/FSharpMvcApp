namespace FSharpWebAppFromTemplate.ViewModel
open System.Collections.Generic

type EmployeeViewModel(id:int, firstName:string, compensations:List<EmployeeCompensationViewModel>) = 
    new(id:int, firstName:string) = EmployeeViewModel(id, firstName, List<EmployeeCompensationViewModel>())
    member val public Id = id with get, set
    member val public FirstName = firstName with get, set
    member val public Compensations = compensations

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