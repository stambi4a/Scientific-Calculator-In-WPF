namespace Scientific_Calculator.Models.Strategies.SignStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class SignValueOperationStrategy
    {
        public double Calculate(double value)
        {
            return Math.Sign(value);
        }
    }
}
