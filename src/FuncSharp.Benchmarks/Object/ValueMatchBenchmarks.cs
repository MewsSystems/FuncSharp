using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class ValueMatchBenchmarks
    {
        private static readonly TestEnum Value3;

        static ValueMatchBenchmarks()
        {
            Value3 = TestEnum.Value3;
        }

        // Last Result - 22.8.2023 - 17.3 ns - 144 B
        [Benchmark]
        public void ValueMatchWith5LambdasAndDefault()
        {
            var number = Value3.Match(
                TestEnum.Value1, _ => 1,
                TestEnum.Value2, _ => 2,
                TestEnum.Value3, _ => 3,
                TestEnum.Value4, _ => 4,
                TestEnum.Value5, _ => 5,
                _ => 14
            );
        }

        // Last Result - 22.8.2023 - 17.0 ns - 144 B
        [Benchmark]
        public void ValueMatchWith5Lambdas()
        {
            var number = Value3.Match(
                TestEnum.Value1, _ => 1,
                TestEnum.Value2, _ => 2,
                TestEnum.Value3, _ => 3,
                TestEnum.Value4, _ => 4,
                TestEnum.Value5, _ => 5
            );
        }

        // Last Result - 22.8.2023 - 15.8 ns - 144 B
        [Benchmark]
        public void ValueMatchWith3Lambdas()
        {
            var number = Value3.Match(
                TestEnum.Value1, _ => 3,
                TestEnum.Value2, _ => 3,
                TestEnum.Value3, _ => 3
            );
        }

        // Last Result - 22.8.2023 - 6.5 ns - 48 B
        [Benchmark]
        public void ValueMatchWith3Lambdas_ButTheFirstOneHits()
        {
            var number = Value3.Match(
                TestEnum.Value3, _ => 3,
                TestEnum.Value4, _ => 4,
                TestEnum.Value5, _ => 5
            );
        }

        // Last Result - 22.8.2023 - 5.8 ns - 48 B
        [Benchmark]
        public void ValueMatchWith1Lambda()
        {
            var number = Value3.Match(
                TestEnum.Value3, _ => 3
            );
        }

        // Last Result - 22.8.2023 - 0.0 ns - 0 B
        [Benchmark]
        public void SwitchStatement()
        {
            int number = Value3 switch
            {
                TestEnum.Value1 => 1,
                TestEnum.Value2 => 2,
                TestEnum.Value3 => 3,
                TestEnum.Value4 => 4,
                TestEnum.Value5 => 5,
                _ => 14
            };
        }
    }
}