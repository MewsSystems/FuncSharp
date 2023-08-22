using FuncSharp;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Enumerable = System.Linq.Enumerable;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class NonEmptyEnumerableBenchmarks
    {
        private static List<string> _list;
        private static INonEmptyEnumerable<string> _nonEmptyEnumerable;
        private static INonEmptyEnumerable<INonEmptyEnumerable<string>> _nestedNonEmptyEnumerable;
        private static INonEmptyEnumerable<string> _nonEmptyWithDuplicates;

        static NonEmptyEnumerableBenchmarks()
        {
            _list = new List<string>{ "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string"};
            _nonEmptyEnumerable = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string");
            _nestedNonEmptyEnumerable = NonEmptyEnumerable.Create(_nonEmptyEnumerable, _nonEmptyEnumerable);
            _nonEmptyWithDuplicates = NonEmptyEnumerable.CreateFlat("1 potato".ToEnumerable(), Enumerable.Repeat("2 potatoes", 3), Enumerable.Repeat("3 potatoes", 2), "4 potatoes".ToEnumerable(), "5 potatoes".ToEnumerable());
        }

        [Benchmark]
        public void AsNonEmpty()
        {
            _list.AsNonEmpty();
        }

        [Benchmark]
        public void Create_params()
        {
            var tenStrings = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string");
        }

        [Benchmark]
        public void Create_Head_Plus_IEnumerable()
        {
            var tenStrings = NonEmptyEnumerable.Create("1 potato", Enumerable.Repeat("2 potatoes", 9));
        }

        [Benchmark]
        public void Create_Head_Plus_ReadonlyList()
        {
            var tenStrings = NonEmptyEnumerable.Create("1 potato", _list);
        }

        [Benchmark]
        public void Option_Create_IEnumerable()
        {
            var tenStrings = NonEmptyEnumerable.Create(Enumerable.Repeat("1 potato", 10));
        }

        [Benchmark]
        public void Option_Create_ReadonlyList()
        {
            var tenStrings = NonEmptyEnumerable.Create<string>(_list);
        }

        [Benchmark]
        public void Option_CreateFlat_ParamsOfOptions()
        {
            var tenStrings = NonEmptyEnumerable.CreateFlat("1 potato".ToOption(), Option.Empty<string>(), "2 potatoes".ToOption(), Option.Empty<string>(), "3 potatoes".ToOption(), Option.Empty<string>(), "4 potatoes".ToOption(), Option.Empty<string>(), "5 potatoes".ToOption(), Option.Empty<string>(), "6 potatoes".ToOption(), Option.Empty<string>(), "7 potatoes".ToOption(), Option.Empty<string>(), "8 potatoes".ToOption(), Option.Empty<string>(), "9 potatoes".ToOption(), Option.Empty<string>(), "Also a longer string".ToOption());
        }

        [Benchmark]
        public void CreateFlat_NonEmpty_ParamsOfEnumerables()
        {
            var tenStrings = NonEmptyEnumerable.CreateFlat("1 potato".ToEnumerable(), Enumerable.Repeat("2 potatoes", 3), Enumerable.Repeat("3 potatoes", 2), "4 potatoes".ToEnumerable(), "5 potatoes".ToEnumerable());
        }

        [Benchmark]
        public void Concat_SingleItem_paramsOfEnumerables()
        {
            var x = "1 potato".Concat(Enumerable.Repeat("2 potatoes", 3), "3 potatoes".ToEnumerable(), "4 potatoes".ToEnumerable());
        }

        [Benchmark]
        public void Concat_NonEmpty_ParamsOfItems()
        {
            var x = _nonEmptyEnumerable.Concat("1 more potato", "2 more potatoes", "3 more potatoes", "4 more potatoes", "5 more potatoes");
        }

        [Benchmark]
        public void Concat_NonEmpty_ParamsOfEnumerables()
        {
            var x = _nonEmptyEnumerable.Concat(Enumerable.Repeat("2 potatoes", 3), "3 potatoes".ToEnumerable(), "4 potatoes".ToEnumerable());
        }

        [Benchmark]
        public void Distinct()
        {
            var x = _nonEmptyWithDuplicates.Distinct();
        }

        [Benchmark]
        public void Distinct_WithFunc()
        {
            var x = _nonEmptyWithDuplicates.Distinct(text => $"{text}{text}");
        }

        [Benchmark]
        public void Select()
        {
            var x = _nonEmptyWithDuplicates.Select(text => $"{text}{text}");
        }

        [Benchmark]
        public void Select_WithIndex()
        {
            var x = _nonEmptyWithDuplicates.Select((text, i) => $"{text} - {i} - {text}");
        }

        [Benchmark]
        public void SelectMany()
        {
            var x = _nonEmptyEnumerable.SelectMany(text => _nonEmptyEnumerable);
        }

        [Benchmark]
        public void Flatten()
        {
            var x = _nestedNonEmptyEnumerable.Flatten();
        }

        [Benchmark]
        public void Foreach()
        {
            foreach (var text in _nonEmptyWithDuplicates)
            {
                var y = $"{text} - i - {text}";
            }
        }
    }
}