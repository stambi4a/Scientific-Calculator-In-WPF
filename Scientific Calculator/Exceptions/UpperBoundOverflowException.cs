namespace Scientific_Calculator.Exceptions
{
    using System;

    public class UpperBoundOverflowException : ArgumentException
    {
        private const string ExceptionMessage = "Result is bigger than chosen numeric type upper limit!";

        public UpperBoundOverflowException()
            : base(ExceptionMessage)
        {
        }
    }
}