namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class ArcusCosineHyperbolicOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Log(value + Math.Sqrt(value * value - 1));

            return result;
        }
    }
}

