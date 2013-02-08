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
    }
}