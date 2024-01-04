using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class PositiveLongTests
{
    [Fact]
    internal void AsPositive_Manual()
    {
        OptionAssert.IsEmpty((-14L).AsPositive());
        OptionAssert.IsEmpty((-1L).AsPositive());
        OptionAssert.IsEmpty(0L.AsPositive());

        Assert.Equal(1L, 1L.AsPositive().Get());
        Assert.Equal(20L, 20L.AsPositive().Get());
        Assert.Equal(26579L, 26579L.AsPositive().Get());
    }

    [Fact]
    internal void AsPositiveUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => (-14L).AsUnsafePositive());
        Assert.Throws<ArgumentException>(() => (-1L).AsUnsafePositive());
        Assert.Throws<ArgumentException>(() => 0L.AsUnsafePositive());

        Assert.Equal(1L, 1L.AsUnsafePositive());
        Assert.Equal(20L, 20L.AsUnsafePositive());
        Assert.Equal(26579L, 26579L.AsUnsafePositive());
    }

    [Property]
    internal void AsPositive(long number)
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
    internal void AsUnsafePositive(long number)
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
    internal void Equality(long first, long second)
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