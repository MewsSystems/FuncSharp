namespace FuncSharp
{
    public struct TryError<E>
    {
        internal TryError(E value)
        {
            Value = value;
        }

        public E Value { get; }
    }
}