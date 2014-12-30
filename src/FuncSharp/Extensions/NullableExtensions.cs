namespace FuncSharp
{
    public static class NullableExtensions
    {
        /// <summary>
        /// Turns the specified value into an option.
        /// </summary>
        public static IOption<T> ToOption<T>(this T? value)
            where T : struct
        {
            return Option.Create(value);
        }
    }
}
