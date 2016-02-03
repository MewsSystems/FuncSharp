using System.Collections.Generic;

namespace FuncSharp
{
    /// <summary>
    /// General representation of a relation.
    /// </summary>
    public abstract class Relation<TProduct, TDataCube>
        where TProduct : IProduct
        where TDataCube : DataCube<TProduct, Unit>, new()
    {
        /// <summary>
        /// Creates an empty relation.
        /// </summary>
        protected Relation()
        {
            Representation = new TDataCube();
        }

        /// <summary>
        /// Internal representation of the relation.
        /// </summary>
        private TDataCube Representation { get; set; }

        /// <summary>
        /// Returns whether the relation contains the specified product.
        /// </summary>
        public bool Contains(TProduct product)
        {
            return Representation.Contains(product);
        }

        /// <summary>
        /// Adds the specified product to the relation.
        /// </summary>
        public void Add(TProduct product)
        {
            Representation.Set(product, Unit.Value);
        }

        /// <summary>
        /// Adds the specified products to the relation.
        /// </summary>
        public void Add(IEnumerable<TProduct> products)
        {
            foreach (var product in products)
            {
                Add(product);
            }
        }
    }
}
