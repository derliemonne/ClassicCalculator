using System;
using System.Collections.Generic;
using System.Globalization;

namespace ClassicCalculator
{
    public enum Digit
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
    }

    public enum BinaryAction
    {
        None,
        Add,
        Subtract,
        Multiply,
        Divide,
    }

    class Calculator
    {
        public const string ZERO = "0";

        public static Dictionary<BinaryAction, string> BinaryActionDisplay = new()
        {
            { BinaryAction.Add, "+" },
            { BinaryAction.Subtract, "-" },
            { BinaryAction.Multiply, "*" },
            { BinaryAction.Divide, "/" },
        };

        private double? _bufferNumber;
        private string _activeNumber;
        private BinaryAction _binaryAction;
        private int _digitsCount = 16;

        public int DigitsCount
        {
            get => _digitsCount;
            set => _digitsCount = value;
        }

        public Calculator()
        {
            _binaryAction = BinaryAction.None;
            _activeNumber = ZERO;
        }

        public string GetUpperDisplayText()
        {
            string output = _bufferNumber?.ToString() ?? "";
            if (BinaryActionDisplay.TryGetValue(_binaryAction, out string? binaryActionDisplay) &&
                binaryActionDisplay is not null)
            {
                output += " " + binaryActionDisplay;
            }
            return output;
        }

        public string GetBottomDisplayText()
        {
            return _activeNumber;

        }

        public void Negate()
        {
            SetActiveNumberSafe(-ParseSafe(_activeNumber));
        }

        public void Clear()
        {
            _bufferNumber = null;
            _activeNumber = ZERO;
            _binaryAction = BinaryAction.None;
        }

        public void ClearEntry()
        {
            _activeNumber = ZERO;
        }

        public void Backspace()
        {
            if (_activeNumber is null)
            {
                return;
            }

            string newNumber = _activeNumber.Substring(0, _activeNumber.Length - 1);
            if (newNumber.Length == 0)
            {
                _activeNumber = ZERO;
            }
            else
            {
                SetActiveNumberSafe(ParseSafe(newNumber));
            }
        }

        public void Percent()
        {
            SetActiveNumberSafe(ParseSafe(_activeNumber) / 100.0);
        }

        public void Sqrt()
        {
            if (_activeNumber is null || _activeNumber == "") return;
            SetActiveNumberSafe(double.Sqrt(ParseSafe(_activeNumber)));
        }

        public void Divide()
        {
            _bufferNumber = ParseSafe(_activeNumber);
            _activeNumber = ZERO;
            _binaryAction = BinaryAction.Divide;
        }

        public void Multiply()
        {
            _bufferNumber = ParseSafe(_activeNumber);
            _activeNumber = ZERO;
            _binaryAction = BinaryAction.Multiply;

        }

        public void Subtract()
        {
            _bufferNumber = ParseSafe(_activeNumber);
            _activeNumber = ZERO;
            _binaryAction = BinaryAction.Subtract;
        }

        public void Add()
        {
            _bufferNumber = ParseSafe(_activeNumber);
            _activeNumber = ZERO;
            _binaryAction = BinaryAction.Add;
        }

        public void Reciprocate()
        {
            SetActiveNumberSafe(1 / ParseSafe(_activeNumber));
        }

        public void Digit(Digit digit)
        {
            _activeNumber ??= ZERO;

            string concatenated = _activeNumber + ((int)digit).ToString();
            SetActiveNumberSafe(ParseSafe(concatenated));
        }

        public void DecimalPoint()
        {
            if (_activeNumber.Contains(".") || _activeNumber.Contains(","))
            {
                return;
            }

            _activeNumber ??= ZERO;
            _activeNumber += ".";
        }

        public void Calculate()
        {
            double? result;
            double activeNumber = ParseSafe(_activeNumber);
            if (_binaryAction == BinaryAction.None)
            {
                return;
            }
            else if (_binaryAction == BinaryAction.Add)
            {
                result = _bufferNumber + activeNumber;
            }
            else if (_binaryAction == BinaryAction.Subtract)
            {
                result = _bufferNumber - activeNumber;
            }
            else if (_binaryAction == BinaryAction.Multiply)
            {
                result = _bufferNumber * activeNumber;
            }
            else if (_binaryAction == BinaryAction.Divide)
            {
                result = _bufferNumber / activeNumber;
            }
            else
            {
                throw new ArgumentException("BinaryAction does not handle all its possible values.");
            }

            if (result is null)
            {
                throw new Exception("Internal Error. Result is null.");
            }
            else
            {
                SetActiveNumberSafe(result.Value);
            }
            _bufferNumber = null;
            _binaryAction = BinaryAction.None;
        }

        private double ParseSafe(string number)
        {
            if (double.TryParse(number, CultureInfo.InvariantCulture, out double parsed))
            {
                return parsed;
            }
            else
            {
#if (DEBUG)
                // Should never execute.
                throw new FormatException("Internal error.");
#else
                return 0;
#endif
            }
        }

        private void SetActiveNumberSafe(double number)
        {
            _activeNumber = number.ToString(CultureInfo.InvariantCulture);
        }
    }
}
