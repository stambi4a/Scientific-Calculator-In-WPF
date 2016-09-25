namespace Scientific_Calculator.Utilities
{
    using System;

    public sealed class Constants
    {
        public const int StoredDataCapacity = 1 << 7;
        public const int BitsInAByte = 1 << 3;

        public const double Pi = Math.PI;
        public const double E = Math.E;

        public const string ConvertFromMethodName = "ConvertInputFromBase";
        public const string ConvertToMethodName = "ConvertInputToBase";
        public const string CalculateMethodName = "Calculate";
        public const string ToStringMethodName = "ToString";

        public const string ConvertFromBasePrefix = "ConvertInputFrom";
        public const string BaseSuffix = "Base";
        public const string ConvertToBasePrefix = "ConvertResultTo";
        public const string ConvertorSuffix = "BaseConvertor";

        public const string DecimalBaseName = "Decimal";
        public const string HexBaseName = "Hex";
        public const string OctBaseName = "Oct";
        public const string BinBaseName = "Bin";

        public const string NumericNamespace = "System.";

        public const string UnsignedByteName = "Byte";
        public const string SignedByteName = "SByte";
        public const string UnsignedInt16Name = "UInt16";
        public const string SignedInt16Name = "Int16";
        public const string UnsignedInt32Name = "UInt32";
        public const string SignedInt32Name = "Int32";
        public const string UnsignedInt64Name = "UInt64";
        public const string SignedInt64Name = "Int64";

        public const string AddPrefix = "Add";
        public const string SubtractPrefix = "Subtract";
        public const string MultiplyPrefix = "Multiply";
        public const string DividePrefix = "Divide";
        public const string ModPrefix = "Mod";
        public const string IncrementPrefix = "Increment";
        public const string DecrementPrefix = "Decrement";
        public const string ChangeSignPrefix = "ChangeSign";
        public const string BitwiseAndPrefix = "BitwiseAnd";
        public const string BitwiseOrPrefix = "BitwiseOr";
        public const string BitwiseNotPrefix = "BitwiseNot";
        public const string BitwiseXorPrefix = "BitwiseXor";
        public const string BitwiseLeftShiftPrefix = "BitwiseLeftShift";
        public const string BitwiseRightShiftPrefix = "BitwiseRightShift";
        public const string BitwiseRotationLeftPrefix = "BitwiseRotationLeft";
        public const string BitwiseRotationRightPrefix = "BitwiseRotationRight";

        public const string PiConstantPrefix = "PiConstant";
        public const string EulerConstantPrefix = "EulerConstant";
        public const string ChooseConstantPrefix = "ChooseConstant";

        public const string SinePrefix = "Sine";
        public const string CosinePrefix = "Cosine";
        public const string TangentPrefix = "Tangent";
        public const string CotangentPrefix = "Cotangent";
        public const string SineHyperbolicPrefix = "SineHyperbolic";
        public const string CosineHyperbolicPrefix = "CosineHyperbolic";
        public const string TangentHyperbolicPrefix = "TangentHyperbolic";
        public const string CotangentHyperbolicPrefix = "CotangentHyperbolic";
        public const string ArcusSinePrefix = "ArcusSine";
        public const string ArcusCosinePrefix = "ArcusCosine";
        public const string ArcusTangentPrefix = "ArcusTangent";
        public const string ArcusCotangentPrefix = "ArcusCotangent";
        public const string ArcusSineHyperbolicPrefix = "ArcusSineHyperbolic";
        public const string ArcusCosineHyperbolicPrefix = "ArcusCosineHyperbolic";
        public const string ArcusTangentHyperbolicPrefix = "ArcusTangentHyperbolic";
        public const string ArcusCotangentHyperbolicPrefix = "ArcusCotangentHyperbolic";
        public const string PowerOfTwoPrefix = "PowerOfTwo";
        public const string PowerOfTenPrefix = "PowerOfTen";
        public const string MultiplierWithPowerOfTenPrefix = "MultiplierWithPowerOfTen";
        public const string PowerOfEulerNumberPrefix = "PowerOfEulerNumber";

        public const string MemoryClearPrefix = "MemoryClear";
        public const string MemoryRestorePrefix = "MemoryRestore";
        public const string AddToMemoryPrefix = "MemoryAddPrefix";
        public const string SubtractFromMemoryPrefix = "MemorySubtract";
        public const string ClearPrefix = "Clear";
        public const string ClearLastPrefix = "ClearLast";
        public const string HistoryPrefix = "History";

        public const string GreatestCommonDivisorPrefix = "GreatestCommonDivisor";
        public const string LeastCommonMultiplierPrefix = "LeastCommonMultiplier";
        public const string PermutationsPrefix = "PermutationsCount";
        public const string DoubleFactorialPrefix = "DoubleFactorial";
        public const string PermutationsSubsetPrefix = "PermutationsSubsetCount";
        public const string CombinationsPrefix = "CombinationsCount";
        public const string FibonacciNumberPrefix = "FibonacciNumber";
        public const string PrimeNumberPrefix = "PrimeNumber";
        public const string RandomNumberPrefix = "RandomNumber";
        public const string AbsoluteValuePrefix = "AbsoluteValue";
        public const string RoundedValuePrefix = "RoundedValue";
        public const string TruncatedValuePrefix = "TruncatedValue";
        public const string SignPrefix = "SignValue";

        public const string SecondPowerOfXPrefix = "SecondPowerOfX";
        public const string CubicPowerOfXPrefix = "CubicPowerOfX";
        public const string YPowerOfXPrefix = "YPowerOfX";
        public const string SquareRootPrefix = "SquareRoot";
        public const string CubicRootPrefix = "CubicRoot";
        public const string YRootPrefix = "YRoot";
        public const string LogarithmAtBase2Prefix = "LogarithmAtBase2";
        public const string LogarithmAtBase10Prefix = "LogarithmAtBase10";
        public const string NaturalLogarithmPrefix = "NaturalLogarithm";
        public const string LogarithmAtBaseXPrefix = "LogarithmAtBaseX";

        public const string LeftBracket = "(";
        public const string RightBracket = ")";

        public const string DeleteSign = "⬅";

        public const string EqualSign = "=";
        public const string AddSign = "+";
        public const string SubtractSign = "–";
        public const string MultiplySign = "*";
        public const string DivideSign = "/";
        public const string ModSign = "%";
        public const string IncrementSign = "++";
        public const string DecrementSign = "--";
        public const string ChangeSignSign = "±";
        public const string BitwiseAndSign = "&";
        public const string BitwiseOrSign = "|";
        public const string BitwiseNotSign = "~";
        public const string BitwiseXorSign = "^";
        public const string BitwiseLeftShiftSign = "<<";
        public const string BitwiseRightShiftSign = ">>";
        public const string BitwiseRotationLeftSign = "RoL";
        public const string BitwiseRotationRightSign = "RoR";

        public const string PiConstantSign = "π";
        public const string EulerConstantSign = "e";
        public const string ChooseConstantSign = "CST";

        public const string SineSign= "sin";
        public const string CosineSign = "cos";
        public const string TangentSign = "tg";
        public const string CotangentSign = "cotg";
        public const string SineHyperbolicSign = "sinh";
        public const string CosineHyperbolicSign = "cosh";
        public const string TangentHyperbolicSign = "tgh";
        public const string CotangentHyperbolicSign = "ctgh";
        public const string ArcusSineSign = "arcsin";
        public const string ArcusCosineSign = "arccos";
        public const string ArcusTangentSign = "arctg";
        public const string ArcusCotangentSign = "arccotg";
        public const string ArcusSineHyperbolicSign = "arcsinh";
        public const string ArcusCosineHyperbolicSign = "arccosh";
        public const string ArcusTangentHyperbolicSign = "arctgh";
        public const string ArcusCotangentHyperbolicSign = "arcctgh";
        public const string PowerOfTwoSign = "2x";
        public const string PowerOfTenSign = "10x";
        public const string MultiplierWithPowerOfTenSign = "EXP";
        public const string PowerOfEulerNumberSign = "ex";
        public const string SecondPowerOfXSign = "x2";
        public const string CubicPowerOfXSign= "x3";
        public const string YPowerOfXSign = "xy";
        public const string SquareRootSign = "v";
        public const string CubicRootSign = "3v";
        public const string YRootSign = "yv";
        public const string LogarithmAtBase2Sign = "log2";
        public const string LogarithmAtBase10Sign = "log10";
        public const string NaturalLogarithmSign = "ln";
        public const string LogarithmAtBaseXSign = "logxy";

        public const string MemoryClearSign = "MC";
        public const string MemoryRestoreSign = "MR";
        public const string AddToMemorySign = "M+";
        public const string SubtractFromMemorySign = "M-";
        public const string ClearSign = "C";
        public const string ClearLastSign = "CE";
        public const string HistorySign = "H";

        public const string ChangeFractionModeSign = "ab/c";
        public const string ChangeAngleUnitSign = "DRG";
        public const string ChangeInversionStateSign = "INV";
        public const string ChangeOperationNotationSign = "PRE";
        public const string ChangeRepresentationNotationSign = "FES";
        public const string ChangePrecisionSign = "Prec";
        public const string ChangeSwitchModeSign = "OnOff";

        public const string GreatestCommonDivisorSign = "GCD";
        public const string LeastCommonMultiplierSign = "LCM";
        public const string PermutationsSign = "n!";
        public const string DoubleFactorialSign = "n!!";
        public const string PermutationsSubsetSign = "nPr";
        public const string CombinationsSign = "nCr";
        public const string FibonacciNumberSign = "Fib";
        public const string PrimeNumberSign = "Pri";
        public const string RandomNumberSign = "RAN";
        public const string AbsoluteValueSign = "ABS";
        public const string RoundedValueSign = "RND";
        public const string TruncatedValueSign = "TRU";
        public const string SignSign = "SGN";

        public const string DigitZero = "0";
        public const string DigitOne = "1";
        public const string DigitTwo = "2";
        public const string DigitThree = "3";
        public const string DigitFour = "4";
        public const string DigitFive = "5";
        public const string DigitSix = "6";
        public const string DigitSeven = "7";
        public const string DigitEight = "8";
        public const string DigitNine = "9";
        public const string DigitTen = "A";
        public const string DigitEleven = "B";
        public const string DigitTwelve = "C";
        public const string DigitThirteen = "D";
        public const string DigitFourteen = "E";
        public const string DigitFifteen = "F";
        public const string DigitZeroZero = "00";
        public const string DigitZeroOne = "01";
        public const string DigitOneZero = "10";
        public const string DigitOneOne = "11";
        public const string DecimalPoint = ".";
    }
}
