namespace Scientific_Calculator.Exceptions
{
    using System;

    public class ZeroDivisionException : DivideByZeroException
    {
        private const string ExceptionMessage = "Division of zero is indefinite arithmetic operation.";

        public ZeroDivisionException()
            : base(ExceptionMessage)
        {
        }
    }
}
