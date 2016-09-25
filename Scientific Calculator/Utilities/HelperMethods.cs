namespace Scientific_Calculator.Utilities
{
    using System;
    using System.Numerics;

    internal class HelperMethods
    {
        private const int FirstNumberToCheck = 3;

        internal static BigInteger Factorial(BigInteger rank)
        {
            BigInteger factorial = 1;
            for (var i = 1; i <= rank; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        internal static BigInteger ProductOfNumbersInInterval(BigInteger start, BigInteger end)
        {
            BigInteger product = 1;
            for (var i = start; i <= end; i++)
            {
                product *= i;
            }

            return product;
        }

        internal static BigInteger DoubleFactorial(BigInteger rank)
        {
            BigInteger product = 1;
            for (var i = rank; i > 0; i -= 2)
            {
                product *= i;
            }

            return product;
        }

        internal static bool CheckIfPrime(double primeCandidate)
        {
            var divisorLimit = Math.Sqrt(primeCandidate);
            var firstDivisor = FirstNumberToCheck;
            for (var i = firstDivisor; i <= divisorLimit; i += 2)
            {
                if (primeCandidate % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
