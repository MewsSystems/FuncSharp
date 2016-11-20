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

    internal class Option<A> : Coproduct2<A, Unit>, IOption<A>
    {
        static Option()
        {
            Empty = new Option<A>();
        }

        public Option(A value)
            : base(value)
        {
        }

        private Option()
            : base(Unit.Value)
        {
        }

        public static IOption<A> Empty { get; }

        public bool IsEmpty
        {
            get { return IsSecond; }
        }

        public bool NonEmpty
        {
            get { return IsFirst; }
        }

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

        public ITry<A> ToTry(Func<Unit, Exception> otherwise)
        {
            return Match(
                a => a.ToTry(),
                _ => otherwise(_).ToTry<A>()
            );
        }

        public A GetOrDefault()
        {
            return this.GetOrElse(default(A));
        }

        public IOption<B> Map<B>(Func<A, B> f)
        {
            return FlatMap(a => Option.Valued(f(a)));
        }

        public IOption<B> Map<B>(Func<A, B?> f)
            where B : struct
        {
            return FlatMap(a => f(a).ToOption());
        }

        public IOption<B> FlatMap<B>(Func<A, IOption<B>> f)
        {
            return Match(
                a => f(a),
                _ => Option.Empty<B>()
            );
        }

        public IOption<A> Where(Func<A, bool> predicate)
        {
            return FlatMap(a => predicate(a).Match(
                t => this,
                f => Option.Empty<A>()
            ));
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
