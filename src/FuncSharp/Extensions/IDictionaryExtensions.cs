using System.Collections.Generic;

namespace FuncSharp
{
    public static class IDictionaryExtensions
    {
        public static IOption<V> Get<K, V>(this IDictionary<K, V> dictionary, K key)
        {
            if (Equals(key, null))
            {
                return Option.Empty<V>();
            }
            return new Tryer<K, V>(dictionary.TryGetValue).Invoke(key);
        }

        public static IOption<V> Get<K, V>(this IEnumerable<KeyValuePair<K, V>> collection, K key)
        {
            if (Equals(key, null))
            {
                return Option.Empty<V>();
            }
            if (collection is IDictionary<K,V>)
            {
                return Get((IDictionary<K,V>)collection, key);
            }
            if (collection is IReadOnlyDictionary<K,V>)
            {
                return new Tryer<K, V>(((IDictionary<K, V>)collection).TryGetValue).Invoke(key);
            }
            return collection.FirstOption(kvp => kvp.Key.Equals(key)).Map(kvp => kvp.Value);
        }
    }
}
