namespace FSharpWebAppFromTemplate.ViewModel
//namespace FSharpWebAppFromTemplate.Controllers

//[<CLIMutable>]

type EmployeeViewModel(id:int, firstName:string) = 
    member val public Id = id with get, set
    member val public FirstName = firstName with get, set


