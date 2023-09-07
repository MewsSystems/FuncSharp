using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks;

[MemoryDiagnoser]
public class IEnumerableExtensionsBenchmarks
{
    private static readonly string[] StringArray;
    private static readonly Stack<string> StringStack_Empty;
    private static readonly Stack<string> StringStack_Single;
    private static readonly Stack<string> StringStack_Many;
    private static readonly IEnumerable<string> StringEnumerable;
    private static readonly IEnumerable<string> StringEnumerable_Array;
    private static readonly int?[] ArrayOfNullables;
    private static readonly Option<int>[] ArrayOfOptions;
    private static readonly Exception[] Exceptions;
    private static readonly INonEmptyEnumerable<Exception> Exceptions_NonEmpty;

    static IEnumerableExtensionsBenchmarks()
    {
        StringEnumerable = Enumerable.Range(0, 2000).Select(i => $"{i} potatoes");
        StringArray = StringEnumerable.ToArray();
        StringEnumerable_Array = StringArray;

        StringStack_Empty = new Stack<string>();
        StringStack_Single = new Stack<string>("1 potato".ToEnumerable());
        StringStack_Many = new Stack<string>(StringArray);

        ArrayOfNullables = ((int?)0).Concat(Enumerable.Range(1, 1000).Select(i => (int?)i), Enumerable.Repeat<int?>(null, 1000)).OrderBy(x => Guid.NewGuid()).ToArray(); // randomized order
        ArrayOfOptions = 0.ToOption().Concat(Enumerable.Range(1, 1000).Select(i => i.ToOption()), Enumerable.Repeat(Option.Empty<int>(), 1000)).OrderBy(x => Guid.NewGuid()).ToArray(); // randomized order
        Exceptions = Enumerable.Range(0, 10).Select(i => new Exception($"{i} potatoes")).ToArray();
        Exceptions_NonEmpty = Exceptions.AsNonEmpty().Get();
    }

    // Last Result - 25.8.2023 - 528.4 ns - 16024 B
    [Benchmark]
    public void ToReadOnlyList()
    {
        var x = StringArray.ToReadOnlyList();
    }

    // Last Result - 25.8.2023 - 24.4 ns - 208 B
    [Benchmark]
    public void SafeConcat_ParamsOfEnumerables()
    {
        var x = StringArray.SafeConcat(StringArray, null, null, null, StringArray, null, null, null);
    }

    // Last Result - 25.8.2023 - 33823 ns - 81592 B
    [Benchmark]
    public void SafeConcat_ParamsOfEnumerables_Enumerated()
    {
        var x = StringArray.SafeConcat(StringArray, null, null, null, StringArray, null, null, null).ToArray();
    }

    // Last Result - 25.8.2023 - 21 ns - 104 B
    [Benchmark]
    public void ExceptNulls_Nullable()
    {
        var x = ArrayOfNullables.ExceptNulls();
    }

    // Last Result - 25.8.2023 - 13462 ns - 8608 B
    [Benchmark]
    public void ExceptNulls_Nullable_Enumerated()
    {
        var x = ArrayOfNullables.ExceptNulls().ToArray();
    }

    // Last Result - 25.8.2023 - 22 ns - 104 B
    [Benchmark]
    public void Options_Flatten()
    {
        var x = ArrayOfOptions.Flatten();
    }

    // Last Result - 25.8.2023 - 8366 ns - 8608 B
    [Benchmark]
    public void Options_Flatten_Enumerated()
    {
        var x = ArrayOfOptions.Flatten().ToArray();
    }

    //Last Result - 25.8.2023 - 35.1 ns - 128 B
    [Benchmark]
    public void FirstOption()
    {
        var x = StringEnumerable.FirstOption();
    }

    // Last Result - 25.8.2023 - 14.6 ns - 40 B
    [Benchmark]
    public void SingleOption_Empty()
    {
        var x = StringStack_Empty.SingleOption();
    }

    // Last Result - 25.8.2023 - 23.6 ns - 72 B
    [Benchmark]
    public void SingleOption_Single()
    {
        var x = StringStack_Single.SingleOption();
    }

    // Last Result - 25.8.2023 - 22.0 ns - 40 B
    [Benchmark]
    public void SingleOption()
    {
        var x = StringStack_Many.SingleOption();
    }

    // Last Result - 25.8.2023 - 1.4 ns - 0 B
    [Benchmark]
    public void IsMultiple_Stack()
    {
        var x = StringStack_Many.IsMultiple();
    }

    // Last Result - 25.8.2023 - 53.8 ns - 144 B
    [Benchmark]
    public void IsMultiple_Enumerable()
    {
        var x = StringEnumerable.IsMultiple();
    }

    // Last Result - 25.8.2023 - 6.9 ns - 0 B
    [Benchmark]
    public void IsMultiple_ArrayAsEnumerable()
    {
        var x = StringEnumerable_Array.IsMultiple();
    }

    // Last Result - 25.8.2023 - 2.2 ns - 0 B
    [Benchmark]
    public void IsMultiple_Array()
    {
        var x = StringArray.IsMultiple();
    }

    // Last Result - 25.8.2023 - 1.4 ns - 0 B
    [Benchmark]
    public void IsSingle_Stack()
    {
        var x = StringStack_Many.IsSingle();
    }

    // Last Result - 25.8.2023 - 54.2 ns - 144 B
    [Benchmark]
    public void IsSingle_Enumerable()
    {
        var x = StringEnumerable.IsSingle();
    }

    // Last Result - 25.8.2023 - 5.3 ns - 0 B
    [Benchmark]
    public void IsSingle_ArrayAsEnumerable()
    {
        var x = StringEnumerable_Array.IsSingle();
    }

    // Last Result - 25.8.2023 - 2.2 ns - 0 B
    [Benchmark]
    public void IsSingle_Array()
    {
        var x = StringArray.IsSingle();
    }

    // Last Result - 25.8.2023 - 121.5 ns - 416 B
    [Benchmark]
    public void AggregateExceptions_Array()
    {
        var x = Exceptions.Aggregate();
    }

    // Last Result - 25.8.2023 - 252.1 ns - 656 B
    [Benchmark]
    public void AggregateExceptions_NonEmpty()
    {
        var x = Exceptions_NonEmpty.Aggregate();
    }
}