using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FuncSharp.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var o = 1.ToOption();
            for (var i = 0; i < 1000000; i++)
            {
                o.Map(_ => "non-empty-mapped");
            }

            //BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}