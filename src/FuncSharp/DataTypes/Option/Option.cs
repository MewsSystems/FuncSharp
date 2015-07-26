using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class Option
    {
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
                return Valued<A>(value.Value);
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

    internal class Option<A> : Sum2<A, Unit>, IOption<A>
    {
        /// <summary>
        /// Static initializer ensuring that option of nullable type cannot be constructed.
        /// </summary>
        static Option()
        {
            var t = typeof(A);
            if (t.IsNullable())
            {
                throw new InvalidOperationException("An option of nullable type " + t + " isn't supported.");
            }

            Empty = new Option<A>();
        }

        public Option(A value)
            : base(1, value)
        {
        }

        private Option()
            : base(2, Unit.Value)
        {
        }

        public static IOption<A> Empty { get; private set; }

        public A Value
        {
            get
            {
                if (IsSecond)
                {
                    throw new InvalidOperationException("An empty option does not have a value.");
                }
                return GetSumValue<A>();
            }
        }

        public bool HasValue
        {
            get { return IsFirst; }
        }

        public bool IsEmpty
        {
            get { return IsSecond; }
        }

        public A GetOrDefault()
        {
            return GetSumValue<A>();
        }

        public IOption<B> Map<B>(Func<A, B> f)
        {
            return FlatMap(a => Option.Valued(f(a)));
        }

        public IOption<B> FlatMap<B>(Func<A, IOption<B>> f)
        {
            return Match(
                a => f(a),
                _ => Option.Empty<B>()
            );
        }
        public IEnumerable<A> ToEnumerable()
        {
            return Match(
                a => new[] { a },
                _ => Enumerable.Empty<A>()
            );
        }

        public override string ToString()
        {
            return Match(
                v => "Value(" + v.SafeToString() + ")",
                _ => "Empty"
            );
        }
    }
}
