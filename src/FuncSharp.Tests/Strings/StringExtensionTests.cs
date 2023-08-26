using System;
using Xunit;

namespace FuncSharp.Tests.Strings;

public class StringExtensionTests
{
    [Fact]
    public void ToGuid()
    {
        var validGuid = Guid.NewGuid();
        OptionAssert.NonEmptyWithValue(validGuid, validGuid.ToString().ToGuid());

        OptionAssert.IsEmpty(((string)null).ToGuid());
        OptionAssert.IsEmpty(string.Empty.ToGuid());
        OptionAssert.IsEmpty("ASDF".ToGuid());
        OptionAssert.IsEmpty($"{validGuid}-{validGuid}".ToGuid());
        OptionAssert.IsEmpty(validGuid.ToString().Substring(1).ToGuid());
    }

    [Fact]
    public void ToBool()
    {
        OptionAssert.NonEmptyWithValue(true, "true".ToBool());
        OptionAssert.NonEmptyWithValue(false, "false".ToBool());

        OptionAssert.IsEmpty(((string)null).ToBool());
        OptionAssert.IsEmpty(string.Empty.ToBool());
        OptionAssert.IsEmpty("ASDF".ToBool());
    }

    [Fact]
    public void ToByte()
    {
        OptionAssert.NonEmptyWithValue((byte)12, "12".ToByte());
        OptionAssert.NonEmptyWithValue((byte)254, "254".ToByte());

        OptionAssert.IsEmpty(((string)null).ToByte());
        OptionAssert.IsEmpty(string.Empty.ToByte());
        OptionAssert.IsEmpty("ASDF".ToByte());
        OptionAssert.IsEmpty("258".ToByte());// Too big
    }

    [Fact]
    public void ToShort()
    {
        OptionAssert.NonEmptyWithValue((short)12, "12".ToShort());
        OptionAssert.NonEmptyWithValue((short)32767, "32767".ToShort());

        OptionAssert.IsEmpty(((string)null).ToShort());
        OptionAssert.IsEmpty(string.Empty.ToShort());
        OptionAssert.IsEmpty("ASDF".ToShort());
        OptionAssert.IsEmpty("32768".ToShort());// Too big
    }

    [Fact]
    public void ToInt()
    {
        OptionAssert.NonEmptyWithValue(12, "12".ToInt());
        OptionAssert.NonEmptyWithValue(2147483647, "2147483647".ToInt());

        OptionAssert.IsEmpty(((string)null).ToInt());
        OptionAssert.IsEmpty(string.Empty.ToInt());
        OptionAssert.IsEmpty("ASDF".ToInt());
        OptionAssert.IsEmpty("2,147,483,648".ToInt());// Too big
    }

    [Fact]
    public void ToLong()
    {
        OptionAssert.NonEmptyWithValue(12, "12".ToLong());
        OptionAssert.NonEmptyWithValue(9223372036854775806, "9223372036854775806".ToLong());

        OptionAssert.IsEmpty(((string)null).ToLong());
        OptionAssert.IsEmpty(string.Empty.ToLong());
        OptionAssert.IsEmpty("ASDF".ToLong());
        OptionAssert.IsEmpty("9223372036854775808".ToLong());// Too big
    }

    [Fact]
    public void ToFloat()
    {
        OptionAssert.NonEmptyWithValue(12f, "12".ToFloat());
        OptionAssert.NonEmpty("12,628".ToFloat());
        Assert.Equal(12.628f, "12,628".ToFloat().Get(), tolerance: 0.00005f);
        OptionAssert.NonEmpty("340282300000000000000000000000000000000".ToFloat());
        Assert.Equal(340282200000000000000000000000000000000f, "340282300000000000000000000000000000000".ToFloat().Get(), tolerance: 1000000000000000000000000000000000f);

        OptionAssert.IsEmpty(((string)null).ToFloat());
        OptionAssert.IsEmpty(string.Empty.ToFloat());
        OptionAssert.IsEmpty("ASDF".ToFloat());
        OptionAssert.NonEmptyWithValue(float.PositiveInfinity, "460282300000000000000000000000000000000".ToFloat()); // It's a value of infinity

    }

    [Fact]
    public void ToDouble()
    {
        OptionAssert.NonEmptyWithValue(12d, "12".ToDouble());
        OptionAssert.NonEmpty("12,628".ToDouble());
        Assert.Equal(12.628d, "12,628".ToDouble().Get(), tolerance: 0.00005);

        OptionAssert.IsEmpty(((string)null).ToDouble());
        OptionAssert.IsEmpty(string.Empty.ToDouble());
        OptionAssert.IsEmpty("ASDF".ToDouble());
    }

    [Fact]
    public void ToDecimal()
    {
        OptionAssert.NonEmptyWithValue(12m, "12".ToDecimal());
        OptionAssert.NonEmptyWithValue(12.628m, "12,628".ToDecimal());
        OptionAssert.NonEmptyWithValue(79228162514264337593543950335m, "79228162514264337593543950335".ToDecimal());

        OptionAssert.IsEmpty(((string)null).ToDecimal());
        OptionAssert.IsEmpty(string.Empty.ToDecimal());
        OptionAssert.IsEmpty("ASDF".ToDecimal());
        OptionAssert.IsEmpty("79228162514264337593543950337".ToDecimal());// Too big
    }

    [Fact]
    public void ToDateTime()
    {
        OptionAssert.NonEmptyWithValue(new DateTime(2022,01,13, 16, 25, 35), "2022-01-13T16:25:35".ToDateTime());

        OptionAssert.IsEmpty(((string)null).ToDateTime());
        OptionAssert.IsEmpty(string.Empty.ToDateTime());
        OptionAssert.IsEmpty("ASDF".ToDateTime());
    }

    [Fact]
    public void ToTimeSpan()
    {
        OptionAssert.NonEmptyWithValue(new TimeSpan(days: 1, hours: 12, minutes: 24, seconds: 02), "1.12:24:02".ToTimeSpan());

        OptionAssert.IsEmpty(((string)null).ToTimeSpan());
        OptionAssert.IsEmpty(string.Empty.ToTimeSpan());
        OptionAssert.IsEmpty("ASDF".ToTimeSpan());
    }

    [Fact]
    public void ToEnum()
    {
        OptionAssert.NonEmptyWithValue(ParseTestEnum.FirstValue, "FirstValue".ToEnum<ParseTestEnum>());
        OptionAssert.NonEmptyWithValue(ParseTestEnum.SecondValue, "SecondValue".ToEnum<ParseTestEnum>());

        OptionAssert.IsEmpty(((string)null).ToEnum<ParseTestEnum>());
        OptionAssert.IsEmpty(string.Empty.ToEnum<ParseTestEnum>());
        OptionAssert.IsEmpty("ASDF".ToEnum<ParseTestEnum>());
    }

    private enum ParseTestEnum
    {
        FirstValue,
        SecondValue
    }
}