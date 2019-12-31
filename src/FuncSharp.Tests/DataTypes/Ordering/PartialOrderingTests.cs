using Xunit;

namespace FuncSharp.Tests
{
    public class PartialOrderingTests
    {
        private static readonly PartialOrdering<int> Ordering = new PartialOrdering<int>((a, b) => a == b, (a, b) => a < b);

        [Fact]
        public void Less()
        {
            Assert.True(Ordering.Less(1, 3));
            Assert.False(Ordering.Less(3, 3));
            Assert.False(Ordering.Less(5, 3));
        }

        [Fact]
        public void LessOrEqual()
        {
            Assert.True(Ordering.LessOrEqual(1, 3));
            Assert.True(Ordering.LessOrEqual(3, 3));
            Assert.False(Ordering.LessOrEqual(5, 3));
        }

        [Fact]
        public void Greater()
        {
            Assert.True(Ordering.Greater(5, 2));
            Assert.False(Ordering.Greater(5, 5));
            Assert.False(Ordering.Greater(2, 10));
        }

        [Fact]
        public void GreaterOrEqual()
        {
            Assert.True(Ordering.GreaterOrEqual(3, 1));
            Assert.True(Ordering.GreaterOrEqual(3, 3));
            Assert.False(Ordering.GreaterOrEqual(5, 20));
        }

        [Fact]
        public void Order()
        {
            Assert.Equal(new[] { 1, 3, 5, 7, 11 }, Ordering.Order(new[] { 7, 11, 3, 5, 1 }));
            Assert.Equal(new[] { 11, 7, 5, 3, 1 }, Ordering.Order(new[] { 7, 11, 3, 5, 1 }, FuncSharp.Order.Descending));
        }
    }
}
