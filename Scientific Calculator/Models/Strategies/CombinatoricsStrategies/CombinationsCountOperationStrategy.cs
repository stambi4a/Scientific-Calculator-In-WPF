namespace Scientific_Calculator.Models.Strategies.CombinatoricsStrategies
{
    using System.Numerics;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Utilities;

    [Component]
    public class CombinationsCountOperationStrategy
    {
        public BigInteger Calculate(double rank, double subset)
        {
            var bIRank = new BigInteger(rank);
            var bISubset = new BigInteger(subset);
            return HelperMethods.ProductOfNumbersInInterval(bIRank - bISubset + 1, bIRank) / HelperMethods.Factorial(bISubset);
        }
    }
}
