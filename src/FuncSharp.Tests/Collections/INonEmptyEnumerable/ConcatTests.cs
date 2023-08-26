using System.Collections.Generic;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class ConcatTests
    {
        [Fact]
        public void Concat_SingleItem_Plus_ParamsOfEnumerables()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes" };
            var nonEmpty = "1 potato".Concat(new List<string> { "2 potatoes", "3 potatoes" }, new List<string> { "4 potatoes", "5 potatoes" });

            Assert.Equal(5, nonEmpty.Count);
            Assert.Equal(expected, nonEmpty);
        }

        [Fact]
        public void Concat_NonEmpty_Plus_ParamsOfItems()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes" };
            var nonEmpty = "1 potato".ToEnumerable().Concat("2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes");

            Assert.Equal(5, nonEmpty.Count);
            Assert.Equal(expected, nonEmpty);
        }

        [Fact]
        public void Concat_NonEmpty_Plus_ParamsOfEnumerables()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes" };
            var nonEmpty = "1 potato".ToEnumerable().Concat(new List<string> { "2 potatoes", "3 potatoes" }, new List<string> { "4 potatoes", "5 potatoes" });

            Assert.Equal(5, nonEmpty.Count);
            Assert.Equal(expected, nonEmpty);
        }
    }
}
