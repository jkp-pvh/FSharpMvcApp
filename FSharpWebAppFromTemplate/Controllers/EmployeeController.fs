namespace FSharpWebAppFromTemplate.Controllers

open Model
//open ViewModel
open BusinessLayer
open Microsoft.AspNetCore.Mvc
open FSharpWebAppFromTemplate.ViewModel


[<Route("api/[controller]/[action]")>]
type EmployeeController() = 
    inherit Controller()

    let _employeeService = EmployeeService()

    [<HttpGet>]
    member this.List() = 
        let employees:List<Employee> = _employeeService.LoadAllEmployees()
        this.View(CustomMapperService.MapToViewModel(employees))


    [<HttpGet>]
    member this.Details(id:int) = 
        let employee = _employeeService.LoadEmployee(id)
        
        let viewModel = CustomMapperService.MapToViewModel(employee) //todo: mapping should be done in business layer!
        this.View(viewModel)
        
    [<HttpGet>]
    member this.DetailsWithPrediction(id:int) = 
        let modelWithPredictions = _employeeService.LoadEmployeeWithPredictions(id)
        
        let viewModel = CustomMapperService.MapToViewModel(modelWithPredictions)

        this.View(viewModel)


        

    [<HttpGet>]
    member this.LoadCompensationTypes() = 
        _employeeService.LoadAllCompensationTypes()
