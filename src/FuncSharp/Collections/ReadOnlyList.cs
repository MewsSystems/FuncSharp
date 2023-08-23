using System.Collections.Generic;
using System.Linq;

namespace FuncSharp;

public static class ReadOnlyList
{
    public static IReadOnlyList<T> Create<T>(params T[] values)
    {
        return CreateFlat(values);
    }

    public static IReadOnlyList<T> Create<T>(T head, IEnumerable<T> tail)
    {
        var list = new List<T> { head };
        list.AddRange(tail);
        return list;
    }

    public static IReadOnlyList<T> CreateFlat<T>(params IEnumerable<T>[] values)
    {
        return values.Flatten().ToArray();
    }

    public static IReadOnlyList<T> CreateFlat<T>(params IOption<T>[] values)
    {
        return values.Flatten().ToArray();
    }

    public static IReadOnlyList<T> CreateFlat<T>(params IEnumerable<IOption<T>>[] values)
    {
        return values.Flatten().Flatten().ToArray();
    }

    public static IReadOnlyList<T> CreateFlat<T>(params IOption<IEnumerable<T>>[] values)
    {
        return values.Flatten().Flatten().ToArray();
    }

    public static IReadOnlyList<T> Empty<T>()
    {
        return ReadOnlyList<T>.Empty;
    }
}

public class ReadOnlyList<T>
{
    public static readonly IReadOnlyList<T> Empty = new List<T>().AsReadOnly();
}
