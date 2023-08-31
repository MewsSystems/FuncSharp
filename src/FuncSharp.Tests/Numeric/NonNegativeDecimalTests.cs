using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class NonNegativeDecimalTests
{
    [Fact]
    internal void AsNonNegative_Manual()
    {
        OptionAssert.IsEmpty((-14m).AsNonNegative());
        OptionAssert.IsEmpty((-1m).AsNonNegative());

        Assert.Equal(0m, 0m.AsNonNegative().Get());
        Assert.Equal(1m, 1m.AsNonNegative().Get());
        Assert.Equal(20m, 20m.AsNonNegative().Get());
        Assert.Equal(26579m, 26579m.AsNonNegative().Get());
    }

    [Fact]
    internal void AsNonNegativeUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => (-14m).AsUnsafeNonNegative());
        Assert.Throws<ArgumentException>(() => (-1m).AsUnsafeNonNegative());

        Assert.Equal(0m, 0m.AsUnsafeNonNegative());
        Assert.Equal(1m, 1m.AsUnsafeNonNegative());
        Assert.Equal(20m, 20m.AsUnsafeNonNegative());
        Assert.Equal(26579m, 26579m.AsUnsafeNonNegative());
    }

    [Property]
    internal void AsNonNegative(decimal number)
    {
        var result = number.AsNonNegative();
        if (number >= 0)
        {
            OptionAssert.NonEmpty(result);
            Assert.Equal(number, result.Get());
            Assert.Equal(number, result.Get().Value);
        }
        else
        {
            OptionAssert.IsEmpty(result);
        }
    }

    [Property]
    internal void AsUnsafeNonNegative(decimal number)
    {
        if (number >= 0)
        {
            var result = number.AsUnsafeNonNegative();
            Assert.Equal(number, result);
            Assert.Equal(number, result.Value);
        }
        else
        {
            Assert.Throws<ArgumentException>(() => number.AsUnsafeNonNegative());
        }
    }
}