using System.Collections;
using System.Collections.Generic;

namespace FuncSharp
{
    /// <summary>
    /// Base class of all immutable products.
    /// </summary>
    public abstract partial class Product : IProduct, IEnumerable<object>
    {
        /// <summary>
        /// Cached hash code of the product (which is often used as a key in dictionaries).
        /// </summary>
        private int? hashCodeCache = null;

        /// <summary>
        /// Values of the product.
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
        /// Returns an enumerator that iterates through the product values.
        /// </summary>
        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return ProductValues.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the product values.
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
