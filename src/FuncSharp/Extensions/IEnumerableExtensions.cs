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
    }
}
