namespace Scientific_Calculator.Core
{
    using System;
    using System.Reflection;
    using System.Windows;

    using Attributes;
    using Enums;
    using Events;
    using Interfaces;

    [Core]
    public class CalculationHandler : ICalculationHandler
    {
        private const string PropertyPrefix = "Current";
        [Inject]
        private readonly ICalculationExecutor calculationExecutor;

        private readonly IRepositoryHandler repositoryHandler;
        private readonly IDependencyContainer dependencyContainer;
        private readonly IMethodInvoker methodInvoker;

        private string currentOutput;
        private string currentInput;
        private RepresentationNotation currentRepresentationNotation;
        private OperationNotation currentOperationNotation;
        private AngleUnit currentAngleUnit;
        private InversionState currentInversionState;
        private FractionMode currentFractionMode;
        private SwitchMode currentSwitchMode;
        private Precision currentPrecision; 

        public event ChangeTextEventHandler InputChanged;
        public event ChangeTextEventHandler OutputChanged;
        public event ChangeTextEventHandler RepresentationNotationChanged;
        public event ChangeTextEventHandler OperationNotationChanged;
        public event ChangeTextEventHandler FractionModeChanged;
        public event ChangeTextEventHandler AngleUnitChanged;
        public event ChangeTextEventHandler SwitchModeChanged;
        public event ChangeTextEventHandler InversionStateChanged;
        public event ChangeTextEventHandler PrecisionChanged;

        public CalculationHandler(
            IRepositoryHandler repositoryHandler, 
            IDependencyContainer dependencyContainer,
            IMethodInvoker methodInvoker)
        {
            this.repositoryHandler = repositoryHandler;
            this.dependencyContainer = dependencyContainer;
            this.methodInvoker = methodInvoker;
            this.SetDefaultSwitchStates();
            this.currentSwitchMode = SwitchMode.On;
        }

        public string CurrentInput
        {
            get
            {
                return this.currentInput;
            }

            private set
            {
                this.OnInputChanged(this, new ChangeTextEventArgs(value));
                this.currentInput = value;
            }
        }

        public string CurrentOutput
        {
            get
            {
                return this.currentOutput;
            }

            private set
            {
                this.OnOutputChanged(this, new ChangeTextEventArgs(value));
                this.currentOutput = value;
            }
        }

        public AngleUnit CurrentAngleUnit
        {
            get
            {
                return this.currentAngleUnit;
            }

            private set
            {
                this.OnAngleUnitChanged(this, new ChangeTextEventArgs(value.ToString()));
                this.currentAngleUnit = value;
            }
        }

        public RepresentationNotation CurrentRepresentationNotation
        {
            get
            {
                return this.currentRepresentationNotation;
            }

            private set
            {
                this.OnRepresentationNotationChanged(this, new ChangeTextEventArgs(value.ToString()));
                this.currentRepresentationNotation = value;
            }
        }

        public InversionState CurrentInversionState
        {
            get
            {
                return this.currentInversionState;
            }

            private set
            {
                this.OnInversionStateChanged(this, new ChangeTextEventArgs(value.ToString()));
                this.currentInversionState = value;
            }
        }

        public OperationNotation CurrentOperationNotation
        {
            get
            {
                return this.currentOperationNotation;
            }

            private set
            {
                this.OnOperationNotationChanged(this, new ChangeTextEventArgs(value.ToString()));
                this.currentOperationNotation = value;
            }
        }

        public FractionMode CurrentFractionMode
        {
            get
            {
                return this.currentFractionMode;
            }

            private set
            {
                this.OnFractionModeChanged(this, new ChangeTextEventArgs(value.ToString()));
                this.currentFractionMode = value;
            }
        }

        public Precision CurrentPrecision
        {
            get
            {
                return this.currentPrecision;
            }

            private set
            {
                var valueToShow = (int)value;
                this.OnPrecisionChanged(this, new ChangeTextEventArgs(valueToShow.ToString()));
                this.currentPrecision = value;
            }
        }

        public SwitchMode CurrentSwitchMode
        {
            get
            {
                return this.currentSwitchMode;
            }

            private set
            {
                this.OnSwitchModeChanged(this, new ChangeTextEventArgs(value.ToString()));
                this.currentSwitchMode = value;
            }
        }


        public void Execute(string input)
        {
            var result = this.calculationExecutor.ProcessInput(input);
            if (result == null)
            {
                return;
            }

            if (result[2] != null)
            {
                this.SetInput(0);
                this.SetOutput(0);                
            }

            if (result[3] != null)
            {
                var type = ((FieldInfo)result[3]);
                var value = type.GetValue(this.calculationExecutor);
                var enumType = type.FieldType;
                var property = this.GetType().GetProperty(PropertyPrefix + enumType.Name, enumType);
                property.SetValue(this, value);
            }

            if (result[9] != null)
            {

            }

            if (result[0] != null)
            {
                this.SetInput(result[0]);
            }

            if (result[1] == null)
            {
                return;
            }

            this.SetOutput(result[1]);
        }

        public void OnInputChanged(object sender, ChangeTextEventArgs args)
        {
            this.InputChanged?.Invoke(sender, args);
        }

        public void OnOutputChanged(object sender, ChangeTextEventArgs args)
        {
            this.OutputChanged?.Invoke(sender, args);
        }

        public void OnRepresentationNotationChanged(object sender, ChangeTextEventArgs args)
        {
            this.RepresentationNotationChanged?.Invoke(sender, args);
        }

        public void OnOperationNotationChanged(object sender, ChangeTextEventArgs args)
        {
            this.OperationNotationChanged?.Invoke(sender, args);
        }

        public void OnFractionModeChanged(object sender, ChangeTextEventArgs args)
        {
            this.FractionModeChanged?.Invoke(sender, args);
        }

        public void OnAngleUnitChanged(object sender, ChangeTextEventArgs args)
        {
            this.AngleUnitChanged?.Invoke(sender, args);
        }

        public void OnInversionStateChanged(object sender, ChangeTextEventArgs args)
        {
            this.InversionStateChanged?.Invoke(sender, args);
        }

        public void OnPrecisionChanged(object sender, ChangeTextEventArgs args)
        {
            this.PrecisionChanged?.Invoke(sender, args);
        }

        public void OnSwitchModeChanged(object sender, ChangeTextEventArgs args)
        {
            this.SwitchModeChanged?.Invoke(sender, args);
        }

        public void Clear()
        {
            this.calculationExecutor.Clear();
        }

        private void SetInput(object inputField)
        {
            this.CurrentInput = inputField.ToString();
        }

        private void SetOutput(object outputField)
        {
            this.CurrentOutput = outputField.ToString();
        }

        public void CalculationHandlerExceptionHandlingMethod(Exception originalException)
        {
            var exception = originalException;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            if (exception is OverflowException)
            {
                MessageBox.Show("Operation overflows numeric Type");
            }

            if(exception is DivideByZeroException)
            {
                MessageBox.Show("Division by zero is indefinite operation");
            }
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