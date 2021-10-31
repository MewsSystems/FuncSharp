using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class OptionBenchmarks
    {
        private object Object { get; } = new object();
        private IOption<string> NonEmptyOption { get; } = "non-empty".ToOption();
        private IOption<string> EmptyOption { get; } = Option.Empty<string>();

        [Benchmark]
        public void Creation()
        {
            Option.Create(42);
            Option.Create(42 as int?);
            Option.Create(null as int?);

            Option.Create(Object);
            Option.Create(null as object);
        }

        [Benchmark]
        public void Retrieval()
        {
            var a = NonEmptyOption.NonEmpty;
            var b = EmptyOption.NonEmpty;
            var c = NonEmptyOption.IsEmpty;
            var d = EmptyOption.IsEmpty;

            NonEmptyOption.Get();

            NonEmptyOption.GetOrElse("else");
            EmptyOption.GetOrElse("else");

            NonEmptyOption.OrElse(_ => NonEmptyOption);
            EmptyOption.OrElse(_ => NonEmptyOption);
        }

        [Benchmark]
        public void Mapping()
        {
            NonEmptyOption.Map(o => "non-empty-mapped");
            EmptyOption.Map(o => "empty-mapped");

            NonEmptyOption.FlatMap(o => EmptyOption);
            NonEmptyOption.FlatMap(o => NonEmptyOption);
            EmptyOption.FlatMap(o => EmptyOption);
            EmptyOption.FlatMap(o => NonEmptyOption);
        }

        [Benchmark]
        public void Matching()
        {
            NonEmptyOption.Match(_ => true, _ => false);
            EmptyOption.Match(_ => true, _ => false);
        }

        [Benchmark]
        public void ToEnumerable()
        {
            NonEmptyOption.ToEnumerable();
            EmptyOption.ToEnumerable();
        }
    }
}