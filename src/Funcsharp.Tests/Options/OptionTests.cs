using System;
using FuncSharp.Options;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class OptionTests
    {
        [Fact]
        public void OptionOfNullableIsntSupported()
        {
            Assert.Throws<TypeInitializationException>(() => Option.None<int?>());
        }

        [Fact]
        public void CreationTest()
        {
            Assert.IsType<Some<int>>(Option.Create(42));
            Assert.IsType<Some<int>>(Option.Create(42 as int?));
            Assert.IsType<None<int>>(Option.Create(null as int?));

            Assert.IsType<Some<object>>(Option.Create(new object()));
            Assert.IsType<None<object>>(Option.Create(null as object));

            Assert.IsType<Some<string>>(Option.Create("foo"));
            Assert.IsType<None<string>>(Option.Create(null as string));
        }

        [Fact]
        public void IsEmptyTest()
        {
            Assert.False(Option.Create(42).IsEmpty);
            Assert.False(Option.Create(42 as int?).IsEmpty);
            Assert.True(Option.None<int>().IsEmpty);
        }

        [Fact]
        public void GetTest()
        {
            Assert.Equal(42, Option.Create(42).Get());
            Assert.Equal(42, Option.Create(42 as int?).Get());
            Assert.Throws<InvalidOperationException>(() => Option.None<int>().Get());
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
            Assert.Equal(84, Option.Create(42).Map(v => v * 2).Get());
            Assert.Equal("xxxxx", Option.Create(5).Map(v => new String('x', v)).Get());
            Assert.True(Option.None<int>().Map(v => v * 2).IsEmpty);
        }

        [Fact]
        public void FlatMapTest()
        {
            Assert.Equal(84, Option.Create(42).FlatMap(v => Option.Create(v * 2)).Get());
            Assert.True(Option.Create(42).FlatMap(v => Option.None<int>()).IsEmpty);

            Assert.True(Option.None<int>().FlatMap(v => Option.Create(v * 2)).IsEmpty);
            Assert.True(Option.None<int>().FlatMap(v => Option.None<int>()).IsEmpty);
        }
    }
}
