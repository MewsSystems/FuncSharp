namespace Funcsharp.Options
{
    public static class OptionExtensions
    {
        /// <summary>
        /// Turns the nullable value into an option.
        /// </summary>
        public static Option<T> ToOption<T>(this T? nullableValue)
            where T : struct
        {
            return Option.Create(nullableValue);
        }

        /// <summary>
        /// Turns the instance into an option.
        /// </summary>
        public static Option<T> ToOption<T>(this T value)
        {
            return Option.Create(value);
        }

        /// <summary>
        /// Turns the specified reference into an option.
        /// </summary>
        public static T? ToNullable<T>(this Option<T> o)
            where T : struct
        {
            if (o.NonEmpty)
            {
                return o.Get();
            }
            return null;
        }
    }
}
