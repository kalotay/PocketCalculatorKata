using System;

namespace PocketCalculator
{
    public class DecimalRegister
    {
        private decimal _representation;

        public void Clear()
        {
            _representation = 0m;
        }

        public void Copy(DecimalRegister other)
        {
            _representation = other._representation;
        }

        public void Add(DecimalRegister a, DecimalRegister b)
        {
            _representation = a._representation + b._representation;
        }

        public void Sub(DecimalRegister a, DecimalRegister b)
        {
            _representation = a._representation - b._representation;
        }

        public void Mul(DecimalRegister a, DecimalRegister b)
        {
            _representation = a._representation * b._representation;
        }

        public void Div(DecimalRegister a, DecimalRegister b)
        {
            _representation = a._representation / b._representation;
        }

        public void Sqrt()
        {
            _representation = (decimal) Math.Sqrt((double) _representation);
        }

        public void Push(Digits digit)
        {
            var absInput = (decimal)digit;
            var input = (_representation < 0m) ? -absInput : absInput;
            var newValue = _representation * 10m + input;

            if (newValue <= 9999999990m)
            {
                _representation = newValue;
            }
        }

        public void PushDecimalPoint()
        {}

        public decimal ToDecimal()
        {
            return _representation;
        }

        public void ChangeSign()
        {
            _representation = -_representation;
        }
    }
}