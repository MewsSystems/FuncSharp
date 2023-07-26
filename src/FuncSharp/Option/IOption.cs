using System;
using System.Collections.Generic;

namespace FuncSharp
{
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
        /// Returns an option of Unit if this option is empty. Or returns an empty option if this option contains value.
        /// </summary>
        IOption<Unit> Second { get; }

        /// <summary>
        /// Returns value of the option if not empty.
        /// </summary>
        A Get(Func<Unit, Exception> otherwise = null);

        /// <summary>
        /// Returns value of the option if it's present. If not, returns default value of the <typeparamref name="A"/> type.
        /// </summary>
        A GetOrDefault();

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<A, R> ifFirst,
            Func<Unit, R> ifSecond);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<A> ifFirst = null,
            Action<Unit> ifSecond = null);

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
        /// Returns an enumerable with the option value. If the option is empty, returns empty enumerable.
        /// </summary>
        /// <returns></returns>
        IEnumerable<A> ToEnumerable();
    }
}
