using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Returns values of the nonempty options.
        /// </summary>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IOption<T>> source)
        {
            return source.Where(o => o.NonEmpty).Select(o => o.GetOrDefault());
        }

        /// <summary>
        /// Returns the max value of the enumerable or an empty option if it is empty.
        /// </summary>
        public static IOption<TValue> SafeMax<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
        {
            return source.AsNonEmpty().Map(s => s.Max(selector));
        }

        /// <summary>
        /// Returns the min value of the enumerable or an empty option if it is empty.
        /// </summary>
        public static IOption<TValue> SafeMin<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
        {
            return source.AsNonEmpty().Map(s => s.Min(selector));
        }

        /// <summary>
        /// Returns first value or an empty option.
        /// </summary>
        public static IOption<T> FirstOption<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            var filtered = predicate is not null ? source.Where(predicate) : source;
            var data = filtered.Take(1).ToArray();
            return data.Length == 0 ? Option.Empty<T>() : Option.Valued(data[0]);
        }

        /// <summary>
        /// Returns first value or an empty option.
        /// </summary>
        public static IOption<T> FirstOptionUsingForeach<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            var filtered = predicate is not null ? source.Where(predicate) : source;
            var data = filtered.Take(1);

            foreach (var item in data)
            {
                return Option.Valued(item);
            }

            return Option.Empty<T>();
        }

        /// <summary>
        /// Returns first value or an empty option.
        /// </summary>
        public static IOption<T> FirstOptionUsingEnumerator<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            var filtered = predicate is not null ? source.Where(predicate) : source;
            var data = filtered.Take(1);

            using var enumerator = data.GetEnumerator();
            return enumerator.MoveNext()
                ? Option.Valued(enumerator.Current)
                : Option.Empty<T>();
        }

        /// <summary>
        /// Returns last value or an empty option.
        /// </summary>
        public static IOption<T> LastOption<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            return source.Reverse().FirstOption(predicate);
        }

        /// <summary>
        /// Returns the only value if the source contains just one value, otherwise an empty option.
        /// </summary>
        public static IOption<T> SingleOption<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            var filtered = predicate is not null ? source.Where(predicate) : source;
            var data = filtered.Take(2).ToArray();
            return data.Length switch
            {
                1 => Option.Valued(data[0]),
                _ => Option.Empty<T>()
            };
        }
    }
}