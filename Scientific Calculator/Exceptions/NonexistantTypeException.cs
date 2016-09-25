namespace Scientific_Calculator.Exceptions
{
    using System;

    public class NonExistantTypeException : ArgumentException
    {
        private const string ExceptionMessage = "No such type is found in the annotated types database!";
        public NonExistantTypeException(string message)
            : base(message)
        {
        }

        public NonExistantTypeException()
            : this(ExceptionMessage)
        {
        }
    }
}
