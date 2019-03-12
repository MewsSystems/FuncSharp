using System;
namespace FuncSharp
{
    public struct Success<A>
    {
        internal Success(A value)
        {
            Value = value;
        }

        public A Value { get; }
    }

    public static class Success
    {
        public static Success<A> Create<A>(A value)
        {
            return new Success<A>(value);
        }
    }
}
