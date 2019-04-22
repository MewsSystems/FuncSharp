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

            source.PartitionMatch(
                f => Assert.True(f.SequenceEqual(new[] { "foo", "bar" })),
                s => Assert.True(s.SequenceEqual(new[] { 42, 21 })),
                t => Assert.True(t.SequenceEqual(new bool[0]))
            );
        }
    }
}