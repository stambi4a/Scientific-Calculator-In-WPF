namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using Scientific_Calculator.Attributes;

    [Component]
    public class SubtractOperationStrategy
    {
        public double Calculate(double first, double second)
        {
            return first - second;
        }
    }
}
