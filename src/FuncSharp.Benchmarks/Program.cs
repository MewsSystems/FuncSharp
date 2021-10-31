using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace FuncSharp.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var e = Option.Empty<string>();
            var o = 1.ToOption();
            for (var i = 0; i < 10000000; i++)
            {
                e.Map(_ => "non-empty-mapped");
                o.Map(_ => "non-empty-mapped");
            }*/

            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}