namespace BusinessLayer

type MapperService() = 
    static let initMapper() = 0

    static member val public MapperConfig = initMapper() with get, set //todo: private set

    //member private static CreateMapperConfig() = 0
    
    static member public  InitializeMapper() = 
        initMapper()

    //let genString () = "this is a string"
    //member val public MyProperty = genString() with get, set
    //member public this.GenerateString = genString
