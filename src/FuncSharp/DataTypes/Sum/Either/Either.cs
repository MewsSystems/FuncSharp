using System;

namespace FuncSharp
{
    public static class Either
    {
        /// <summary>
        /// Creates a new either with the specified value on the left side.
        /// </summary>
        public static IEither<A, B> Left<A, B>(A value)
        {
            return new Either<A, B>(Sum.CreateFirst<A, B>(value));
        }

        /// <summary>
        /// Creates a new either with the specified value on the right side.
        /// </summary>
        public static IEither<A, B> Right<A, B>(B value)
        {
            return new Either<A, B>(Sum.CreateSecond<A, B>(value));
        }
    }

    internal class Either<A, B> : IEither<A, B>
    {
        public Either(Sum2<A, B> representation)
        {
            Representation = representation;
        }

        public bool IsLeft
        {
            get { return Representation.IsFirst; }
        }

        public bool IsRight
        {
            get { return Representation.IsSecond; }
        }

        public IOption<A> Left
        {
            get { return Representation.First; }
        }

        public IOption<B> Right
        {
            get { return Representation.Second; }
        }

        public IEither<B, A> Swapped
        {
            get
            {
                return Match(
                    r => Either.Left<B, A>(r),
                    l => Either.Right<B, A>(l)
                );
            }
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

        private Sum2<A, B> Representation { get; set; }

        public R Match<R>(Func<B, R> ifRight, Func<A, R> ifLeft)
        {
            return Representation.Match(ifLeft, ifRight);
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
            return Match(_ => "Left", _ => "Right") + "(" + SumValue.SafeToString() + ")";
        }
    }
}
