namespace BusinessLayer

open DataLayer

type EmployeeService() =
    member public this.LoadEmployees() =
        let personRepository = new EmployeeRepository()
        personRepository.LoadPeople()
