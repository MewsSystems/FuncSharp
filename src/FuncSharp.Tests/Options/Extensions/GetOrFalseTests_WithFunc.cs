using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetOrFalseTests_WithFunc
    {
        public GetOrFalseTests_WithFunc()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        public void GetOrFalse_WithFunc()
        {
            Assert.False(true.ToOption().GetOrFalse(b => !b));
            Assert.True(false.ToOption().GetOrFalse(b => !b));
            Assert.False(Option.Empty<bool>().GetOrFalse(b => !b));

            Assert.True(Option.Valued(new ReferenceType(14)).GetOrFalse(t => t.Value > 7));
            Assert.False(Option.Valued(new ReferenceType(14)).GetOrFalse(t => t.Value < 7));
            Assert.False(Option.Empty<ReferenceType>().GetOrFalse(t => t.Value < 7));
        }

        [Property]
        internal void GetOrFalse_WithFunc_short(IOption<short> option)
        {
            Assert.Equal(option.GetOrDefault(i => i > 0), option.GetOrFalse(i => i > 0));
        }

        [Property]
        internal void GetOrFalse_WithFunc_int(IOption<int> option)
        {
            Assert.Equal(option.GetOrDefault(i => i > 1567), option.GetOrFalse(i => i > 1567));
        }

        [Property]
        internal void GetOrFalse_WithFunc_long(IOption<long> option)
        {
            Assert.Equal(option.GetOrDefault(i => i < 1567), option.GetOrFalse(i => i < 1567));
        }

        [Property]
        internal void GetOrFalse_WithFunc_decimal(IOption<decimal> option)
        {
            Assert.Equal(option.GetOrDefault(d => d < -1200), option.GetOrFalse(d => d < -1200));
        }

        [Property]
        internal void GetOrFalse_WithFunc_double(IOption<double> option)
        {
            Assert.Equal(option.GetOrDefault(d => Math.Abs(d) > 14), option.GetOrFalse(d => Math.Abs(d) > 14));
        }

        [Property]
        internal void GetOrFalse_WithFunc_bool(IOption<bool> option)
        {
            Assert.Equal(option.GetOrDefault(b => !b), option.GetOrFalse(b => !b));
        }

        [Property]
        internal void GetOrFalse_WithFunc_ReferenceType(IOption<ReferenceType> option)
        {
            Assert.Equal(option.GetOrDefault(t => t.Value > 1567), option.GetOrFalse(t => t.Value > 1567));
        }
    }
}
