namespace FuncSharp
{
    public struct SuccessTry<A>
    {
        internal SuccessTry(A value)
        {
            Value = value;
        }

        public A Value { get; }
    }
}