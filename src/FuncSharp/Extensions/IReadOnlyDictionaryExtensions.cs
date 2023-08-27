using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace FuncSharp
{
    public static class IReadOnlyDictionaryExtensions
    {
        [Pure]
        public static Option<V> Get<K, V>(this IReadOnlyDictionary<K, V> dictionary, K key)
        {
            return key is not null && dictionary.TryGetValue(key, out var value)
                ? Option.Valued(value)
                : Option.Empty<V>();
        }
    }
}
