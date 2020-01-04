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

        public static Try<T> ToTry<T>(this bool b, Func<Unit, T> ifTrue, Func<Unit, Exception> ifFalse)
        {
            return b.Match<Try<T>>(
                t => Try.Success(ifTrue(Unit.Value)),
                f => Try.Exception(ifFalse(Unit.Value))
            );
        }

        public static Try<T, E> ToTry<T, E>(this bool b, Func<Unit, T> ifTrue, Func<Unit, E> ifFalse)
        {
            return b ? Try.Success<T, E>(ifTrue(Unit.Value)) : Try.Error<T, E>(ifFalse(Unit.Value));
        }
    }
}
