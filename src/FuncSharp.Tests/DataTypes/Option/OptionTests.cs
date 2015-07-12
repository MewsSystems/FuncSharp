using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class OptionTests
    {
        [Fact]
        public void OptionOfNullableIsNotSupported()
        {
            Assert.Throws<TypeInitializationException>(() => Option.None<int?>());
        }

        [Fact]
        public void IsEmptyTest()
        {
            Assert.False(Option.Create(42).IsNone);
            Assert.False(Option.Create(42 as int?).IsNone);
            Assert.True(Option.Create(null as int?).IsNone);

            Assert.False(Option.Create(new object()).IsNone);
            Assert.True(Option.Create(null as object).IsNone);

            Assert.False(Option.Create("foo").IsNone);
            Assert.True(Option.Create(null as string).IsNone);
        }

        [Fact]
        public void GetTest()
        {
            Assert.Equal(42, Option.Create(42).Value);
            Assert.Equal(42, Option.Create(42 as int?).Value);
            Assert.Throws<InvalidOperationException>(() => Option.None<int>().Value);
        }

        [Fact]
        public void OrElseTest()
        {
            Assert.Equal(Option.Some(42), Option.Create(42).OrElse(() => Option.Some(53)));
            Assert.Equal(Option.Some(42), Option.None<int>().OrElse(() => Option.Some(42)));
        }

        [Fact]
        public void GetOrElseTest()
        {
            Assert.Equal(42, Option.Create(42).GetOrElse(() => 123));
            Assert.Equal(123, Option.None<int>().GetOrElse(() => 123));
        }

        [Fact]
        public void GetOrDefaultTest()
        {
            Assert.Equal(42, Option.Create(42).GetOrDefault());
            Assert.Equal(0, Option.None<int>().GetOrDefault());
        }

        [Fact]
        public void MapTest()
        {
            Assert.Equal(84, Option.Create(42).Map(v => v * 2).Value);
            Assert.Equal("xxxxx", Option.Create(5).Map(v => new String('x', v)).Value);
            Assert.True(Option.None<int>().Map(v => v * 2).IsNone);
        }

        [Fact]
        public void FlatMapTest()
        {
            Assert.Equal(84, Option.Create(42).FlatMap(v => Option.Create(v * 2)).Value);
            Assert.True(Option.Create(42).FlatMap(v => Option.None<int>()).IsNone);

            Assert.True(Option.None<int>().FlatMap(v => Option.Create(v * 2)).IsNone);
            Assert.True(Option.None<int>().FlatMap(v => Option.None<int>()).IsNone);
        }
    }
}
