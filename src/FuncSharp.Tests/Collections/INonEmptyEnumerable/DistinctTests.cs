using System.Collections.Generic;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class DistinctTests
    {
        [Fact]
        public void Distinct()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes" };
            var nonEmpty = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes","1 potato", "2 potatoes", "3 potatoes","1 potato", "2 potatoes", "3 potatoes");
            var result = nonEmpty.Distinct();
            
            Assert.Equal(3, result.Count);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Distinct_WithFunc()
        {
            var expected = new List<string> { "potato", "potatoes" };
            var nonEmpty = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes","1 potato", "2 potatoes", "3 potatoes","1 potato", "2 potatoes", "3 potatoes");
            var result = nonEmpty.Distinct(text => text.Substring(2));

            Assert.Equal(2, result.Count);
            Assert.Equal(expected, result);
        }
    }
}
