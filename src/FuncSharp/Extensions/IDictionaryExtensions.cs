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
    }
}
