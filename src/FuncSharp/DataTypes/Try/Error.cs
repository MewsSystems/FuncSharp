using System;
namespace FuncSharp
{
    public struct Error<A>
    {
        internal Error(A value)
        {
            Value = value;
        }

        public A Value { get; }
    }

    public static class Error
    {
        public static Error<A> Create<A>(A value)
        {
            return new Error<A>(value);
        }
    }
}
