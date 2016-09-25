namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class YPowerOfXOperationStrategy
    {
        public double Calculate(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }
    }
}