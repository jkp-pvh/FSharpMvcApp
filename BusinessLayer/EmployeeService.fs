namespace BusinessLayer

open DataLayer

type PredictedCompensations(multipliers:int[], baseValue:int) = 
    member val public Multipliers = multipliers with get
    member val public BaseValue = baseValue with get
    member val public ComputedValues = None

type EmployeeService() =
    let GenerateMultiplier min increment index = 
        min + (increment * index)

    member public this.LoadEmployee(id) = 
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        let temp = this.GenerateMultipliers(0, 100, 5)
        personRepository.LoadEmployee(id)
        //let retVal = personRepository.LoadEmployee(id)
        //retVal.Compensations = 

    member public this.LoadAllEmployees() =
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        personRepository.LoadAllEmployees()

    member public this.LoadAllCompensationTypes() = 
        let employeeRepo = new EmployeeRepository()
        employeeRepo.LoadAllCompensationTypes()

    member private this.GenerateMultipliers(min:int, max:int, steps:int) = 
        let increment = (float)(max - min) / ((float) (steps-1))
        let multiplierFunc = GenerateMultiplier min  ((int)increment)
        let retVal = List.init steps multiplierFunc
        retVal;

    (*
    The fact that F# is both OO and functional makes it EXTREMELY difficult to learn.
        example: what is the difference between methods and let bindings? How do you know when to use each? Seems like you can't use currying on methods - now I have to convert my method to a let binding

    Confusion between F#'s List type and System.Collections.Generic.List<T>

    F#'s type inference is TERRIBLE. I've had to specify type almost everywhere
    *)