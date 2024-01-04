using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class NonNegativeLongTests
{
    [Fact]
    internal void AsNonNegative_Manual()
    {
        OptionAssert.IsEmpty((-14L).AsNonNegative());
        OptionAssert.IsEmpty((-1L).AsNonNegative());

        Assert.Equal(0L, 0L.AsNonNegative().Get());
        Assert.Equal(1L, 1L.AsNonNegative().Get());
        Assert.Equal(20L, 20L.AsNonNegative().Get());
        Assert.Equal(26579L, 26579L.AsNonNegative().Get());
    }

    [Fact]
    internal void AsNonNegativeUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => (-14L).AsUnsafeNonNegative());
        Assert.Throws<ArgumentException>(() => (-1L).AsUnsafeNonNegative());

        Assert.Equal(0L, 0L.AsUnsafeNonNegative());
        Assert.Equal(1L, 1L.AsUnsafeNonNegative());
        Assert.Equal(20L, 20L.AsUnsafeNonNegative());
        Assert.Equal(26579L, 26579L.AsUnsafeNonNegative());
    }

    [Property]
    internal void AsNonNegative(long number)
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
    internal void AsUnsafeNonNegative(long number)
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

    [Property]
    internal void Equality(long first, long second)
    {
        var numbersAreEqual = first == second;
        var firstOption = first.AsNonNegative();
        var secondOption = second.AsNonNegative();
        var bothOptionsEmpty = firstOption.IsEmpty && secondOption.IsEmpty;
        if (!bothOptionsEmpty)
        {
            Assert.Equal(numbersAreEqual, firstOption == secondOption);
        }
    }
}