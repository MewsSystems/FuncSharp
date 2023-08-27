using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options;

public class MapEmptyTests
{
    public MapEmptyTests()
    {
        Arb.Register<OptionGenerators>();
    }

    [Fact]
    internal void MapEmpty()
    {
        // A non-empty option is always empty when mapped with MapEmpty
        OptionAssert.IsEmpty(Option.Valued(2).MapEmpty(_ => 14));
        OptionAssert.IsEmpty("asd".ToOption().MapEmpty(_ => (int?)null));
        OptionAssert.IsEmpty(Option.Valued("").MapEmpty(_ => "asd"));

        // Empty option will always have value when mapped with MapEmpty
        OptionAssert.NonEmptyWithValue(14, Option.Empty<int>().MapEmpty(_ => 14));
        OptionAssert.NonEmptyWithValue(28, Option.Empty<string>().MapEmpty(_ => (int?)28));
        OptionAssert.NonEmptyWithValue(null, Option.Empty<int>().MapEmpty(_ => (string)null));
        OptionAssert.NonEmptyWithValue("xxxxx", Option.Empty<string>().MapEmpty(v => "xxxxx"));
    }

    [Property]
    internal void Map_int(Option<int> option)
    {
        AssertMapEmpty(option);
    }

    [Property]
    internal void Map_decimal(Option<decimal> option)
    {
        AssertMapEmpty(option);
    }

    [Property]
    internal void Map_double(Option<double> option)
    {
        AssertMapEmpty(option);
    }

    [Property]
    internal void Map_bool(Option<bool> option)
    {
        AssertMapEmpty(option);
    }

    [Property]
    internal void Map_ReferenceType(Option<ReferenceType> option)
    {
        AssertMapEmpty(option);
    }

    private void AssertMapEmpty<T>(Option<T> option)
    {
        AssertMapEmpty(option, _ => (ReferenceType)null);
        AssertMapEmpty(option, _ => new ReferenceType(6));
        AssertMapEmpty(option, _ => 14);
        AssertMapEmpty(option, _ => (int?)14);
        AssertMapEmpty(option, _ => (int?)null);
    }

    private void AssertMapEmpty<T, TResult>(Option<T> option, Func<Unit, TResult> map)
    {
        var result = option.MapEmpty(map);
        Assert.Equal(option.NonEmpty, result.IsEmpty);
        if (option.IsEmpty)
        {
            OptionAssert.NonEmptyWithValue(map(Unit.Value), result);
        }
    }
}