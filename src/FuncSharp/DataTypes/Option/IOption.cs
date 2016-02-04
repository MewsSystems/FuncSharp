using System;
using System.Collections.Generic;

namespace FuncSharp
{
    public interface IOption<out A> : ICoproduct2<A, Unit>
    {
        /// <summary>
        /// Returns whether the option is empty (doesn't contain any value).
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Returns whether the option is not empty (contain a value).
        /// </summary>
        bool NonEmpty { get; }

        /// <summary>
        /// Returns value of the option if not empty.
        /// </summary>
        A Get(Func<Unit, Exception> otherwise = null);

        /// <summary>
        /// Returns value of the option if it's present. If not, returns default value of the <typeparamref name="A"/> type.
        /// </summary>
        A GetOrDefault();

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and 
        /// returns a new option with that new value.
        /// </summary>
        IOption<B> Map<B>(Func<A, B> f);

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and 
        /// returns a new option with that new value.
        /// </summary>
        IOption<B> Map<B>(Func<A, B?> f)
            where B : struct;

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and 
        /// returns that new option.
        /// </summary>
        IOption<B> FlatMap<B>(Func<A, IOption<B>> f);

        /// <summary>
        /// Retuns the current option only if its value matches the specified predicate. Otherwise returns an empty option.
        /// </summary>
        IOption<A> Where(Func<A, bool> predicate);

        /// <summary>
        /// Returns a nenumerable with the option value. If the option is empty, returns empty enumerable.
        /// </summary>
        /// <returns></returns>
        IEnumerable<A> ToEnumerable();
    }
}
