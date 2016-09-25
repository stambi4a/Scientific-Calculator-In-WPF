namespace Scientific_Calculator.Models.Strategies.CommonArithmeticStrategies
{
    using Scientific_Calculator.Attributes;

    [Component]
    public class MultiplyOperationStrategy
    {
        public double Calculate(double first, double second)
        {
            return first * second;
        }
    }
}
