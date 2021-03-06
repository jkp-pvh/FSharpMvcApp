namespace BusinessLayer

open DataLayer
open System.Linq
open Model
open Common
open BusinessLayerCSharp

type EmployeeService() =
    let GenerateMultiplier min increment index = 
        min + (increment * (decimal)index)

    let _employeeRepository = new EmployeeRepository()

    //member public this.LoadEmployee(id) = 
    //    let personRepository = new EmployeeRepository() //todo: move this to a member var
    //    let retVal = personRepository.LoadEmployee(id)
        
    //    let fsCompensations = List.ofSeq retVal.Compensations //need to convert from System.Collections.Generic.List to F# list
    //    let predictions = fsCompensations |> List.map(fun c -> this.GeneratePredictedCompensation(c))
        
    //    retVal

    member public this.LoadEmployeeWithPredictions(id) =
        let employee = _employeeRepository.LoadEmployeeGroupJoin(id)
        
        let fsCompensations = List.ofSeq employee.Compensations //need to convert from System.Collections.Generic.List to F# list
        
        
        let predictions = fsCompensations |> List.map(fun c -> this.GeneratePredictedCompensation(c))
        
        //let predictionSvc = new CompensationPredictionService()
        //let predictions = fsCompensations |> List.map(fun c -> predictionSvc.GetPredictedCompensation(c)) 

        (employee, predictions)

    member public this.LoadAllEmployees() =
        _employeeRepository.LoadAllEmployees()

    member public this.LoadAllCompensationTypes() = 
        _employeeRepository.LoadAllCompensationTypes()

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