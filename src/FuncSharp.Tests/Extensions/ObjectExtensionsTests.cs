using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void AsCoproductWorks()
        {
            Assert.Equal("foo", "foo".AsCoproduct<string, int>().First.Get());
            Assert.Equal(42, 42.AsCoproduct<string, int>().Second.Get());
            Assert.Equal(42, 42.AsCoproduct<int, int>().First.Get());
            Assert.Throws<ArgumentException>(() => new object().AsCoproduct<string, int>());
        }

        [Fact]
        public void AsSafeCoproductWorks()
        {
            Assert.Equal("foo", "foo".AsSafeCoproduct<string, int>().First.Get());
            Assert.Equal(42, 42.AsSafeCoproduct<string, int>().Second.Get());
            Assert.Equal(42, 42.AsSafeCoproduct<int, int>().First.Get());
            Assert.Equal("foo", "foo".AsSafeCoproduct<int, int>().Third.Get());
        }
    }
}
