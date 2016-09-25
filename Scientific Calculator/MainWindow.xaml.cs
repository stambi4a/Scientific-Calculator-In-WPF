namespace Scientific_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using Scientific_Calculator.Core;
    using Scientific_Calculator.Data;
    using Scientific_Calculator.Events;
    using Scientific_Calculator.ExtensionMethods;
    using Scientific_Calculator.Interfaces;
    using Scientific_Calculator.Utilities;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICalculationRepository calculationRepository;
        private readonly IOperationsContainer operationsContainer;

        public MainWindow()
        {
            this.InitializeComponent();
            IDependencyContainer dependencyContainer = new DependencyContainer();
            this.calculationRepository = new CalculationRepository();
            dependencyContainer.AddDependency(typeof(ICalculationRepository), this.calculationRepository);
            dependencyContainer.AddDependency(typeof(IDependencyContainer), dependencyContainer);
            this.operationsContainer = dependencyContainer.Resolve<IOperationsContainer>();
            this.operationsContainer.CalculationHandler.InputChanged += this.ChangeInputFieldContent;
            this.operationsContainer.CalculationHandler.OutputChanged += this.ChangeOutputFieldContent;
            this.operationsContainer.CalculationHandler.RepresentationNotationChanged += this.ChangeRepresentationNotationFieldContent;
            this.operationsContainer.CalculationHandler.OperationNotationChanged += this.ChangeOperationNotationFieldContent;
            this.operationsContainer.CalculationHandler.InversionStateChanged += this.ChangeInversionStateFieldContent;
            this.operationsContainer.CalculationHandler.AngleUnitChanged += this.ChangeAngleUnitFieldContent;
            this.operationsContainer.CalculationHandler.FractionModeChanged += this.ChangeFractionModeFieldContent;
            this.operationsContainer.CalculationHandler.PrecisionChanged += this.ChangePrecisionFieldContent;
            this.operationsContainer.CalculationHandler.SwitchModeChanged += this.ChangeSwitchModeContent;
            this.ChangeInputFieldContent(this, new ChangeTextEventArgs("0"));
            this.ChangeOutputFieldContent(this, new ChangeTextEventArgs("0"));
        }

        public MainWindow(ICalculationRepository calculationRepository)
        {
            IDependencyContainer dependencyContainer = new DependencyContainer();
            this.calculationRepository = calculationRepository;
            dependencyContainer.AddDependency(typeof(ICalculationRepository), calculationRepository);
            dependencyContainer.AddDependency(typeof(IDependencyContainer), dependencyContainer);
            this.operationsContainer = dependencyContainer.Resolve<IOperationsContainer>();
            this.InitializeComponent();
        }

        private void MainGridLoaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += delegate { this.DragMove(); };
        }

        #region LostFocusEvents
        private void ThematicSubMenuLostFocus(object sender, RoutedEventArgs e)
        {
            this.ThematicSubSubMenu.IsCheckable = true;
        }

        private void ThemesSubMenuLostFocus(object sender, RoutedEventArgs e)
        {
            this.ThemesSubMenu.IsCheckable = true;
        }
        #endregion
        #region ClickEvents
        private void ModeSubMenuItemClick(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            if (item == null)
            {
                return;
            }

            var children = new List<MenuItem>();
            children.FindVisualChildren(this.ModeSubMenu);
            foreach (var child in children)
            {
                if (child != null && child.Name != item.Name)
                {
                    child.IsChecked = false;
                }
            }

            item.IsChecked = true;
        }

        private void ViewSubMenuItemClick(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            if (item == null)
            {
                return;
            }

            var children = new List<MenuItem>();
            children.FindVisualChildren(this.ViewSubMenu);
            foreach (var child in children)
            {
                if (child != null && child.Name != item.Name)
                {
                    child.IsChecked = false;
                }
            }

            item.IsChecked = true;
        }

        private void ThematicSubSubMenu_OnClick(object sender, RoutedEventArgs e)
        {
            this.ThematicSubSubMenu.IsCheckable = false;
            this.ThematicSubSubMenu.IsChecked = false;
            this.ThematicSubSubMenu.IsSubmenuOpen = true;
        }

        private void ThemesMenuItem_OnClickhemesSubSubMenu_OnClick(object sender, RoutedEventArgs e)
        {
            this.ThemesSubMenu.IsCheckable = false;
            this.ThemesSubMenu.IsChecked = false;
            this.ThemesSubMenu.IsSubmenuOpen = true;
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(((Button)sender).Content.ToString());
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.DeleteSign);
        }

        private void ButtonHistoryClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.HistorySign);
        }

        private void FractionSwitcherButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ChangeFractionModeSign);
        }

        private void PowerOfTwoButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.PowerOfTwoSign);
        }

        private void PowerOfTenButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.PowerOfTenSign);
        }

        private void PowerOfEulerNumberButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.PowerOfEulerNumberSign);
        }

        private void SecondPowerOfXButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.SecondPowerOfXSign);
        }

        private void ThirdPowerOfXButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.CubicPowerOfXSign);
        }

        private void YPowerOfXButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.YPowerOfXSign);
        }

        private void SquareRootButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.SquareRootSign);
        }

        private void ThirdRootButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.CubicRootSign);
        }

        private void YRootButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.YRootSign);
        }

        private void LogarithmAtBase2ButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.LogarithmAtBase2Sign);
        }

        private void LogarithmAtBase10ButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.LogarithmAtBase10Sign);
        }

        private void NaturalLogarithmButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.NaturalLogarithmSign);
        }

        private void LogarithmAtXBaseNumberButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.LogarithmAtBaseXSign);
        }

        private void ArcusSineButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ArcusSineSign);
        }

        private void ArcusCosineButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ArcusCosineSign);
        }

        private void ArcusTangentFunctionButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ArcusTangentSign);
        }

        private void ArcusContangentButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ArcusCotangentSign);
        }

        private void ArcusSineHyperbolicButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ArcusSineHyperbolicSign);
        }

        private void ArcusCosineHyperbolicButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ArcusCosineHyperbolicSign);
        }

        private void ArcusTangentHyperbolicButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ArcusTangentHyperbolicSign);
        }

        private void ArcusCotangentHyperbolicButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ArcusCotangentHyperbolicSign);
        }

        private void SwitchButtonClick(object sender, RoutedEventArgs e)
        {
            this.operationsContainer.Execute(Constants.ChangeSwitchModeSign);
        }

        #endregion

        #region CustomEvents
        private void ChangeInputFieldContent(object sender, ChangeTextEventArgs args)
        {
            this.InputField.Document = new FlowDocument();
            this.InputField.Selection.Text = args.FieldValue;
        }

        private void ChangeOutputFieldContent(object sender, ChangeTextEventArgs args)
        {
            this.OutputField.Selection.Text = args.FieldValue;
        }

        private void ChangeSwitchModeContent(object sender, ChangeTextEventArgs args)
        {
            if (args.FieldValue == "Off")
            {
                this.SwitchButtonOnBackground.Visibility = Visibility.Hidden;
                this.SwitchButtonOffBackground.Visibility = Visibility.Visible;
                this.InputField.IsEnabled = false;
                this.OutputField.IsEnabled = false;
                this.RepresentationNotationField.IsEnabled = false;
                this.OperationNotationField.IsEnabled = false;
                this.InversionStateField.IsEnabled = false;
                this.FractionModeField.IsEnabled = false;
                this.AngleUnitField.IsEnabled = false;
                this.PrecisionField.IsEnabled = false;
                this.LowerRightTextBox.IsEnabled = false;
                this.InputField.Selection.Text = string.Empty;
                this.OutputField.Selection.Text = string.Empty;
                this.RepresentationNotationField.Selection.Text = string.Empty;
                this.OperationNotationField.Selection.Text = string.Empty;
                this.InversionStateField.Selection.Text = string.Empty;
                this.FractionModeField.Selection.Text = string.Empty;
                this.AngleUnitField.Selection.Text = string.Empty;
                this.PrecisionField.Selection.Text = string.Empty;
                this.SwitchButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 137, 17, 17));
            }
            else
            {
                this.SwitchButtonOnBackground.Visibility = Visibility.Visible;
                this.SwitchButtonOffBackground.Visibility = Visibility.Hidden;
                this.InputField.IsEnabled = true;
                this.OutputField.IsEnabled = true;
                this.RepresentationNotationField.IsEnabled = true;
                this.OperationNotationField.IsEnabled = true;
                this.InversionStateField.IsEnabled = true;
                this.FractionModeField.IsEnabled = true;
                this.AngleUnitField.IsEnabled = true;
                this.PrecisionField.IsEnabled = true;
                this.LowerRightTextBox.IsEnabled = true;
                this.ChangeInputFieldContent(this, new ChangeTextEventArgs("0"));
                this.ChangeOutputFieldContent(this, new ChangeTextEventArgs("0"));
                this.SwitchButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 25, 162, 61));
            }
            //var textBox = this.
        }

        private void ChangeRepresentationNotationFieldContent(object sender, ChangeTextEventArgs args)
        {
            if (args.FieldValue == "Nor")
            {
                this.RepresentationNotationField.Selection.Text = string.Empty;

                return;
            }

            this.RepresentationNotationField.Selection.Text = args.FieldValue.ToUpper();
        }

        private void ChangeOperationNotationFieldContent(object sender, ChangeTextEventArgs args)
        {
            if (args.FieldValue == "Pre")
            {
                this.OperationNotationField.Selection.Text = string.Empty;

                return;
            }
            this.OperationNotationField.Selection.Text = args.FieldValue.ToUpper();
        }

        private void ChangeFractionModeFieldContent(object sender, ChangeTextEventArgs args)
        {
            if (args.FieldValue == "Dec")
            {
                this.FractionModeField.Selection.Text = string.Empty;

                return;
            }

            this.FractionModeField.Selection.Text = args.FieldValue.ToUpper();
        }

        private void ChangePrecisionFieldContent(object sender, ChangeTextEventArgs args)
        {
         if (args.FieldValue == "0")
            {
                this.PrecisionField.Selection.Text = string.Empty;

                return;
            }   

            this.PrecisionField.Selection.Text = args.FieldValue.ToUpper();
        }

        private void ChangeInversionStateFieldContent(object sender, ChangeTextEventArgs args)
        {
            if (args.FieldValue == "None")
            {
                this.InversionStateField.Selection.Text = string.Empty;
                this.SineFunctionButton.Visibility = Visibility.Visible;
                this.CosineFunctionButton.Visibility = Visibility.Visible;
                this.TangentFunctionButton.Visibility = Visibility.Visible;
                this.CotangentFunctionButton.Visibility = Visibility.Visible;
                this.SineHyperbolicFunctionButton.Visibility = Visibility.Visible;
                this.CosineHyperbolicFunctionButton.Visibility = Visibility.Visible;
                this.TangentHyperbolicFunctionButton.Visibility = Visibility.Visible;
                this.CotangentHyperbolicFunctionButton.Visibility = Visibility.Visible;

                this.ArcusSineFunctionButton.Visibility = Visibility.Hidden;
                this.ArcusCosineFunctionButton.Visibility = Visibility.Hidden;
                this.ArcusTangentFunctionButton.Visibility = Visibility.Hidden;
                this.ArcusCotangentFunctionButton.Visibility = Visibility.Hidden;
                this.ArcusSineHyperbolicFunctionButton.Visibility = Visibility.Hidden;
                this.ArcusCosineHyperbolicFunctionButton.Visibility = Visibility.Hidden;
                this.ArcusTangentHyperbolicFunctionButton.Visibility = Visibility.Hidden;
                this.ArcusCotangentHyperbolicFunctionButton.Visibility = Visibility.Hidden;
                return;
            }

            this.InversionStateField.Selection.Text = args.FieldValue.ToUpper();
            this.SineFunctionButton.Visibility = Visibility.Hidden;
            this.CosineFunctionButton.Visibility = Visibility.Hidden;
            this.TangentFunctionButton.Visibility = Visibility.Hidden;
            this.CotangentFunctionButton.Visibility = Visibility.Hidden;
            this.SineHyperbolicFunctionButton.Visibility = Visibility.Hidden;
            this.CosineHyperbolicFunctionButton.Visibility = Visibility.Hidden;
            this.TangentHyperbolicFunctionButton.Visibility = Visibility.Hidden;
            this.CotangentHyperbolicFunctionButton.Visibility = Visibility.Hidden;

            this.ArcusSineFunctionButton.Visibility = Visibility.Visible;
            this.ArcusCosineFunctionButton.Visibility = Visibility.Visible;
            this.ArcusTangentFunctionButton.Visibility = Visibility.Visible;
            this.ArcusCotangentFunctionButton.Visibility = Visibility.Visible;
            this.ArcusSineHyperbolicFunctionButton.Visibility = Visibility.Visible;
            this.ArcusCosineHyperbolicFunctionButton.Visibility = Visibility.Visible;
            this.ArcusTangentHyperbolicFunctionButton.Visibility = Visibility.Visible;
            this.ArcusCotangentHyperbolicFunctionButton.Visibility = Visibility.Visible;
        }

        private void ChangeAngleUnitFieldContent(object sender, ChangeTextEventArgs args)
        {
            if (args.FieldValue == "Rad")
            {
                this.AngleUnitField.Selection.Text = string.Empty;

                return;
            }

            this.AngleUnitField.Selection.Text = args.FieldValue.ToUpper();
        }

        #endregion

        #region ExceptionHandling

        #endregion

        #region KeyboardHandling Evennts
        private void MainWindowDetectKeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key;
            switch (key)
            {
                case Key.D0:
                case Key.NumPad0:
                    {
                        this.ButtonClick(this.Zero0DigitButton, null);
                    }

                    break;
                case Key.D1:
                case Key.NumPad1:
                    {
                        this.ButtonClick(this.One1DigitButton, null);
                    }

                    break;
                case Key.D2:
                case Key.NumPad2:
                    {
                        this.ButtonClick(this.Two2DigitButton, null);
                    }

                    break;
                case Key.D3:
                case Key.NumPad3:
                    {
                        this.ButtonClick(this.Three3DigitButton, null);
                    }

                    break;
                case Key.D4:
                case Key.NumPad4:
                    {
                        this.ButtonClick(this.Four4DigitButton, null);
                    }

                    break;
                case Key.D5:
                case Key.NumPad5:
                    {
                        this.ButtonClick(this.Five5DigitButton, null);
                    }

                    break;
                case Key.D6:
                case Key.NumPad6:
                    {
                        this.ButtonClick(this.Six6DigitButton, null);
                    }

                    break;
                case Key.D7:
                case Key.NumPad7:
                    {
                        this.ButtonClick(this.Seven7DigitButton, null);
                    }

                    break;
                case Key.D8:
                case Key.NumPad8:
                    {
                        this.ButtonClick(this.Eight8DigitButton, null);
                    }

                    break;
                case Key.D9:
                case Key.NumPad9:
                    {
                        this.ButtonClick(this.Nine9DigitButton, null);
                    }

                    break;
                case Key.Add:
                    {
                        this.ButtonClick(this.AddOperationButton, null);
                    }

                    break;
                case Key.Subtract:
                    {
                        this.ButtonClick(this.SubtractOperationButton, null);
                    }

                    break;
                case Key.Multiply:
                    {
                        this.ButtonClick(this.MultiplyOperationButton, null);
                    }

                    break;
                case Key.Divide:
                    {
                        this.ButtonClick(this.DivideOperationButton, null);
                    }

                    break;
                case Key.Enter:
                    {
                        this.ButtonClick(this.EqualsButton, null);
                    }

                    break;

                case Key.Back:
                case Key.Delete:
                    {
                        this.ButtonClick(this.DeleteSpecialButton, null);
                    }

                    break;
                case Key.LeftCtrl:
                case Key.RightCtrl:
                    {
                        this.OutputField.Focus();
                    }

                    break;
                default:
                    return;

            }
        }

        #endregion

        #region Preview Events
        private void MainWindowPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key;
            if (key == Key.Enter)
            {
                this.EqualsButton.Focus();
            }
        }
        #endregion
    }
}
