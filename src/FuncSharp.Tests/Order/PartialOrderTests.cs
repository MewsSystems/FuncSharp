using Xunit;

namespace FuncSharp.Tests
{
    public class PartialOrderTests
    {
        private static readonly PartialOrder<int> P = new PartialOrder<int>((a, b) => a < b);

        [Fact]
        public void Less()
        {
            Assert.True(P.Less(1, 3));
            Assert.False(P.Less(3, 3));
            Assert.False(P.Less(5, 3));
        }

        [Fact]
        public void LessOrEqual()
        {
            Assert.True(P.LessOrEqual(1, 3));
            Assert.True(P.LessOrEqual(3, 3));
            Assert.False(P.LessOrEqual(5, 3));
        }

        [Fact]
        public void Greater()
        {
            Assert.True(P.Greater(5, 2));
            Assert.False(P.Greater(5, 5));
            Assert.False(P.Greater(2, 10));
        }

        [Fact]
        public void GreaterOrEqual()
        {
            Assert.True(P.GreaterOrEqual(3, 1));
            Assert.True(P.GreaterOrEqual(3, 3));
            Assert.False(P.GreaterOrEqual(5, 20));
        }

        [Fact]
        public void Order()
        {
            Assert.Equivalent(new[] { 1, 3, 5, 7, 11 }, P.Order(new[] { 7, 11, 3, 5, 1 }));
            Assert.Equivalent(new[] { 11, 7, 5, 3, 1 }, P.Order(new[] { 7, 11, 3, 5, 1 }, Ordering.Descending));
        }
    }
}
