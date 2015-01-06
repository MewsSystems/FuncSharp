using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class VectorTests
    {
        [Fact]
        public void ConstructionPreservesValues()
        {
            var v1 = Vector.Create(42, "foo");
            Assert.Equal(42, v1.Value1);
            Assert.Equal("foo", v1.Value2);
        }

        [Fact]
        public void ValueColllectionIsCorrect()
        {
            var v1 = Vector.Create("foo", 42, "bar");
            Assert.NotNull(v1.Values);
            Assert.Equal(3, v1.Values.Count());
            Assert.Equal("foo", v1.Values.ElementAt(0));
            Assert.Equal(42, v1.Values.ElementAt(1));
            Assert.Equal("bar", v1.Values.ElementAt(2));
        }

        [Fact]
        public void ExceptValueExcludesCorrectValue()
        {
            var v = Vector.Create("foo", "bar", "baz");

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
            var v1 = Vector.Create("foo", "bar");
            var v2 = Vector.Create("foo", "bar");
            var v3 = Vector.Create(12345, 67890);

            Assert.True(v1.Equals(v2));
            Assert.False(v1.Equals(v3));
        }

        [Fact]
        public void ZeroDimensionalVectorsAreAlwaysEqual()
        {
            var v1 = Vector.Create();
            var v2 = Vector.Create();

            Assert.True(v1.Equals(v2));
        }

        [Fact]
        public void HashCodeDependsOnStructure()
        {
            var v1 = Vector.Create("foo", "bar");
            var v2 = Vector.Create("foo", "bar");
            var v3 = Vector.Create(12345, 67890);

            Assert.True(v1.GetHashCode() == v2.GetHashCode());
            Assert.False(v1.GetHashCode() == v3.GetHashCode());
        }

        [Fact]
        public void ForEachIteratesOverVectorValues()
        {
            var v = Vector.Create(1, "foo", true);
            Assert.True(new object[] { 1, "foo", true }.SequenceEqual(v.ToList()));
        }

        [Fact]
        public void ConversionToTupleWorks()
        {
            var v = Vector.Create(42, "foo", true);
            var t = v.ToTuple();
            Assert.Equal(42, t.Item1);
            Assert.Equal("foo", t.Item2);
            Assert.Equal(true, t.Item3);
        }
    }
}
