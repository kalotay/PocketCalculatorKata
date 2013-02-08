namespace PocketCalculator
{
    public class CasioCalculator
    {
        private decimal _display;
        private decimal _input;
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
            _display = _buffer.ApplyTo(_display);
            _buffer = _subBuffer;
            _buffer.AddToBuffer(_display);
            _input = 0m;
        }

        public void PressStar()
        {
            _display = _buffer.ApplyTo(_display);
            _buffer = _mulBuffer;
            _buffer.AddToBuffer(_display);
            _input = 0m;
        }

        public void PressSlash()
        {
            _display = _buffer.ApplyTo(_display);
            _buffer = _divBuffer;
            _buffer.AddToBuffer(_display);
            _input = 0m;
        }

        public void PressPlusMinus()
        {
            _display = -_display;
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

    internal class SubtractionBuffer: Buffer
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

    public abstract class Buffer: IBuffer
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