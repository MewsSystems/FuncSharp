using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void FirstOption()
        {
            Assert.True(new List<int>().FirstOption().IsEmpty);
            Assert.True(new List<int>().LastOption().IsEmpty);
            Assert.Equal(1.ToOption(), new List<int> { 1, 2, 3 }.FirstOption());
            Assert.Equal(3.ToOption(), new List<int> { 1, 2, 3 }.LastOption());
        }

        [Fact]
        public void Transpose()
        {
            var source = new[]
            {
                Coproduct3.CreateFirst<string, int, bool>("foo"),
                Coproduct3.CreateSecond<string, int, bool>(42),
                Coproduct3.CreateFirst<string, int, bool>("bar"),
                Coproduct3.CreateSecond<string, int, bool>(21)
            };

            var transposed = source.Transpose();
            Assert.True(transposed.ProductValue1.SequenceEqual(new[] { "foo", "bar" }));
            Assert.True(transposed.ProductValue2.SequenceEqual(new[] { 42, 21 }));
            Assert.True(transposed.ProductValue3.SequenceEqual(new bool[0]));
        }
    }
}