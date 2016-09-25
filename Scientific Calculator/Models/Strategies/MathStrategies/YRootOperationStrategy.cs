namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class YRootOperationStrategy
    {
        public double Calculate(double exponent, double baseNumber)
        {
            return Math.Pow(baseNumber, 1 / exponent);
        }
    }
}
