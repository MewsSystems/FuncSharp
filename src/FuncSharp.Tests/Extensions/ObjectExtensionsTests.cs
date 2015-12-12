using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void AsSumWorks()
        {
            Assert.Equal("foo", "foo".AsSum<string, int>().First.Get());
            Assert.Equal(42, 42.AsSum<string, int>().Second.Get());
            Assert.Equal(42, 42.AsSum<int, int>().First.Get());
            Assert.Throws<ArgumentException>(() => new object().AsSum<string, int>());
        }

        [Fact]
        public void AsSafeSumWorks()
        {
            Assert.Equal("foo", "foo".AsSafeSum<string, int>().First.Get());
            Assert.Equal(42, 42.AsSafeSum<string, int>().Second.Get());
            Assert.Equal(42, 42.AsSafeSum<int, int>().First.Get());
            Assert.Equal("foo", "foo".AsSafeSum<int, int>().Third.Get());
        }
    }
}
