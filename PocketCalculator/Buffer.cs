namespace PocketCalculator
{
    internal abstract class Buffer : IBuffer
    {
        protected decimal Store;

        public void AddToBuffer(decimal number)
        {
            Store = number;
        }

        public abstract decimal ApplyTo(decimal number);
    }
}