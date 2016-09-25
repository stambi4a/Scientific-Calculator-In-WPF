namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using Scientific_Calculator.Attributes;

    [Component]
    public class ReciprocalOperationStrategy
    {
        public double Calculate(double first)
        {
            return 1 / first;
        }
    }
}