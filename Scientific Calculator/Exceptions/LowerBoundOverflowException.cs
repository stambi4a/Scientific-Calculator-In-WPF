namespace Scientific_Calculator.Exceptions
{
    using System;

    public class LowerBoundOverflowException : ArgumentException
    {
        private const string ExceptionMessage = "Result is smaller than chosen numeric type lower limit!";

        public LowerBoundOverflowException()
            : base(ExceptionMessage)
        {
        }
    }
}
