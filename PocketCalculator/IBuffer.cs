namespace PocketCalculator
{
    internal interface IBuffer
    {
        void AddToBuffer(decimal number);

        decimal ApplyTo(decimal number);
    }
}