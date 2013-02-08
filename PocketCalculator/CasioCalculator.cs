namespace PocketCalculator
{
    public class CasioCalculator
    {
        public decimal Display { get; private set; }

        private readonly NullBuffer _nullBuffer;
        private readonly AdditionBuffer _addBuffer;
        private readonly SubtractionBuffer _subBuffer;
        private readonly MultiplicationBuffer _mulBuffer;
        private readonly DivisionBuffer _divBuffer;

        private bool _resetInput;
        private IBuffer _buffer;

        public CasioCalculator()
        {
            _nullBuffer = new NullBuffer();
            _addBuffer = new AdditionBuffer();
            _subBuffer = new SubtractionBuffer();
            _mulBuffer = new MultiplicationBuffer();
            _divBuffer = new DivisionBuffer();
        }

        public void PressAC()
        {
            _buffer = _nullBuffer;
        }

        public void PressDigit(Digits digit)
        {
            if (Display >= 999999999m) return;

            var input = (decimal) digit;
            Display = _resetInput ? input : Display * 10m + ((Display >= 0)?input:-input);
            _resetInput = false;
        }

        public void PressEqual()
        {
            Display = _buffer.ApplyTo(Display);
            _buffer = _nullBuffer;
            AddToBuffer();
        }

        public void PressPlus()
        {
            if (!_resetInput) Display = _buffer.ApplyTo(Display);
            _buffer = _addBuffer;
            AddToBuffer();
        }

        public void PressMinus()
        {
            if (!_resetInput) Display = _buffer.ApplyTo(Display);
            _buffer = _subBuffer;
            AddToBuffer();
        }

        public void PressStar()
        {
            if (!_resetInput) Display = _buffer.ApplyTo(Display);
            _buffer = _mulBuffer;
            AddToBuffer();
        }

        public void PressSlash()
        {
            if (!_resetInput) Display = _buffer.ApplyTo(Display);
            _buffer = _divBuffer;
            AddToBuffer();
        }

        public void PressPlusMinus()
        {
            Display = -Display;
        }

        private void AddToBuffer()
        {
            _buffer.AddToBuffer(Display);
            _resetInput = true;
        }
    }
}