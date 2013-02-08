namespace PocketCalculator
{
    internal class NullBuffer : IBuffer
    {
        public void AddToBuffer(decimal number)
        {
        }

        public decimal ApplyTo(decimal number)
        {
            return number;
        }
    }
}