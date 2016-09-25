namespace Scientific_Calculator.Interfaces
{
    public interface IOperationsContainer
    {
        ICalculationHandler CalculationHandler { get; }

        void Execute(string input);

        void RestoreResultFromMemory();
    }
}