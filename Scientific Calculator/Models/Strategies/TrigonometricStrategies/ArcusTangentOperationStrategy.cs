namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class ArcusTangentOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Atan(value);

            return result;
        }
    }
}


