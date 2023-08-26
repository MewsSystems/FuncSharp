using System;
using System.Collections.Generic;

namespace FuncSharp
{
    public static class Option
    {
        /// <summary>
        /// True value as an option.
        /// </summary>
        public static Option<bool> True { get; } = true.ToOption();

        /// <summary>
        /// False value as an option.
        /// </summary>
        public static Option<bool> False { get; } = false.ToOption();

        /// <summary>
        /// Unit value as an option.
        /// </summary>
        public static Option<Unit> Unit { get; } = FuncSharp.Unit.Value.ToOption();

        /// <summary>
        /// Creates a new option based on the specified value. Returns option with the value if is is non-null, empty otherwise.
        /// </summary>
        public static Option<A> Create<A>(A value)
        {
            if (value is not null)
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

    public struct Option<A> : IOption
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

        public static readonly IReadOnlyList<A> EmptyList = new List<A>().AsReadOnly();

        public static Option<A> Empty { get; } = new Option<A>();

        object IOption.Value => Value;
        bool IOption.IsEmpty => IsEmpty;
        bool IOption.NonEmpty => NonEmpty;

        private A Value { get; }

        public bool NonEmpty { get; }

        public bool IsEmpty => !NonEmpty;

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

        public R Get<R>(Func<A, R> func, Func<Unit, Exception> otherwise = null)
        {
            if (NonEmpty)
            {
                return func(Value);
            }
            if (otherwise != null)
            {
                throw otherwise(Unit.Value);
            }
            throw new InvalidOperationException("An empty option does not have a value.");
        }

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

        public A GetOrDefault()
        {
            return Value;
        }

        public R GetOrDefault<R>(Func<A, R> func)
        {
            if (NonEmpty)
                return func(Value);
            return default(R);
        }

        public Option<B> Map<B>(Func<A, B> f)
        {
            if (NonEmpty)
            {
                return new Option<B>(f(Value));
            }
            return Option<B>.Empty;
        }

        public Option<B> MapEmpty<B>(Func<Unit, B> f)
        {
            if (NonEmpty)
            {
                return Option<B>.Empty;
            }
            return new Option<B>(f(Unit.Value));
        }

        public Option<B> FlatMap<B>(Func<A, Option<B>> f)
        {
            if (NonEmpty)
            {
                return f(Value);
            }
            return Option<B>.Empty;
        }

        public Option<B> FlatMap<B>(Func<A, B?> f) where B : struct
        {
            if (NonEmpty)
            {
                var result = f(Value);
                if (result is not null)
                {
                    return Option.Valued(result.Value);
                }
                return Option<B>.Empty;
            }
            return Option<B>.Empty;
        }

        public Option<B> As<B>()
        {
            return NonEmpty || Value is not B b
                ? Option<B>.Empty
                : Option.Valued(b);
        }

        public IReadOnlyList<A> ToList()
        {
            if (NonEmpty)
            {
                return new[] { Value };
            }
            return EmptyList;
        }

        public override string ToString()
        {
            if (NonEmpty)
            {
                return "Value(" + Value.SafeToString() + ")";
            }
            return "Empty";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, NonEmpty);
        }

        public static bool operator ==(Option<A> obj1, object obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Option<A> obj1, object obj2)
        {
            return !obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Option<A> other)
            {
                return NonEmpty == other.NonEmpty && Value.SafeEquals(other.GetOrDefault());
            }
            if (typeof(A) == typeof(NonEmptyString) && obj is Option<string> otherString)
            {
                return NonEmpty == otherString.NonEmpty && string.Equals(Value as NonEmptyString, otherString.GetOrDefault());
            }
            if (typeof(A) == typeof(string) && obj is Option<NonEmptyString> otherNonEmptyString)
            {
                return NonEmpty == otherNonEmptyString.NonEmpty && string.Equals(otherNonEmptyString.GetOrDefault(), Value);
            }
            return false;
        }
    }
}
