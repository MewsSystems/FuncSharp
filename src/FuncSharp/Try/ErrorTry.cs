namespace FuncSharp
{
    public struct ErrorTry<E>
    {
        internal ErrorTry(E value)
        {
            Value = value;
        }

        public E Value { get; }
    }
}