namespace FuncSharp
{
    internal class LeftEither<A, B> : Either<A, B>
    {
        private IOption<A> value;

        public LeftEither(A value)
        {
            this.value = Option.Some(value);
        }

        public override IOption<A> Left
        {
            get { return value; }
        }

        public override IOption<B> Right
        {
            get { return Option.None<B>(); }
        }
    }
}
