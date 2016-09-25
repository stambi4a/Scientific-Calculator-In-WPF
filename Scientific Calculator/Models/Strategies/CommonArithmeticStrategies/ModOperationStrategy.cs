namespace Scientific_Calculator.Models.Strategies.CommonArithmeticStrategies
{
    using Scientific_Calculator.Attributes;

    [Component]
    public class ModOperationStrategy
    {
        public double Calculate(double first, double second)
        {
            return first % second;
        }
    }
}
