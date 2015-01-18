using System;

namespace FuncSharp
{
    public interface IOption<out A> : IProduct
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
    }

    public static class IOptionExtensions
    {
        /// <summary>
        /// If the option is nonempty, invokes the <paramref name="ifSome"/> function and returns its result. Otherwise the option
        /// is empty and result of the <paramref name="ifEmpty"/> function is returned.
        /// </summary>
        public static B Match<A, B>(this IOption<A> option, Func<A, B> ifSome, Func<Unit, B> ifEmpty)
        {
            if (option.IsEmpty)
            {
                return ifEmpty(Unit.Value);
            }
            else
            {
                return ifSome(option.Value);
            }
        }

        /// <summary>
        /// Returns value of the option.
        /// </summary>
        public static A Get<A>(this IOption<A> option)
        {
            return option.Value;
        }

        /// <summary>
        /// Returns value of the option if it's present. If not, returns default value of the <typeparamref name="A"/> type.
        /// </summary>
        public static A GetOrDefault<A>(this IOption<A> option)
        {
            return option.GetOrElse(() => default(A));
        }

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
            return option.Match(
                a => option as IOption<B>,
                _ => alternative()
            );
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and 
        /// returns a new option with that new value.
        /// </summary>
        public static IOption<B> Map<A, B>(this IOption<A> option, Func<A, B> f)
        {
            return option.FlatMap(a => Option.Some(f(a)));
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and 
        /// returns that new option.
        /// </summary>
        public static IOption<B> FlatMap<A, B>(this IOption<A> option, Func<A, IOption<B>> f)
        {
            return option.Match(
                a => f(a),
                _ => Option.None<B>()
            );
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this IOption<A> option)
            where A : struct
        {
            return option.Match<A, A?>(
                a => option.Value,
                _ => null
            );
        }
    }
}
