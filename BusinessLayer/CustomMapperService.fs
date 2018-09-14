namespace BusinessLayer

open FSharpWebAppFromTemplate.ViewModel
open Model

type CustomMapperService() = 

    static member public MapToViewModel(employee) =
        EmployeeViewModel(employee.Id, employee.FirstName)

    static member public MapToViewModel(employees:List<Employee>) = 
        //employees.iter(fun curEmployee -> EmployeeViewModel(curEmployee.Id, curEmployee.FirstName))
        let employeeViewModels = employees |> List.map(fun curEmployee -> EmployeeViewModel(curEmployee.Id, curEmployee.FirstName))
        EmployeeListViewModel(employeeViewModels)