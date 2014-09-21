using System.Collections;
using System.Collections.Generic;
using FuncSharp.ProductTypes;

namespace FuncSharp.Vectors
{
    /// <summary>
    /// Base class of all immutable vectors.
    /// </summary>
    public abstract partial class Vector : IProduct, IEnumerable<object>
    {
        /// <summary>
        /// Cached hash code of the vector (which is often used as a key in dictionaries).
        /// </summary>
        private int? hashCodeCache = null;

        /// <summary>
        /// Values of the vector.
        /// </summary>
        public abstract IEnumerable<object> Values { get; }

        /// <summary>
        /// Values of the product.
        /// </summary>
        public IEnumerable<object> ProductValues
        {
            get { return Values; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the vector values.
        /// </summary>
        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return ProductValues.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the vector values.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<object>).GetEnumerator();
        }

        public override int GetHashCode()
        {
            if (!hashCodeCache.HasValue)
            {
                hashCodeCache = this.ProductHashCode();
            }

            return hashCodeCache.Value;
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
}
