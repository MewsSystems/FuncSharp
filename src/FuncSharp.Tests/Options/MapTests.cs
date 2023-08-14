using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class MapTests
    {
        public MapTests()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        internal void Map()
        {
            // Empty option mapped is always empty
            OptionAssert.IsEmpty(Option.Empty<int>().Map(v => v * 2));
            OptionAssert.IsEmpty(Option.Empty<string>().Map(v => (int?)null));

            // Valued option mapped will always have value
            OptionAssert.NonEmptyWithValue(84, 42.ToOption().Map(v => v * 2));
            OptionAssert.NonEmptyWithValue(84, 42.ToOption().Map(v => v * 2 as int?));
            OptionAssert.NonEmptyWithValue("xxxxx", 5.ToOption().Map(v => new String('x', v)));

            // Even if you map to null, the option is still valued
            OptionAssert.NonEmpty(5.ToOption().Map(v => null as int?));
            OptionAssert.NonEmpty(5.ToOption().Map(v => (string)null));
        }

        [Property]
        internal void Map_int(IOption<int> option)
        {
            AssertMapResult(option, i => i * 2);

            // Also mapping to a reference type.
            AssertMapResult(option, i => new ReferenceType(i * 2));
        }

        [Property]
        internal void Map_decimal(IOption<decimal> option)
        {
            AssertMapResult(option, d => d * 2);
        }

        [Property]
        internal void Map_double(IOption<double> option)
        {
            AssertMapResult(option, d => d * 2);
        }

        [Property]
        internal void Map_bool(IOption<bool> option)
        {
            AssertMapResult(option, b => !b);
        }

        [Property]
        internal void Map_ReferenceType(IOption<ReferenceType> option)
        {
            AssertMapResult(option, d => new ReferenceType(d.Value * 2));

            // Also mapping to a struct
            AssertMapResult(option, d => d.Value * 2);
        }

        private void AssertMapResult<T, TResult>(IOption<T> option, Func<T, TResult> map)
        {
            var result = option.Map(map);
            Assert.Equal(option.IsEmpty, result.IsEmpty);
            if (option.NonEmpty)
            {
                Assert.Equal(map(option.GetOrDefault()), result.GetOrDefault());
            }
        }
    }
}
