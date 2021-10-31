using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void Match()
        {
            Assert.Equal("foo", 0.Match(
                0, _ => "foo",
                1, _ => "bar"
            ));
            Assert.Equal("bar", 1.Match(
                0, _ => "foo",
                1, _ => "bar"
            ));
            Assert.Equal("baz", 2.Match(
                0, _ => "foo",
                1, _ => "bar",
                _ => "baz"
            ));
            Assert.True(DateTimeKind.Utc.Match(DateTimeKind.Utc, _ => true));
            Assert.Throws<ArgumentException>(() => 2.Match(
                0, _ => "foo",
                1, _ => "bar"
            ));
        }

        [Fact]
        public void AsCoproduct()
        {
            Assert.Equal("foo", "foo".AsCoproduct<string, int>().First.Get());
            Assert.Equal(42, 42.AsCoproduct<string, int>().Second.Get());
            Assert.Equal(42, 42.AsCoproduct<int, int>().First.Get());
            Assert.Throws<ArgumentException>(() => new object().AsCoproduct<string, int>());

            Assert.Equal("foo", "foo".AsCoproduct("foo", "bar").First.Get());
            Assert.Equal("foo", "foo".AsCoproduct("bar", "foo").Second.Get());
            Assert.Throws<ArgumentException>(() => new object().AsCoproduct("foo", "bar"));
        }

        [Fact]
        public void AsSafeCoproduct()
        {
            Assert.Equal("foo", "foo".AsSafeCoproduct<string, int>().First.Get());
            Assert.Equal(42, 42.AsSafeCoproduct<string, int>().Second.Get());
            Assert.Equal(42, 42.AsSafeCoproduct<int, int>().First.Get());
            Assert.Equal("foo", "foo".AsSafeCoproduct<int, int>().Third.Get());

            Assert.Equal("foo", "foo".AsSafeCoproduct("foo", "bar").First.Get());
            Assert.Equal("foo", "foo".AsSafeCoproduct("bar", "foo").Second.Get());
            Assert.Equal("foo", "foo".AsSafeCoproduct("bar", "baz").Third.Get());
        }
    }
}
