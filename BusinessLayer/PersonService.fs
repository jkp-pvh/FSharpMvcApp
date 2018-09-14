namespace BusinessLayer

open DataLayer

type EmployeeService() =
    member public this.GetPeople() =
        let personRepository = new EmployeeRepository()
        personRepository.LoadPeople()
