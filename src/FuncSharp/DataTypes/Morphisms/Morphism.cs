using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncSharp
{
    public static class Morphism
    {
        /// <summary>
        /// Returns an identity morphism of the specified values.
        /// </summary>
        public static IMorphism<A, A> Identity<A>(IEnumerable<A> values)
        {
            return Create(values.Select(v => Product.Create(v, v)));
        }

        /// <summary>
        /// Returns a morphism defined by the specified mappings.
        /// </summary>
        public static IMorphism<A, B> Create<A, B>(params IProduct2<A, B>[] mappings)
        {
            return Create(mappings.AsEnumerable());
        }

        /// <summary>
        /// Returns a morphism defined by the specified mappings.
        /// </summary>
        public static IMorphism<A, B> Create<A, B>(IEnumerable<IProduct2<A, B>> mappings)
        {
            return new Morphism<A, B>(mappings);
        }

        /// <summary>
        /// Returns an isomorphism defined by the specified pairings.
        /// </summary>
        public static IIsoMorphism<A, B> CreateIso<A, B>(params IProduct2<A, B>[] pairings)
        {
            return new IsoMorphism<A, B>(pairings.AsEnumerable());
        }

        /// <summary>
        /// Returns a composition of the two morphisms.
        /// </summary>
        public static IMorphism<A, C> Compose<A, B, C>(IMorphism<A, B> m1, IMorphism<B, C> m2)
        {
            var mappings = m1.Domain.Select(a => m1.Apply(a).FlatMap(b => m2.Apply(b).Map(c => Product.Create(a, c))));
            return Create(mappings.SelectMany(m => m.ToEnumerable()));
        }
    }

    internal class Morphism<A, B> : IMorphism<A, B>
    {
        public Morphism(IEnumerable<IProduct2<A, B>> mappings)
        {
            Mappings = new DataCube1<A, B>();
            foreach (var mapping in mappings)
            {
                Mappings.SetOrElseUpdate(mapping.ProductValue1, mapping.ProductValue2, (oldValue, newValue) =>
                {
                    if (!Equals(oldValue, newValue))
                    {
                        throw new ArgumentException("Value '" + newValue.SafeToString() + "' cannot be mappend to two different values.");
                    }
                    return newValue;
                });
            }

            Domain = Mappings.Domain1;
            Range = Mappings.Values.Distinct().ToList();
        }

        public IEnumerable<A> Domain { get; private set; }
        public IEnumerable<B> Range { get; private set; }

        private DataCube1<A, B> Mappings { get; set; }

        public IOption<B> Apply(A source)
        {
            return Mappings.Get(source);
        }
    }
}
