namespace Scientific_Calculator.Models.Strategies.SpecialRowsStrategies
{
    using System;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Utilities;

    [Component]
    public class PrimeNumberOperationStrategy
    {
        private const int FirstPrimeNumber = 2;
        public double Calculate(double index)
        {
            if (index == 1)
            {
                return FirstPrimeNumber;
            }

            var currentIndex = 1;
            var currentNumber = 1;
            while (currentIndex < index)
            {
                currentNumber += 2;
                if (HelperMethods.CheckIfPrime(currentNumber))
                {
                    currentIndex++;
                }
            }

            return currentNumber;
        }
    }
}
