using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class Option
    {
        /// <summary>
        /// Creates a new option based on the specified value. Returns Some if the value is non-null, 
        /// None otherwise.
        /// </summary>
        public static IOption<T> Create<T>(T value)
        {
            if (value != null)
            {
                return Some<T>(value);
            }
            return None<T>();
        }

        /// <summary>
        /// Creates a new option based on the specified value. Returns Some if the value is non-null, 
        /// None otherwise.
        /// </summary>
        public static IOption<T> Create<T>(T? value)
            where T : struct
        {
            if (value.HasValue)
            {
                return Some<T>(value.Value);
            }
            return None<T>();
        }

        /// <summary>
        /// An option with value.
        /// </summary>
        public static IOption<T> Some<T>(T value)
        {
            return new Some<T>(value);
        }

        /// <summary>
        /// An empty option.
        /// </summary>
        public static IOption<T> None<T>()
        {
            return FuncSharp.None<T>.Instance;
        }
    }

    internal abstract class Option<A> : IOption<A>
    {
        /// <summary>
        /// Static initializer ensuring that option of nullable type cannot be constructed.
        /// </summary>
        static Option()
        {
            var t = typeof(A);
            if (t.IsNullable())
            {
                throw new InvalidOperationException("An option of nullable type " + t + " isn't supported.");
            }
        }

        public abstract A Value { get; }

        public abstract bool IsEmpty { get; }

        public bool NonEmpty
        {
            get { return !IsEmpty; }
        }

        public abstract IEnumerable<object> ProductValues { get; }

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

    internal class Some<A> : Option<A>
    {
        private A value;

        public Some(A a)
        {
            value = a;
        }

        public override A Value
        {
            get { return value; }
        }

        public override bool IsEmpty
        {
            get { return false; }
        }

        public override IEnumerable<object> ProductValues
        {
            get { yield return Value; }
        }
    }

    internal class None<A> : Option<A>
    {
        public static readonly None<A> Instance = new None<A>();

        private None()
        {
        }

        public override A Value
        {
            get { throw new InvalidOperationException("None does not have a value."); }
        }

        public override bool IsEmpty
        {
            get { return true; }
        }

        public override IEnumerable<object> ProductValues
        {
            get { return Enumerable.Empty<object>(); }
        }
    }
}
