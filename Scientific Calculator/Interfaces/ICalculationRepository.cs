namespace Scientific_Calculator.Interfaces
{
    using System.Collections.Generic;

    public interface ICalculationRepository
    {
        IList<string> StoredCalculationInput { get; }

        IList<string> StoredCalculationResults { get; }

        IList<string> StoredCalculationBitViews { get; }
    }
}
