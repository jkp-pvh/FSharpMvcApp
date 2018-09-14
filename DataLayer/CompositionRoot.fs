namespace DataLayer

open System.Linq
open Microsoft.EntityFrameworkCore


module Globals =


let CreateDbContext =
    (fun() ->
        let optionsBuilder = new DbContextOptionsBuilder<MainDbContext>() 
        optionsBuilder.UseSqlServer("Data Source=(localdb)\FSharpWebAppDB;Initial Catalog=MainDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        new MainDbContext(optionsBuilder.Options)
    )


let dbContext = CreateDbContext()