namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class MultiplierWithPowerOfTenOperationStrategy
    {
        public double Calculate(double multiplier, double exponent)
        {
            var result = multiplier * Math.Pow(10, exponent);

            return result;
        }
    }
}
