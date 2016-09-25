namespace Scientific_Calculator.Interfaces
{
    using System.Collections.Generic;

    public interface IRepositoryHandler
    {
        void AddData(string input, string result, string bitView);

        IReadOnlyList<string>[] GetLastCountData(int count);

        void DeleteData(int index);

        void SaveResultsToList(int count);
    }
}