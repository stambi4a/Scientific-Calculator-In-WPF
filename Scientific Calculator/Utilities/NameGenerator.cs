namespace Scientific_Calculator.Utilities
{
    public class NameGenerator
    {
        public static string GenerateStrategyName(string nameParameter)
        {
            var strategyName = nameParameter + "OperationStrategy";

            return strategyName;
        }

        public static string GenerateConvertorName(string nameParameter)
        {
            var convertorName = nameParameter + Constants.ConvertorSuffix;

            return convertorName;
        }

        public static string GenerateMethodName(string prefix, string modifier, string suffix)
        {
            return prefix + modifier + suffix;
        }
    }
}
