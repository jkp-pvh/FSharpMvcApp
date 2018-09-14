namespace FSharpWebAppFromTemplate.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open BusinessLayer
open Microsoft.Data.OData
open Microsoft.Data.OData

type Person(name:string) =
    member val public Name = name with get, set

[<Route("api/[controller]/[action]")>]
type HomeController () =
    inherit Controller()

    //[<HttpGet>]
    //member this.Get() =
    //    [|"value1"; "value2"|]

    //[<HttpGet("{id}")>]
    //member this.Get(id:int) =
    //    "value"

    //[<HttpGet("/HelloWorld")>]
    [<HttpGet>]
    member this.HelloWorld() =
        //"Hello, World"
        ViewResult()

    //[<HttpGet("{name}")>]
    [<HttpGet>]
    [<Route("{name}")>]
    member this.Hello(name:string) =
        this.View(Person(name))
        //ViewResult(Person(name))
        
        //String.Format("Hello, {0}", name)


    [<HttpPost>]
    //[<FromBody>]value:string
    member this.PostMethod() =
        let personService = new EmployeeService() //todo: member var with dependency injection
        personService.LoadEmployees()
        //base.Json(personService.GetPeople())
        //Json()
        //"post method called"

    //[<HttpPut("{id}")>]
    //member this.Put(id:int, [<FromBody>]value:string ) =
    //    ()

    //[<HttpDelete("{id}")>]
    //member this.Delete(id:int) =
    //    ()
