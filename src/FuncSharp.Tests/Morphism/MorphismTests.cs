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
                Product2.Create(1, true),
                Product2.Create(1, false)
            ));
        }

        [Fact]
        public void IsoMorphismHasUniqueInverse()
        {
            Assert.Throws<ArgumentException>(() => Morphism.CreateIso(
                Product2.Create(1, true),
                Product2.Create(2, true)
            ));
        }

        [Fact]
        public void DomainRange()
        {
            var m = Morphism.Create(
                Product2.Create(1, true),
                Product2.Create(2, true),
                Product2.Create(3, false)
            );
            Assert.Equivalent(3, m.Domain.Count());
            Assert.Contains(1, m.Domain);
            Assert.Contains(2, m.Domain);
            Assert.Contains(3, m.Domain);

            Assert.Equivalent(2, m.Range.Count());
            Assert.Contains(true, m.Range);
            Assert.Contains(false, m.Range);
        }

        [Fact]
        public void Apply()
        {
            var m = Morphism.Create(
                Product2.Create("foo", 123),
                Product2.Create("bar", 456),
                Product2.Create("baz", 789)
            );
            Assert.Equivalent(123.ToOption(), m.Apply("foo"));
            Assert.Equivalent(456.ToOption(), m.Apply("bar"));
            Assert.Equivalent(789.ToOption(), m.Apply("baz"));
            Assert.True(m.Apply("xyz").IsEmpty);
        }

        [Fact]
        public void IsoMorphism()
        {
            var m = Morphism.CreateIso(
                Product2.Create(0, false),
                Product2.Create(1, true)
            );

            Assert.Equivalent(false.ToOption(), m.Apply(0));
            Assert.Equivalent(true.ToOption(), m.Apply(1));

            Assert.Equivalent(0.ToOption(), m.Inverse.Apply(false));
            Assert.Equivalent(1.ToOption(), m.Inverse.Apply(true));
        }
    }
}
