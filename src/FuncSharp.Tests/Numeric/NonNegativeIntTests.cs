using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class NonNegativeIntTests
{
    [Fact]
    internal void AsNonNegative_Manual()
    {
        OptionAssert.IsEmpty((-14).AsNonNegative());
        OptionAssert.IsEmpty((-1).AsNonNegative());

        Assert.Equal(0, 0.AsNonNegative().Get());
        Assert.Equal(1, 1.AsNonNegative().Get());
        Assert.Equal(20, 20.AsNonNegative().Get());
        Assert.Equal(26579, 26579.AsNonNegative().Get());
    }

    [Fact]
    internal void AsNonNegativeUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => (-14).AsUnsafeNonNegative());
        Assert.Throws<ArgumentException>(() => (-1).AsUnsafeNonNegative());

        Assert.Equal(0, 0.AsUnsafeNonNegative());
        Assert.Equal(1, 1.AsUnsafeNonNegative());
        Assert.Equal(20, 20.AsUnsafeNonNegative());
        Assert.Equal(26579, 26579.AsUnsafeNonNegative());
    }

    [Property]
    internal void AsNonNegative(int number)
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
    internal void AsUnsafeNonNegative(int number)
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
    internal void Equality(int first, int second)
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