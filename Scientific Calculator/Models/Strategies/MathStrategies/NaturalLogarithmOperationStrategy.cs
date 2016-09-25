namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class NaturalLogarithmOperationStrategy
    {
        public double Calculate(double element)
        {
            var result = Math.Log(element);

            return result;
        }
    }
}

