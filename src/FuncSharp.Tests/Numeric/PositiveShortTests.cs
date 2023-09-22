using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class PositiveShortTests
{
    [Fact]
    internal void AsPositive_Manual()
    {
        OptionAssert.IsEmpty(((short)-14).AsPositive());
        OptionAssert.IsEmpty(((short)-1).AsPositive());
        OptionAssert.IsEmpty(((short)0).AsPositive());

        Assert.Equal(1, ((short)1).AsPositive().Get());
        Assert.Equal(20, ((short)20).AsPositive().Get());
        Assert.Equal(26579, ((short)26579).AsPositive().Get());
    }

    [Fact]
    internal void AsPositiveUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => ((short)-14).AsUnsafePositive());
        Assert.Throws<ArgumentException>(() => ((short)-1).AsUnsafePositive());
        Assert.Throws<ArgumentException>(() => ((short)0).AsUnsafePositive());

        Assert.Equal(1, ((short)1).AsUnsafePositive());
        Assert.Equal(20, ((short)20).AsUnsafePositive());
        Assert.Equal(26579, ((short)26579).AsUnsafePositive());
    }

    [Property]
    internal void AsPositive(short number)
    {
        var result = number.AsPositive();
        if (number > 0)
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
    internal void AsUnsafePositive(short number)
    {
        if (number > 0)
        {
            var result = number.AsUnsafePositive();
            Assert.Equal(number, result);
            Assert.Equal(number, result.Value);
        }
        else
        {
            Assert.Throws<ArgumentException>(() => number.AsUnsafePositive());
        }
    }
}