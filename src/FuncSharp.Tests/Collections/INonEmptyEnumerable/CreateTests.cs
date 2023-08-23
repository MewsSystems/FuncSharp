using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class CreateTests
    {
        [Fact]
        public void Create_From_Params()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string" };
            var tenStrings = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string");
            Assert.Equal(10, tenStrings.Count);
            Assert.Equivalent(expected, tenStrings);

        }

        [Fact]
        public void Create_From_Head_Plus_IEnumerable()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes"};
            IEnumerable<string> enumerable = Enumerable.Repeat("2 potatoes", 9);
            var tenStrings = NonEmptyEnumerable.Create("1 potato", enumerable);
            Assert.Equal(10, tenStrings.Count);
            Assert.Equivalent(expected, tenStrings);
        }

        [Fact]
        public void Create_From_Head_Plus_EnumeratedIEnumerable()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes"};
            Stack<string> stack = new Stack<string>(Enumerable.Repeat("2 potatoes", 9).ToList());
            var tenStrings = NonEmptyEnumerable.Create("1 potato", stack);
            Assert.Equal(10, tenStrings.Count);
            Assert.Equivalent(expected, tenStrings);
        }

        [Fact]
        public void Create_From_Head_Plus_List()
        {
            var expected = new List<string> { "1 potato", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes", "2 potatoes"};
            List<string> readOnlyList = Enumerable.Repeat("2 potatoes", 9).ToList();
            var tenStrings = NonEmptyEnumerable.Create("1 potato", readOnlyList);
            Assert.Equal(10, tenStrings.Count);
            Assert.Equivalent(expected, tenStrings);
        }
    }
}
