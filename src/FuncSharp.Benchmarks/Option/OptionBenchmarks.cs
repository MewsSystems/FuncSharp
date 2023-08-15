using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class OptionBenchmarks
    {
        private static readonly object Object;
        private static readonly IOption<string> NonEmptyOption;
        private static readonly IOption<string> EmptyOption;

        static OptionBenchmarks()
        {
            Object = new object();
            NonEmptyOption = "non-empty".ToOption();
            EmptyOption = Option.Empty<string>();
        }

        [Benchmark]
        public void Creation_AllCases()
        {
            Option.Create(42);
            Option.Create(42 as int?);
            Option.Create(null as int?);

            Option.Create(Object);
            Option.Create(null as object);
        }

        [Benchmark]
        public void IsEmptyOrNonEmpty_AllCases()
        {
            var a = NonEmptyOption.NonEmpty;
            var b = EmptyOption.NonEmpty;
            var c = NonEmptyOption.IsEmpty;
            var d = EmptyOption.IsEmpty;
        }

        [Benchmark]
        public void Get()
        {
            NonEmptyOption.Get();
        }

        [Benchmark]
        public void GetOrElse_NonEmpty()
        {
            NonEmptyOption.GetOrElse("else");
        }

        [Benchmark]
        public void GetOrElse_Empty()
        {
            EmptyOption.GetOrElse("else");
        }

        [Benchmark]
        public void Lazy_GetOrElse_NonEmpty()
        {
            NonEmptyOption.GetOrElse(_ => "else");
        }

        [Benchmark]
        public void Lazy_GetOrElse_Empty()
        {
            EmptyOption.GetOrElse(_ => "else");
        }

        [Benchmark]
        public void OrElse_NonEmpty_ToNonEmpty()
        {
            NonEmptyOption.OrElse(_ => NonEmptyOption);
        }

        [Benchmark]
        public void OrElse_NonEmpty_ToEmpty()
        {
            NonEmptyOption.OrElse(_ => EmptyOption);
        }

        [Benchmark]
        public void OrElse_Empty_ToNonEmpty()
        {
            EmptyOption.OrElse(_ => NonEmptyOption);
        }

        [Benchmark]
        public void OrElse_Empty_ToEmpty()
        {
            EmptyOption.OrElse(_ => EmptyOption);
        }

        [Benchmark]
        public void Map_NonEmpty()
        {
            NonEmptyOption.Map(o => "non-empty-mapped");
        }

        [Benchmark]
        public void Map_Empty()
        {
            EmptyOption.Map(o => "empty-mapped");
        }

        [Benchmark]
        public void FlatMap_NonEmpty_ToNonEmpty()
        {
            NonEmptyOption.FlatMap(o => NonEmptyOption);
        }

        [Benchmark]
        public void FlatMap_NonEmpty_ToEmpty()
        {
            NonEmptyOption.FlatMap(o => EmptyOption);
        }

        [Benchmark]
        public void FlatMap_Empty_ToNonEmpty()
        {
            EmptyOption.FlatMap(o => NonEmptyOption);
        }

        [Benchmark]
        public void FlatMap_Empty_ToEmpty()
        {
            EmptyOption.FlatMap(o => EmptyOption);
        }

        [Benchmark]
        public void Matching_NonEmpty()
        {
            NonEmptyOption.Match(_ => true, _ => false);
        }

        [Benchmark]
        public void Matching_Empty()
        {
            EmptyOption.Match(_ => true, _ => false);
        }

        [Benchmark]
        public void ToEnumerable_NonEmpty()
        {
            NonEmptyOption.ToList();
        }

        [Benchmark]
        public void ToEnumerable_Empty()
        {
            EmptyOption.ToList();
        }
    }
}