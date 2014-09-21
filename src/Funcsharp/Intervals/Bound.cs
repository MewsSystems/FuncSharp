using System.Collections.Generic;
using FuncSharp.ProductTypes;

namespace FuncSharp.Intervals
{
    public class Bound<T> : IProduct
    {
        /// <summary>
        /// Creates a new bound with the specified value and type.
        /// </summary>
        internal Bound(T value, BoundType type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// Value of the bound.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Type of the bound.
        /// </summary>
        public BoundType Type { get; private set; }

        /// <summary>
        /// Values of the bound as a product.
        /// </summary>
        public IEnumerable<object> ProductValues
        {
            get
            {
                yield return Value;
                yield return Type;
            }
        }

        /// <summary>
        /// Returns whether the bound is open (exclusive).
        /// </summary>
        public bool IsOpen
        {
            get { return Type == BoundType.Open; }
        }

        /// <summary>
        /// Returns whether the bound is closed (inclusive).
        /// </summary>
        public bool IsClosed
        {
            get { return Type == BoundType.Closed; }
        }

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

    public static class Bound
    {
        /// <summary>
        /// Creates a new open (exclusive) bound with the specified value.
        /// </summary>
        public static Bound<T> Open<T>(T value)
        {
            return new Bound<T>(value, BoundType.Open);
        }

        /// <summary>
        /// Creates a new closed (inclusive) bound with the specified value.
        /// </summary>
        public static Bound<T> Closed<T>(T value)
        {
            return new Bound<T>(value, BoundType.Closed);
        }
    }
}
