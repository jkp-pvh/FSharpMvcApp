namespace BusinessLayer

open DataLayer
open System.Linq
open Model
open Common


type EmployeeService() =
    let GenerateMultiplier min increment index = 
        min + (increment * (decimal)index)

    member public this.LoadEmployee(id) = 
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        let retVal = personRepository.LoadEmployee(id)
        
        let fsCompensations = List.ofSeq retVal.Compensations //need to convert from System.Collections.Generic.List to F# list
        let predictions = fsCompensations |> List.map(fun c -> this.GeneratePredictedCompensation(c))
        
        retVal

    member public this.LoadEmployeeWithPredictions(id) =
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        let retVal = personRepository.LoadEmployee(id)
        
        let fsCompensations = List.ofSeq retVal.Compensations //need to convert from System.Collections.Generic.List to F# list
        let predictions = fsCompensations |> List.map(fun c -> this.GeneratePredictedCompensation(c))

        (retVal, predictions)

    member public this.LoadAllEmployees() =
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        personRepository.LoadAllEmployees()

    member public this.LoadAllCompensationTypes() = 
        let employeeRepo = new EmployeeRepository()
        employeeRepo.LoadAllCompensationTypes()

    member private this.GenerateMultipliers(min:decimal, max:decimal, steps:int) = 
        let increment = (decimal)(max - min) / ((decimal) (steps-1))
        let multiplierFunc = GenerateMultiplier min  increment 
        let retVal = Array.init steps multiplierFunc
        retVal;

    member private this.GeneratePredictedCompensation(compensation) = 
        let compensationType = enum<CompensationTypeEnum>(compensation.CompensationTypeId);

        let (min, max) = match compensationType with
                            | CompensationTypeEnum.Bonus -> (0m, 1m)
                            | CompensationTypeEnum.Hourly -> (30m, 50m)
                            | CompensationTypeEnum.Commission -> (0m, 100000m)
                            | CompensationTypeEnum.Salary -> ((decimal)compensation.Value, (decimal)compensation.Value)

        let multipliers = this.GenerateMultipliers(min, max, Constants.NumPredictions)
        let multipliersIdentity = this.GenerateMultipliers(1.0m, 1.0m, Constants.NumPredictions)
        let multipliersHourly = multipliers |> Array.map(fun curMultiplier -> curMultiplier * 52.0m)

        let baseCompensationValue = match compensationType with 
                        | CompensationTypeEnum.Commission -> (decimal)compensation.Value / 100m //todo: maybe Compensation.Value should have been decimal in the DB
                        | _ -> (decimal)compensation.Value

        let computedValues = match compensationType with 
                                | CompensationTypeEnum.Salary -> multipliersIdentity |> Array.map(fun (x:decimal) -> x * baseCompensationValue)
                                | CompensationTypeEnum.Hourly -> multipliersHourly |> Array.map(fun (x:decimal) -> x * baseCompensationValue)
                                | _ -> multipliers |> Array.map (fun (x:decimal) -> x * baseCompensationValue)
        
        PredictedCompensation(multipliers, computedValues, compensationType.ToString())

    (*
    The fact that F# is both OO and functional makes it EXTREMELY difficult to learn.
        example: what is the difference between methods and let bindings? How do you know when to use each? Seems like you can't use currying on methods - now I have to convert my method to a let binding

    Confusion between F#'s List type and System.Collections.Generic.List<T>

    F#'s type inference is TERRIBLE. I've had to specify type almost everywhere

    F# documentation seems not as good as the rest of MS's documentation, more like Oracle or Java. Only gives trivial examples
    *)