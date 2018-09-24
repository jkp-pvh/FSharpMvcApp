namespace BusinessLayer

open DataLayer

type EmployeeService() =
    //member private this.CalculateCompensation()

    //member private this.CalculateCompensations(employee)
    //    employee.Compensations |> List.map()

    member public this.LoadEmployee(id) = 
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        personRepository.LoadEmployee(id)
        //let retVal = personRepository.LoadEmployee(id)
        //retVal.Compensations = 

    member public this.LoadAllEmployees() =
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        personRepository.LoadAllEmployees()

    member public this.LoadAllCompensationTypes() = 
        let employeeRepo = new EmployeeRepository()
        employeeRepo.LoadAllCompensationTypes()