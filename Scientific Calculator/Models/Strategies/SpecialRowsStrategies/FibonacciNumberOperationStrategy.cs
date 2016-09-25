namespace Scientific_Calculator.Models.Strategies.SpecialRowsStrategies
{
    using System.Numerics;

    using Scientific_Calculator.Attributes;

    [Component]
    public class FibonacciNumberOperationStrategy
    {
        private const int FirstFibonacci = 1;
        private const int SecondFibonacci = 1;

        public BigInteger Calculate(double index)
        {
            if (index == 1)
            {
                return FirstFibonacci;
            }

            if (index == 2)
            {
                return SecondFibonacci;
            }

            var currentIndex = 3;
            BigInteger firstFibonacciNumber = FirstFibonacci;
            BigInteger secondFibonacciNumber = SecondFibonacci;
            while (currentIndex <= index)
            {
                secondFibonacciNumber += firstFibonacciNumber;
                firstFibonacciNumber = secondFibonacciNumber - firstFibonacciNumber;
                currentIndex++;
            }

            return secondFibonacciNumber;
        }
    }
}
