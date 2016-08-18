using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IOption<T>> options)
        {
            return options.SelectMany(o => o.ToEnumerable());
        }

        public static IOption<T> FirstOption<T>(this IEnumerable<T> e, Func<T, bool> predicate = null)
        {
            return e.FirstOrDefault(predicate ?? (t => true)).ToOption();
        }

        public static IOption<T> LastOption<T>(this IEnumerable<T> e, Func<T, bool> predicate = null)
        {
            return e.LastOrDefault(predicate ?? (t => true)).ToOption();
        }

        public static IOption<T> SingleOption<T>(this IEnumerable<T> e, Func<T, bool> predicate = null)
        {
            var data = e.Where(predicate ?? (t => true)).Take(2).ToList();
            if (data.Count == 2)
            {
                return Option.Empty<T>();
            }
            return data.FirstOption();
        }
    }
}
