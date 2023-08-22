using System.Linq;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class NonEmptyEnumerableBenchmarks
    {
        private static INonEmptyEnumerable<string> _nonEmptyEnumerable;
        private static INonEmptyEnumerable<INonEmptyEnumerable<string>> _nestedNonEmptyEnumerable;

        static NonEmptyEnumerableBenchmarks()
        {
            _nonEmptyEnumerable = NonEmptyEnumerable.Create("1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string");
            _nestedNonEmptyEnumerable = NonEmptyEnumerable.Create(_nonEmptyEnumerable, _nonEmptyEnumerable);
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
            var tenStrings = NonEmptyEnumerable.Create("1 potato", Enumerable.Repeat("2 potatoes", 9).ToList());
        }

        [Benchmark]
        public void Option_Create_IEnumerable()
        {
            var tenStrings = NonEmptyEnumerable.Create(Enumerable.Repeat("1 potato", 10));
        }

        [Benchmark]
        public void Option_Create_ReadonlyList()
        {
            var tenStrings = NonEmptyEnumerable.Create<string>(Enumerable.Repeat("1 potato", 10).ToList());
        }

        [Benchmark]
        public void Option_CreateFlat_Params()
        {
            var tenStrings = NonEmptyEnumerable.CreateFlat("1 potato".ToOption(), "2 potatoes".ToOption(), "3 potatoes".ToOption(), "4 potatoes".ToOption(), "5 potatoes".ToOption(), "6 potatoes".ToOption(), "7 potatoes".ToOption(), "8 potatoes".ToOption(), "9 potatoes".ToOption(), "Also a longer string".ToOption());
        }

        [Benchmark]
        public void CreateFlat_NonEmptyOfNonEmpty()
        {
            var tenStrings = NonEmptyEnumerable.CreateFlat("1 potato".ToOption(), "2 potatoes".ToOption(), "3 potatoes".ToOption(), "4 potatoes".ToOption(), "5 potatoes".ToOption(), "6 potatoes".ToOption(), "7 potatoes".ToOption(), "8 potatoes".ToOption(), "9 potatoes".ToOption(), "Also a longer string".ToOption());
        }

        [Benchmark]
        public void CreateFlat_NonEmpty_params()
        {
            var tenStrings = NonEmptyEnumerable.CreateFlat("1 potato".ToEnumerable(), Enumerable.Repeat("2 potatoes", 3), Enumerable.Repeat("3 potatoes", 2), "4 potatoes".ToEnumerable(), "5 potatoes".ToEnumerable());
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
        public void Concat_Item_params()
        {
            var x = "1 potato".Concat(Enumerable.Repeat("2 potatoes", 3), "3 potatoes".ToEnumerable(), "4 potatoes".ToEnumerable());
        }

        [Benchmark]
        public void Concat_NonEmpty_Items()
        {
            var x = _nonEmptyEnumerable.Concat("1 more potato", "2 more potatoes", "3 more potatoes", "4 more potatoes", "5 more potatoes");
        }

        [Benchmark]
        public void Concat_NonEmpty_Enumerables()
        {
            var x = _nonEmptyEnumerable.Concat(Enumerable.Repeat("2 potatoes", 3), "3 potatoes".ToEnumerable(), "4 potatoes".ToEnumerable());
        }

        public INonEmptyEnumerable<T> Distinct()
        {
            return new NonEmptyEnumerable<T>(Enumerable.Distinct(this).ToArray());
        }

        public INonEmptyEnumerable<TResult> Distinct<TResult>(Func<T, TResult> selector)
        {
            return new NonEmptyEnumerable<TResult>(Enumerable.Select(this, selector).Distinct().ToArray());
        }

        public INonEmptyEnumerable<TResult> Select<TResult>(Func<T, TResult> func)
        {
            return new NonEmptyEnumerable<TResult>(Enumerable.Select(this, func).ToArray());
        }

        public INonEmptyEnumerable<TResult> Select<TResult>(Func<T, int, TResult> func)
        {
            return new NonEmptyEnumerable<TResult>(Enumerable.Select(this, func).ToArray());
        }
    }
}