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
            var p0 = new SampleProductType();
            var p1 = new SampleProductType(1, "foo", null);
            var p2 = new SampleProductType(2, "bar", p1);

            Assert.Equal("SampleProductType()", p0.ToString());
            Assert.Equal("SampleProductType(1, foo, null)", p1.ToString());
            Assert.Equal("SampleProductType(2, bar, SampleProductType(1, foo, null))", p2.ToString());
        }

        [Fact]
        public void ProductHashCodeIsNotTrivial()
        {
            var p1 = new SampleProductType(1, "foo", true, null);
            var p2 = new SampleProductType(2, "bar", false, new object());
            var p3 = new SampleProductType(3, "baz", true, new object());

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
            var v1 = Product.Create(42, "foo");
            Assert.Equal(42, v1.Value1);
            Assert.Equal("foo", v1.Value2);
        }

        [Fact]
        public void ValueColllectionIsCorrect()
        {
            var v1 = Product.Create("foo", 42, "bar");
            Assert.NotNull(v1.Values);
            Assert.Equal(3, v1.Values.Count());
            Assert.Equal("foo", v1.Values.ElementAt(0));
            Assert.Equal(42, v1.Values.ElementAt(1));
            Assert.Equal("bar", v1.Values.ElementAt(2));
        }

        [Fact]
        public void ExceptValueExcludesCorrectValue()
        {
            var v = Product.Create("foo", "bar", "baz");

            var v1 = v.ExceptValue1;
            Assert.Equal("bar", v1.Value1);
            Assert.Equal("baz", v1.Value2);

            var v2 = v.ExceptValue2;
            Assert.Equal("foo", v2.Value1);
            Assert.Equal("baz", v2.Value2);
        }

        [Fact]
        public void EqualsIsStructural()
        {
            var v1 = Product.Create("foo", "bar");
            var v2 = Product.Create("foo", "bar");
            var v3 = Product.Create(12345, 67890);

            Assert.True(v1.Equals(v2));
            Assert.False(v1.Equals(v3));
        }

        [Fact]
        public void ZeroDimensionalProductsAreAlwaysEqual()
        {
            var v1 = Product.Create();
            var v2 = Product.Create();

            Assert.True(v1.Equals(v2));
        }

        [Fact]
        public void HashCodeDependsOnStructure()
        {
            var v1 = Product.Create("foo", "bar");
            var v2 = Product.Create("foo", "bar");
            var v3 = Product.Create(12345, 67890);

            Assert.True(v1.GetHashCode() == v2.GetHashCode());
            Assert.False(v1.GetHashCode() == v3.GetHashCode());
        }

        [Fact]
        public void ForEachIteratesOverProductValues()
        {
            var v = Product.Create(1, "foo", true);
            Assert.True(new object[] { 1, "foo", true }.SequenceEqual(v.ToList()));
        }

        [Fact]
        public void ConversionToTupleWorks()
        {
            var v = Product.Create(42, "foo", true);
            var t = v.ToTuple();
            Assert.Equal(42, t.Item1);
            Assert.Equal("foo", t.Item2);
            Assert.Equal(true, t.Item3);
        }
    }

    public class SampleProductType : IProduct
    {
        public SampleProductType(params object[] values)
        {
            ProductValues = values;
        }

        public IEnumerable<object> ProductValues { get; private set; }

        public override string ToString()
        {
            return this.ProductToString();
        }
        public override int GetHashCode()
        {
            return this.ProductHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.ProductEquals(obj);
        }
    }
}
