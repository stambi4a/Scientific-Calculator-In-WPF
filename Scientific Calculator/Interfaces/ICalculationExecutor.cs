namespace Scientific_Calculator.Interfaces
{
    using System.Threading;

    public interface ICalculationExecutor
    {
        object[] ProcessInput(string input);

        void Clear();

        void ClearAll();
    }
}
