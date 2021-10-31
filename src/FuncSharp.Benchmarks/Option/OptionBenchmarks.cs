using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class OptionBenchmarks
    {
        public IOption<string> NonEmptyOption { get; } = "non-empty".ToOption();
        public IOption<string> EmptyOption { get; } = Option.Empty<string>();

        [Benchmark]
        public IOption<string> MapNonEmptyToConstant()
        {
            return NonEmptyOption.Map(o => "non-empty-mapped");
        }

        [Benchmark]
        public IOption<string> MapEmptyToConstant()
        {
            return EmptyOption.Map(o => "empty-mapped");
        }

        [Benchmark]
        public string GetNonEmpty()
        {
            return NonEmptyOption.Get();
        }

        [Benchmark]
        public IOption<string> FlatMapNonEmptyToEmpty()
        {
            return NonEmptyOption.FlatMap(o => EmptyOption);
        }

        [Benchmark]
        public IOption<string> FlatMapNonEmptyToNonEmpty()
        {
            return NonEmptyOption.FlatMap(o => NonEmptyOption);
        }

        [Benchmark]
        public void ToEnumerableFromNonEmpty()
        {
            NonEmptyOption.ToEnumerable();
        }

        [Benchmark]
        public void ToEnumerableFromEmpty()
        {
            EmptyOption.ToEnumerable();
        }

        [Benchmark]
        public bool MatchNonEmpty()
        {
            return NonEmptyOption.Match(_ => true, _ => false);
        }

        [Benchmark]
        public bool MatchEmpty()
        {
            return EmptyOption.Match(_ => true, _ => false);
        }

        [Benchmark]
        public IOption<string> Empty()
        {
            return Option.Empty<string>();
        }

        [Benchmark]
        public IOption<string> Valued()
        {
            return Option.Valued("value");
        }

        [Benchmark]
        public string GetOrElseNonEmpty()
        {
            return NonEmptyOption.GetOrElse("else");
        }

        [Benchmark]
        public string GetOrElseEmpty()
        {
            return EmptyOption.GetOrElse("else");
        }

        [Benchmark]
        public IOption<string> OrElseNonEmpty()
        {
            return NonEmptyOption.OrElse(_ => NonEmptyOption);
        }

        [Benchmark]
        public IOption<string> OrElseEmpty()
        {
            return EmptyOption.OrElse(_ => NonEmptyOption);
        }
    }
}