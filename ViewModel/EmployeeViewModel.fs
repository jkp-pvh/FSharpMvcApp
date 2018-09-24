namespace FSharpWebAppFromTemplate.ViewModel
open System.Collections.Generic

type EmployeeViewModel(id:int, firstName:string, compensations:List<EmployeeCompensationViewModel>) = 
    new(id:int, firstName:string) = EmployeeViewModel(id, firstName, List<EmployeeCompensationViewModel>())
    member val public Id = id with get, set
    member val public FirstName = firstName with get, set
    member val public Compensations = compensations

and EmployeeCompensationViewModel(valueWithUnits:string, compensationType:string) = 
    member val public ValueWithUnits = valueWithUnits with get, set
    member val public Type = compensationType with get, set
