using System;

namespace FuncSharp
{
    public static class Option
    {
        /// <summary>
        /// Creates a new option based on the specified value. Returns Some if the value is non-null, 
        /// None otherwise.
        /// </summary>
        public static IOption<A> Create<A>(A value)
        {
            if (value != null)
            {
                return Some<A>(value);
            }
            return None<A>();
        }

        /// <summary>
        /// Creates a new option based on the specified value. Returns Some if the value is non-null, 
        /// None otherwise.
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
        /// An option with value.
        /// </summary>
        public static IOption<A> Some<A>(A value)
        {
            return new Option<A>(Sum.CreateFirst<A, Unit>(value));
        }

        /// <summary>
        /// An empty option.
        /// </summary>
        public static IOption<A> None<A>()
        {
            return Option<A>.None;
        }
    }

    internal class Option<A> : IOption<A>
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

            None = new Option<A>(Sum.CreateSecond<A, Unit>(Unit.Value));
        }

        public Option(Sum2<A, Unit> representation)
        {
            Representation = representation;
        }

        public static IOption<A> None { get; private set; }

        public A Value
        {
            get
            {
                return Match(
                    v => v,
                    _ =>
                    {
                        throw new InvalidOperationException("An empty option does not have a value.");
                    }
                );
            }
        }

        public bool IsEmpty
        {
            get { return Representation.IsSecond; }
        }

        public bool NonEmpty
        {
            get { return !IsEmpty; }
        }

        public int SumArity
        {
            get { return Representation.SumArity; }
        }
        public int SumDiscriminator
        {
            get { return Representation.SumDiscriminator; }
        }
        public object SumValue
        {
            get { return Representation.SumValue; }
        }

        private Sum2<A, Unit> Representation { get; set; }

        public R Match<R>(Func<A, R> ifSome, Func<Unit, R> ifNone)
        {
            return Representation.Match(ifSome, ifNone);
        }

        public A GetOrDefault()
        {
            return this.GetOrElse(() => default(A));
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

        public override int GetHashCode()
        {
            return this.SumHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.SumEquals(obj);
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
