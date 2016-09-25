namespace Scientific_Calculator.Models.Strategies.CombinatoricsStrategies
{
    using System.Numerics;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Utilities;

    [Component]
    public class DoubleFactorialOperationStrategy
    {
        public BigInteger Calculate(double rank)
        {
            return HelperMethods.DoubleFactorial(new BigInteger(rank));
        }
    }
}
