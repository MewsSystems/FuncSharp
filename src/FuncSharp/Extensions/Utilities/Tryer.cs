namespace FuncSharp
{
    public delegate bool Tryer<A, TResult>(A a, out TResult result);

    public delegate bool Tryer<A, B, TResult>(A a, B b, out TResult result);

    public delegate bool Tryer<A, B, C, TResult>(A a, B b, C c, out TResult result);

    public static class Tryer
    {
        public static Option<TResult> Invoke<A, TResult>(Tryer<A, TResult> tryer, A a)
        {
            TResult result;
            if (tryer(a, out result))
            {
                return Option.Valued(result);
            }
            return Option.Empty<TResult>();
        }

        public static Option<TResult> Invoke<A, B, TResult>(Tryer<A, B, TResult> tryer, A a, B b)
        {
            TResult result;
            if (tryer(a, b, out result))
            {
                return Option.Valued(result);
            }
            return Option.Empty<TResult>();
        }

        public static Option<TResult> Invoke<A, B, C, TResult>(Tryer<A, B, C, TResult> tryer, A a, B b, C c)
        {
            TResult result;
            if (tryer(a, b, c, out result))
            {
                return Option.Valued(result);
            }
            return Option.Empty<TResult>();
        }
    }
}
