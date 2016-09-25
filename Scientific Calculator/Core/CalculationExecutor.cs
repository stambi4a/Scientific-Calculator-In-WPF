namespace Scientific_Calculator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Enums;
    using Scientific_Calculator.Exceptions;
    using Scientific_Calculator.Interfaces;
    using Scientific_Calculator.Utilities;

    [Core]
    public class CalculationExecutor : ICalculationExecutor
    {
        private const int ReturnDataCount = 10;
        private readonly IDictionary<string, string> infixOperators = new Dictionary<string, string>
                                                                                  {
            {Constants.AddSign, Constants.AddPrefix },
            {Constants.SubtractSign, Constants.SubtractPrefix },
            {Constants.MultiplySign, Constants.MultiplyPrefix },
            {Constants.DivideSign, Constants.DividePrefix },
            {Constants.ModSign, Constants.ModPrefix }
                                                                                  };

        private readonly IDictionary<string, string> postfixOperators = new Dictionary<string, string>()
                                                                                       {
            { Constants.ChangeSignSign, Constants.ChangeSignPrefix },            
                                                                                       };

        private readonly IDictionary<string, string> prefixOperators = new Dictionary<string, string>
                                                               {
            {Constants.BitwiseNotSign, Constants.BitwiseNotPrefix }
                                                               };

        private readonly ISet<string> trigonometricOperations = new HashSet<string>()
                                                                    {
                                                                        Constants.SineSign,
                                                                        Constants.CosineSign,
                                                                        Constants.TangentSign,
                                                                        Constants.CotangentSign,
                                                                        Constants.SineHyperbolicSign,
                                                                        Constants.CosineHyperbolicSign,
                                                                        Constants.TangentHyperbolicSign,
                                                                        Constants.CotangentHyperbolicSign,
                                                                        Constants.ArcusSineSign,
                                                                        Constants.ArcusCosineSign,
                                                                        Constants.ArcusTangentSign,
                                                                        Constants.ArcusCotangentSign,
                                                                        Constants.ArcusSineHyperbolicSign,
                                                                        Constants.ArcusCosineHyperbolicSign,
                                                                        Constants.ArcusTangentHyperbolicSign,
                                                                        Constants.ArcusCotangentHyperbolicSign
                                                                    };
        private readonly IDictionary<string, string> prefixOrPostOperations = new Dictionary<string, string>
                                                               {
            {Constants.SineSign, Constants.SinePrefix },
            {Constants.CosineSign, Constants.CosinePrefix },
            {Constants.TangentSign, Constants.TangentPrefix },
            {Constants.CotangentSign, Constants.CotangentPrefix },
            {Constants.SineHyperbolicSign, Constants.SineHyperbolicPrefix },
            {Constants.CosineHyperbolicSign, Constants.CosineHyperbolicPrefix },
            {Constants.TangentHyperbolicSign, Constants.TangentHyperbolicPrefix },
            {Constants.CotangentHyperbolicSign, Constants.CotangentHyperbolicPrefix },
            {Constants.ArcusSineSign, Constants.ArcusSinePrefix },
            {Constants.ArcusCosineSign, Constants.ArcusCosinePrefix },
            {Constants.ArcusTangentSign, Constants.ArcusTangentPrefix },
            {Constants.ArcusCotangentSign, Constants.ArcusCotangentPrefix },
            {Constants.ArcusSineHyperbolicSign, Constants.ArcusSineHyperbolicPrefix },
            {Constants.ArcusCosineHyperbolicSign, Constants.ArcusCosineHyperbolicPrefix },
            {Constants.ArcusTangentHyperbolicSign, Constants.ArcusTangentHyperbolicPrefix },
            {Constants.ArcusCotangentHyperbolicSign, Constants.ArcusCotangentHyperbolicPrefix },
            {Constants.SecondPowerOfXSign, Constants.SecondPowerOfXPrefix},
            {Constants.CubicPowerOfXSign, Constants.CubicPowerOfXPrefix},
            {Constants.SquareRootSign, Constants.SquareRootPrefix},
            {Constants.CubicRootSign, Constants.CubicRootPrefix},
            {Constants.LogarithmAtBase2Sign, Constants.LogarithmAtBase2Prefix},
            {Constants.LogarithmAtBase10Sign, Constants.LogarithmAtBase10Prefix},
            {Constants.NaturalLogarithmSign, Constants.NaturalLogarithmPrefix},
            {Constants.PowerOfTwoSign, Constants.PowerOfTwoPrefix},
            {Constants.PowerOfTenSign, Constants.PowerOfTenPrefix},
            {Constants.PowerOfEulerNumberSign, Constants.PowerOfEulerNumberPrefix},
            {Constants.PermutationsSign, Constants.PermutationsPrefix},
            {Constants.DoubleFactorialSign, Constants.DoubleFactorialPrefix},
            {Constants.FibonacciNumberSign, Constants.FibonacciNumberPrefix},
            {Constants.PrimeNumberSign, Constants.PrimeNumberPrefix},
            {Constants.RandomNumberSign, Constants.RandomNumberPrefix},
            {Constants.AbsoluteValueSign, Constants.AbsoluteValuePrefix},
            {Constants.SignSign, Constants.SignPrefix},
            {Constants.RoundedValueSign, Constants.RoundedValuePrefix},
            {Constants.TruncatedValueSign, Constants.TruncatedValuePrefix}
                                                               };

        private readonly IDictionary<string, string> prefixAndPostOperations = new Dictionary<string, string>
                                                               {
            { Constants.MultiplierWithPowerOfTenSign, Constants.MultiplierWithPowerOfTenPrefix },
            { Constants.GreatestCommonDivisorSign, Constants.GreatestCommonDivisorPrefix },
            { Constants.LeastCommonMultiplierSign, Constants.LeastCommonMultiplierPrefix },
            { Constants.PermutationsSubsetSign, Constants.PermutationsSubsetPrefix },
            { Constants.CombinationsSign, Constants.CombinationsPrefix },
            { Constants.YRootSign, Constants.YRootPrefix},
            { Constants.YPowerOfXSign, Constants.YPowerOfXPrefix},
            { Constants.LogarithmAtBaseXSign, Constants.LogarithmAtBaseXPrefix }
                                                               };

        private readonly IDictionary<string, int> operatorsPrecedence = new Dictionary<string, int>()
                                                                                   {
            { Constants.YRootSign, 8 },
            { Constants.YPowerOfXSign, 8 },
            { Constants.LogarithmAtBaseXSign, 8},
            { Constants.MultiplierWithPowerOfTenSign, 8 },
            { Constants.GreatestCommonDivisorSign, 8 },
            { Constants.LeastCommonMultiplierSign, 8 },
            { Constants.PermutationsSubsetSign, 8 },
            { Constants.CombinationsSign, 8 },

            { Constants.BitwiseNotSign, 7 },
            { Constants.PermutationsSign, 7 },
            { Constants.DoubleFactorialSign, 7 },
            { Constants.FibonacciNumberSign, 7 },
            { Constants.PrimeNumberSign, 7 },
            { Constants.RandomNumberSign, 7 },
            { Constants.AbsoluteValueSign, 7 },
            { Constants.SignSign, 7 },
            { Constants.RoundedValueSign, 7 },
            { Constants.TruncatedValueSign, 7 },
            { Constants.PowerOfTwoSign, 7 },
            { Constants.PowerOfTenSign, 7 },
            { Constants.PowerOfEulerNumberSign, 7 },
            { Constants.LogarithmAtBase2Sign, 7 },
            { Constants.LogarithmAtBase10Sign, 7 },
            { Constants.NaturalLogarithmSign, 7 },
            { Constants.SquareRootSign, 7 },
            { Constants.CubicRootSign, 7 },
            { Constants.SecondPowerOfXSign, 7 },
            { Constants.CubicPowerOfXSign, 7 },
            { Constants.SineSign, 7 },
            { Constants.CosineSign, 7 },
            { Constants.TangentSign, 7 },
            { Constants.CotangentSign, 7 },
            { Constants.SineHyperbolicSign, 7 },
            { Constants.CosineHyperbolicSign, 7 },
            { Constants.TangentHyperbolicSign, 7 },
            { Constants.CotangentHyperbolicSign, 7 },
            { Constants.ArcusSineSign, 7 },
            { Constants.ArcusCosineSign, 7 },
            { Constants.ArcusTangentSign, 7 },
            { Constants.ArcusCotangentSign, 7 },
            { Constants.ArcusSineHyperbolicSign, 7 },
            { Constants.ArcusCosineHyperbolicSign, 7 },
            { Constants.ArcusTangentHyperbolicSign, 7 },
            { Constants.ArcusCotangentHyperbolicSign, 7 },

            { Constants.IncrementSign, 6 },
            { Constants.DecrementSign, 6 },
            { Constants.ChangeSignSign, 6 },

            { Constants.MultiplySign, 5 },
            { Constants.DivideSign, 5 },
            { Constants.ModSign, 5 },

            { Constants.AddSign, 4 },
            { Constants.SubtractSign, 4 },

            { Constants.BitwiseLeftShiftSign, 3 },
            { Constants.BitwiseRightShiftSign, 3 },
            { Constants.BitwiseRotationLeftSign, 3 },
            { Constants.BitwiseRotationRightSign, 3 },

            { Constants.BitwiseAndSign, 2 },

            { Constants.BitwiseXorSign, 1 },

            { Constants.BitwiseOrSign, 0 },
                                                                                   };

        private readonly ISet<string> digits = new HashSet<string>()
                                                          {
                                                              Constants.DigitZero, 
                                                              Constants.DigitOne,
                                                              Constants.DigitTwo,
                                                              Constants.DigitThree,
                                                              Constants.DigitFour,
                                                              Constants.DigitFive,
                                                              Constants.DigitSix,
                                                              Constants.DigitSeven,
                                                              Constants.DigitEight,
                                                              Constants.DigitNine,
                                                              Constants.DigitTen,
                                                              Constants.DigitEleven,
                                                              Constants.DigitTwelve,
                                                              Constants.DigitThirteen,
                                                              Constants.DigitFourteen,
                                                              Constants.DigitFifteen,
                                                              Constants.DigitZeroZero,
                                                              Constants.DigitZeroOne,
                                                              Constants.DigitOneZero,
                                                              Constants.DigitOneOne,
                                                              Constants.DecimalPoint,
                                                              Constants.PiConstantSign,
                                                              Constants.EulerConstantSign
                                                          };

        private readonly IDictionary<string, double> constants = new Dictionary<string, double>()
                                                   {
            { Constants.PiConstantSign, Math.PI },
            { Constants.EulerConstantSign, Math.E }
                                                   };

        private readonly IDictionary<string, string> specialOperations = new Dictionary<string, string>
                                                              {
            { Constants.ClearSign, Constants.ClearPrefix },
            { Constants.ClearLastSign, Constants.ClearLastPrefix },
            { Constants.AddToMemorySign, Constants.AddToMemoryPrefix },
            { Constants.SubtractFromMemorySign, Constants.SubtractFromMemoryPrefix },
            { Constants.MemoryRestoreSign, Constants.MemoryRestorePrefix },
            { Constants.MemoryClearSign, Constants.MemoryClearPrefix }
                                                              };

        private readonly IDictionary<string, Type> switchOperations = new Dictionary<string, Type>
                                                              {
            { Constants.ChangeRepresentationNotationSign, typeof(RepresentationNotation) },
            { Constants.ChangeOperationNotationSign, typeof(OperationNotation) },
            { Constants.ChangeAngleUnitSign, typeof(AngleUnit) },
            { Constants.ChangeFractionModeSign, typeof(FractionMode) },
            { Constants.ChangeInversionStateSign, typeof(InversionState) },
            { Constants.ChangePrecisionSign, typeof(Precision) },
            { Constants.ChangeSwitchModeSign, typeof(SwitchMode) },
                                                              };

        private readonly StringBuilder currentNumberBuilder;
        private readonly IDependencyContainer dependencyContainer;
        private readonly IMethodInvoker methodInvoker;
        private readonly List<List<object>> numbers;
        private readonly List<List<string>> operators;
        private readonly List<object> addedToMemoryResults;
        private readonly List<string> currentIterationInputs;
        private bool decimalPointIsUsed;
        private readonly string decimalPoint = Constants.DecimalPoint;

        private object currentResult;
        private string previousInput;

        private NumberFormatInfo nfi;

        private AngleUnit currentAngleUnit;
        private FractionMode currentFractionMode;
        private InversionState currentInversionState;
        private OperationNotation currentOperationNotation;
        private SwitchMode currentSwitchMode;
        private RepresentationNotation currentRepresentationNotation;
        private Precision currentPrecision;
        private bool isSwitchedOn;

        public CalculationExecutor(IDependencyContainer dependencyContainer, IMethodInvoker methodInvoker)
        {
            this.methodInvoker = methodInvoker;
            this.dependencyContainer = dependencyContainer;
            this.currentNumberBuilder = new StringBuilder();
            this.numbers = new List<List<object>> { new List<object>() };
            this.operators = new List<List<string>> { new List<string>() };
            this.addedToMemoryResults = new List<object>();
            this.currentIterationInputs = new List<string>();
            this.SetDefaults();
            this.currentSwitchMode = SwitchMode.On;
        }

        public int Count => this.numbers.Count;

        public object[] ProcessInput(string input)
        {
            var data = new object[ReturnDataCount];

            if (this.switchOperations.ContainsKey(input))
            {
                var switchOperationType = this.switchOperations[input];
                if (this.currentSwitchMode == SwitchMode.Off && switchOperationType != typeof(SwitchMode))
                {
                    return null;
                }

                data[3] = this.ChangeSwitchOperationFieldValue(switchOperationType);
                if (this.currentSwitchMode == SwitchMode.Off)
                {
                    this.ClearAll();
                    this.SetDefaults();
                }

                return data;
            }

            if (this.currentSwitchMode == SwitchMode.Off)
            {
                return null;
            }

            if (this.specialOperations.ContainsKey(input))
            {
                data = this.PerformSpecialOperation(this.specialOperations[input]);

                return data;
            }

            if (input == this.decimalPoint)
            {
                if (this.decimalPointIsUsed)
                {
                    return null;
                }

                this.decimalPointIsUsed = true;
            }

            if (this.constants.ContainsKey(input))
            {
                if (this.currentNumberBuilder.Length > 0 && this.currentNumberBuilder.ToString() != Constants.DigitZero)
                {
                    return null;
                }
            }

            if (this.digits.Contains(input))
            {
                if (this.previousInput != null 
                    && (this.postfixOperators.ContainsKey(this.previousInput) 
                    || (this.currentOperationNotation == OperationNotation.Post && this.prefixOrPostOperations.ContainsKey(this.previousInput))))
                {
                    return null;
                }

                if (this.operators[this.Count - 1].Count == 0 && this.currentResult != null || (this.previousInput != null && this.constants.ContainsKey(this.previousInput)))
                {
                    this.currentResult = null;
                }

                if (this.numbers[this.Count - 1].Count > 0 && this.operators[this.Count - 1].Count == 0)
                {
                    this.numbers.RemoveAt(this.numbers[this.Count - 1].Count - 1);
                    this.currentResult = null;
                }

                if (this.currentNumberBuilder.Length == 0 && this.currentResult != null)
                {
                    this.numbers[this.Count - 1].Add(this.currentResult);
                    this.currentResult = null;
                }

                var baseValue = this.currentNumberBuilder.ToString();
                if (baseValue.Length > 0)
                {
                    this.currentResult = double.Parse(baseValue, this.nfi);
                }

                this.previousInput = input;
                this.currentIterationInputs.Add(input);

                if (this.constants.ContainsKey(input))
                {
                    this.currentResult = this.constants[input];
                    data[0] = this.currentResult;

                    return data;
                }
                
                this.currentNumberBuilder.Append(input);               
                baseValue = this.currentNumberBuilder.ToString();
                this.currentResult = double.Parse(baseValue, this.nfi);
                data[0] = this.currentResult;              

                return data;
            }

            if (input == Constants.LeftBracket)
            {
                if ((this.numbers[this.Count - 1].Count > 0 || this.currentResult != null)
                    && (this.previousInput == null || !this.infixOperators.ContainsKey(this.previousInput)))
                {
                    return null;
                }

                this.numbers[this.Count - 1].Add(this.currentResult);
                this.currentResult = null;
                this.numbers.Add(new List<object>());
                this.operators.Add(new List<string>());
                this.ProcessInput(Constants.DigitZero);

                return null;
            }

            if (input == Constants.RightBracket)
            {
                if (this.operators.Count == 1)
                {
                    return null;
                }

                this.Clear();

                var operatorGroup = this.operators[this.Count - 1];
                var numbersGroup = this.numbers[this.Count - 1];

                if (this.prefixOperators.ContainsKey(this.previousInput) 
                    || (this.currentOperationNotation == OperationNotation.Pre
                    && this.prefixOrPostOperations.ContainsKey(this.previousInput)))
                {
                    this.operators[this.Count - 1].RemoveAt(this.operators[this.Count - 1].Count - 1);
                    this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                }

                if (this.prefixAndPostOperations.ContainsKey(this.previousInput))
                {
                    this.operators[this.Count - 1].RemoveAt(this.operators[this.Count - 1].Count - 1);
                    this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                    this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                }

                while (operatorGroup.Count > 0)
                {
                    var currentOperator = operatorGroup[operatorGroup.Count - 1];
                    operatorGroup.RemoveAt(operatorGroup.Count - 1);
                    this.currentResult = this.Calculate(currentOperator, numbersGroup);
                }

                this.operators.RemoveAt(this.Count - 1);
                this.numbers.RemoveAt(this.Count - 1);
                data[1] = this.currentResult;

                return data;
            }

            if (input == Constants.DeleteSign)
            {
                if (this.currentNumberBuilder.Length == 0)
                {
                    return null;
                }

                if(this.previousInput == Constants.DecimalPoint)
                {
                    this.decimalPointIsUsed = false;
                }

                this.currentNumberBuilder.Length--;
                this.previousInput = this.currentNumberBuilder.Length > 0
                                         ? this.currentNumberBuilder[this.currentNumberBuilder.Length - 1].ToString(
                                             )
                                         : null;
                this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                var baseValue = this.currentNumberBuilder.ToString();
                if (this.currentNumberBuilder.Length == 0)
                {
                    baseValue = Constants.DigitZero;
                }
                
                this.currentResult = double.Parse(baseValue, this.nfi);
                data[0] = this.currentResult;

                return data;
            }

            if (input == Constants.EqualSign)
            {
                this.Clear();
                while (this.operators.Count > 0)
                {
                    var operatorGroup = this.operators[this.Count - 1];
                    var numbersGroup = this.numbers[this.Count - 1];

                    while (operatorGroup.Count > 0)
                    {
                        var currentOperator = operatorGroup[operatorGroup.Count - 1];
                        operatorGroup.RemoveAt(operatorGroup.Count - 1);
                        this.currentResult = this.Calculate(currentOperator, numbersGroup);
                    }

                    this.operators.RemoveAt(this.Count - 1);
                    this.numbers.RemoveAt(this.Count - 1);
                }

                this.operators.Add(new List<string>());
                this.numbers.Add(new List<object>());
                this.previousInput = input;
                this.currentIterationInputs.Add(input);

                data[1] = this.currentResult;
                //this.ProcessInput(Constants.DigitZero);
                return data;
            }

            if (this.prefixAndPostOperations.ContainsKey(input))
            {
                if (this.digits.Contains(this.previousInput)
                    || this.previousInput == Constants.EqualSign
                    || (this.currentOperationNotation == OperationNotation.Post
                    && this.prefixOrPostOperations.ContainsKey(this.previousInput)))
                {
                    this.operators[this.Count - 1].Add(input);
                    //this.numbers[this.Count - 1].Add(this.currentResult);
                    this.Clear();
                    this.previousInput = input;
                    this.currentIterationInputs.Add(input);

                    return data;
                }

                if (this.infixOperators.ContainsKey(this.previousInput) 
                    || (this.currentOperationNotation == OperationNotation.Pre 
                    && this.prefixOrPostOperations.ContainsKey(this.previousInput))
                    ||this.prefixAndPostOperations.ContainsKey(this.previousInput))
                {
                    this.previousInput = input;
                    this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                    this.currentIterationInputs.Add(input);
                    this.operators[this.Count - 1].RemoveAt(this.operators[this.Count - 1].Count - 1);
                    this.operators[this.Count - 1].Add(input);
                }

                return null;
            }

            if (this.infixOperators.ContainsKey(input))
            {
                if (this.infixOperators.ContainsKey(this.previousInput))
                {
                    this.previousInput = input;
                    this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                    this.currentIterationInputs.Add(input);
                    this.operators[this.Count - 1].RemoveAt(this.operators[this.Count - 1].Count - 1);
                    this.operators[this.Count - 1].Add(input);

                    return null;
                }

                if (this.prefixOperators.ContainsKey(this.previousInput) 
                    || (this.currentOperationNotation == OperationNotation.Pre 
                    && this.prefixOrPostOperations.ContainsKey(this.previousInput))
                    || this.prefixAndPostOperations.ContainsKey(this.previousInput))
                {
                    return null;
                }

                if (this.postfixOperators.ContainsKey(this.previousInput)
                    || (this.currentOperationNotation == OperationNotation.Post
                    && this.prefixOrPostOperations.ContainsKey(this.previousInput)))
                {
                    var previousOperators = new Queue<string>();
                    while (this.operators[this.Count - 1].Count > 0 && this.operatorsPrecedence[input]
                           <= this.operatorsPrecedence[this.operators[this.Count - 1].Last()])
                    {
                        previousOperators.Enqueue(this.operators[this.Count - 1].Last());
                        this.operators[this.Count - 1].RemoveAt(this.operators[this.Count - 1].Count - 1);
                    }

                    this.operators[this.Count - 1].Add(input);

                    while (previousOperators.Count > 0)
                    {
                        this.currentResult = this.Calculate(
                            previousOperators.Dequeue(),
                            this.numbers[this.Count - 1]);
                    }

                    data[1] = this.currentResult;
                    this.previousInput = input;
                    this.currentIterationInputs.Add(input);

                    return data;
                }

                if (this.digits.Contains(this.previousInput))
                {
                    this.Clear();
                    while (this.operators[this.Count - 1].Count > 0 && this.operatorsPrecedence[this.operators[this.Count - 1].Last()]
                        >= this.operatorsPrecedence[input])
                    {
                        var currentOperator = this.operators[this.Count - 1].Last();
                        this.operators[this.Count - 1].RemoveAt(this.operators[this.Count - 1].Count - 1);
                        this.currentResult = this.Calculate(currentOperator, this.numbers[this.Count - 1]);
                        data[1] = this.currentResult;
                    }

                    this.operators[this.Count - 1].Add(input);
                    this.previousInput = input;
                    this.currentIterationInputs.Add(input);

                    return data;
                }

                if (this.previousInput == Constants.EqualSign)
                {
                    this.operators[this.Count - 1].Add(input);
                    this.previousInput = input;
                    this.currentIterationInputs.Add(input);

                    return data;
                }

                return null;
            }

            if (this.postfixOperators.ContainsKey(input) ||
                (this.currentOperationNotation == OperationNotation.Post
                 && this.prefixOrPostOperations.ContainsKey(input)))
            {
                if (this.prefixAndPostOperations.ContainsKey(this.previousInput))
                {
                    return null;
                }

                if (this.infixOperators.ContainsKey(this.previousInput))
                {
                    this.operators[this.Count - 1].RemoveAt(this.operators[this.Count - 1].Count - 1);//postfix operators can be imposed over infix operators
                    this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);      
                }

                if (this.digits.Contains(this.previousInput))
                {
                    this.Clear();
                    if (this.operators[this.Count - 1].Count > 0 
                        && (this.prefixOperators.ContainsKey(this.operators[this.Count - 1].Last())
                        || (this.currentOperationNotation == OperationNotation.Pre
                        && this.prefixOrPostOperations.ContainsKey(this.operators[this.Count - 1].Last()))))
                    {
                        var currentOperator = this.operators[this.Count - 1].Last();
                        this.operators[this.Count - 1].RemoveAt(this.operators[this.Count - 1].Count - 1);
                        this.currentResult = this.Calculate(currentOperator, this.numbers[this.Count - 1]);
                    }
                }

                if (this.previousInput == Constants.EqualSign || this.digits.Contains(this.previousInput) || this.infixOperators.ContainsKey(this.previousInput) || this.postfixOperators.ContainsKey(this.previousInput) 
                    || (this.currentOperationNotation == OperationNotation.Post && this.prefixOrPostOperations.ContainsKey(this.previousInput)))
                {
                    this.previousInput = input;
                    this.currentIterationInputs.Add(input);
                    this.currentResult = this.Calculate(input, null);
                    data[1] = this.currentResult;

                    return data;
                }

                return null;
            }

            if (this.prefixOperators.ContainsKey(input)
                || (this.currentOperationNotation == OperationNotation.Pre
                && this.prefixOrPostOperations.ContainsKey(input)))
            {
                if (this.postfixOperators.ContainsKey(this.previousInput)
                    || this.prefixAndPostOperations.ContainsKey(this.previousInput)
                    || this.prefixOrPostOperations.ContainsKey(this.previousInput)) // Chained Prefix Operations are not supported currently, except in brackets
                {
                    return null;
                }

                //if (this.digits.Contains(this.previousInput))
                //{
                    
                //}

                if (this.infixOperators.ContainsKey(this.previousInput))
                {
                    this.numbers[this.Count - 1].Add(this.currentResult);
                    this.currentResult = null;
                }

                if (this.operators[this.Count - 1].Count == 0 && this.currentResult != null)
                {
                    this.currentResult = null;
                    this.numbers[this.Count - 1].Clear();
                }

                this.operators[this.Count - 1].Add(input);
                this.previousInput = input;
                this.currentIterationInputs.Add(input);

                return null;
            }

            throw new InvalidInputException();
        }

        public void Clear()
        {
            this.currentNumberBuilder.Clear();
            this.decimalPointIsUsed = false;
        }

        public void ClearAll()
        {
            this.Reset();
            this.addedToMemoryResults.Clear();
        }

        public void Reset()
        {
            this.ResetIteration();
            this.currentIterationInputs.Clear();
        }

        public void ResetIteration()
        {
            this.numbers.Clear();
            this.numbers.Add(new List<object>());
            this.operators.Clear();
            this.operators.Add(new List<string>());
            this.currentResult = null;
            this.previousInput = null;
            this.Clear();
        }

        private void SetDefaults()
        {            
            this.currentResult = null;
            this.previousInput = null;
            this.decimalPointIsUsed = false;
            this.ChangeNumberDecSeparator(Constants.DecimalPoint);
            this.ProcessInput(Constants.DigitZero);
            this.SetDefaultSwitchStates();
        }   

        private object[] PerformSpecialOperation(string operationName)
        {
            var data = new object[ReturnDataCount];
            switch (operationName)
            {
                case Constants.ClearPrefix:
                    {
                        this.ClearAll();
                        this.ProcessInput(Constants.DigitZero);
                        data[2] = Constants.ClearPrefix;
                    }

                    break;
                case Constants.ClearLastPrefix:
                    {
                        this.ResetIteration();
                        data[2] = Constants.ClearLastPrefix;
                        if (this.currentIterationInputs.Count == 0)
                        {
                            this.ProcessInput(Constants.DigitZero);
                            return data;
                        }

                        this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                        var count = this.currentIterationInputs.Count;
                        if (count > 0)
                        {
                            for (var i = 0; i < count - 1; i++)
                            {
                                var input = this.currentIterationInputs[i];
                                this.ProcessInput(input);
                                this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                            }

                            {
                                var input = this.currentIterationInputs[count - 1];
                                data = this.ProcessInput(input);
                                this.currentIterationInputs.RemoveAt(this.currentIterationInputs.Count - 1);
                            }
                        }
                    }

                    break;

                case Constants.AddToMemoryPrefix:
                    {
                        if (this.currentResult != null)
                        {
                            this.addedToMemoryResults.Add(this.currentResult);
                        }
                    }

                    break;
                case Constants.SubtractFromMemoryPrefix:
                    {
                        if (this.addedToMemoryResults.Count > 0)
                        {
                            this.addedToMemoryResults.RemoveAt(this.addedToMemoryResults.Count - 1);
                            data[0] = 0;
                        }
                    }

                    break;
                case Constants.MemoryClearPrefix:
                    {
                        this.addedToMemoryResults.Clear();
                        return null;
                    }

                case Constants.MemoryRestorePrefix:
                    {
                        var count = this.addedToMemoryResults.Count;
                        this.currentResult = 0m;
                        data[0] = 0;
                        data[1] = this.currentResult;
                        if (count > 0)
                        {
                            for (var i = 0; i < count; i++)
                            {
                                var result = this.addedToMemoryResults[i];
                                this.currentResult = this.Calculate(Constants.AddSign, new List<object> { result });
                            }

                            data[0] = 0;
                            data[1] = this.currentResult;
                        }
                    }

                    break;

                default:
                    throw new UnimplementedOperationException();
            }

            return data;
        }

        private object Calculate(string operatorName, IList<object> numberGroup)
        {
            if (this.trigonometricOperations.Contains(operatorName))
            {
                if (this.currentAngleUnit == AngleUnit.Deg)
                {
                    this.currentResult = double.Parse(this.currentResult.ToString()) * Math.PI / 180;
                }

                if (this.currentAngleUnit == AngleUnit.Grad)
                {
                    this.currentResult = double.Parse(this.currentResult.ToString()) * Math.PI / 200;
                }
            }

            if (this.infixOperators.ContainsKey(operatorName))
            {
                object operand = null;
                if (numberGroup.Count > 0)
                {
                    operand = numberGroup[numberGroup.Count - 1];
                    numberGroup.RemoveAt(numberGroup.Count - 1);
                }
                else
                {
                    operand = this.currentResult;
                }

                var componentPrefix = this.infixOperators[operatorName];
                var result = this.CalculateOperation(componentPrefix, operand);

                return result;
            }

            if (this.postfixOperators.ContainsKey(operatorName))
            {
                var componentPrefix = this.postfixOperators[operatorName];
                var result = this.CalculateOperation(componentPrefix, null);

                return result;
            }

            if (this.currentOperationNotation == OperationNotation.Post 
                && this.prefixOrPostOperations.ContainsKey(operatorName))
            {
                var componentPrefix = this.prefixOrPostOperations[operatorName];
                var result = this.CalculateOperation(componentPrefix, null);

                return result;
            }

            if (this.prefixOperators.ContainsKey(operatorName))
            {
                var componentPrefix = this.prefixOperators[operatorName];
                var result = this.CalculateOperation(componentPrefix, null);

                return result;
            }

            if (this.currentOperationNotation == OperationNotation.Pre 
                && this.prefixOrPostOperations.ContainsKey(operatorName))
            {
                var componentPrefix = this.prefixOrPostOperations[operatorName];
                var result = this.CalculateOperation(componentPrefix, null);

                return result;
            }

            if (this.prefixAndPostOperations.ContainsKey(operatorName))
            {
                object operand = null;
                if (numberGroup.Count > 0)
                {
                    operand = numberGroup[numberGroup.Count - 1];
                    numberGroup.RemoveAt(numberGroup.Count - 1);
                }
                else
                {
                    return null;
                }

                var componentPrefix = this.prefixAndPostOperations[operatorName];
                var result = this.CalculateOperation(componentPrefix, operand);

                return result;
            }

            return null;
        }

        private object CalculateOperation(string componentPrefix, object operand)
        {
            var componentName = NameGenerator.GenerateStrategyName(componentPrefix);
            var component = this.dependencyContainer.GetComponent(componentName, null);
            var method = this.methodInvoker.GetMethodByName(component.GetType(), Constants.CalculateMethodName);
            object result = null;
            if (operand != null)
            {
                result = method.Invoke(component, new[] { operand, this.currentResult });
            }
            else
            {
                result = method.Invoke(component, new[] { this.currentResult });
            }

            return result;
        }

        private void ChangeNumberDecSeparator(string separator)
        {
            this.nfi = new CultureInfo("en-US", false).NumberFormat;
            this.nfi.NumberDecimalSeparator = separator;
        }

        private object ChangeSwitchOperationFieldValue(Type switchOperationType)
        {
            var fieldName = "current" + switchOperationType.Name;

            var field = this.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldValue = field.GetValue(this);
            fieldValue = (int)fieldValue + 1;
            if(!Enum.IsDefined(switchOperationType, fieldValue))
            {
                fieldValue = 0;
            }

            field.SetValue(this, fieldValue);

            return field;
        }
        private void SetDefaultSwitchStates()
        {
            this.currentRepresentationNotation = RepresentationNotation.Nor;
            this.currentOperationNotation = OperationNotation.Pre;
            this.currentInversionState = InversionState.None;
            this.currentAngleUnit = AngleUnit.Rad;
            this.currentFractionMode = FractionMode.Dec;
            this.currentPrecision = Precision.None;
        }

    }
}
