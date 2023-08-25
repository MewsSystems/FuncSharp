using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class WhereTests
    {
        public WhereTests()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void Where()
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
        internal void Where_short(IOption<short> option)
        {
            AssertWhere(option, i => i > 0);
        }

        [Property]
        internal void Where_int(IOption<int> option)
        {
            AssertWhere(option, i => i > 1567);
        }

        [Property]
        internal void Where_long(IOption<long> option)
        {
            AssertWhere(option, i => i < 1567);
        }

        [Property]
        internal void Where_decimal(IOption<decimal> option)
        {
            AssertWhere(option, d => d < -1200);
        }

        [Property]
        internal void Where_double(IOption<double> option)
        {
            AssertWhere(option, d => Math.Abs(d) > 14);
        }

        [Property]
        internal void Where_bool(IOption<bool> option)
        {
            AssertWhere(option, b => !b);
        }

        [Property]
        internal void Where_ReferenceType(IOption<ReferenceType> option)
        {
            AssertWhere(option, t => t.Value > 1567);
        }

        private void AssertWhere<T>(IOption<T> option, Func<T, bool> map)
        {
            var whereResult = option.Where(x => map(x));

            if (option.NonEmpty)
            {
                Assert.Equal(map(option.Get()), whereResult.NonEmpty);
                if (whereResult.NonEmpty)
                {
                    Assert.Equal(option.Get(), whereResult.Get());
                }
            }
            else
            {
                OptionAssert.IsEmpty(whereResult);
            }
        }
    }
}
