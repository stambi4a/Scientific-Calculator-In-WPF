namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class LogarithmAtBase2OperationStrategy
    {
        public double Calculate(double element)
        {
            var result = Math.Log(element, 2);

            return result;
        }
    }
}
