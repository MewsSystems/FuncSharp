namespace FuncSharp
{
    public static class NullableExtensions
    {
        /// <summary>
        /// Turns the specified value into an option.
        /// </summary>
        public static IOption<A> ToOption<A>(this A? value)
            where A : struct
        {
            return Option.Create(value);
        }
    }
}
