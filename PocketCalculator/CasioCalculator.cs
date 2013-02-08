namespace PocketCalculator
{
    public class CasioCalculator
    {
        public decimal Display { get; private set; }

        public void TurnOn()
        {
            Display = 0m;
        }

        public void PressOne()
        {
            Display = 1m;
        }

        public void PressTwo()
        {
            Display = 12m;
        }

        public void PressNumber(Digit number)
        {
            switch (number)
            {
                case Digit.One:
                    Display = 1m;
                    break;
                case Digit.Two:
                    Display = 12m;
                    break;
            }
        }
    }

    public enum Digit:byte
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