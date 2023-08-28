using System;
using FsCheck.Xunit;
using Xunit;

namespace FuncSharp.Tests.Numeric;

public class DigitTests
{
    [Fact]
    internal void AsDigit()
    {
        AssertDigitOption(0, '0'.AsDigit());
        AssertDigitOption(1, '1'.AsDigit());
        AssertDigitOption(2, '2'.AsDigit());
        AssertDigitOption(3, '3'.AsDigit());
        AssertDigitOption(4, '4'.AsDigit());
        AssertDigitOption(5, '5'.AsDigit());
        AssertDigitOption(6, '6'.AsDigit());
        AssertDigitOption(7, '7'.AsDigit());
        AssertDigitOption(8, '8'.AsDigit());
        AssertDigitOption(9, '9'.AsDigit());

        OptionAssert.IsEmpty('a'.AsDigit());
        OptionAssert.IsEmpty('z'.AsDigit());
        OptionAssert.IsEmpty('B'.AsDigit());
        OptionAssert.IsEmpty(char.MinValue.AsDigit());
        OptionAssert.IsEmpty(char.MaxValue.AsDigit());
    }

    [Property]
    internal void AllNumbersSucceed(int number)
    {
        var firstDigit = Math.Abs(number).ToString()[0];
        OptionAssert.NonEmpty(firstDigit.AsDigit());
    }

    [Property]
    internal void AsPositive(char c)
    {
        var result = c.AsDigit();
        Assert.Equal(char.IsDigit(c), result.NonEmpty);
    }

    private void AssertDigitOption(byte value, Option<Digit> digit)
    {
        Assert.True(digit.NonEmpty, "Option was expected to have a value, but was empty.");
        Assert.Equal(value, digit.Get());
        Assert.Equal(value, digit.Get().Value);
    }
}