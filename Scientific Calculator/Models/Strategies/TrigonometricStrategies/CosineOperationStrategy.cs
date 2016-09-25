namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class CosineOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Cos(value);

            return result;
        }
    }
}
