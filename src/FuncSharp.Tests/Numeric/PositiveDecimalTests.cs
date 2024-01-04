using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class PositiveDecimalTests
{
    [Fact]
    internal void AsPositive_Manual()
    {
        OptionAssert.IsEmpty((-14m).AsPositive());
        OptionAssert.IsEmpty((-1m).AsPositive());
        OptionAssert.IsEmpty(0m.AsPositive());

        Assert.Equal(1m, 1m.AsPositive().Get());
        Assert.Equal(20m, 20m.AsPositive().Get());
        Assert.Equal(26579m, 26579m.AsPositive().Get());
    }

    [Fact]
    internal void AsPositiveUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => (-14m).AsUnsafePositive());
        Assert.Throws<ArgumentException>(() => (-1m).AsUnsafePositive());
        Assert.Throws<ArgumentException>(() => 0m.AsUnsafePositive());

        Assert.Equal(1m, 1m.AsUnsafePositive());
        Assert.Equal(20m, 20m.AsUnsafePositive());
        Assert.Equal(26579m, 26579m.AsUnsafePositive());
    }

    [Property]
    internal void AsPositive(decimal number)
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
    internal void AsUnsafePositive(decimal number)
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

    [Property]
    internal void Equality(decimal first, decimal second)
    {
        var numbersAreEqual = first == second;
        var firstOption = first.AsPositive();
        var secondOption = second.AsPositive();
        var bothOptionsEmpty = firstOption.IsEmpty && secondOption.IsEmpty;
        if (!bothOptionsEmpty)
        {
            Assert.Equal(numbersAreEqual, firstOption == secondOption);
        }
    }
}