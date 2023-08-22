using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class TempBenchmarks
    {
        private static readonly string head;
        private static readonly List<string> tail;
        private static readonly List<string> all;

        static TempBenchmarks()
        {
            head = "1 potato";
            tail = Enumerable.Repeat("2 potatoes", 9).ToList();
            all = ReadOnlyList.Create(head, tail).AsList();
        }
        [Benchmark]
        public void Create_FromHeadAndTail()
        {
            NonEmptyEnumerable<string>.Create(head, tail);
        }

        [Benchmark]
        public void Create_FromAll()
        {
            NonEmptyEnumerable<string>.Create(all);
        }
    }
}