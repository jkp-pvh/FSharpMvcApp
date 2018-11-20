namespace Model
open System.ComponentModel.DataAnnotations.Schema
open System.Collections.Generic

[<Table("Employee")>]    
[<CLIMutable>]
type Employee = {
    Id:int;
    FirstName:string;
    Compensations:List<EmployeeCompensation> //NOTE: Employee cannot have a property of type List<EmployeeCompensation> because you can only reference types that are defined BEFORE this one (in solution explorer). Whenever we need to reference an Employee and his/her compensations, we will need to do it with a tuple of Employee*List<EmployeeCompensation>
}

and [<Table("EmployeeCompensation")>]    
[<CLIMutable>] EmployeeCompensation = {
    Id:int;
    Value:int;

    [<ForeignKey("Employee")>]
    EmployeeId:int;
    Employee:Employee;
    
    [<ForeignKey("CompensationType")>]
    CompensationTypeId:int;
    CompensationType:CompensationType
}


