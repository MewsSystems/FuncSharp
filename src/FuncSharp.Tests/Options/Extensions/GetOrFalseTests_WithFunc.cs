using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class GetOrFalseTests_WithFunc
{
    public GetOrFalseTests_WithFunc()
    {
        Arb.Register<OptionGenerators>();
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
    internal void GetOrFalse_WithFunc_short(Option<short> option)
    {
        AssertGetOrFalse(option, i => i > 0);
    }

    [Property]
    internal void GetOrFalse_WithFunc_int(Option<int> option)
    {
        AssertGetOrFalse(option, i => i > 1567);
    }

    [Property]
    internal void GetOrFalse_WithFunc_long(Option<long> option)
    {
        AssertGetOrFalse(option, i => i < 1567);
    }

    [Property]
    internal void GetOrFalse_WithFunc_decimal(Option<decimal> option)
    {
        AssertGetOrFalse(option, d => d < -1200);
    }

    [Property]
    internal void GetOrFalse_WithFunc_double(Option<double> option)
    {
        AssertGetOrFalse(option, d => Math.Abs(d) > 14);
    }

    [Property]
    internal void GetOrFalse_WithFunc_bool(Option<bool> option)
    {
        AssertGetOrFalse(option, b => !b);
    }

    [Property]
    internal void GetOrFalse_WithFunc_ReferenceType(Option<ReferenceType> option)
    {
        AssertGetOrFalse(option, t => t.Value > 1567);
    }

    private void AssertGetOrFalse<T>(Option<T> option, Func<T, bool> map)
    {
        var result = option.GetOrFalse(map);
        Assert.Equal(option.GetOrDefault(map), result);

        if (option.NonEmpty)
        {
            Assert.Equal(map(option.Get()), result);
        }
        else
        {
            Assert.False(result);
        }
    }
}