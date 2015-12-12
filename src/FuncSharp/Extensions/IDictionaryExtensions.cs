using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class IDictionaryExtensions
    {
        public static IOption<V> Get<K, V>(this IDictionary<K, V> dictionary, K key)
        {
            return new Tryer<K, V>(dictionary.TryGetValue).Invoke(key);
        }
    }
}
