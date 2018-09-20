namespace BusinessLayer

open DataLayer

type EmployeeService() =
    member public this.LoadEmployee(id) = 
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        personRepository.LoadEmployee(id)

    member public this.LoadAllEmployees() =
        let personRepository = new EmployeeRepository() //todo: move this to a member var
        personRepository.LoadAllEmployees()

    member public this.LoadAllCompensationTypes() = 
        let employeeRepo = new EmployeeRepository()
        employeeRepo.LoadAllCompensationTypes()