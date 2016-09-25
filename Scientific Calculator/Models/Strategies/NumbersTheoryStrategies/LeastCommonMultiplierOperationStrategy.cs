namespace Scientific_Calculator.Models.Strategies.NumbersTheoryStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class LeastCommonMultiplierOperationStrategy
    {
        public double Calculate(double left, double right)
        {
            if (left == right)
            {
                return left;
            }

            var min = Math.Min(left, right);
            var max = Math.Max(left, right);

            while (max % min != 0)
            {
                var swap = min;
                min = max % min;
                max = swap;
            }

            var result = left * (right / min);

            return result;
        }
    }
}

