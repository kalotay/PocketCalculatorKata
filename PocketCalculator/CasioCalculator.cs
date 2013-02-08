namespace PocketCalculator
{
    public class CasioCalculator
    {
        private decimal _numbers;
        public string Display { get { return string.Format("{0}.", _numbers); } }

        public void PressAC()
        {
            _numbers = 0m;
        }

        public void PressDigit(Digits digit)
        {
            if (_numbers >= 999999999m) return;

            _numbers = _numbers * 10m + (byte) digit;
        }

        public void PressEqual()
        {
            _numbers = 0m;
        }

        public void PressPlus()
        {
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