using BenchmarkDotNet.Running;

namespace FuncSharp.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(NonEmptyEnumerableBenchmarks));
        }
    }
}
