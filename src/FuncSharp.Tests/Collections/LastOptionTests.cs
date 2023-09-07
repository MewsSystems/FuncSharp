using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable;

public class LastOptionTests
{
    [Fact]
    public void LastOption_Empty()
    {
        IEnumerable<string> enumerable = Enumerable.Empty<string>();
        string[] array = new string[]{};

        OptionAssert.IsEmpty(enumerable.LastOption());
        OptionAssert.IsEmpty(array.LastOption());

        OptionAssert.IsEmpty(enumerable.LastOption(t => t.Contains("potato")));
        OptionAssert.IsEmpty(array.LastOption(t => t.Contains("potato")));
    }

    [Fact]
    public void LastOption_Single()
    {
        IEnumerable<string> enumerable = Enumerable.Repeat("A potato", 1);
        string[] array = new []{"A potato"};

        OptionAssert.NonEmptyWithValue("A potato", enumerable.LastOption());
        OptionAssert.NonEmptyWithValue("A potato", array.LastOption());

        OptionAssert.NonEmptyWithValue("A potato", enumerable.LastOption(t => t.Contains("potato")));
        OptionAssert.NonEmptyWithValue("A potato", array.LastOption(t => t.Contains("potato")));

        OptionAssert.IsEmpty(enumerable.LastOption(t => t.Contains("ASDF")));
        OptionAssert.IsEmpty(array.LastOption(t => t.Contains("ASDF")));
    }

    [Fact]
    public void LastOption_Multiple()
    {
        IEnumerable<string> enumerable = Enumerable.Range(0, 10).Select(i => $"{i} potatoes");
        string[] array = Enumerable.Range(0, 10).Select(i => $"{i} potatoes").ToArray();

        OptionAssert.NonEmptyWithValue("9 potatoes", enumerable.LastOption());
        OptionAssert.NonEmptyWithValue("9 potatoes", array.LastOption());

        OptionAssert.NonEmptyWithValue("9 potatoes", enumerable.LastOption(t => t.Contains("potato")));
        OptionAssert.NonEmptyWithValue("9 potatoes", array.LastOption(t => t.Contains("potato")));

        OptionAssert.NonEmptyWithValue("3 potatoes", enumerable.LastOption(t => t.Contains("3 pot")));
        OptionAssert.NonEmptyWithValue("3 potatoes", array.LastOption(t => t.Contains("3 pot")));

        OptionAssert.IsEmpty(enumerable.LastOption(t => t.Contains("ASDF")));
        OptionAssert.IsEmpty(array.LastOption(t => t.Contains("ASDF")));
    }
}