namespace Model
open System.ComponentModel.DataAnnotations.Schema

[<Table("Employee")>]    
[<CLIMutable>]
type Employee = {
    Id:int;
    FirstName:string
}
    