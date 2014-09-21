using System;
using System.Collections.Generic;
using FuncSharp.ProductTypes;
using FuncSharp.Reflection;

namespace FuncSharp.Options
{
    public abstract class Option<TValue> : IProduct
    {
        /// <summary>
        /// Static initializer ensuring that option of nullable type cannot be constructed.
        /// </summary>
        static Option()
        {
            var t = typeof(TValue);
            if (t.IsNullable())
            {
                throw new InvalidOperationException("An option of nullable type " + t + " isn't supported.");
            }
        }

        /// <summary>
        /// Returns whether the option contains a value.
        /// </summary>
        public bool NonEmpty
        {
            get { return !IsEmpty; }
        }

        /// <summary>
        /// Returns whether the option is empty (doesn't contain any value).
        /// </summary>
        public abstract bool IsEmpty { get; }

        /// <summary>
        /// Values of the option as product type.
        /// </summary>
        public abstract IEnumerable<object> ProductValues { get; }

        /// <summary>
        /// Returns value of the option.
        /// </summary>
        public abstract TValue Get();

        /// <summary>
        /// Returns value of the option if it's present. If not, returns value created by the otherwise function.
        /// </summary>
        public abstract TValue GetOrElse(Func<TValue> otherwise);

        /// <summary>
        /// Returns value of the option if it's present. If not, returns default value of the <typeparamref name="TValue"/> type.
        /// </summary>
        public TValue GetOrDefault()
        {
            return GetOrElse(() => default(TValue));
        }

        /// <summary>
        /// Maps value of the current option (if present) into a new value using the specified function and 
        /// returns a new option with that new value.
        /// </summary>
        public abstract Option<TNewValue> Map<TNewValue>(Func<TValue, TNewValue> f);

        /// <summary>
        /// Maps value of the current option (if present) into a new option using the specified function and 
        /// returns that new option.
        /// </summary>
        public abstract Option<TNewValue> FlatMap<TNewValue>(Func<TValue, Option<TNewValue>> f);

        public override int GetHashCode()
        {
            return this.ProductHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.ProductEquals(obj);
        }
        public override string ToString()
        {
            return this.ProductToString();
        }
    }

    public static class Option
    {
        /// <summary>
        /// Creates a new option based on the specified value. Returns Some if the value is non-null, 
        /// None otherwise.
        /// </summary>
        public static Option<T> Create<T>(T value)
        {
            if (value != null)
            {
                return new Some<T>(value);
            }
            return None<T>();
        }

        /// <summary>
        /// Creates a new option based on the specified value. Returns Some if the value is non-null, 
        /// None otherwise.
        /// </summary>
        public static Option<T> Create<T>(T? value)
            where T : struct
        {
            if (value.HasValue)
            {
                return new Some<T>(value.Value);
            }
            return None<T>();
        }

        /// <summary>
        /// An empty option.
        /// </summary>
        public static None<T> None<T>()
        {
            return Options.None<T>.Instance;
        }
    }
}
