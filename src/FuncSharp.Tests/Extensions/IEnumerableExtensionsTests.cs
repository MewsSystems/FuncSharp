using System.Collections.Generic;
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
    }
}
