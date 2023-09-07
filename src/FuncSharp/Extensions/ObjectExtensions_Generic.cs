using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace FuncSharp
{
    public static partial class ObjectExtensions
    {
        [Pure]
        public static INonEmptyEnumerable<T> ToEnumerable<T>(this T value)
        {
            return NonEmptyEnumerable.Create(value);
        }

        [Pure]
        public static bool SafeEquals<T>(this T t, T other)
        {
            return Equals(t, other);
        }

        [Pure]
        public static bool SafeNotEquals<T>(this T t, T other)
        {
            return !t.SafeEquals(other);
        }

        [Pure]
        public static bool SafeEquals<T>(this T t, T? other)
            where T : struct
        {
            return ((T?)t).SafeEquals(other);
        }

        [Pure]
        public static bool SafeEquals<T>(this T? t, T other)
            where T : struct
        {
            return t.SafeEquals((T?)other);
        }

        [DebuggerStepThrough]
        [Pure]
        public static void MatchRef<A>(this A a, Action<A> action = null, Action<Unit> otherwise = null)
            where A : class
        {
            if (a is not null)
            {
                if (action is not null)
                {
                    action(a);
                }
            }
            else if (otherwise is not null)
            {
                otherwise(Unit.Value);
            }
        }

        [DebuggerStepThrough]
        [Pure]
        public static bool MatchRef<A>(this A a, Func<A, bool> func)
            where A : class
        {
            return a is not null && func(a);
        }

        [DebuggerStepThrough]
        [Pure]
        public static B MatchRef<A, B>(this A a, Func<A, B> func, Func<Unit, B> otherwise)
            where A : class
        {
            if (a is not null)
            {
                return func(a);
            }
            return otherwise(Unit.Value);
        }

        [DebuggerStepThrough]
        [Pure]
        public static async Task<B> MatchRefAsync<A, B>(this A a, Func<A, Task<B>> func, Func<Unit, Task<B>> otherwise)
            where A : class
        {
            if (a is not null)
            {
                return await func(a);
            }
            return await otherwise(Unit.Value);
        }

        [DebuggerStepThrough]
        [Pure]
        public static B MapRef<A, B>(this A a, Func<A, B> func)
            where A : class
            where B : class
        {
            if (a is not null)
            {
                return func(a);
            }

            return null;
        }

        [DebuggerStepThrough]
        [Pure]
        public static async Task<B> MapRefAsync<A, B>(this A a, Func<A, Task<B>> func)
            where A : class
            where B : class
        {
            if (a is not null)
            {
                return await func(a);
            }
            return default;
        }

        [DebuggerStepThrough]
        [Pure]
         public static B? MapRefToVal<A, B>(this A a, Func<A, B> func)
            where A : class
            where B : struct
        {
            return a is not null
                ? func(a)
                : null;
        }

        [DebuggerStepThrough]
        [Pure]
        public static B? MapRefToVal<A, B>(this A a, Func<A, B?> func)
            where A : class
            where B : struct
        {
            return a is not null
                ? func(a)
                : null;
        }

        [DebuggerStepThrough]
        [Pure]
        public static void MatchVal<A>(this A? a, Action<A> action = null, Action<Unit> otherwise = null)
            where A : struct
        {
            if (a is not null)
            {
                if (action is not null)
                {
                    action(a.Value);
                }
            }
            else if (otherwise is not null)
            {
                otherwise(Unit.Value);
            }
        }

        [DebuggerStepThrough]
        [Pure]
        public static bool MatchVal<A>(this A? a, Func<A, bool> func)
            where A : struct
        {
            return a is {} value && func(value);
        }

        [DebuggerStepThrough]
        [Pure]
        public static B MatchVal<A, B>(this A? a, Func<A, B> func, Func<Unit, B> otherwise)
            where A : struct
        {
            return a is {} value
                ? func(value)
                : otherwise(Unit.Value);
        }

        [DebuggerStepThrough]
        [Pure]
        public static B? MapVal<A, B>(this A? a, Func<A, B> func)
            where A : struct
            where B : struct
        {
            return a is {} value
                ? func(value)
                : null;
        }

        [DebuggerStepThrough]
        [Pure]
        public static B? MapVal<A, B>(this A? a, Func<A, B?> func)
            where A : struct
            where B : struct
        {
            return a is {} value
                ? func(value)
                : null;
        }

        [DebuggerStepThrough]
        [Pure]
        public static B MapValToRef<A, B>(this A? a, Func<A, B> func)
            where A : struct
            where B : class
        {
            return a is {} value
                ? func(value)
                : null;
        }

        [DebuggerStepThrough]
        [Pure]
        public static async Task<B> MapValToRefAsync<A, B>(this A? a, Func<A, Task<B>> func)
            where A : struct
            where B : class
        {
            if (a is not null)
            {
                return await func(a.Value);
            }
            return default;
        }

        /// <summary>
        /// Casts the specified object to the given type.
        /// </summary>
        [Pure]
        public static Option<A> As<A>(this object o)
            where A : class
        {
            return (o as A).ToOption();
        }

        /// <summary>
        /// Returns string representation of the object. If the object is null, return the optionally specified null text.
        /// </summary>
        [Pure]
        public static string SafeToString(this object o, string nullText = "null")
        {
            if (o == null)
            {
                return nullText;
            }
            return o.ToString();
        }

        /// <summary>
        /// Turns the specified value into an option.
        /// </summary>
        [Pure]
        public static Option<A> ToOption<A>(this A value)
        {
            return Option.Create(value);
        }

        /// <summary>
        /// Turns the specified value into an option.
        /// </summary>
        public static Option<A> ToOption<A>(this A? value)
            where A : struct
        {
            return Option.Create(value);
        }

        /// <summary>
        /// Turns the specified value into a successful try.
        /// </summary>
        [Pure]
        public static Try<A, E> ToTry<A, E>(this A value)
        {
            return Try.Success<A, E>(value);
        }

        /// <summary>
        /// Turns the specified error into a try.
        /// </summary>
        [Pure]
        public static Try<A, E> ToTry<A, E>(this E e)
        {
            return Try.Error<A, E>(e);
        }
    }
}