using System;
using System.Windows;
using System.Windows.Controls;
using NCalc;  // Подключаем библиотеку NCalc

namespace StylishCalculator
{
    public partial class MainWindow : Window
    {
        private string _currentInput;

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
            DisplayTop.Text = _currentInput;  // Обновляем верхний экран с текущим вводом
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _currentInput += " " + button.Content.ToString() + " ";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;  // Обновляем верхний экран с текущим вводом
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
            DisplayTop.Text = "";  // Очищаем верхний экран
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentInput.Length > 0)
            {
                _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
                Display.Text = _currentInput;
                DisplayTop.Text = _currentInput;  // Обновляем верхний экран после удаления
            }
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput += " ^ "; // Добавляем символ для возведения в степень
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;  // Обновляем верхний экран
        }

        private void SqrtButton_Click(object sender, RoutedEventArgs e)
        {
            _currentInput = "sqrt(" + _currentInput + ")";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;  // Обновляем верхний экран
        }

        private void TrigButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _currentInput = button.Content.ToString() + "(" + _currentInput + ")";
            Display.Text = _currentInput;
            DisplayTop.Text = _currentInput;  // Обновляем верхний экран
        }

        // Добавляем обработку для кнопок с открывающей и закрывающей скобкой
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
            DisplayTop.Text = _currentInput;  // Обновляем верхний экран с текущим вводом
        }
    }
}
