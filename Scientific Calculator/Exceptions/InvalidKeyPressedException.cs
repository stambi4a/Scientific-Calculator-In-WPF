namespace Scientific_Calculator.Exceptions
{
    using System;

    public class InvalidKeyPressedException : InvalidOperationException
    {
        private const string ExceptionMessage = "Pressed key is invalid!";

        public InvalidKeyPressedException()
            : base(ExceptionMessage)
        {
        }
    }
}
