namespace Scientific_Calculator.Models.Strategies.TrigonometricStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class TangentOperationStrategy
    {
        public double Calculate(double value)
        {
            var result = Math.Tan(value);

            return result;
        }
    }

}
