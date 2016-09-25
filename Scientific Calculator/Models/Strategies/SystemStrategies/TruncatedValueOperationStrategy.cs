namespace Scientific_Calculator.Models.Strategies.SystemStrategies
{
    using System;

    using Attributes;

    [Component]
    public class TruncatedValueOperationStrategy
    {
        public double Calculate(double number)
        {
            return Math.Truncate(number);
        }
    }
}



