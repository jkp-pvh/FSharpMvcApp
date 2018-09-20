namespace BusinessLayer

open FSharpWebAppFromTemplate.ViewModel
open Model

type CustomMapperService() = 

    static member public MapToViewModel(employee:Employee) = //NOTE: type inference was working here until I added the class CompensationType. Even though CompensationType has properties Id and Name (while Employee has properties Id and FirstName), the compiler is still confused by this, so I had to add a type annotation.
        EmployeeViewModel(employee.Id, employee.FirstName)

    static member public MapToViewModel(employees:List<Employee>) = 
        //employees.iter(fun curEmployee -> EmployeeViewModel(curEmployee.Id, curEmployee.FirstName))
        let employeeViewModels = employees |> List.map(fun curEmployee -> EmployeeViewModel(curEmployee.Id, curEmployee.FirstName))
        EmployeeListViewModel(employeeViewModels)