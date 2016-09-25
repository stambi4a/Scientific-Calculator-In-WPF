namespace Scientific_Calculator.Exceptions
{
    using System;

    public class UnimplementedTypeException : ArgumentException
    {
        private const string ExceptionMessage = "{0} is not implemented type!";

        public UnimplementedTypeException()
            : base(ExceptionMessage)
        {
        }
    }
}
