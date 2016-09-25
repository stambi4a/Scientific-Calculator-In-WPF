namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class PowerOfTwoOperationStrategy
    {
        public double Calculate(double first)
        {
            return Math.Pow(2, first);
        }
    }
}
