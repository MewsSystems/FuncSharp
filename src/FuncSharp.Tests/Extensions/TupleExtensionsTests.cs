using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class TupleExtensionsTests
    {
        [Fact]
        public void ConversionToProductWorks()
        {
            var t = Tuple.Create(42, "foo", true);
            var v = t.ToProduct();
            Assert.Equal(42, v.ProductValue1);
            Assert.Equal("foo", v.ProductValue2);
            Assert.True(v.ProductValue3);
        }
    }
}
