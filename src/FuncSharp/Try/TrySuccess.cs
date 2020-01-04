namespace FuncSharp
{
    public struct TrySuccess<A>
    {
        internal TrySuccess(A value)
        {
            Value = value;
        }

        public A Value { get; }
    }
}