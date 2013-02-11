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
        private decimal _memoryRegister;

        public void PressAC()
        {
            _mainRegister = 0m;
            _auxRegitser = 0m;

        }

        public void PressDigit(Digits digit)
        {
            MaybeFlush();
            if (_resetScan)
            {
                _mainRegister = 0;
                _resetScan = false;
            }

            var absInput = (decimal)digit;
            var input = (_mainRegister < 0m) ? -absInput : absInput;

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

        public void PressC()
        {
            _mainRegister = 0m;
        }

        public void PressMPlus()
        {
            EvaluateBinOp();
            _memoryRegister += _mainRegister;
            _resetScan = true;
        }

        public void PressMMinus()
        {
            EvaluateBinOp();
            _memoryRegister -= _mainRegister;
            _resetScan = true;
        }

        public void PressMR()
        {
            _mainRegister = _memoryRegister;
        }

        public void PressBinaryOperation(Func<decimal, decimal, decimal> operation)
        {
            EvaluateBinOp();
            _binaryop = operation;
            _flush = true;
            _resetScan = true;
        }

        private void EvaluateBinOp()
        {
            if (_binaryop != null)
            {
                _mainRegister = _binaryop(_auxRegitser, _mainRegister);
            }
        }

        private void MaybeFlush()
        {
            if (!_flush) return;
            _auxRegitser = _mainRegister;
            _flush = false;
        }

        public void PressSqrt()
        {
            _mainRegister = (decimal)Math.Sqrt((double)_mainRegister);
        }
    }
}