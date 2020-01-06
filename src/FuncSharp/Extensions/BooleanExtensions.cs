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

        public static Try<A, E> ToTry<A, E>(this bool b, Func<Unit, A> success, Func<Unit, E> error)
        {
            return b.Match<Try<A, E>>(
                t => Try.Success(success(Unit.Value)),
                f => Try.Error(error(Unit.Value))
            );
        }
    }
}
