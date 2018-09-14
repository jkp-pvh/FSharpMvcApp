namespace DataLayer

open Model
open Microsoft.EntityFrameworkCore

type MainDbContext(options) = 
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable employees:DbSet<Employee>

    member x.Employees
        with get() = x.employees
        and set v = x.employees <- v
    
    //override this.

    override this.OnConfiguring(optionsBuilder) =
        optionsBuilder.UseSqlServer("Data Source=(localdb)\FSharpWebAppDB;Initial Catalog=MainDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False") |> ignore

    //member val StringVal = ""
    //    with get, set

