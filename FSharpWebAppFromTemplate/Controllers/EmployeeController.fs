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
        //let retVal = EmployeeListViewModel([ EmployeeViewModel(1, "abc"); EmployeeViewModel(2, "def") ]) // //using the let binding so we can add a type annotation. Compiler infers this as List<EmployeeViewModel>, but not sure why it isn't confused by EmployeeModel. Did it choose ViewModel over Model arbitrarily?
        
        //this.View(retVal)
        //ViewResult()
        let personService = new EmployeeService() //todo: member var with dependency injection
        this.View(personService.GetPeople())
        //base.Json(personService.GetPeople())      


    [<HttpGet>]
    member this.Details() = 
        this.View(EmployeeViewModel(1, "abc");
        
        //{ Id=1; FirstName="abc" }
        )
