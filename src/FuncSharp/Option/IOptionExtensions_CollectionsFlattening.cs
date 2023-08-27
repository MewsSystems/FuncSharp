using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static partial class OptionExtensions
    {
        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IEnumerable<A> Flatten<A>(this Option<IEnumerable<A>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : Enumerable.Empty<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyList<A> Flatten<A>(this Option<IReadOnlyList<A>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList.Empty<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyCollection<A> Flatten<A>(this Option<IReadOnlyCollection<A>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList.Empty<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyList<A> Flatten<A>(this Option<INonEmptyEnumerable<A>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList.Empty<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static A[] Flatten<A>(this Option<A[]> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : Array.Empty<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static List<A> Flatten<A>(this Option<List<A>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : new List<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IEnumerable<Value> Flatten<Key, Value>(this Option<IGrouping<Key, Value>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : Enumerable.Empty<Value>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyCollection<KeyValuePair<Key, Value>> Flatten<Key, Value>(this Option<Dictionary<Key, Value>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList.Empty<KeyValuePair<Key, Value>>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static ICollection<KeyValuePair<Key, Value>> Flatten<Key, Value>(this Option<IDictionary<Key, Value>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList<KeyValuePair<Key, Value>>.EmptyReadOnlyCollection;
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyCollection<KeyValuePair<Key, Value>> Flatten<Key, Value>(this Option<IReadOnlyDictionary<Key, Value>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList.Empty<KeyValuePair<Key, Value>>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IEnumerable<KeyValuePair<Key, Value>> Flatten<Key, Value>(this Option<IEnumerable<KeyValuePair<Key, Value>>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : Enumerable.Empty<KeyValuePair<Key, Value>>();
        }

         /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IEnumerable<A> GetOrEmpty<A>(this Option<IEnumerable<A>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : Enumerable.Empty<A>();
        }

         /// <summary>
         /// Returns the value if the option is nonempty, otherwise empty.
         /// </summary>
         public static IReadOnlyList<A> GetOrEmpty<A>(this Option<IReadOnlyList<A>> option)
         {
             return option.NonEmpty
                 ? option.GetOrDefault()
                 : ReadOnlyList.Empty<A>();
         }

         /// <summary>
         /// Returns the value if the option is nonempty, otherwise empty.
         /// </summary>
         public static IReadOnlyCollection<A> GetOrEmpty<A>(this Option<IReadOnlyCollection<A>> option)
         {
             return option.NonEmpty
                 ? option.GetOrDefault()
                 : ReadOnlyList.Empty<A>();
         }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyList<A> GetOrEmpty<A>(this Option<INonEmptyEnumerable<A>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList.Empty<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static A[] GetOrEmpty<A>(this Option<A[]> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : Array.Empty<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static List<A> GetOrEmpty<A>(this Option<List<A>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : new List<A>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IEnumerable<Value> GetOrEmpty<Key, Value>(this Option<IGrouping<Key, Value>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : Enumerable.Empty<Value>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyCollection<KeyValuePair<Key, Value>> GetOrEmpty<Key, Value>(this Option<Dictionary<Key, Value>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList.Empty<KeyValuePair<Key, Value>>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static ICollection<KeyValuePair<Key, Value>> GetOrEmpty<Key, Value>(this Option<IDictionary<Key, Value>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList<KeyValuePair<Key, Value>>.EmptyReadOnlyCollection;
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IReadOnlyCollection<KeyValuePair<Key, Value>> GetOrEmpty<Key, Value>(this Option<IReadOnlyDictionary<Key, Value>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : ReadOnlyList.Empty<KeyValuePair<Key, Value>>();
        }

        /// <summary>
        /// Returns the value if the option is nonempty, otherwise empty.
        /// </summary>
        public static IEnumerable<KeyValuePair<Key, Value>> GetOrEmpty<Key, Value>(this Option<IEnumerable<KeyValuePair<Key, Value>>> option)
        {
            return option.NonEmpty
                ? option.GetOrDefault()
                : Enumerable.Empty<KeyValuePair<Key, Value>>();
        }
    }
}
