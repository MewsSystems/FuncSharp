using System;

namespace FuncSharp
{
    public static class IOptionExtensions
    {
        /// <summary>
        /// Returns value of the option if it has value. If not, returns the <paramref name="otherwise"/>.
        /// </summary>
        public static B GetOrElse<A, B>(this IOption<A> option, B otherwise)
            where A : B
        {
            return option.GetOrElse(_ => otherwise);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns value created by the otherwise function.
        /// </summary>
        public static B GetOrElse<A, B>(this IOption<A> option, Func<Unit, B> otherwise)
            where A : B
        {
            return option.Match(
                a => a,
                _ => otherwise(Unit.Value)
            );
        }

        /// <summary>
        /// Returns the option if it has value. Otherwise returns the alternative option.
        /// </summary>
        public static IOption<B> OrElse<A, B>(this IOption<A> option, Func<Unit, IOption<B>> alternative)
            where A : B
        {
            return option.Match<IOption<B>>(
                _ => option as IOption<B>,
                _ => alternative(Unit.Value)
            );
        }

        /// <summary>
        /// Returns the value of the outer option or an empty opion.
        /// </summary>
        public static IOption<A> Flatten<A>(this IOption<IOption<A>> option)
        {
            return option.FlatMap(o => o);
        }

        /// <summary>
        /// Turns the option of nullable into an option.
        /// </summary>
        public static IOption<A> Flatten<A>(this IOption<A?> option)
            where A : struct
        {
            return option.FlatMap(a => a.ToOption());
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<A>(this IOption<A> option)
            where A : struct
        {
            return option.Match<A?>(
                a => a,
                _ => null
            );
        }
    }
}
