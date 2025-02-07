using System;
using System.Windows;
using System.Windows.Controls;
using NCalc;

namespace StylishCalculator
{
    public partial class MainWindow : Window
    {
        private string _currentInput;
        private bool _isFunctionPressed = false; // Флаг для отслеживания нажатия функции

        public MainWindow()
        {
            InitializeComponent();
            _currentInput = "";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _currentInput += button.Content.ToString();
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _currentInput += " " + button.Content.ToString() + " ";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = _currentInput;

                // Заменяем тригонометрические функции на корректные
                expression = expression.Replace("cos", "Cos")
                                       .Replace("sin", "Sin")
                                       .Replace("tan", "Tan")
                                       .Replace("ctg", "Ctg");

                // Создаем объект Expression из NCalc для вычисления выражения
                NCalc.Expression exp = new NCalc.Expression(expression);

                // Получаем результат
                var result = exp.Evaluate();

                // Обновляем верхний экран с полным выражением
                DisplayTop.Text = _currentInput;

                // Выводим результат
                Display.Text = result.ToString();
                _currentInput = result.ToString(); // Сохраняем результат для дальнейших вычислений
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput = "";
            Display.Text = "";
            DisplayTop.Text = "";
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentInput.Length > 0)
            {
                _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
                Display.Text = _currentInput;
                DisplayTop.Text = _currentInput;
            }
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput += " ^ ";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void SqrtButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput = "Sqrt(" + _currentInput + ")";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void TrigButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _currentInput += button.Content.ToString() + "("; // Добавляем функцию и открывающую скобку
            _isFunctionPressed = true; // Устанавливаем флаг, что функция была нажата
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void ParenthesisButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content.ToString() == "(")
            {
                _currentInput += "(";
            }
            else if (button.Content.ToString() == ")")
            {
                _currentInput += ")";
            }

            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput = "Log10(" + _currentInput + ")";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void LnButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput = "Ln(" + _currentInput + ")";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void PiButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput += "3.14159265359";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private void EButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput += "2.71828182846";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;
        }

        private double Factorial(int number)
        {
            if (number < 0) return 0; // Ошибка для отрицательных чисел
            double result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        private void FactorialButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number = int.Parse(_currentInput);
                double result = Factorial(number);
                _currentInput = result.ToString();
                Display.Text = _currentInput;
                DisplayTop.Text = _currentInput;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double number = double.Parse(_currentInput);
                double result = number / 100;
                _currentInput = result.ToString();
                Display.Text = _currentInput;
                DisplayTop.Text = _currentInput;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}