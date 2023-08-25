using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class IsTests
    {
        public IsTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void Is()
        {
            // Flatmap to a valued option should have the value.
            OptionAssert.NonEmptyWithValue(84, 42.ToOption().FlatMap(v => (v * 2).ToOption()));

            // Flatmap to Empty option should be empty.
            OptionAssert.IsEmpty(42.ToOption().FlatMap(v => Option.Empty<int>()));

            // Flatmap on empty option is always empty.
            OptionAssert.IsEmpty(Option.Empty<int>().FlatMap(v => (v * 2).ToOption()));
            OptionAssert.IsEmpty(Option.Empty<int>().FlatMap(v => Option.Empty<int>()));
        }

        [Property]
        internal void Is_short(IOption<short> option)
        {
            AssertIs(option, i => i > 0);
        }

        [Property]
        internal void Is_int(IOption<int> option)
        {
            AssertIs(option, i => i > 1567);
        }

        [Property]
        internal void Is_long(IOption<long> option)
        {
            AssertIs(option, i => i < 1567);
        }

        [Property]
        internal void Is_decimal(IOption<decimal> option)
        {
            AssertIs(option, d => d < -1200);
        }

        [Property]
        internal void Is_double(IOption<double> option)
        {
            AssertIs(option, d => Math.Abs(d) > 14);
        }

        [Property]
        internal void Is_bool(IOption<bool> option)
        {
            AssertIs(option, b => !b);
        }

        [Property]
        internal void Is_ReferenceType(IOption<ReferenceType> option)
        {
            AssertIs(option, t => t.Value > 1567);
        }

        private void AssertIs<T>(IOption<T> option, Func<T, bool> map)
        {
            var isResult = option.Is(x => map(x));

            if (option.NonEmpty)
            {
                Assert.Equal(map(option.Get()), isResult);
            }
            else
            {
                Assert.False(isResult);
            }
        }
    }
}
