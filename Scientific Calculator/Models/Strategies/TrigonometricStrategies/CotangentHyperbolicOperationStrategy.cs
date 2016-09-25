namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class CotangentHyperbolicOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = 1 / Math.Tanh(value);

            return result;
        }
    }
}