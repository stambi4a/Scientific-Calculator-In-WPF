namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class TangentHyperbolicOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Tanh(value);

            return result;
        }
    }
}
