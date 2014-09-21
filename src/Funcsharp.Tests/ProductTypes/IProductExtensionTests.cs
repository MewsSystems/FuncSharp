using System.Collections.Generic;
using Funcsharp.ProductTypes;
using Xunit;

namespace Funcsharp.Tests.ProductTypes
{
    public class IProductExtensionTests
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
