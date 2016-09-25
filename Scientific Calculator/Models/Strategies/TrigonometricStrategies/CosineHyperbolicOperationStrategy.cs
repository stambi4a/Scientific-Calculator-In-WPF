namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class CosineHyperbolicOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Cosh(value);

            return result;
        }
    }
}



