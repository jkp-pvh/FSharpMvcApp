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
        //todo: group join
        let employees = Globals.dbContext.Employees.Include(fun e -> e.Compensations).Where(fun e -> e.Id = id) //todo: ThenInclude(fun c -> c.Compensations). If I try to do this, the param "c" is of type List<EmployeeCompensation> instead of EmployeeCompensation
        let compensationTypes = Globals.dbContext.CompensationTypes
        let foo = employees.ToList().ForEach(fun e -> this.AssignCompensationTypes(e))
        employees.Single()

    member public this.LoadEmployeeGroupJoin(id) = 
        let compensations = Globals.dbContext.EmployeeCompensations.Include(fun ec -> ec.CompensationType);
        let employees = Globals.dbContext.Employees.Where(fun e -> e.Id = id) 

        //employees.GroupJoin(compensations, (fun e -> e.Id), (fun c -> c.EmployeeId), fun x-> {Id=1; FirstName=x.ToString(); Compensations=compensations})

        //Globals.dbContext.Employees.GroupJoin(Globals.dbContext.EmployeeCompensations, fun e -> e.Compensations
        0

    
    
    member public this.LoadAllEmployees() =
        Globals.dbContext.Employees.ToArray() |> Array.toList

    member public this.LoadAllCompensationTypes() = 
        Globals.dbContext.CompensationTypes
        