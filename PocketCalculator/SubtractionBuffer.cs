namespace PocketCalculator
{
    internal class SubtractionBuffer : Buffer
    {
        public override decimal ApplyTo(decimal number)
        {
            return Store - number;
        }
    }
}