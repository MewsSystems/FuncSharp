using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class ProductTests
    {
        [Fact]
        public void ProductToStringIsCorrect()
        {
            var p0 = Product0.Create();
            var p1 = Product3.Create(1, "foo", null as object);
            var p2 = Product3.Create(2, "bar", p1);

            Assert.Equal("Product0()", p0.ToString());
            Assert.Equal("Product3(1, foo, null)", p1.ToString());
            Assert.Equal("Product3(2, bar, Product3(1, foo, null))", p2.ToString());
        }

        [Fact]
        public void ProductHashCodeIsNotTrivial()
        {
            var p1 = Product4.Create(1, "foo", true, null as object);
            var p2 = Product4.Create(2, "bar", false, new object());
            var p3 = Product4.Create(3, "baz", true, new object());

            var h1 = p1.GetHashCode();
            var h2 = p2.GetHashCode();
            var h3 = p3.GetHashCode();

            // Not all of them are equal. Testing three which should minimaze probability of collision no matter
            // how it's actually implemented.
            Assert.True(h1 != h2 || h1 != h3 || h2 != h3);
        }

        [Fact]
        public void ConstructionPreservesValues()
        {
            var p1 = Product2.Create(42, "foo");
            Assert.Equal(42, p1.ProductValue1);
            Assert.Equal("foo", p1.ProductValue2);
        }

        [Fact]
        public void ValueColllectionIsCorrect()
        {
            var p1 = Product3.Create("foo", 42, "bar");
            Assert.NotNull(p1.ProductValues);
            Assert.Equal(3, p1.ProductValues.Count());
            Assert.Equal("foo", p1.ProductValues.ElementAt(0));
            Assert.Equal(42, p1.ProductValues.ElementAt(1));
            Assert.Equal("bar", p1.ProductValues.ElementAt(2));
        }

        [Fact]
        public void EqualsIsStructural()
        {
            var p1 = Product2.Create("foo", "bar");
            var p2 = Product2.Create("foo", "bar");
            var p3 = Product2.Create(12345, 67890);

            Assert.True(p1.Equals(p2));
            Assert.False(p1.Equals(p3));
        }

        [Fact]
        public void ZeroDimensionalProductsAreAlwaysEqual()
        {
            var p1 = Product0.Create();
            var p2 = Product0.Create();

            Assert.True(p1.Equals(p2));
        }

        [Fact]
        public void HashCodeDependsOnStructure()
        {
            var p1 = Product2.Create("foo", "bar");
            var p2 = Product2.Create("foo", "bar");
            var p3 = Product2.Create(12345, 67890);

            Assert.True(p1.GetHashCode() == p2.GetHashCode());
            Assert.False(p1.GetHashCode() == p3.GetHashCode());
        }

        [Fact]
        public void ConversionToTupleWorks()
        {
            var p = Product3.Create(42, "foo", true);
            var t = p.ToTuple();
            Assert.Equal(42, t.Item1);
            Assert.Equal("foo", t.Item2);
            Assert.True(t.Item3);
        }
    }
}
