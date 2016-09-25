namespace Scientific_Calculator.Models.Strategies.SystemStrategies
{
    using System;

    using Attributes;

    [Component]
    public class RoundedValueOperationStrategy
    {
        public double Calculate(double number)
        {
            return Math.Round(number);
        }
    }
}

