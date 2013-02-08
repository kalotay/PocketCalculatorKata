namespace PocketCalculator
{
    internal class MultiplicationBuffer : Buffer
    {
        public override decimal ApplyTo(decimal number)
        {
            return Store*number;
        }
    }
}