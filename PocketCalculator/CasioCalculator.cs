using System;

namespace PocketCalculator
{
    public class CasioCalculator
    {
        public decimal Display { get { return _mainRegister; } }

        private Func<decimal, decimal, decimal> _binaryop;
        private decimal _mainRegister;
        private decimal _auxRegitser;
        private bool _flush;
        private bool _resetScan;

        public void PressAC()
        {
        }

        public void PressDigit(Digits digit)
        {
            var input = (decimal)digit;

            MaybeFlush();

            if (_resetScan)
            {
                _mainRegister = 0;
                _resetScan = false;
            }

            var newValue = _mainRegister * 10m + input;

            if (newValue <= 9999999990m)
            {
                _mainRegister = newValue;
            }
        }

        public void PressEqual()
        {
            PressBinaryOperation(null);
        }

        public void PressPlus()
        {
            PressBinaryOperation((a, b) => a + b);
        }

        public void PressMinus()
        {
            PressBinaryOperation((a,b) => a - b);
        }

        public void PressStar()
        {
            PressBinaryOperation((a,b) => a * b);
        }

        public void PressSlash()
        {
            PressBinaryOperation((a,b) => a / b);
        }

        public void PressPlusMinus()
        {
            MaybeFlush();
            _mainRegister = -_mainRegister;
        }

        public void PressDot()
        {
        }

        public void PressBinaryOperation(Func<decimal, decimal, decimal> operation)
        {
            if (_binaryop != null)
            {
                _mainRegister = _binaryop(_auxRegitser, _mainRegister);
            }
            _binaryop = operation;
            _flush = true;
            _resetScan = true;
        }

        private void MaybeFlush()
        {
            if (!_flush) return;
            _auxRegitser = _mainRegister;
            _flush = false;
        }
    }
}