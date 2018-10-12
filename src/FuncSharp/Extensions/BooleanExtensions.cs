using System;

namespace FuncSharp
{
    public static class BooleanExtensions
    {
        public static R Match<R>(this bool b, Func<Unit, R> ifTrue, Func<Unit, R> ifFalse)
        {
            return b ? ifTrue(Unit.Value) : ifFalse(Unit.Value);
        }

        public static void Match(this bool b, Action<Unit> ifTrue, Action<Unit> ifFalse)
        {
            if (b)
            {
                ifTrue(Unit.Value);
            }
            else
            {
                ifFalse(Unit.Value);
            }
        }
    }
}
