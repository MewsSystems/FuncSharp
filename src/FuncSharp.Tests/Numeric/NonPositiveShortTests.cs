using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class NonPositiveShortTests
{
    [Fact]
    internal void AsNonPositive_Manual()
    {
        OptionAssert.IsEmpty(((short)14).AsNonPositive());
        OptionAssert.IsEmpty(((short)1).AsNonPositive());

        Assert.Equal(0, ((short)0).AsNonPositive().Get());
        Assert.Equal(-1, ((short)-1).AsNonPositive().Get());
        Assert.Equal(-20, ((short)-20).AsNonPositive().Get());
        Assert.Equal(-26579, ((short)-26579).AsNonPositive().Get());
    }

    [Fact]
    internal void AsNonPositiveUnsafe_Manual()
    {
        Assert.Throws<ArgumentException>(() => ((short)14).AsUnsafeNonPositive());
        Assert.Throws<ArgumentException>(() => ((short)1).AsUnsafeNonPositive());

        Assert.Equal(0, ((short)0).AsUnsafeNonPositive());
        Assert.Equal(-1, ((short)-1).AsUnsafeNonPositive());
        Assert.Equal(-20, ((short)-20).AsUnsafeNonPositive());
        Assert.Equal(-26579, ((short)-26579).AsUnsafeNonPositive());
    }

    [Property]
    internal void AsNonPositive(short number)
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
    internal void AsUnsafeNonPositive(short number)
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