using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class CreateTests
    {
        [Fact]
        public void Create_params()
        {
            var tenStrings = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string");
            var list = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string" };
            Assert.Equal(10, tenStrings.Count);
            Assert.Equivalent(list, tenStrings);

        }

        [Fact]
        public void Create_Head_Plus_IEnumerable()
        {
            var tenStrings = NonEmptyEnumerable.Create("1 potato", Enumerable.Repeat("2 potatoes", 9));
            var list = new List<string> { "1 potato", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes"};
            Assert.Equal(10, tenStrings.Count);
            Assert.Equivalent(list, tenStrings);
        }

        [Fact]
        public void Create_Head_Plus_ReadonlyList()
        {
            var tenStrings = NonEmptyEnumerable.Create("1 potato", Enumerable.Repeat("2 potatoes", 9).ToList());
            var list = new List<string> { "1 potato", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes"};
            Assert.Equal(10, tenStrings.Count);
            Assert.Equivalent(list, tenStrings);
        }
    }
}
