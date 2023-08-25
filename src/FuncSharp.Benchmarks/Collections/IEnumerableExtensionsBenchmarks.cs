using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
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
        private static readonly IOption<int>[] ArrayOfOptions;

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
        }

        // [Benchmark]
        // public void SafeConcat_ParamsOfEnumerables()
        // {
        //     var x = StringArray.SafeConcat(StringArray, null, null, null, StringArray, null, null, null);
        // }
        //
        // [Benchmark]
        // public void SafeConcat_ParamsOfEnumerables_Enumerated()
        // {
        //     var x = StringArray.SafeConcat(StringArray, null, null, null, StringArray, null, null, null).ToArray();
        // }
        //
        // [Benchmark]
        // public void ExceptNulls_Nullable()
        // {
        //     var x = ArrayOfNullables.ExceptNulls();
        // }
        //
        // [Benchmark]
        // public void ExceptNulls_Nullable_Enumerated()
        // {
        //     var x = ArrayOfNullables.ExceptNulls().ToArray();
        // }
        //
        // [Benchmark]
        // public void Options_Flatten()
        // {
        //     var x = ArrayOfOptions.Flatten();
        // }
        //
        // [Benchmark]
        // public void Options_Flatten_Enumerated()
        // {
        //     var x = ArrayOfOptions.Flatten().ToArray();
        // }
        //
        // [Benchmark]
        // public void FirstOption()
        // {
        //     var x = StringEnumerable.FirstOption();
        // }
        //
        // [Benchmark]
        // public void SingleOption_Empty()
        // {
        //     var x = StringStack_Empty.SingleOption();
        // }
        //
        // [Benchmark]
        // public void SingleOption_Single()
        // {
        //     var x = StringStack_Single.SingleOption();
        // }
        //
        // [Benchmark]
        // public void SingleOption()
        // {
        //     var x = StringStack_Many.SingleOption();
        // }

        [Benchmark]
        public void NonEmpty_EnumeratedEnumerable()
        {
            var x = StringStack_Many.Third();
        }

        [Benchmark]
        public void NonEmpty_Enumerable()
        {
            var x = StringEnumerable.Third();
        }

        [Benchmark]
        public void NonEmpty_ArrayAsEnumerable()
        {
            var x = StringEnumerable_Array.Third();
        }

        [Benchmark]
        public void NonEmpty_Array()
        {
            var x = StringArray.Third();
        }
    }
}