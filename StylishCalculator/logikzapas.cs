//using System;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Input;

//namespace StylishCalculator
//{
//    public partial class MainWindow : Window
//    {
//        private double _firstNumber;
//        private double _secondNumber;
//        private string _operation;
//        private string _currentInput;

//        public MainWindow()
//        {
//            InitializeComponent();
//            _currentInput = "";
//        }

//        private void NumberButton_Click(object sender, RoutedEventArgs e)
//        {
//            Button button = (Button)sender;
//            _currentInput += button.Content.ToString();
//            Display.Text = _currentInput;
//        }

//        private void OperationButton_Click(object sender, RoutedEventArgs e)
//        {
//            Button button = (Button)sender;

//            if (!string.IsNullOrEmpty(_currentInput))
//            {
//                _firstNumber = double.Parse(_currentInput);
//                _operation = button.Content.ToString();
//                DisplayTop.Text = _currentInput + " " + _operation;
//                _currentInput = "";
//                Display.Text = "";
//            }
//        }

//        private void EqualsButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(_currentInput))
//            {
//                _secondNumber = double.Parse(_currentInput);
//                double result = 0;

//                switch (_operation)
//                {
//                    case "+":
//                        result = _firstNumber + _secondNumber;
//                        break;
//                    case "-":
//                        result = _firstNumber - _secondNumber;
//                        break;
//                    case "*":
//                        result = _firstNumber * _secondNumber;
//                        break;
//                    case "/":
//                        if (_secondNumber != 0)
//                            result = _firstNumber / _secondNumber;
//                        else
//                            MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
//                        break;
//                    case "^":
//                        result = Math.Pow(_firstNumber, _secondNumber);
//                        break;
//                }

//                DisplayTop.Text = _firstNumber + " " + _operation + " " + _secondNumber;
//                Display.Text = result.ToString();
//                _currentInput = result.ToString(); // Save the result for further calculations.
//            }
//        }

//        private void ClearButton_Click(object sender, RoutedEventArgs e)
//        {
//            _currentInput = "";
//            _firstNumber = 0;
//            _secondNumber = 0;
//            _operation = "";
//            DisplayTop.Text = "";
//            Display.Text = "";
//        }

//        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (_currentInput.Length > 0)
//            {
//                _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
//                Display.Text = _currentInput;
//            }
//        }

//        private void PowerButton_Click(object sender, RoutedEventArgs e)
//        {
//            _operation = "^";
//            if (!string.IsNullOrEmpty(_currentInput))
//            {
//                _firstNumber = double.Parse(_currentInput);
//                DisplayTop.Text = _currentInput + " ^ ";
//                _currentInput = "";
//            }
//        }

//        private void SqrtButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(_currentInput))
//            {
//                _firstNumber = double.Parse(_currentInput);
//                double result = Math.Sqrt(_firstNumber);
//                DisplayTop.Text = "√" + _firstNumber;
//                Display.Text = result.ToString();
//                _currentInput = result.ToString();
//            }
//        }

//        private void TrigButton_Click(object sender, RoutedEventArgs e)
//        {
//            Button button = (Button)sender;
//            if (!string.IsNullOrEmpty(_currentInput))
//            {
//                _firstNumber = double.Parse(_currentInput);
//                double result = 0;

//                switch (button.Content.ToString())
//                {
//                    case "cos":
//                        result = Math.Cos(_firstNumber);
//                        break;
//                    case "sin":
//                        result = Math.Sin(_firstNumber);
//                        break;
//                    case "tan":
//                        result = Math.Tan(_firstNumber);
//                        break;
//                    case "ctg":
//                        result = 1 / Math.Tan(_firstNumber);
//                        break;
//                }

//                DisplayTop.Text = button.Content.ToString() + "(" + _firstNumber + ")";
//                Display.Text = result.ToString();
//                _currentInput = result.ToString();
//            }
//        }
//    }
//}