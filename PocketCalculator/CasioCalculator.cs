namespace PocketCalculator
{
    public class CasioCalculator
    {
        private IBuffer _buffer;

        private readonly NullBuffer _nullBuffer;
        private readonly AdditionBuffer _addBuffer;
        private readonly SubtractionBuffer _subBuffer;
        private readonly MultiplicationBuffer _mulBuffer;
        private readonly DivisionBuffer _divBuffer;

        public CasioCalculator()
        {
            _nullBuffer = new NullBuffer();
            _addBuffer = new AdditionBuffer();
            _subBuffer = new SubtractionBuffer();
            _mulBuffer = new MultiplicationBuffer();
            _divBuffer = new DivisionBuffer();
        }

        public decimal Display { get; private set; }

        private decimal _input;
        private bool _resetInput;

        public void PressAC()
        {
            _buffer = _nullBuffer;
        }

        public void PressDigit(Digits digit)
        {
            if (_resetInput) _input = 0m;

            _resetInput = false;

            if (Display >= 999999999m) return;

            _input = _input*10m + (byte) digit;
            Display = _input;
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

    internal class DivisionBuffer : Buffer
    {
        public override decimal ApplyTo(decimal number)
        {
            return Store/number;
        }
    }

    internal class MultiplicationBuffer : Buffer
    {
        public override decimal ApplyTo(decimal number)
        {
            return Store*number;
        }
    }

    internal class SubtractionBuffer : Buffer
    {
        public override decimal ApplyTo(decimal number)
        {
            return Store - number;
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

    public abstract class Buffer : IBuffer
    {
        protected decimal Store;

        public void AddToBuffer(decimal number)
        {
            Store = number;
        }

        public abstract decimal ApplyTo(decimal number);
    }

    public class AdditionBuffer : Buffer
    {
        public override decimal ApplyTo(decimal number)
        {
            return number + Store;
        }
    }

    internal interface IBuffer
    {
        void AddToBuffer(decimal number);

        decimal ApplyTo(decimal number);
    }

    public enum Digits : byte
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