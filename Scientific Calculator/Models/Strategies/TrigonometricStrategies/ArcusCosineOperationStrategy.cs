namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class ArcusCosineOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Acos(value);

            return result;
        }
    }
}


