using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class SelectTests
    {
        public SelectTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        internal void Select()
        {
            // Empty option mapped is always empty
            OptionAssert.IsEmpty(Option.Empty<int>().Select(v => v * 2));
            OptionAssert.IsEmpty(Option.Empty<string>().Select(v => (int?)null));

            // Valued option mapped will always have value
            OptionAssert.NonEmptyWithValue(84, 42.ToOption().Select(v => v * 2));
            OptionAssert.NonEmptyWithValue(84, 42.ToOption().Select(v => v * 2 as int?));
            OptionAssert.NonEmptyWithValue("xxxxx", 5.ToOption().Select(v => new String('x', v)));

            // Even if you map to null, the option is still valued
            OptionAssert.NonEmpty(5.ToOption().Select(v => null as int?));
            OptionAssert.NonEmpty(5.ToOption().Select(v => (string)null));
        }

        [Property]
        internal void Select_int(IOption<int> option)
        {
            AssertSelectResult(option, i => i * 2);

            // Also mapping to a reference type.
            AssertSelectResult(option, i => new ReferenceType(i * 2));
        }

        [Property]
        internal void Select_decimal(IOption<decimal> option)
        {
            AssertSelectResult(option, d => d * 2);
        }

        [Property]
        internal void Select_double(IOption<double> option)
        {
            AssertSelectResult(option, d => d * 2);
        }

        [Property]
        internal void Select_bool(IOption<bool> option)
        {
            AssertSelectResult(option, b => !b);
        }

        [Property]
        internal void Select_ReferenceType(IOption<ReferenceType> option)
        {
            AssertSelectResult(option, d => new ReferenceType(d.Value * 2));

            // Also mapping to a struct
            AssertSelectResult(option, d => d.Value * 2);
        }

        private void AssertSelectResult<T, TResult>(IOption<T> option, Func<T, TResult> map)
        {
            var result = option.Select(map);
            Assert.Equivalent(option.IsEmpty, result.IsEmpty);
            if (option.NonEmpty)
            {
                Assert.Equivalent(map(option.GetOrDefault()), result.GetOrDefault());
            }

            var linqResult =
                from x in option
                select map(x);
            Assert.Equivalent(result, linqResult);
        }
    }
}
