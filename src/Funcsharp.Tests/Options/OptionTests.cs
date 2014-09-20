using System;
using Funcsharp.Options;
using Xunit;

namespace Funcsharp.Tests.Options
{
    public class OptionTests
    {
        [Fact]
        public void OptionOfNullableIsntSupported()
        {
            Assert.Throws<TypeInitializationException>(() => Option.None<int?>());
        }

        [Fact]
        public void CreationWorks()
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
        public void IsEmptyReturnsCorrectValues()
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
        public void ValueWorks()
        {
            Assert.Equal(Option.Create(42).Value, 42);
            Assert.Equal(Option.Create(42 as int?).Value, 42);
            Assert.Throws<InvalidOperationException>(() => Option.Create(null as int?).Value);

            var o = new object();
            Assert.Equal(Option.Create(o).Value, o);
            Assert.Throws<InvalidOperationException>(() => Option.Create(null as object).Value);

            Assert.Equal(Option.Create("foo").Value, "foo");
            Assert.Throws<InvalidOperationException>(() => Option.Create(null as string).Value);
        }
    }
}
