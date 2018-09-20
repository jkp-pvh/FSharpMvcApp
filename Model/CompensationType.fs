namespace Model

open System.ComponentModel.DataAnnotations.Schema



[<Table("CompensationType")>]    
[<CLIMutable>]
type CompensationType = {
    Id:int;
    Name:string;
}