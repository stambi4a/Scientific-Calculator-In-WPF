namespace Scientific_Calculator.Exceptions
{
    using System;

    public class UnmappableTypeException : InvalidOperationException
    {
        private const string ExceptionMessage =
            "Cannot map dependency of type {0}. It is not annotated with [Component] ";
        public UnmappableTypeException(string typeName)
            : base(string.Format(ExceptionMessage, typeName))
        {
        }
    }
}
