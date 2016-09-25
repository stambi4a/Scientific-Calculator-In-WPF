namespace Scientific_Calculator.Interfaces
{
    using System;

    using Scientific_Calculator.Events;

    public interface ICalculationHandler
    {
        event ChangeTextEventHandler InputChanged;
        event ChangeTextEventHandler OutputChanged;
        event ChangeTextEventHandler RepresentationNotationChanged;
        event ChangeTextEventHandler OperationNotationChanged;
        event ChangeTextEventHandler InversionStateChanged;
        event ChangeTextEventHandler FractionModeChanged;
        event ChangeTextEventHandler AngleUnitChanged;
        event ChangeTextEventHandler SwitchModeChanged;
        event ChangeTextEventHandler PrecisionChanged;

        //event EventHandler ReceiveNonEmptyResult;

        void Execute(string input);

        void Clear();

        void CalculationHandlerExceptionHandlingMethod(Exception originalException);
    }
}
