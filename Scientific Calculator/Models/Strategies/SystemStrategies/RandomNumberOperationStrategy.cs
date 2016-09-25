namespace Scientific_Calculator.Models.Strategies.SystemStrategies
{
    using System;

    using Attributes;

    [Component]
    public class RandomNumberOperationStrategy
    {
        public double Calculate(double seed)
        {
            var randomGenerator = new Random();
            var result = randomGenerator.Next((int)seed);

            return result;
        }
    }
}
