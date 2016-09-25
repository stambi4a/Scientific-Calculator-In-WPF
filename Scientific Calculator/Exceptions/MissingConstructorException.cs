namespace Scientific_Calculator.Exceptions
{
    using System;

    public class MissingConstructorException : ArgumentException
    {
        private const string ExceptionMessage = "Constructor with given parameters is not found on the type {0}";
        public MissingConstructorException(string message, string typeName)
            : base(string.Format(message, typeName))
        {
        }

        public MissingConstructorException(string typeName)
            : this(ExceptionMessage, typeName)
        {
        }
    }
}
