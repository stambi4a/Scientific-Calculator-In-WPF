namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class SquareRootOperationStrategy
    {
        public double Calculate(double first)
        {
            return (Math.Sqrt(first));
        }
    }
}
