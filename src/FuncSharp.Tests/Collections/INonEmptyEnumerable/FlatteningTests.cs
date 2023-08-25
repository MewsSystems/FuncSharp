using System.Collections.Generic;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class FlatteningTests
    {
        [Fact]
        public void CreateFlat()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "10 potatoes"};

            var first = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes");
            var second = NonEmptyEnumerable.Create("4 potatoes", "5 potatoes", "6 potatoes");
            var third = NonEmptyEnumerable.Create("7 potatoes", "8 potatoes", "9 potatoes");
            var fourth = NonEmptyEnumerable.Create("10 potatoes");
            var result = NonEmptyEnumerable.CreateFlat(first, second, third, fourth);
            Assert.Equivalent(10, result.Count);
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public void Flatten()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "10 potatoes"};

            var first = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes");
            var second = NonEmptyEnumerable.Create("4 potatoes", "5 potatoes", "6 potatoes");
            var third = NonEmptyEnumerable.Create("7 potatoes", "8 potatoes", "9 potatoes");
            var fourth = NonEmptyEnumerable.Create("10 potatoes");
            INonEmptyEnumerable<INonEmptyEnumerable<string>> nestedEnumerable = NonEmptyEnumerable.Create(first, second, third, fourth);
            var result = nestedEnumerable.Flatten();

            Assert.Equivalent(10, result.Count);
            Assert.Equivalent(expected, result);
            Assert.Equivalent(NonEmptyEnumerable.CreateFlat(first, second, third, fourth), result);
        }
    }
}
