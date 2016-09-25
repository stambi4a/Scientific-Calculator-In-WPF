namespace Scientific_Calculator.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Interfaces;

    [Core]
    public class RepositoryHandler : IRepositoryHandler
    {
        private readonly ICalculationRepository calculationRepository;

        public RepositoryHandler(ICalculationRepository calculationRepository)
        {
            this.calculationRepository = calculationRepository;
        }

        private void AddInput(string input)
        {
            this.calculationRepository.StoredCalculationInput.Add(input);
        }

        private void AddResult(string result)
        {
            this.calculationRepository.StoredCalculationResults.Add(result);
        }

        private void AddBitView(string bitView)
        {
            this.calculationRepository.StoredCalculationBitViews.Add(bitView);
        }

        public void AddData(string input, string result, string bitView)
        {
            this.AddInput(input);
            this.AddResult(result);
            this.AddBitView(bitView);
        }

        public IReadOnlyList<string>[] GetLastCountData(int count)
        {
            var length = this.calculationRepository.StoredCalculationInput.Count;
            if (count > length)
            {
                count = length;
            }

            var inputList = this.calculationRepository.StoredCalculationInput.Skip(length - count).ToList();
            var resultsList = this.calculationRepository.StoredCalculationResults.Skip(length - count).ToList();
            var bitViewList = this.calculationRepository.StoredCalculationBitViews.Skip(length - count).ToList();
            IReadOnlyList<string>[] data = { inputList, resultsList, bitViewList };

            return data;
        }

        public void DeleteData(int index)
        {
            this.calculationRepository.StoredCalculationInput.RemoveAt(index);
            this.calculationRepository.StoredCalculationResults.RemoveAt(index);
            this.calculationRepository.StoredCalculationBitViews.RemoveAt(index);
        }

        public void SaveResultsToList(int count)
        {
            //var dialog = new SaveFileDialog
            //                 {
            //                     InitialDirectory = @"e:\",
            //                     Filter = Resources.CalculationHandler_SaveResultsToList,
            //                     FilterIndex = 1
            //                 };
            //if (dialog.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            //var fileName = dialog.FileName;
            //using (var myStream = new StreamWriter(fileName, false))
            //{
            //    var length = this.calculationRepository.StoredCalculationInput.Count;
            //    var builder = new StringBuilder();
            //    for (var i = 0; i < length; i++)
            //    {
            //        builder
            //            .Append($"{i + 1} line:")
            //            .Append("Input = ")
            //            .Append(this.calculationRepository.StoredCalculationInput[i])
            //            .Append("; Output = ")
            //            .Append(this.calculationRepository.StoredCalculationResults[i])
            //            .Append("; BitView = ")
            //            .AppendLine(this.calculationRepository.StoredCalculationBitViews[i]);
            //    }

            //    myStream.Write(builder.ToString());
            //}
        }
    }
}
