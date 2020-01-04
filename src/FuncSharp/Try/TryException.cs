using System;

namespace FuncSharp
{
    public struct TryException
    {
        internal TryException(Exception value)
        {
            Value = value;
        }

        public Exception Value { get; }
    }
}