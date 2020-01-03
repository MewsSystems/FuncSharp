using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class Option
    {
        static Option()
        {
            True = true.ToOption();
            False = false.ToOption();
        }

        /// <summary>
        /// True value as an option.
        /// </summary>
        public static Option<bool> True { get; }

        /// <summary>
        /// False value as an option.
        /// </summary>
        public static Option<bool> False { get; }

        /// <summary>
        /// Creates a new option based on the specified value. Returns option with the value if is is non-null, empty otherwise.
        /// </summary>
        public static Option<A> Create<A>(A value)
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
        public static Option<A> Create<A>(A? value)
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

    public class Option<A> : Coproduct2<A, Unit>
    {
        static Option()
        {
            Empty = new Option<A>();
        }

        internal Option(A value)
            : base(value)
        {
        }

        private Option()
            : base(Unit.Value)
        {
        }

        public static Option<A> Empty { get; }

        /// <summary>
        /// Returns whether the option is empty (doesn't contain any value).
        /// </summary>
        public bool IsEmpty
        {
            get { return IsSecond; }
        }

        /// <summary>
        /// Returns whether the option is not empty (contain a value).
        /// </summary>
        public bool NonEmpty
        {
            get { return IsFirst; }
        }

        /// <summary>
        /// Returns value of the option if not empty.
        /// </summary>
        public A Get(Func<Unit, Exception> otherwise = null)
        {
            return this.GetOrElse<A, A>(_ =>
            {
                if (otherwise != null)
                {
                    throw otherwise(_);
                }
                else
                {
                    throw new InvalidOperationException("An empty option does not have a value.");
                }
            });
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and 
        /// returns a new option with that new value.
        /// </summary>
        public Option<B> Map<B>(Func<A, B> f)
        {
            return FlatMap(a => Option.Valued(f(a)));
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and 
        /// returns a new option with that new value.
        /// </summary>
        public Option<B> Map<B>(Func<A, B?> f)
            where B : struct
        {
            return FlatMap(a => f(a).ToOption());
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and 
        /// returns that new option.
        /// </summary>
        public Option<B> FlatMap<B>(Func<A, Option<B>> f)
        {
            return Match(
                a => f(a),
                _ => Option.Empty<B>()
            );
        }

        /// <summary>
        /// Returns an enumerable with the option value. If the option is empty, returns empty enumerable.
        /// </summary>
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
