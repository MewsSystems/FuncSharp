using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable;

public class SingleOptionTests
{
    // [Fact]
    // public void SingleOption_Empty()
    // {
    //     IEnumerable<string> enumerable = Enumerable.Empty<string>();
    //     string[] array = new string[]{};
    //
    //     OptionAssert.IsEmpty(enumerable.SingleOption());
    //     OptionAssert.IsEmpty(array.SingleOption());
    //
    //     OptionAssert.IsEmpty(enumerable.SingleOption(t => t.Contains("potato")));
    //     OptionAssert.IsEmpty(array.SingleOption(t => t.Contains("potato")));
    // }
    //
    // [Fact]
    // public void SingleOption_Single()
    // {
    //     IEnumerable<string> enumerable = Enumerable.Repeat("A potato", 1);
    //     string[] array = new []{"A potato"};
    //
    //     OptionAssert.NonEmptyWithValue("A potato", enumerable.SingleOption());
    //     OptionAssert.NonEmptyWithValue("A potato", array.SingleOption());
    //
    //     OptionAssert.NonEmptyWithValue("A potato", enumerable.SingleOption(t => t.Contains("potato")));
    //     OptionAssert.NonEmptyWithValue("A potato", array.SingleOption(t => t.Contains("potato")));
    //
    //     OptionAssert.IsEmpty(enumerable.SingleOption(t => t.Contains("ASDF")));
    //     OptionAssert.IsEmpty(array.SingleOption(t => t.Contains("ASDF")));
    // }
    //
    // [Fact]
    // public void SingleOption_Multiple()
    // {
    //     IEnumerable<string> enumerable = Enumerable.Range(0, 10).Select(i => $"{i} potatoes");
    //     string[] array = Enumerable.Range(0, 10).Select(i => $"{i} potatoes").ToArray();
    //
    //     OptionAssert.IsEmpty(enumerable.SingleOption());
    //     OptionAssert.IsEmpty(array.SingleOption());
    //
    //     OptionAssert.NonEmptyWithValue("3 potatoes", enumerable.SingleOption(t => t.Contains("3 pot")));
    //     OptionAssert.NonEmptyWithValue("3 potatoes", array.SingleOption(t => t.Contains("3 pot")));
    //
    //     OptionAssert.IsEmpty(enumerable.SingleOption(t => t.Contains("potato")));
    //     OptionAssert.IsEmpty(array.SingleOption(t => t.Contains("potato")));
    //
    //     OptionAssert.IsEmpty(enumerable.SingleOption(t => t.Contains("ASDF")));
    //     OptionAssert.IsEmpty(array.SingleOption(t => t.Contains("ASDF")));
    // }
}