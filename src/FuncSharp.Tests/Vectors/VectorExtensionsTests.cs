using System;
using Xunit;

namespace FuncSharp.Vectors.Tests
{
    public class VectorExtensionsTests
    {
        [Fact]
        public void ConversionToTupleWorks()
        {
            var v = Vector.Create(42, "foo", true);
            var t = v.ToTuple();
            Assert.Equal(42, t.Item1);
            Assert.Equal("foo", t.Item2);
            Assert.Equal(true, t.Item3);
        }

        [Fact]
        public void ConversionFromTupleWorks()
        {
            var t = Tuple.Create(42, "foo", true);
            var v = t.ToVector();
            Assert.Equal(42, v.Value1);
            Assert.Equal("foo", v.Value2);
            Assert.Equal(true, v.Value3);
        }
    }
}
