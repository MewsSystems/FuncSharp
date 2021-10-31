using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class Option
    {
        /// <summary>
        /// True value as an option.
        /// </summary>
        public static IOption<bool> True { get; } = true.ToOption();

        /// <summary>
        /// False value as an option.
        /// </summary>
        public static IOption<bool> False { get; } = false.ToOption();

        /// <summary>
        /// Creates a new option based on the specified value. Returns option with the value if is is non-null, empty otherwise.
        /// </summary>
        public static IOption<A> Create<A>(A value)
        {
            if (value != null)
            {
                return Valued(value);
            }

            return Empty<A>();
        }

        /// <summary>
        /// Creates a new option based on the specified value. Returns option with the value if is is non-null, empty otherwise.
        /// </summary>
        public static IOption<A> Create<A>(A? value)
            where A : struct
        {
            if (value.HasValue)
            {
                return Valued(value.Value);
            }
            return Empty<A>();
        }

        /// <summary>
        /// Returns an option with the specified value.
        /// </summary>
        public static IOption<A> Valued<A>(A value)
        {
            return new Option<A>(value);
        }

        /// <summary>
        /// Returns an empty option.
        /// </summary>
        public static IOption<A> Empty<A>()
        {
            return Option<A>.Empty;
        }
    }

    internal sealed class Option<A> : Coproduct2<A, Unit>, IOption<A>
    {
        public Option(A value)
        {
            Value = value;
            NonEmpty = true;
        }

        private Option()
        {
            Value = default;
            NonEmpty = false;
        }

        private A Value { get; }

        public static IOption<A> Empty { get; } = new Option<A>();

        public int CoproductArity => 2;

        public int CoproductDiscriminator => NonEmpty ? 1 : 2;

        public object CoproductValue => Value;

        public bool IsFirst => NonEmpty;

        public IOption<A> First => this;

        public bool IsSecond => !NonEmpty;

        public IOption<Unit> Second => Option<Unit>.Empty;

        public bool IsEmpty => !NonEmpty;
        
        public bool NonEmpty { get; }

        public R Match<R>(Func<A, R> ifFirst, Func<Unit, R> ifSecond)
        {
            if (NonEmpty)
            {
                return ifFirst(Value);
            }
            return ifSecond(Unit.Value);
        }

        public void Match(Action<A> ifFirst = null, Action<Unit> ifSecond = null)
        {
            if (NonEmpty)
            {
                if (ifFirst != null)
                {
                    ifFirst(Value);
                }
            }
            else
            {
                if (ifSecond != null)
                {
                    ifSecond(Unit.Value);
                }
            }
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
            if (NonEmpty)
            {
                return Value;
            }
            return default;
        }

        public IOption<B> Map<B>(Func<A, B> f)
        {
            if (NonEmpty)
            {
                return new Option<B>(f(Value));
            }
            return Option<B>.Empty;
        }

        public IOption<B> Map<B>(Func<A, B?> f) where B : struct
        {
            if (NonEmpty)
            {
                return f(Value).ToOption();
            }
            return Option.Empty<B>();
        }

        public IOption<B> FlatMap<B>(Func<A, IOption<B>> f)
        {
            if (NonEmpty)
            {
                return f(Value);
            }
            return Option<B>.Empty;
        }

        public IEnumerable<A> ToEnumerable()
        {
            if (NonEmpty)
            {
                return new[] { Value };
            }
            return Enumerable.Empty<A>();
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
            return this.CoproductHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.CoproductEquals(obj);
        }
    }
}
