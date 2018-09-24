namespace DataLayer

open System.Linq
open Microsoft.EntityFrameworkCore
open Model

type EmployeeRepository() =

    
    member private this.AssignCompensationType(compensation, types:DbSet<CompensationType>) =
        compensation.CompensationType <- types.Single(fun t -> t.Id = compensation.CompensationTypeId)
    
    member private this.AssignCompensationTypes(employee) = 
        employee.Compensations.ForEach(fun c -> this.AssignCompensationType(c, Globals.dbContext.CompensationTypes))
        //employee.Compensations |> List.map(fun c -> this.AssignCompensationType(c, Globals.dbContext.CompensationTypes))
    
    member public this.LoadEmployee(id) = 
        //.ThenInclude(fun c -> c)
        let employees = Globals.dbContext.Employees.Include(fun e -> e.Compensations).Where(fun e -> e.Id = id) //todo: ThenInclude(fun c -> c.Compensations). If I try to do this, the param "c" is of type List<EmployeeCompensation> instead of EmployeeCompensation
        let compensationTypes = Globals.dbContext.CompensationTypes
        let foo = employees.ToList().ForEach(fun e -> this.AssignCompensationTypes(e))
        employees.Single()

        //0

    
    
    member public this.LoadAllEmployees() =
        Globals.dbContext.Employees.ToArray() |> Array.toList

    member public this.LoadAllCompensationTypes() = 
        Globals.dbContext.CompensationTypes
        