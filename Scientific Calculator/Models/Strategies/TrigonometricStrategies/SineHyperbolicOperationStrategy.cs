namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class SineHyperbolicOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Sinh(value);

            return result;
        }
    }
}
