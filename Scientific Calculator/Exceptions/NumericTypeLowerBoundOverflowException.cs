namespace Scientific_Calculator.Exceptions
{
    using System;

    public class NumericTypeLowerBoundOverflowException : ArgumentException
    {
        private const string ExceptionMessage = "Result is smaller than chosen numeric type lower limit!";

        public NumericTypeLowerBoundOverflowException()
            : base(ExceptionMessage)
        {
        }
    }
}
