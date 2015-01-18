namespace FuncSharp
{
    internal class RightEither<A, B> : Either<A, B>
    {
        private IOption<B> value;

        public RightEither(B value)
        {
            this.value = Option.Some(value);
        }

        public override IOption<A> Left
        {
            get { return Option.None<A>(); }
        }

        public override IOption<B> Right
        {
            get { return value; }
        }
    }
}
