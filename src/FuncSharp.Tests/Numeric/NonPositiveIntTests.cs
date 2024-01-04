using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class NonPositiveIntTests
{
    [Fact]
    internal void AsNonPositive_Manual()
    {
        OptionAssert.IsEmpty(14.AsNonPositive());
        OptionAssert.IsEmpty(1.AsNonPositive());

        Assert.Equal(0, 0.AsNonPositive().Get());
        Assert.Equal(-1, (-1).AsNonPositive().Get());
        Assert.Equal(-20, (-20).AsNonPositive().Get());
        Assert.Equal(-26579, (-26579).AsNonPositive().Get());
    }

    [Fact]
    internal void AsNonPositiveUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => 14.AsUnsafeNonPositive());
        Assert.Throws<ArgumentException>(() => 1.AsUnsafeNonPositive());

        Assert.Equal(0, 0.AsUnsafeNonPositive());
        Assert.Equal(-1, (-1).AsUnsafeNonPositive());
        Assert.Equal(-20, (-20).AsUnsafeNonPositive());
        Assert.Equal(-26579, (-26579).AsUnsafeNonPositive());
    }

    [Property]
    internal void AsNonPositive(int number)
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
    internal void AsUnsafeNonPositive(int number)
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
    internal void Equality(int first, int second)
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