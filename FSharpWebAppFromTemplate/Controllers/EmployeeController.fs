namespace FSharpWebAppFromTemplate.Controllers

open Model
//open ViewModel
open BusinessLayer
open Microsoft.AspNetCore.Mvc
open FSharpWebAppFromTemplate.ViewModel


[<Route("api/[controller]/[action]")>]
type EmployeeController() = 
    inherit Controller()

    [<HttpGet>]
    member this.List() = 
        //this.View(CustomMapperService.MapToViewModel([{ Id=1; FirstName="Michael" }; { Id=2; FirstName="Jackson" }]))
        let employeeService = EmployeeService()
        let employees:List<Employee> = employeeService.LoadAllEmployees()
        this.View(CustomMapperService.MapToViewModel(employees))


    [<HttpGet>]
    member this.Details(id:int) = 
        //this.View(CustomMapperService.MapToViewModel({ Id=1; FirstName="Michael" }))
        let employeeService = EmployeeService() //todo: member var
        let employee = employeeService.LoadEmployee(id)
        this.View(CustomMapperService.MapToViewModel(employee))


