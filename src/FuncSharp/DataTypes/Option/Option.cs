using System;

namespace FuncSharp
{
    public static class Option
    {
        /// <summary>
        /// Creates a new option based on the specified value. Returns Some if the value is non-null, None otherwise.
        /// </summary>
        public static IOption<A> Create<A>(A value)
        {
            if (value != null)
            {
                return Some(value);
            }
            return None<A>();
        }

        /// <summary>
        /// Creates a new option based on the specified value. Returns nonempty option if the value is non-null, empty otherwise.
        /// </summary>
        public static IOption<A> Create<A>(A? value)
            where A : struct
        {
            if (value.HasValue)
            {
                return Some<A>(value.Value);
            }
            return None<A>();
        }

        /// <summary>
        /// Creates an option with value.
        /// </summary>
        public static IOption<A> Some<A>(A value)
        {
            return new Option<A>(value);
        }

        /// <summary>
        /// Returns an empty option.
        /// </summary>
        public static IOption<A> None<A>()
        {
            return Option<A>.None;
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

            None = new Option<A>();
        }

        public Option(A value)
            : base(1, value)
        {
        }

        private Option()
            : base(2, Unit.Value)
        {
        }

        public static IOption<A> None { get; private set; }

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

        public bool IsSome
        {
            get { return IsFirst; }
        }

        public bool IsNone
        {
            get { return IsSecond; }
        }

        public A GetOrDefault()
        {
            return GetSumValue<A>();
        }

        public IOption<B> Map<B>(Func<A, B> f)
        {
            return FlatMap(a => Option.Some(f(a)));
        }

        public IOption<B> FlatMap<B>(Func<A, IOption<B>> f)
        {
            return Match(
                a => f(a),
                _ => Option.None<B>()
            );
        }

        public override string ToString()
        {
            return Match(
                v => "Some(" + v.SafeToString() + ")",
                _ => "None"
            );
        }
    }
}
