namespace PocketCalculator
{
    public class CasioCalculator
    {
        private decimal _display;
        private decimal _input;
        private IBuffer _buffer;

        private readonly NullBuffer _nullBuffer;
        private AdditionBuffer _addBuffer;

        public CasioCalculator()
        {
            _nullBuffer = new NullBuffer();
            _addBuffer = new AdditionBuffer();
        }

        public string Display
        {
            get { return string.Format("{0}.", _display); }
        }

        public void PressAC()
        {
            _buffer = _nullBuffer;
        }

        public void PressDigit(Digits digit)
        {
            if (_display >= 999999999m) return;

            _input = _input * 10m + (byte) digit;
            _display = _input;
        }

        public void PressEqual()
        {
            _display = _buffer.ApplyTo(_display);
            _buffer = _nullBuffer;
            _input = 0m;
        }

        public void PressPlus()
        {
            _display = _buffer.ApplyTo(_display);
            _buffer = _addBuffer;
            _buffer.AddToBuffer(_display);
            _input = 0m;
        }

        public void PressMinus()
        {
            _display = 0m;
        }

        public void PressStar()
        {
            _display = 0m;
        }

        public void PressSlash()
        {
            _display = 0m;
        }
    }

    public class NullBuffer : IBuffer
    {
        public void AddToBuffer(decimal number)
        {
        }

        public decimal ApplyTo(decimal number)
        {
            return number;
        }
    }

    public class AdditionBuffer : IBuffer
    {
        private decimal _buffer;

        public void AddToBuffer(decimal number)
        {
            _buffer = number;
        }

        public decimal ApplyTo(decimal number)
        {
            return number + _buffer;
        }

    }

    internal interface IBuffer
    {
        void AddToBuffer(decimal number);

        decimal ApplyTo(decimal number);
    }

    public enum Digits:byte
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine
    }
}