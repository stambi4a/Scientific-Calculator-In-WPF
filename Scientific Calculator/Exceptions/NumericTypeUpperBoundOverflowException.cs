namespace Scientific_Calculator.Exceptions
{
    using System;

    public class NumericTypeUpperBoundOverflowException : ArgumentException
    {
        private const string ExceptionMessage = "Result is bigger than chosen numeric type upper limit!";

        public NumericTypeUpperBoundOverflowException()
            : base(ExceptionMessage)
        {
        }
    }
}