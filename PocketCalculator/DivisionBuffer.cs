namespace PocketCalculator
{
    internal class DivisionBuffer : Buffer
    {
        public override decimal ApplyTo(decimal number)
        {
            return Store/number;
        }
    }
}