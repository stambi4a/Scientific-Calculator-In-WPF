namespace Scientific_Calculator.Exceptions
{
    using System;

    public class UnimplementedOperationException : InvalidOperationException
    {
        private const string ExceptionMessage = "This operation is not implemented";

        public UnimplementedOperationException()
            : base(ExceptionMessage)
        {
        }
    }
}