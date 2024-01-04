using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class NonPositiveDecimalTests
{
    [Fact]
    internal void AsNonPositive_Manual()
    {
        OptionAssert.IsEmpty(14m.AsNonPositive());
        OptionAssert.IsEmpty(1m.AsNonPositive());

        Assert.Equal(0m, 0m.AsNonPositive().Get());
        Assert.Equal(-1m, (-1m).AsNonPositive().Get());
        Assert.Equal(-20m, (-20m).AsNonPositive().Get());
        Assert.Equal(-26579m, (-26579m).AsNonPositive().Get());
    }

    [Fact]
    internal void AsNonPositiveUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => 14m.AsUnsafeNonPositive());
        Assert.Throws<ArgumentException>(() => 1m.AsUnsafeNonPositive());

        Assert.Equal(0m, 0m.AsUnsafeNonPositive());
        Assert.Equal(-1m, (-1m).AsUnsafeNonPositive());
        Assert.Equal(-20m, (-20m).AsUnsafeNonPositive());
        Assert.Equal(-26579m, (-26579m).AsUnsafeNonPositive());
    }

    [Property]
    internal void AsNonPositive(decimal number)
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
    internal void AsUnsafeNonPositive(decimal number)
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
    internal void Equality(decimal first, decimal second)
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