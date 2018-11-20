using BusinessLayer;
using Model;
using System;

namespace BusinessLayerCSharp
{
    public class CompensationPredictionService
    {

        public PredictedCompensation GetPredictedCompensation(EmployeeCompensation employeeCompensation)
        {
            const int steps = 5;

            BaseCompensationPredictor predictor;

            var compType = (CompensationTypeEnum)employeeCompensation.CompensationTypeId;
            switch(compType)
            {
                case CompensationTypeEnum.Bonus:
                    predictor = new BonusCompensationPredictor(steps, employeeCompensation.Value);
                    break;
                case CompensationTypeEnum.Commission:
                    predictor = new CommissionCompensationPredictor(steps, employeeCompensation.Value);
                    break;
                case CompensationTypeEnum.Salary:
                    predictor = new SalaryCompensationPredictor(steps, employeeCompensation.Value);
                    break;
                case CompensationTypeEnum.Hourly:
                    predictor = new HourlyCompensationPredictor(steps, employeeCompensation.Value);
                    break;
                default:
                    predictor = new DefaultCompensationPredictor();
                    break;
            }

            return predictor.CalculatePredictedCompensation();
        }
    }
}
