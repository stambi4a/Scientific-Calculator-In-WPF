namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class ArcusSineOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Asin(value);

            return result;
        }
    }
}
