using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class DictionaryBenchmarks
    {
        private static readonly IReadOnlyDictionary<int, string> Dictionary;

        static DictionaryBenchmarks()
        {
            Dictionary = Enumerable.Range(0, 1000).ToDictionary(i => i, i => $"{i} potatoes");
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void Get_Valid()
        {
            var x = Dictionary.Get(14);
        }

        [Benchmark]
        public void Get_InValid()
        {
            var x = Dictionary.Get(-14);
        }
    }
}