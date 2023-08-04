using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FuncSharp
{
    public static class Option
    {

        /// <summary>
        /// Unit value as an option.
        /// </summary>
        public static Option<Unit> Unit { get; } = Valued(FuncSharp.Unit.Value);

        /// <summary>
        /// Creates a new option based on the specified value. Returns option with the value if is is non-null, empty otherwise.
        /// </summary>
        public static Option<A> Create<A>(A value)
        {
            if (value != null)
            {
                return new Option<A>(value);
            }
            return Option<A>.Empty;
        }

        /// <summary>
        /// Creates a new option based on the specified value. Returns option with the value if is is non-null, empty otherwise.
        /// </summary>
        public static Option<A> Create<A>(A? value)
            where A : struct
        {
            if (value.HasValue)
            {
                return new Option<A>(value.Value);
            }
            return Option<A>.Empty;
        }

        /// <summary>
        /// Returns an option with the specified value.
        /// </summary>
        public static Option<A> Valued<A>(A value)
        {
            return new Option<A>(value);
        }

        /// <summary>
        /// Returns an empty option.
        /// </summary>
        public static Option<A> Empty<A>()
        {
            return Option<A>.Empty;
        }
    }

    public struct Option<A> : IOption<A>, IOption
    {
        public Option(A value)
        {
            Value = value;
            NonEmpty = true;
        }

        public Option()
        {
            Value = default;
            NonEmpty = false;
        }

        object IOption.Value => Value;

        private A Value { get; }

        public static Option<A> Empty { get; } = new Option<A>();

        public bool NonEmpty { get; }

        public bool IsEmpty => !NonEmpty;

        [Pure]
        public A GetOrDefault()
        {
            return Value;
        }

        [Pure]
        public R GetOrDefault<R>(Func<A, R> func)
        {
            if (NonEmpty)
                return func(Value);
            return default(R);
        }

        [Pure]
        public A Get(Func<Unit, Exception> otherwise = null)
        {
            if (NonEmpty)
            {
                return Value;
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new InvalidOperationException("An empty option does not have a value.");
        }

        public R Match<R>(Func<A, R> ifNonEmpty, Func<Unit, R> ifEmpty)
        {
            if (NonEmpty)
            {
                return ifNonEmpty(Value);
            }
            return ifEmpty(Unit.Value);
        }

        public void Match(Action<A> ifNonEmpty = null, Action<Unit> ifEmpty = null)
        {
            if (NonEmpty)
            {
                if (ifNonEmpty != null)
                {
                    ifNonEmpty(Value);
                }
            }
            else
            {
                if (ifEmpty != null)
                {
                    ifEmpty(Unit.Value);
                }
            }
        }

        [Pure]
        public Option<B> Map<B>(Func<A, B> f)
        {
            if (NonEmpty)
            {
                return new Option<B>(f(Value));
            }
            return Option<B>.Empty;
        }

        [Pure]
        public Option<B> MapEmpty<B>(Func<Unit, B> f)
        {
            if (IsEmpty)
            {
                return new Option<B>(f(Unit.Value));
            }
            return Option<B>.Empty;
        }

        [Pure]
        public Option<B> FlatMap<B>(Func<A, Option<B>> f)
        {
            if (NonEmpty)
            {
                return f(Value);
            }
            return Option<B>.Empty;
        }

        [Pure]
        public Option<B> FlatMap<B>(Func<A, B?> f) where B : struct
        {
            if (NonEmpty)
            {
                return f(Value).ToOption();
            }
            return Option<B>.Empty;
        }

        [Pure]
        public IEnumerable<A> ToEnumerable()
        {
            if (NonEmpty)
            {
                return new[] { Value };
            }
            return Enumerable.Empty<A>();
        }

        [Pure]
        public override string ToString()
        {
            if (NonEmpty)
            {
                return "Value(" + Value.SafeToString() + ")";
            }
            return "Empty";
        }

        [Pure]
        public override int GetHashCode()
        {
            return Structural.HashCode(NonEmpty, Value);
        }

        [Pure]
        public override bool Equals(object obj)
        {
            if (obj is Option<A> other)
            {
                return NonEmpty == other.NonEmpty && Equals(Value, other.Value);
            }
            return false;
        }
    }
}
