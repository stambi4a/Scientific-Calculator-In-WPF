namespace Scientific_Calculator.Models.Strategies.SignStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class AbsoluteValueOperationStrategy
    {
        public double Calculate(double value)
        {
            return Math.Abs(value);
        }
    }
}
