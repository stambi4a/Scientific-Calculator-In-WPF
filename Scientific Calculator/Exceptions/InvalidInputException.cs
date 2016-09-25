namespace Scientific_Calculator.Exceptions
{
    using System;

    public class InvalidInputException : InvalidOperationException
    {
        private const string ExceptionMessage = "Input is invalid";

        public InvalidInputException()
            : base(ExceptionMessage)
        {
        }
    }
}
