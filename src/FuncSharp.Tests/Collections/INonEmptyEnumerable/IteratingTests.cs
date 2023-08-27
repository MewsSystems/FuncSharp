using System.Collections.Generic;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable;

public class SelectManyTests
{
    [Fact]
    public void Select()
    {
        var expected = new List<string> { "1 p", "2 p", "3 p", "4 p", "5 p"};
        var nonEmpty = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes");

        var result = nonEmpty.Select(text => text.Substring(0, 3));
        Assert.Equal(5, result.Count);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Select_WithIndex()
    {
        var expected = new List<string> { "1 p-0", "2 p-1", "3 p-2", "4 p-3", "5 p-4"};
        var nonEmpty = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes");

        var result = nonEmpty.Select((text, index) => $"{text.Substring(0, 3)}-{index}");
        Assert.Equal(5, result.Count);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SelectMany()
    {
        var expected = new List<string> { "1 potato", "something else", "2 potatoes", "something else", "3 potatoes", "something else", "4 potatoes", "something else", "5 potatoes", "something else" };
        var nonEmpty = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes");

        var result = nonEmpty.SelectMany(text => NonEmptyEnumerable.Create(text, "something else"));
        Assert.Equal(10, result.Count);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Foreach()
    {
        var expected = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes"};
        var nonEmpty = NonEmptyEnumerable.Create(expected).Get();

        var result = new List<string>();
        foreach (var text in nonEmpty)
        {
            result.Add(text);
        }

        Assert.Equal(5, result.Count);
        Assert.Equal(expected, result);
    }
}