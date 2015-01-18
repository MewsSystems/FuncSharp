namespace FuncSharp
{
    public static class Either
    {
        /// <summary>
        /// Creates a new either with the specified value on the left side.
        /// </summary>
        public static IEither<A, B> Left<A, B>(A value)
        {
            return new LeftEither<A, B>(value);
        }

        /// <summary>
        /// Creates a new either with the specified value on the right side.
        /// </summary>
        public static IEither<A, B> Right<A, B>(B value)
        {
            return new RightEither<A, B>(value);
        }
    }

    internal abstract class Either<A, B> : IEither<A, B>
    {
        public abstract IOption<A> Left { get; }
        public abstract IOption<B> Right { get; }

        public bool IsLeft
        {
            get { return Left.NonEmpty; }
        }
        public bool IsRight
        {
            get { return Right.NonEmpty; }
        }

        public int SumArity
        {
            get { return 2; }
        }
        public int SumDiscriminator
        {
            get { return this.Match(_ => 1, _ => 2); }
        }
        public object SumValue
        {
            get { return this.Match<A, B, object>(l => l, r => r); }
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
            return
                this.Match(_ => "Left", _ => "Right") + "(" +
                    SumValue.SafeToString() +
                ")";
        }
    }
}
