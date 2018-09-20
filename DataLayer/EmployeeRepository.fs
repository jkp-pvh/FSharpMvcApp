namespace DataLayer

open System.Linq
open Microsoft.EntityFrameworkCore

type EmployeeRepository() =

    member public this.LoadEmployee(id) = 
        Globals.dbContext.Employees.Include(fun e -> e.Compensations).Where(fun e -> e.Id = id).SingleOrDefault()
    
    member public this.LoadAllEmployees() =
        Globals.dbContext.Employees.ToArray() |> Array.toList

    member public this.LoadAllCompensationTypes() = 
        Globals.dbContext.CompensationTypes
        