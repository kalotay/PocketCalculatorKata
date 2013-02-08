namespace PocketCalculator
{
    internal class AdditionBuffer : Buffer
    {
        public override decimal ApplyTo(decimal number)
        {
            return number + Store;
        }
    }
}