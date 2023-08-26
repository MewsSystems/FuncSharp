using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class ToNullableTests
    {
        public ToNullableTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void ToNullable()
        {
            Assert.Equal(1, 1.ToOption().ToNullable());
            Assert.Equal(2, ((int?)2).ToOption<int?>().ToNullable());
            Assert.Null(Option.Valued<int?>(null).ToNullable());

            Assert.Null(Option.Empty<int>().ToNullable());
            Assert.Null(Option.Empty<int?>().ToNullable());
        }

        [Property]
        internal void ToNullable_int(Option<int> option)
        {
            AssertToNullable(option);
        }

        [Property]
        internal void ToNullable_decimal(Option<decimal> option)
        {
            AssertToNullable(option);
        }

        [Property]
        internal void ToNullable_double(Option<double> option)
        {
            AssertToNullable(option);
        }

        [Property]
        internal void ToNullable_bool(Option<bool> option)
        {
            AssertToNullable(option);
        }

        [Property]
        internal void ToNullable_nullableInt(Option<int?> option)
        {
            AssertToNullableOnNullableOption(option);
        }

        [Property]
        internal void ToNullable_nullabledecimal(Option<decimal?> option)
        {
            AssertToNullableOnNullableOption(option);
        }

        [Property]
        internal void ToNullable_nullabledouble(Option<double?> option)
        {
            AssertToNullableOnNullableOption(option);
        }

        [Property]
        internal void ToNullable_nullablebool(Option<bool?> option)
        {
            AssertToNullableOnNullableOption(option);
        }

        private void AssertToNullable<T>(Option<T> option)
            where T: struct
        {
            var result = option.ToNullable();
            if (option.NonEmpty)
            {
                Assert.NotNull(result);
                Assert.Equal(option.GetOrDefault(), result);
            }
            else
            {
                Assert.Null(result);
            }
        }

        private void AssertToNullableOnNullableOption<T>(Option<T?> option)
            where T: struct
        {
            var result = option.ToNullable();
            if (option.NonEmpty)
            {
                Assert.Equal(option.GetOrDefault(), result);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}
