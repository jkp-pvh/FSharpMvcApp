namespace BusinessLayer

open FSharpWebAppFromTemplate.ViewModel
open Model
open System.Linq

type CustomMapperService() = 

    static member public MapToViewModel(compensation:EmployeeCompensation) =
        EmployeeCompensationViewModel(compensation.Value, compensation.CompensationType.Name)
    
    static member public MapToViewModel(employee:Employee) = //NOTE: type inference was working here until I added the class CompensationType. Even though CompensationType has properties Id and Name (while Employee has properties Id and FirstName), the compiler is still confused by this, so I had to add a type annotation.
        //let compensationViewModels = employee.Compensations.Select(fun c -> MapToViewModel(c)).ToList()
        let compensationViewModels = employee.Compensations.Select(fun c -> EmployeeCompensationViewModel(c.Value, c.CompensationType.Name)).ToList()
        EmployeeViewModel(employee.Id, employee.FirstName, compensationViewModels)

    static member public MapToViewModel(employees:List<Employee>) = 
        //employees.iter(fun curEmployee -> EmployeeViewModel(curEmployee.Id, curEmployee.FirstName))
        let employeeViewModels = employees |> List.map(fun curEmployee -> EmployeeViewModel(curEmployee.Id, curEmployee.FirstName))
        EmployeeListViewModel(employeeViewModels)