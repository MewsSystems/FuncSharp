namespace FuncSharp
{
    public delegate bool TryParser<TResult>(string s, out TResult result);

    public delegate bool TryParser<TResult, A>(string s, A a, out TResult result);

    public delegate bool TryParser<TResult, A, B>(string s, A a, B b, out TResult result);

    public static class TryParserExtensions
    {
        public static IOption<TResult> ToOption<TResult>(this TryParser<TResult> tryParser, string s)
        {
            TResult result;
            if (tryParser(s, out result))
            {
                return Option.Valued(result);
            }
            return Option.Empty<TResult>();
        }

        public static IOption<TResult> ToOption<TResult, A>(this TryParser<TResult, A> tryParser, string s, A a)
        {
            TResult result;
            if (tryParser(s, a, out result))
            {
                return Option.Valued(result);
            }
            return Option.Empty<TResult>();
        }

        public static IOption<TResult> ToOption<TResult, A, B>(this TryParser<TResult, A, B> tryParser, string s, A a, B b)
        {
            TResult result;
            if (tryParser(s, a, b, out result))
            {
                return Option.Valued(result);
            }
            return Option.Empty<TResult>();
        }
    }
}
