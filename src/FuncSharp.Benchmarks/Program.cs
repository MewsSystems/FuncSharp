using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FuncSharp.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}