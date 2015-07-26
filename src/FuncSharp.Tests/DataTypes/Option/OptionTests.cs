using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class OptionTests
    {
        [Fact]
        public void OptionOfNullableIsNotSupported()
        {
            Assert.Throws<TypeInitializationException>(() => Option.Empty<int?>());
        }

        [Fact]
        public void IsEmptyTest()
        {
            Assert.False(Option.Create(42).IsEmpty);
            Assert.False(Option.Create(42 as int?).IsEmpty);
            Assert.True(Option.Create(null as int?).IsEmpty);

            Assert.False(Option.Create(new object()).IsEmpty);
            Assert.True(Option.Create(null as object).IsEmpty);

            Assert.False(Option.Create("foo").IsEmpty);
            Assert.True(Option.Create(null as string).IsEmpty);
        }

        [Fact]
        public void ValueTest()
        {
            Assert.Equal(42, Option.Create(42).Value);
            Assert.Equal(42, Option.Create(42 as int?).Value);
            Assert.Throws<InvalidOperationException>(() => Option.Empty<int>().Value);
        }

        [Fact]
        public void OrElseTest()
        {
            Assert.Equal(Option.Valued(42), Option.Create(42).OrElse(_ => Option.Create(53)));
            Assert.Equal(Option.Valued(42), Option.Empty<int>().OrElse(_ => Option.Create(42)));
        }

        [Fact]
        public void GetOrElseTest()
        {
            Assert.Equal(42, Option.Create(42).GetOrElse(_ => 123));
            Assert.Equal(123, Option.Empty<int>().GetOrElse(_ => 123));
        }

        [Fact]
        public void GetOrDefaultTest()
        {
            Assert.Equal(42, Option.Create(42).GetOrDefault());
            Assert.Equal(0, Option.Empty<int>().GetOrDefault());
        }

        [Fact]
        public void MapTest()
        {
            Assert.Equal(84, Option.Create(42).Map(v => v * 2).Value);
            Assert.Equal("xxxxx", Option.Create(5).Map(v => new String('x', v)).Value);
            Assert.True(Option.Empty<int>().Map(v => v * 2).IsEmpty);
        }

        [Fact]
        public void FlatMapTest()
        {
            Assert.Equal(84, Option.Create(42).FlatMap(v => Option.Create(v * 2)).Value);
            Assert.True(Option.Create(42).FlatMap(v => Option.Empty<int>()).IsEmpty);

            Assert.True(Option.Empty<int>().FlatMap(v => Option.Create(v * 2)).IsEmpty);
            Assert.True(Option.Empty<int>().FlatMap(v => Option.Empty<int>()).IsEmpty);
        }
    }
}
