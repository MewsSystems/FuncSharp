using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class PositiveIntTests
{
    [Fact]
    internal void AsPositive_Manual()
    {
        OptionAssert.IsEmpty((-14).AsPositive());
        OptionAssert.IsEmpty((-1).AsPositive());
        OptionAssert.IsEmpty(0.AsPositive());

        Assert.Equal(1, 1.AsPositive().Get());
        Assert.Equal(20, 20.AsPositive().Get());
        Assert.Equal(26579, 26579.AsPositive().Get());
    }

    [Fact]
    internal void AsPositiveUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => (-14).AsUnsafePositive());
        Assert.Throws<ArgumentException>(() => (-1).AsUnsafePositive());
        Assert.Throws<ArgumentException>(() => 0.AsUnsafePositive());

        Assert.Equal(1, 1.AsUnsafePositive());
        Assert.Equal(20, 20.AsUnsafePositive());
        Assert.Equal(26579, 26579.AsUnsafePositive());
    }

    [Property]
    internal void AsPositive(int number)
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
    internal void AsUnsafePositive(int number)
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