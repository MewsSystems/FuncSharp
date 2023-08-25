using System;
using System.Threading.Tasks;
using Xunit;

namespace FuncSharp.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void Match()
        {
            Assert.Equivalent("foo", 0.Match(
                0, _ => "foo",
                1, _ => "bar"
            ));
            Assert.Equivalent("bar", 1.Match(
                0, _ => "foo",
                1, _ => "bar"
            ));
            Assert.Equivalent("baz", 2.Match(
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
        public async Task MatchAsync()
        {
            Assert.Equivalent("foo", await 0.MatchAsync(
                0, _ => Task.FromResult("foo"),
                1, _ => Task.FromResult("bar")
            ));
            
            Assert.Equivalent("baz", await 2.MatchAsync(
                0, _ => Task.FromResult("foo"),
                1, _ => Task.FromResult("bar"),
                _ => Task.FromResult("baz")
            ));

            await Assert.ThrowsAsync<ArgumentException>(async () => await 2.MatchAsync(
                0, _ => Task.FromResult("foo"),
                1, _ => Task.FromResult("bar")
            ));
        }

        [Fact]
        public void AsCoproduct()
        {
            Assert.Equivalent("foo", "foo".AsCoproduct<string, int>().First.Get());
            Assert.Equivalent(42, 42.AsCoproduct<string, int>().Second.Get());
            Assert.Equivalent(42, 42.AsCoproduct<int, int>().First.Get());
            Assert.Throws<ArgumentException>(() => new object().AsCoproduct<string, int>());

            Assert.Equivalent("foo", "foo".AsCoproduct("foo", "bar").First.Get());
            Assert.Equivalent("foo", "foo".AsCoproduct("bar", "foo").Second.Get());
            Assert.Throws<ArgumentException>(() => new object().AsCoproduct("foo", "bar"));
        }

        [Fact]
        public void AsSafeCoproduct()
        {
            Assert.Equivalent("foo", "foo".AsSafeCoproduct<string, int>().First.Get());
            Assert.Equivalent(42, 42.AsSafeCoproduct<string, int>().Second.Get());
            Assert.Equivalent(42, 42.AsSafeCoproduct<int, int>().First.Get());
            Assert.Equivalent("foo", "foo".AsSafeCoproduct<int, int>().Third.Get());

            Assert.Equivalent("foo", "foo".AsSafeCoproduct("foo", "bar").First.Get());
            Assert.Equivalent("foo", "foo".AsSafeCoproduct("bar", "foo").Second.Get());
            Assert.Equivalent("foo", "foo".AsSafeCoproduct("bar", "baz").Third.Get());
        }
    }
}
