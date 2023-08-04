using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IOptionExtensions
    {
        //TODO - boxing here
        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static Option<A> ToStructOption<A>(this IOption<A> option)
        {
            return option.Map(a => a);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static A GetOrNull<T, A>(this T option)
            where T : IOption<A>
            where A : class
        {
            return option.GetOrDefault();
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns null.
        /// </summary>
        public static R GetOrNull<T, A, R>(this T option, Func<A, R> func)
            where T : IOption<A>
            where R : class
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static int GetOrZero<T, A>(this T option, Func<A, int> func)
            where T : IOption<A>
        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns zero.
        /// </summary>
        public static decimal GetOrZero<T, A>(this T option, Func<A, decimal> func)
            where T : IOption<A>

        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns false.
        /// </summary>
        public static bool GetOrFalse<T, A>(this T option, Func<A, bool> func)
            where T : IOption<A>

        {
            return option.GetOrDefault(func);
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns the <paramref name="otherwise"/>.
        /// </summary>
        public static B GetOrElse<T, A, B>(this T option, B otherwise)
            where T : IOption<A>
            where A : B
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            return otherwise;
        }

        /// <summary>
        /// Returns value of the option if it has value. If not, returns value created by the otherwise function.
        /// </summary>
        public static B GetOrElse<T, A, B>(this T option, Func<Unit, B> otherwise)
            where T : IOption<A>
            where A : B
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            return otherwise(Unit.Value);
        }

        /// <summary>
        /// Returns the option if it has value. Otherwise returns the alternative option.
        /// </summary>
        public static Option<B> OrElse<T, A, B>(this T option, Func<Unit, Option<B>> alternative)
            where T : IOption<A>
            where A : B
        {
            if (option.NonEmpty)
            {
                return new Option<B>(option.GetOrDefault());
            }
            return alternative(Unit.Value);
        }

        // TODO - Unfortunately, C# cannot have 2 methods with the same signature with constraints being the only difference. I chose flattening of Enumerables.
        // /// <summary>
        // /// Returns the value of the outer option or an empty opion.
        // /// </summary>
        // public static Option<A> Flatten<T, A>(this T option)
        //     where T : IOption<Option<A>>
        // {
        //     if (option.NonEmpty)
        //     {
        //         return option.GetOrDefault();
        //     }
        //     return Option<A>.Empty;
        // }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty enumerable.
        /// </summary>
        public static IEnumerable<A> Flatten<T, A>(this T option)
            where T : IOption<IEnumerable<A>>
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault();
            }
            return Enumerable.Empty<A>();
        }

        /// <summary>
        /// Turns the option of nullable into an option.
        /// </summary>
        public static Option<A> Flatten<A>(this Option<A?> option)
            where A : struct
        {
            if (option.NonEmpty)
            {
                return option.GetOrDefault().ToOption();
            }
            return Option<A>.Empty;
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and
        /// returns a new option with that new value.
        /// </summary>
        public static Option<B> Select<T, A, B>(this T option, Func<A, B> f)
            where T: IOption<A>
        {
            return option.Map(f);
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and
        /// returns that new option.
        /// </summary>
        public static Option<B> SelectMany<T, A, B>(this T option, Func<A, Option<B>> f)
            where T: IOption<A>
        {
            return option.FlatMap(f);
        }

        /// <summary>
        /// Maps the current value to a new option using the specified function and combines values of both of the options.
        /// </summary>
        public static Option<B> SelectMany<T, A, X, B>(this T option, Func<A, Option<X>> f, Func<A, X, B> compose)
            where T: IOption<A>
        {
            return option.FlatMap(a => f(a).Map(x => compose(a, x)));
        }

        /// <summary>
        /// Returns the current option only if its value matches the specified predicate. Otherwise returns an empty option.
        /// </summary>
        public static Option<A> Where<T, A>(this T option, Func<A, bool> predicate)
            where T : IOption<A>
        {
            if (option.IsEmpty || !predicate(option.GetOrDefault()))
            {
                return Option.Empty<A>();
            }
            return option.Map(a => a);
        }

        // TODO - Where with Casting
        // /// <summary>
        // /// Returns the current option only if its value matches the specified predicate. Otherwise returns an empty option.
        // /// </summary>
        // public static T Where<T, A>(this T option, Func<A, bool> predicate)
        //     where T : IOption<A>
        // {
        //     if (option.IsEmpty || !predicate(option.GetOrDefault()))
        //     {
        //         return (T)(IOption<A>)Option.Empty<A>();
        //     }
        //     return option;
        // }

        /// <summary>
        /// Retuns true if value of the option matches the specified predicate. Otherwise returns false.
        /// </summary>
        public static bool Is<T, A>(this T option, Func<A, bool> predicate)
            where T : IOption<A>
        {
            if (option.NonEmpty)
                return predicate(option.GetOrDefault());
            return false;
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static A? ToNullable<T, A>(this T option)
            where T : IOption<A>
            where A : struct
        {
            if (option.NonEmpty)
                return option.GetOrDefault();
            return null;
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static B? ToNullable<T, A, B>(this T option, Func<A, B> func)
            where T : IOption<A>
            where B : struct
        {
            if (option.NonEmpty)
                return func(option.GetOrDefault());
            return null;
        }

        /// <summary>
        /// Turns the option into a nullable value.
        /// </summary>
        public static B? ToNullable<T, A, B>(this T option, Func<A, B?> func)
            where T : IOption<A>
            where B : struct
        {
            if (option.NonEmpty)
                return func(option.GetOrDefault());
            return null;
        }

        /// <summary>
        /// Turns the option into a try using the exception in case of empty option.
        /// </summary>
        public static ITry<A, E> ToTry<T, A, E>(this T option, Func<Unit, E> e)
            where T : IOption<A>
        {
            if (option.NonEmpty)
                return Try.Success<A, E>(option.GetOrDefault());

            return Try.Error<A, E>(e(Unit.Value));
        }
    }
}
