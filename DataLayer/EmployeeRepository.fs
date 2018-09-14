namespace DataLayer

open System.Linq
open Microsoft.EntityFrameworkCore
//open CompositionRoot

type EmployeeRepository() =
    
//    do
//      _dbContext <- CreateDbContext()  
      
    
  
    //member this._dbContext = CreateDbContext()
    
    
    
    member public this.LoadPeople() =
        Globals.dbContext.Employees.ToArray() |> Array.toList
        //this._dbContext.Employees.Value.ToList()
        //["Joe", "Fred", "Mary", "Sue"]
        //

        