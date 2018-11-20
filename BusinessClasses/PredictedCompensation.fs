namespace BusinessLayer

type PredictedCompensation(multipliers:decimal[], computedValues:decimal[], compensationTypeName:string) = 
    member val public Multipliers = multipliers with get
    member val public ComputedValues = computedValues with get
    member val public CompensationTypeName = compensationTypeName with get
