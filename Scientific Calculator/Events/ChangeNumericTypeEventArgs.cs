namespace Scientific_Calculator.Events
{
    using System;

    public class ChangeNumericTypeEventArgs : EventArgs
    {
        public ChangeNumericTypeEventArgs(string fieldValue)
        {
            this.FieldValue = fieldValue;
        }

        public string FieldValue { get; }
    }
}
