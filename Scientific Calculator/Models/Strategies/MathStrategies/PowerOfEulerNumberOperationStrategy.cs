namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class PowerOfEulerNumberOperationStrategy
    {
        public double Calculate(double first)
        {
            return Math.Pow(Math.E, first);
        }
    }
}


