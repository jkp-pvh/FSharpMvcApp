namespace FSharpWebAppFromTemplate.ViewModel

//[<CLIMutable>]
type EmployeeListViewModel(employees:List<EmployeeViewModel>) = 
    member val public Employees = employees with get, set


