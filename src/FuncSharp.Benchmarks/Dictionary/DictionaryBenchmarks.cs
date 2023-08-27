using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks;

[MemoryDiagnoser]
public class DictionaryBenchmarks
{
    private static readonly IReadOnlyDictionary<int, string> Dictionary;

    static DictionaryBenchmarks()
    {
        Dictionary = Enumerable.Range(0, 1000).ToDictionary(i => i, i => $"{i} potatoes");
    }

    // Last Result - 26.8.2023 - 8.4 ns - 32 B
    [Benchmark]
    public void Get_Valid()
    {
        var x = Dictionary.Get(14);
    }

    // Last Result - 26.8.2023 - 4.7 ns - 0 B
    [Benchmark]
    public void Get_Invalid()
    {
        var x = Dictionary.Get(-14);
    }
}