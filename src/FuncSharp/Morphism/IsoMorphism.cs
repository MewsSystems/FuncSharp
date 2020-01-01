using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    internal class IsoMorphism<A, B> : Morphism<A, B>, IIsoMorphism<A, B>
    {
        public IsoMorphism(IEnumerable<IProduct2<A, B>> mappings)
            : base(mappings)
        {
            Inverse = Morphism.Create(mappings.Select(m => Product2.Create(m.ProductValue2, m.ProductValue1)));
        }

        public IMorphism<B, A> Inverse { get; }
    }
}
