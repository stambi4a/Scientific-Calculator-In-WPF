namespace Scientific_Calculator.Models.Strategies.CommonArithmeticStrategies
{
    using Scientific_Calculator.Attributes;

    [Component]
    public class ChangeSignOperationStrategy
    {
        public double Calculate(double first)
        {
            return -first;
        }
    }
}
