using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class NonPositiveLongTests
{
    [Fact]
    internal void AsNonPositive_Manual()
    {
        OptionAssert.IsEmpty(14L.AsNonPositive());
        OptionAssert.IsEmpty(1L.AsNonPositive());

        Assert.Equal(0L, 0L.AsNonPositive().Get());
        Assert.Equal(-1L, (-1L).AsNonPositive().Get());
        Assert.Equal(-20L, (-20L).AsNonPositive().Get());
        Assert.Equal(-26579L, (-26579L).AsNonPositive().Get());
    }

    [Fact]
    internal void AsNonPositiveUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => 14L.AsUnsafeNonPositive());
        Assert.Throws<ArgumentException>(() => 1L.AsUnsafeNonPositive());

        Assert.Equal(0L, 0L.AsUnsafeNonPositive());
        Assert.Equal(-1L, (-1L).AsUnsafeNonPositive());
        Assert.Equal(-20L, (-20L).AsUnsafeNonPositive());
        Assert.Equal(-26579L, (-26579L).AsUnsafeNonPositive());
    }

    [Property]
    internal void AsNonPositive(long number)
    {
        var result = number.AsNonPositive();
        if (number <= 0)
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
    internal void AsUnsafeNonPositive(long number)
    {
        if (number <= 0)
        {
            var result = number.AsUnsafeNonPositive();
            Assert.Equal(number, result);
            Assert.Equal(number, result.Value);
        }
        else
        {
            Assert.Throws<ArgumentException>(() => number.AsUnsafeNonPositive());
        }
    }

    [Property]
    internal void Equality(long first, long second)
    {
        var numbersAreEqual = first == second;
        var firstOption = first.AsNonPositive();
        var secondOption = second.AsNonPositive();
        var bothOptionsEmpty = firstOption.IsEmpty && secondOption.IsEmpty;
        if (!bothOptionsEmpty)
        {
            Assert.Equal(numbersAreEqual, firstOption == secondOption);
        }
    }
}