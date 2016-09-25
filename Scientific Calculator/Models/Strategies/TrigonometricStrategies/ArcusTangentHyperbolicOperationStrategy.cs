namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class ArcusTangentHyperbolicOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = 1d / 2 * Math.Log((1 + value) / (1 - value));

            return result;
        }
    }
}
