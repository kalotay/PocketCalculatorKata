namespace PocketCalculator
{
    public class CasioCalculator
    {
        private decimal _numbers;
        private decimal _buffer;
        public string Display { get; private set; }

        public void PressAC()
        {
            _numbers = 0m;
            GenerateDisplay(_numbers);
        }

        public void PressDigit(Digits digit)
        {
            if (_numbers >= 999999999m) return;

            _numbers = _numbers * 10m + (byte) digit;
            GenerateDisplay(_numbers);
        }

        private void GenerateDisplay(decimal numbers)
        {
            Display = string.Format("{0}.", numbers);
        }

        public void PressEqual()
        {
            _numbers += _buffer;
            GenerateDisplay(_numbers);
            _numbers = 0m;
            _buffer = 0m;
        }

        public void PressPlus()
        {
            _buffer += _numbers;
            GenerateDisplay(_buffer);
            _numbers = 0m;
        }

        public void PressMinus()
        {
            _numbers = 0m;
        }

        public void PressStar()
        {
            _numbers = 0m;
        }

        public void PressSlash()
        {
            _numbers = 0m;
        }
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