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
        /// Returns value of the option.
        /// </summary>
        public static A Get<A>(this IOption<A> option)
        {
            return option.Value;
        }

        /// <summary>
        /// Returns the option if it's nonempty. Otherwise returns the alternative option.
        /// </summary>
        public static IOption<B> OrElse<A, B>(this IOption<A> option, Func<IOption<B>> alternative)
            where A : B
        {
            if (option.IsEmpty)
            {
                return alternative();
            }
            else
            {
                return option as IOption<B>;
            }
        }

        /// <summary>
        /// Returns value of the option if it's nonempty. If not, returns value created by the otherwise function.
        /// </summary>
        public static B GetOrElse<A, B>(this IOption<A> option, Func<B> otherwise)
            where A : B
        {
            return option.OrElse(() => Option.Some(otherwise())).Value;
        }

        /// <summary>
        /// Returns value of the option if it's present. If not, returns default value of the <typeparamref name="A"/> type.
        /// </summary>
        public static A GetOrDefault<A>(this IOption<A> option)
        {
            return option.GetOrElse(() => default(A));
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and 
        /// returns that new option.
        /// </summary>
        public static IOption<B> FlatMap<A, B>(this IOption<A> option, Func<A, IOption<B>> f)
        {
            if (option.IsEmpty)
            {
                return Option.None<B>();
            }
            else
            {
                return f(option.Value);
            }
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
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this IOption<A> option)
            where A : struct
        {
            if (option.IsEmpty)
            {
                return null;
            }
            else
            {
                return option.Value;
            }
        }
    }
}
