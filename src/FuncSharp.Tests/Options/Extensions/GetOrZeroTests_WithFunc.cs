using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetOrZeroTests_WithFunc
    {
        public GetOrZeroTests_WithFunc()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void GetOrZero_WithFunc()
        {
            Assert.Equal(1m, 2m.ToOption().GetOrZero(v => v / 2));
            Assert.Equal(2, Unit.Value.ToOption().GetOrZero(_ => 2));
            Assert.Equal(28, Option.Valued(new ReferenceType(14)).GetOrZero(t => t.Value * 2));

            Assert.Equal(0, Option.Empty<ReferenceType>().GetOrZero(t => t.Value * 2));
            Assert.Equal(0, Option.Empty<int>().GetOrZero(v => v / 0));
        }

        [Property]
        internal void GetOrZero_WithFunc_short(Option<short> option)
        {
            Assert.Equal(option.GetOrDefault(i => i * 2), option.GetOrZero(i => i * 2));
        }

        [Property]
        internal void GetOrZero_WithFunc_int(Option<int> option)
        {
            Assert.Equal(option.GetOrDefault(i => i * 3), option.GetOrZero(i => i * 3));
        }

        [Property]
        internal void GetOrZero_WithFunc_long(Option<long> option)
        {
            Assert.Equal(option.GetOrDefault(i => i * 4), option.GetOrZero(i => i * 4));
        }

        [Property]
        internal void GetOrZero_WithFunc_decimal(Option<decimal> option)
        {
            Assert.Equal(option.GetOrDefault(d => d * 5), option.GetOrZero(d => d * 5));
        }

        [Property]
        internal void GetOrZero_WithFunc_double(Option<double> option)
        {
            Assert.Equal(option.GetOrDefault(d => d * 6), option.GetOrZero(d => d * 6));
        }

        [Property]
        internal void GetOrZero_WithFunc_bool(Option<bool> option)
        {
            Assert.Equal(option.GetOrDefault(b => b ? 2 : 17), option.GetOrZero(b => b ? 2 : 17));
        }

        [Property]
        internal void GetOrZero_WithFunc_ReferenceType(Option<ReferenceType> option)
        {
            Assert.Equal(option.GetOrDefault(t => t.Value * 3), option.GetOrZero(t => t.Value * 3));
        }
    }
}
