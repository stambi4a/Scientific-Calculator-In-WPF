namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class LogarithmAtBaseXOperationStrategy
    {
        public double Calculate(double baseNumber, double element)
        {
            var result = Math.Log(element, baseNumber);

            return result;
        }
    }
}
