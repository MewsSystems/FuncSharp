using System.Collections.Generic;

namespace FuncSharp
{
    public static class IReadOnlyDictionaryExtensions
    {
        public static Option<V> Get<K, V>(this IReadOnlyDictionary<K, V> dictionary, K key)
        {
            if (Equals(key, null))
            {
                return Option.Empty<V>();
            }
            return Tryer.Invoke<K, V>(dictionary.TryGetValue, key);
        }
    }
}
