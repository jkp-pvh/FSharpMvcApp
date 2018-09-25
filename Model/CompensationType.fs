namespace Model

open System.ComponentModel.DataAnnotations.Schema

type CompensationTypeEnum = Salary = 1 | Bonus = 2 | Hourly = 3 | Commission = 4

[<Table("CompensationType")>]    
[<CLIMutable>]
type CompensationType = {
    Id:int;
    Name:string;
}