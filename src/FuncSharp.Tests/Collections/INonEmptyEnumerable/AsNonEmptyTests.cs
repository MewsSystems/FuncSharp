using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable;

public class AsNonEmptyTests
{
    [Fact]
    public void AsNonEmpty_null()
    {
        IEnumerable<string> enumerableNull = null;
        string[] arrayNull = null;

        OptionAssert.IsEmpty(enumerableNull.AsNonEmpty());
        OptionAssert.IsEmpty(arrayNull.AsNonEmpty());
    }

    [Fact]
    public void AsNonEmpty_Empty()
    {
        IEnumerable<string> enumerableEmpty = Enumerable.Empty<string>();
        string[] arrayEmpty = new string[]{};

        OptionAssert.IsEmpty(enumerableEmpty.AsNonEmpty());
        OptionAssert.IsEmpty(arrayEmpty.AsNonEmpty());
    }

    [Fact]
    public void AsNonEmpty_Single()
    {
        IEnumerable<string> enumerableSingle = Enumerable.Repeat("A potato", 1);
        string[] arraySingle = new []{"A potato"};
        var expected = NonEmptyEnumerable.Create("A potato");

        OptionAssert.NonEmptyWithValue(expected, enumerableSingle.AsNonEmpty());
        OptionAssert.NonEmptyWithValue(expected, arraySingle.AsNonEmpty());
    }

    [Fact]
    public void AsNonEmpty_Multiple()
    {
        IEnumerable<string> enumerableMultiple = Enumerable.Range(0, 4).Select(i => $"{i} potatoes");
        string[] arrayMultiple = Enumerable.Range(0, 4).Select(i => $"{i} potatoes").ToArray();
        var expected = NonEmptyEnumerable.Create("0 potatoes", "1 potatoes", "2 potatoes", "3 potatoes");

        OptionAssert.NonEmptyWithValue(expected, enumerableMultiple.AsNonEmpty());
        OptionAssert.NonEmptyWithValue(expected, arrayMultiple.AsNonEmpty());
    }
}