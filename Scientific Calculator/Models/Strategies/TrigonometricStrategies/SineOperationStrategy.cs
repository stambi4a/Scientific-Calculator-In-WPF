namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class SineOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Sin(value);

            return result;
        }
    }
}
