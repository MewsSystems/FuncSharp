using System;

namespace FuncSharp
{
    public interface IOption<out A> : ISum
    {
        /// <summary>
        /// Value of the option.
        /// </summary>
        A Value { get; }

        /// <summary>
        /// Returns whether the option is empty (doesn't contain any value).
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Returns whether the option contains a value.
        /// </summary>
        bool NonEmpty { get; }

        /// <summary>
        /// If the option is nonempty, invokes the <paramref name="ifSome"/> function and returns its result. Otherwise the option
        /// is empty and result of the <paramref name="ifEmpty"/> function is returned.
        /// </summary>
        R Match<R>(Func<A, R> ifSome, Func<Unit, R> ifNone);

        /// <summary>
        /// Returns value of the option if it's present. If not, returns default value of the <typeparamref name="A"/> type.
        /// </summary>
        A GetOrDefault();

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and 
        /// returns a new option with that new value.
        /// </summary>
        IOption<B> Map<B>(Func<A, B> f);

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and 
        /// returns that new option.
        /// </summary>
        IOption<B> FlatMap<B>(Func<A, IOption<B>> f);
    }

    public static class IOptionExtensions
    {
        /// <summary>
        /// Returns value of the option if it's nonempty. If not, returns value created by the otherwise function.
        /// </summary>
        public static B GetOrElse<A, B>(this IOption<A> option, Func<B> otherwise)
            where A : B
        {
            return option.Match(
                a => a,
                _ => otherwise()
            );
        }

        /// <summary>
        /// Returns the option if it's nonempty. Otherwise returns the alternative option.
        /// </summary>
        public static IOption<B> OrElse<A, B>(this IOption<A> option, Func<IOption<B>> alternative)
            where A : B
        {
            return option.Match<IOption<B>>(
                _ => option as IOption<B>,
                _ => alternative()
            );
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this IOption<A> option)
            where A : struct
        {
            return option.Match<A?>(
                a => option.Value,
                _ => null
            );
        }
    }
}
