namespace BusinessLayer

open FSharpWebAppFromTemplate.ViewModel
open Model

type CustomMapperService() = 
    let myVar = 0
    static member public MapToViewModel(employee) =
        EmployeeViewModel(employee.Id, employee.FirstName)