using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class TupleExtensionsTests
    {
        [Fact]
        public void ConversionToVectorWorks()
        {
            var t = Tuple.Create(42, "foo", true);
            var v = t.ToVector();
            Assert.Equal(42, v.Value1);
            Assert.Equal("foo", v.Value2);
            Assert.Equal(true, v.Value3);
        }
    }
}
