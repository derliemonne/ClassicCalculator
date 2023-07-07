using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ClassicCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator _calculator;

        public MainWindow()
        {
            InitializeComponent();
            _calculator = new Calculator();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            UpperDisplay.Content = _calculator.GetUpperDisplayText();
            BottomDisplay.Content = _calculator.GetBottomDisplayText();
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Backspace();
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            _calculator.ClearEntry();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Clear();
        }

        private void Negate_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Negate();
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Sqrt();
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Seven);
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Eight);
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Nine);
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Divide();
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Percent();
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Four);
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Five);
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Six);
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Multiply();
        }

        private void Reciprocate_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Reciprocate();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.One);
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Two);
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Three);
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Subtract();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Calculate();
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Digit(Digit.Zero);
        }

        private void DecimalPoint_Click(object sender, RoutedEventArgs e)
        {
            _calculator.DecimalPoint();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _calculator.Add();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _calculator.Calculate();
            }
            else if (e.Key == Key.OemPlus)
            {
                _calculator.Add();
            }
            else if (e.Key == Key.OemMinus)
            {
                _calculator.Subtract();
            }
            else if (e.Key == Key.OemQuestion)
            {
                _calculator.Divide();
            }
            else if (e.Key == Key.D8 && Keyboard.Modifiers == ModifierKeys.Shift)
            {
                _calculator.Multiply();
            }
            else if (e.Key == Key.Back)
            {
                _calculator.Backspace();
            }
            else if (e.Key == Key.D0)
            {
                _calculator.Digit(Digit.Zero);
            }
            else if (e.Key == Key.D1)
            {
                _calculator.Digit(Digit.One);
            }
            else if (e.Key == Key.D2)
            {
                _calculator.Digit(Digit.Two);
            }
            else if (e.Key == Key.D3)
            {
                _calculator.Digit(Digit.Three);
            }
            else if (e.Key == Key.D4)
            {
                _calculator.Digit(Digit.Four);
            }
            else if (e.Key == Key.D5)
            {
                _calculator.Digit(Digit.Five);
            }
            else if (e.Key == Key.D6)
            {
                _calculator.Digit(Digit.Six);
            }
            else if (e.Key == Key.D7)
            {
                _calculator.Digit(Digit.Seven);
            }
            else if (e.Key == Key.D8)
            {
                _calculator.Digit(Digit.Eight);
            }
            else if (e.Key == Key.D9)
            {
                _calculator.Digit(Digit.Nine);
            }
            else if (e.Key == Key.OemComma)
            {
                _calculator.DecimalPoint();
            }
            e.Handled = true;
        }

        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == "*")
            {
                _calculator.Multiply();
            }
            //if (e.Text == "," || e.Text == ".")
            //{
            //    _calculator.DecimalPoint();
            //}
        }
    }
}
