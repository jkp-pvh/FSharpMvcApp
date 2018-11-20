using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayerCSharp
{
    public abstract class BaseCompensationPredictor
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public int Steps { get; set; }
        protected decimal BaseValue { get; set; }

        internal decimal Increment { get; set; }
        protected decimal[] Multipliers;
        protected decimal[] ComputedValues;

        

        internal BaseCompensationPredictor(decimal min, decimal max, int steps, decimal baseValue)
        {
            Min = min;
            Max = max;
            Steps = steps;
            Increment = (Max - Min) / (decimal)(Steps - 1);
            BaseValue = baseValue;

            Multipliers = new decimal[Steps];
            ComputedValues = new decimal[Steps];
        }

        public abstract PredictedCompensation CalculatePredictedCompensation();

        public virtual void CalculatePredictionHelper()
        {
            for (var i = 0; i < Steps; i++)
            {
                Multipliers[i] = Min + (Increment * i);
                ComputedValues[i] = Multipliers[i] * BaseValue;
            }
        }
    }

    public class BonusCompensationPredictor : BaseCompensationPredictor
    {
        public BonusCompensationPredictor(int steps, decimal baseValue)
            : base(0, 1, steps, baseValue)
        {

        }

        public override PredictedCompensation CalculatePredictedCompensation()
        {
            var compensationTypeName = "Bonus";

            CalculatePredictionHelper();

            var retVal = new PredictedCompensation(Multipliers, ComputedValues, compensationTypeName);
            return retVal;
        }
    }

    public class CommissionCompensationPredictor : BaseCompensationPredictor
    {
        public CommissionCompensationPredictor(int steps, decimal baseValue)
            : base(0, 100000, steps, baseValue)
        {

        }

        public override PredictedCompensation CalculatePredictedCompensation()
        {
            var compensationTypeName = "Commission";

            CalculatePredictionHelper();

            for(var i = 0; i < Steps; i++ )
            {
                ComputedValues[i] /= 100;
            }

            var retVal = new PredictedCompensation(Multipliers, ComputedValues, compensationTypeName);
            return retVal;
        }

    }

    public class SalaryCompensationPredictor : BaseCompensationPredictor
    {
        public SalaryCompensationPredictor(int steps, decimal baseValue)
            :base(1, 1, steps, baseValue)
        {

        }

        public override PredictedCompensation CalculatePredictedCompensation()
        {
            var compensationTypeName = "Salary";

            CalculatePredictionHelper();

            var multipliersForDisplay = new decimal[Steps];
            Array.Fill(multipliersForDisplay, BaseValue);

            var retVal = new PredictedCompensation(multipliersForDisplay, ComputedValues, compensationTypeName);
            return retVal;
        }
    }

    public class HourlyCompensationPredictor : BaseCompensationPredictor
    {
        public HourlyCompensationPredictor(int steps, decimal baseValue)
            :base(30, 50, steps, baseValue)
        {
        }

        public override PredictedCompensation CalculatePredictedCompensation()
        {
            var compensationTypeName = "Hourly";

            CalculatePredictionHelper();

            for(int i=0; i<Steps; i++)
            {
                ComputedValues[i] *= 52; //52 weeks per year
            }

            var retVal = new PredictedCompensation(Multipliers, ComputedValues, compensationTypeName);
            return retVal;
        }
    }

    public class DefaultCompensationPredictor : BaseCompensationPredictor
    {
        public DefaultCompensationPredictor()
            :base(0, 0, 0, 0)
        { }

        public override PredictedCompensation CalculatePredictedCompensation()
        {
            return new PredictedCompensation(
                new decimal[] { 1, 2, 3 },
                new decimal[] { 10, 20, 30 },
                "Foo");
        }
    }
}
