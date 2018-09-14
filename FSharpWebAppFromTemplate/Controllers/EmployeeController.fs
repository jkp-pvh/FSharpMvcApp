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
        this.View(CustomMapperService.MapToViewModel([{ Id=1; FirstName="Michael" }; { Id=2; FirstName="Jackson" }]))


    [<HttpGet>]
    member this.Details() = 
        this.View(CustomMapperService.MapToViewModel({ Id=1; FirstName="Michael" }))


