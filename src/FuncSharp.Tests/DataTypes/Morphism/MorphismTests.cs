using System;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class MorphismTests
    {
        [Fact]
        public void MorphismIsFunction()
        {
            Assert.Throws<ArgumentException>(() => Morphism.Create(
                Product.Create(1, true),
                Product.Create(1, false)
            ));
        }

        [Fact]
        public void IsoMorphismHasUniqueInverse()
        {
            Assert.Throws<ArgumentException>(() => Morphism.CreateIso(
                Product.Create(1, true),
                Product.Create(2, true)
            ));
        }

        [Fact]
        public void DomainRangeTest()
        {
            var m = Morphism.Create(
                Product.Create(1, true),
                Product.Create(2, true),
                Product.Create(3, false)
            );
            Assert.Equal(3, m.Domain.Count());
            Assert.True(m.Domain.Contains(1));
            Assert.True(m.Domain.Contains(2));
            Assert.True(m.Domain.Contains(3));

            Assert.Equal(2, m.Range.Count());
            Assert.True(m.Range.Contains(true));
            Assert.True(m.Range.Contains(false));
        }

        [Fact]
        public void ApplyTest()
        {
            var m = Morphism.Create(
                Product.Create("foo", 123),
                Product.Create("bar", 456),
                Product.Create("baz", 789)
            );
            Assert.Equal(123.ToOption(), m.Apply("foo"));
            Assert.Equal(456.ToOption(), m.Apply("bar"));
            Assert.Equal(789.ToOption(), m.Apply("baz"));
            Assert.True(m.Apply("xyz").IsEmpty);
        }

        [Fact]
        public void IsoMorphismTest()
        {
            var m = Morphism.CreateIso(
                Product.Create(0, false),
                Product.Create(1, true)
            );

            Assert.Equal(false.ToOption(), m.Apply(0));
            Assert.Equal(true.ToOption(), m.Apply(1));

            Assert.Equal(0.ToOption(), m.Inverse.Apply(false));
            Assert.Equal(1.ToOption(), m.Inverse.Apply(true));
        }
    }
}
