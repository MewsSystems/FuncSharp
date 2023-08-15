using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    public enum TestEnum
    {
        Value1,
        Value2,
        Value3,
        Value4,
        Value5
    }

    [MemoryDiagnoser]
    public class ValueMatchBenchmarks
    {
        private static readonly TestEnum Value3;

        static ValueMatchBenchmarks()
        {
            Value3 = TestEnum.Value3;
        }

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

        [Benchmark]
        public void SwitchStatement()
        {
            int number;
            switch (Value3)
            {
                case TestEnum.Value1:
                    number = 1;
                    break;
                case TestEnum.Value2:
                    number = 2;
                    break;
                case TestEnum.Value3:
                    number = 3;
                    break;
                case TestEnum.Value4:
                    number = 4;
                    break;
                case TestEnum.Value5:
                    number = 5;
                    break;
                default:
                    number = 14;
                    break;
            }
        }

        [Benchmark]
        public void ValueMatchWithJust1Lambda()
        {
            var number = Value3.Match(
                TestEnum.Value3, _ => 3
            );
        }
    }
}