namespace Scientific_Calculator.Events
{
    using System;

    public class ChangeTextEventArgs : EventArgs
    {
        public ChangeTextEventArgs(string fieldValue)
        {
            this.FieldValue = fieldValue;
        }

        public string FieldValue { get; }
    }
}
