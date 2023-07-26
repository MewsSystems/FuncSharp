using System;
using System.Collections.Generic;

namespace FuncSharp
{
    /// <summary>
    /// This interface serves for generic funcionality such as comparing objects, sorting etc. However it bypasses the whole point of an Option - map and Match functions for accessing value.
    /// </summary>
    public interface IOption
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
        /// Gets the value inside the option or the default for the type of the option.
        /// </summary>
        public object Value { get; }
    }

    public interface IOption<out A>
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
        /// Returns result of the first function when the option has value or the second function when option is empty.
        /// </summary>
        R Match<R>(
            Func<A, R> ifNonEmpty,
            Func<Unit, R> ifEmpty);

        /// <summary>
        /// Executes the first function when the option has value or the second function when option is empty.
        /// </summary>
        void Match(
            Action<A> ifNonEmpty = null,
            Action<Unit> ifEmpty = null);

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and 
        /// returns a new option with that new value.
        /// </summary>
        IOption<B> Map<B>(Func<A, B> f);

        /// <summary>
        /// Maps a unit in case the option is empty.
        /// </summary>
        IOption<B> MapEmpty<B>(Func<Unit, B> f);

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and 
        /// returns a flattened option. So result only has a value if both options have a value.
        /// </summary>
        IOption<B> FlatMap<B>(Func<A, IOption<B>> f);

        /// <summary>
        /// Returns an enumerable with the option value. If the option is empty, returns empty enumerable.
        /// </summary>
        /// <returns></returns>
        IEnumerable<A> ToEnumerable();
    }
}
