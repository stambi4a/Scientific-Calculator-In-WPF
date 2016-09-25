namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class ArcusCotangentOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Atan( 1/ value);

            return result;
        }
    }
}