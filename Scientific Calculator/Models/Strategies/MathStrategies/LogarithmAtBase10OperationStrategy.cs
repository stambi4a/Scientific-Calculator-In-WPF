namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class LogarithmAtBase10OperationStrategy
    {
        public double Calculate(double element)
        {
            var result = Math.Log10(element);

            return result;
        }
    }
}

