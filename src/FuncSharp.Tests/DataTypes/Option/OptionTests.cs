using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class OptionTests
    {
        [Fact]
        public void IsEmptyTest()
        {
            Assert.False(42.ToOption().IsEmpty);
            Assert.False((42 as int?).ToOption().IsEmpty);
            Assert.True((null as int?).ToOption().IsEmpty);

            Assert.False(new object().ToOption().IsEmpty);
            Assert.True((null as object).ToOption().IsEmpty);

            Assert.False("foo".ToOption().IsEmpty);
            Assert.True((null as string).ToOption().IsEmpty);
        }

        [Fact]
        public void ValueTest()
        {
            Assert.Equal(42, 42.ToOption().Get());
            Assert.Equal(42, (42 as int?).ToOption().Get());
            Assert.Throws<InvalidOperationException>(() => Option.Empty<int>().Get());
        }

        [Fact]
        public void OrElseTest()
        {
            Assert.Equal(Option.Valued(42), 42.ToOption().OrElse(_ => 53.ToOption()));
            Assert.Equal(Option.Valued(42), Option.Empty<int>().OrElse(_ => 42.ToOption()));
        }

        [Fact]
        public void GetOrElseTest()
        {
            Assert.Equal(42, 42.ToOption().GetOrElse(_ => 123));
            Assert.Equal(123, Option.Empty<int>().GetOrElse(_ => 123));
        }

        [Fact]
        public void GetOrDefaultTest()
        {
            Assert.Equal(42, 42.ToOption().GetOrDefault());
            Assert.Equal(0, Option.Empty<int>().GetOrDefault());
        }

        [Fact]
        public void MapTest()
        {
            Assert.Equal(84, 42.ToOption().Map(v => v * 2).Get());
            Assert.Equal("xxxxx", 5.ToOption().Map(v => new String('x', v)).Get());
            Assert.True(Option.Empty<int>().Map(v => v * 2).IsEmpty);
        }

        [Fact]
        public void NullableMapTest()
        {
            Assert.Equal(84, 42.ToOption().Map(v => v * 2 as int?).Get());
            Assert.True(5.ToOption().Map(v => null as int?).IsEmpty);
        }

        [Fact]
        public void FlatMapTest()
        {
            Assert.Equal(84, 42.ToOption().FlatMap(v => (v * 2).ToOption()).Get());
            Assert.True(42.ToOption().FlatMap(v => Option.Empty<int>()).IsEmpty);

            Assert.True(Option.Empty<int>().FlatMap(v => (v * 2).ToOption()).IsEmpty);
            Assert.True(Option.Empty<int>().FlatMap(v => Option.Empty<int>()).IsEmpty);
        }
    }
}
