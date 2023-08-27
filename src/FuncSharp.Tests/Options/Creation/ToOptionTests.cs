using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class ToOptionTests
{
    public ToOptionTests()
    {
        Arb.Register<OptionGenerators>();
    }

    [Fact]
    public void ToOption()
    {
        OptionAssert.NonEmptyWithValue(3, 3.ToOption());
        OptionAssert.NonEmptyWithValue(0, 0.ToOption());
        OptionAssert.NonEmptyWithValue(2, ((int?)2).ToOption());
        OptionAssert.NonEmptyWithValue(new ReferenceType(13), new ReferenceType(13).ToOption());
        OptionAssert.NonEmptyWithValue(Unit.Value, Unit.Value.ToOption());

        OptionAssert.IsEmpty(((int?)null).ToOption());
        OptionAssert.IsEmpty(((ReferenceType)null).ToOption());
        OptionAssert.IsEmpty(((Unit)null).ToOption());
    }

    [Property]
    internal void ToOption_int(int i)
    {
        AssertToOption(i);
    }

    [Property]
    internal void ToOption_nullableint(int? i)
    {
        AssertToOption(i);
    }

    [Property]
    internal void ToOption_decimal(decimal option)
    {
        AssertToOption(option);
    }

    [Property]
    internal void ToOption_nullabledecimal(decimal? option)
    {
        AssertToOption(option);
    }

    [Property]
    internal void ToOption_double(double option)
    {
        AssertToOption(option);
    }

    [Property]
    internal void ToOption_nullabledouble(double? option)
    {
        AssertToOption(option);
    }

    [Property]
    internal void ToOption_bool(bool option)
    {
        AssertToOption(option);
    }

    [Property]
    internal void ToOption_nullablebool(bool? option)
    {
        AssertToOption(option);
    }

    [Property]
    internal void ToOption_ReferenceType(ReferenceType option)
    {
        AssertToOption(option);
    }

    private void AssertToOption<T>(T value)
    {
        var option = value.ToOption();
        Assert.Equal(value is null, option.IsEmpty);

        if(value is not null)
        {
            Assert.Equal(value, option.Get());
        }
    }
}