namespace DataLayer

open System.Linq
open Microsoft.EntityFrameworkCore
//open CompositionRoot

type EmployeeRepository() =
    
//    do
//      _dbContext <- CreateDbContext()  
      
    
  
    //member this._dbContext = CreateDbContext()
    
    member public this.LoadEmployee(id) = 
        Globals.dbContext.Employees.Where(fun x -> x.Id = id).SingleOrDefault()
    
    member public this.LoadAllEmployees() =
        Globals.dbContext.Employees.ToArray() |> Array.toList
        //this._dbContext.Employees.Value.ToList()
        //["Joe", "Fred", "Mary", "Sue"]
        //

        