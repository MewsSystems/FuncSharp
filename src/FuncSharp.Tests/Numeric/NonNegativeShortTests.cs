using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class NonNegativeShortTests
{
    [Fact]
    internal void AsNonNegative_Manual()
    {
        OptionAssert.IsEmpty(((short)-14).AsNonNegative());
        OptionAssert.IsEmpty(((short)-1).AsNonNegative());

        Assert.Equal(0, ((short)0).AsNonNegative().Get());
        Assert.Equal(1, ((short)1).AsNonNegative().Get());
        Assert.Equal(20, ((short)20).AsNonNegative().Get());
        Assert.Equal(26579, ((short)26579).AsNonNegative().Get());
    }

    [Fact]
    internal void AsNonNegativeUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => ((short)-14).AsUnsafeNonNegative());
        Assert.Throws<ArgumentException>(() => ((short)-1).AsUnsafeNonNegative());

        Assert.Equal(0, ((short)0).AsUnsafeNonNegative());
        Assert.Equal(1, ((short)1).AsUnsafeNonNegative());
        Assert.Equal(20, ((short)20).AsUnsafeNonNegative());
        Assert.Equal(26579, ((short)26579).AsUnsafeNonNegative());
    }

    [Property]
    internal void AsNonNegative(short number)
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
    internal void AsUnsafeNonNegative(short number)
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