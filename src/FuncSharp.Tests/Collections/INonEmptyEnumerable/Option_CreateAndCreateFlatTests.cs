using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable;

public class Option_CreateAndCreateFlatTests
{
    [Fact]
    public void AsNonEmptyExtension()
    {
        var expected = new List<string> { "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato"};
        var nonEmpty = Enumerable.Repeat("1 potato", 10).AsNonEmpty();
        OptionAssert.NonEmpty(nonEmpty);
        Assert.Equal(10, nonEmpty.Get().Count);
        Assert.Equal(expected, nonEmpty.Get());

        OptionAssert.IsEmpty(Enumerable.Repeat("1 potato", 0).AsNonEmpty());
        OptionAssert.IsEmpty(Enumerable.Empty<string>().AsNonEmpty());
        OptionAssert.IsEmpty(expected.Where(s => s != "1 potato").AsNonEmpty());
    }

    [Fact]
    public void Option_Create_IEnumerable()
    {
        var expected = new List<string> { "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato"};
        var nonEmpty = NonEmptyEnumerable.Create(Enumerable.Repeat("1 potato", 10));
        OptionAssert.NonEmpty(nonEmpty);
        Assert.Equal(10, nonEmpty.Get().Count);
        Assert.Equal(expected, nonEmpty.Get());

        OptionAssert.IsEmpty(NonEmptyEnumerable.Create(Enumerable.Repeat("1 potato", 0)));
        OptionAssert.IsEmpty(NonEmptyEnumerable.Create(Enumerable.Empty<string>()));
        OptionAssert.IsEmpty(NonEmptyEnumerable.Create(expected.Where(s => s != "1 potato")));
    }

    [Fact]
    public void Option_Create_ReadonlyList()
    {
        var expected = new List<string> { "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato"};
        var nonEmpty = NonEmptyEnumerable.Create<string>(Enumerable.Repeat("1 potato", 10).ToList());
        OptionAssert.NonEmpty(nonEmpty);
        Assert.Equal(10, nonEmpty.Get().Count);
        Assert.Equal(expected, nonEmpty.Get());

        OptionAssert.IsEmpty(NonEmptyEnumerable.Create<string>(Enumerable.Repeat("1 potato", 0).ToList()));
        OptionAssert.IsEmpty(NonEmptyEnumerable.Create<string>(new List<string>()));
        OptionAssert.IsEmpty(NonEmptyEnumerable.Create<string>(Enumerable.Empty<string>().ToList()));
        OptionAssert.IsEmpty(NonEmptyEnumerable.Create<string>(expected.Where(s => s != "1 potato").ToList()));
    }

    [Fact]
    public void Option_CreateFlat_Params()
    {
        var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string" };
        var nonEmpty = NonEmptyEnumerable.CreateFlat("1 potato".ToOption(), Option.Empty<string>(), "2 potatoes".ToOption(), Option.Empty<string>(), Option.Empty<string>(), "3 potatoes".ToOption(), "4 potatoes".ToOption(), "5 potatoes".ToOption(), "6 potatoes".ToOption(), "7 potatoes".ToOption(), "8 potatoes".ToOption(), "9 potatoes".ToOption(), "Also a longer string".ToOption());
        OptionAssert.NonEmpty(nonEmpty);
        Assert.Equal(10, nonEmpty.Get().Count);
        Assert.Equal(expected, nonEmpty.Get());

        OptionAssert.IsEmpty(NonEmptyEnumerable.CreateFlat<string>());
        OptionAssert.IsEmpty(NonEmptyEnumerable.CreateFlat<string>(Option.Empty<string>(), Option.Empty<string>(), Option.Empty<string>()));
    }
}