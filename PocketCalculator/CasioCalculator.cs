namespace PocketCalculator
{
    public class CasioCalculator
    {
        private decimal _numbers;
        public string Display { get { return string.Format("{0}.", _numbers); } }

        public void TurnOn()
        {
            _numbers = 0m;
        }

        public void PressDigit(Digits digit)
        {
            if (_numbers >= 999999999m) return;

            _numbers = _numbers * 10m + (byte) digit;
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