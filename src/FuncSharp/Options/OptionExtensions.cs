namespace FuncSharp
{
    public static class OptionExtensions
    {
        /// <summary>
        /// Turns the nullable value into an option.
        /// </summary>
        public static IOption<A> ToOption<A>(this A? nullableValue)
            where A : struct
        {
            return Option.Create(nullableValue);
        }

        /// <summary>
        /// Turns the instance into an option.
        /// </summary>
        public static IOption<A> ToOption<A>(this A value)
        {
            return Option.Create(value);
        }
    }
}
