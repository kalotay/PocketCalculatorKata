﻿using System;

namespace PocketCalculator
{
    public class CasioCalculator
    {
        public decimal Display { get { return _mainRegister; } }

        private Func<decimal, decimal, decimal> _binaryop;
        private decimal _mainRegister;
        private decimal _auxRegitser;
        private bool _resetScan;

        public CasioCalculator()
        {
            _binaryop = null;
        }

        public void PressAC()
        {
        }

        public void PressDigit(Digits digit)
        {
            var input = (decimal)digit;


            if (_resetScan)
            {
                if (_binaryop != null && _auxRegitser == 0m)
                {
                    _auxRegitser = _mainRegister;
                }
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
            if (_binaryop != null)
            {
                _mainRegister = _binaryop(_auxRegitser, _mainRegister);
            }
            _binaryop = null;
            _resetScan = true;
            _auxRegitser = 0m;
        }

        public void PressPlus()
        {
            if (_binaryop != null)
            {
                _mainRegister = _binaryop(_auxRegitser, _mainRegister);
                _auxRegitser = 0m;
            }
            _binaryop = (a, b) => a + b;
            _resetScan = true;
        }

        public void PressMinus()
        {
            if (_binaryop != null)
            {
                _mainRegister = _binaryop(_auxRegitser, _mainRegister);
                _auxRegitser = 0m;
            }
            _binaryop = (a, b) => a - b;
            _resetScan = true;
        }

        public void PressStar()
        {
            if (_binaryop != null)
            {
                _mainRegister = _binaryop(_auxRegitser, _mainRegister);
                _auxRegitser = 0m;
            }
            _binaryop = (a, b) => a*b;
            _resetScan = true;
        }

        public void PressSlash()
        {
            if (_binaryop != null)
            {
                _mainRegister = _binaryop(_auxRegitser, _mainRegister);
                _auxRegitser = 0m;
            }
            _binaryop = (a, b) => a/b;
            _resetScan = true;
        }

        public void PressPlusMinus()
        {
            if (_binaryop != null && _resetScan)
            {
                _auxRegitser = _mainRegister;
            }
            _mainRegister = -_mainRegister;
        }

        public void PressDot()
        {
        }
    }
}