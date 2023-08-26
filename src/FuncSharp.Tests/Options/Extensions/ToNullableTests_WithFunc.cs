using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class ToNullableTests_WithFunc
    {
        public ToNullableTests_WithFunc()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void ToNullable_WithFunc()
        {
            Assert.Equal(1, 2.ToOption().ToNullable(v => v / 2));
            Assert.Equal(2, Unit.Value.ToOption().ToNullable(_ => 2));
            Assert.Equal(3, ((int?)1).ToOption<int?>().ToNullable(v => v * 3));
            Assert.Null(((int?)2).ToOption<int?>().ToNullable(v => (int?)null));

            Assert.Null(Option.Empty<Unit>().ToNullable(_ => 14));
            Assert.Null(Option.Empty<Unit>().ToNullable(_ => (int?)14));
        }

        [Property]
        internal void ToNullable_WithFunc_int(Option<int> option)
        {
            AssertToNullableWithFunc(option, i => i * 2);
            AssertToNullableWithFuncToNullable(option, i => (int?)i * 2);
        }

        [Property]
        internal void ToNullable_WithFunc_nullableint(Option<int?> option)
        {
            AssertToNullableWithFunc(option, i => 14);
            AssertToNullableWithFuncToNullable(option, i => (int?)i * 2);
            AssertToNullableWithFuncToNullable(option, i => (int?)null);
        }

        [Property]
        internal void ToNullable_WithFunc_decimal(Option<decimal> option)
        {
            AssertToNullableWithFunc(option, d => d * 2);
            AssertToNullableWithFuncToNullable(option, d => (decimal?)d * 2);
        }

        [Property]
        internal void ToNullable_WithFunc_double(Option<double> option)
        {
            AssertToNullableWithFunc(option, d => d * 2);
            AssertToNullableWithFuncToNullable(option, d => (double?)d * 2);
        }

        [Property]
        internal void ToNullable_WithFunc_bool(Option<bool> option)
        {
            AssertToNullableWithFunc(option, b => !b);
            AssertToNullableWithFuncToNullable(option, b => (bool?)!b);
        }

        [Property]
        internal void ToNullable_WithFunc_ReferenceType(Option<ReferenceType> option)
        {
            AssertToNullableWithFunc(option, t => t.Value * 2);
            AssertToNullableWithFuncToNullable(option, t => (int?)t.Value * 2);
            AssertToNullableWithFuncToNullable(option, t => (int?)null);
        }

        private void AssertToNullableWithFunc<T, TResult>(Option<T> option, Func<T, TResult> map)
            where TResult : struct
        {
            var result = option.ToNullable(map);
            if (option.NonEmpty)
            {
                Assert.NotNull(result);
                Assert.Equal(map(option.GetOrDefault()), result);
            }
            else
            {
                Assert.Null(result);
            }
        }

        private void AssertToNullableWithFuncToNullable<T, TResult>(Option<T> option, Func<T, TResult?> map)
            where TResult : struct
        {
            var result = option.ToNullable(map);
            if (option.NonEmpty)
            {
                Assert.Equal(map(option.GetOrDefault()), result);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}
