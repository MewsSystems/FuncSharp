using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class CoproductBenchmarks
    {
        [Benchmark]
        public void Creation()
        {
            new TestCoproduct(true);
            new TestCoproduct(42);
            new TestCoproduct(42m);
            new TestCoproduct("foo");

            new TestCoproduct((object)true);
            new TestCoproduct((object)42);
            new TestCoproduct((object)42m);
            new TestCoproduct((object)"foo");
        }
    }

    public sealed class TestCoproduct : Coproduct4<bool, int, decimal, string>
    {
        public TestCoproduct(bool b) : base(b) { }
        public TestCoproduct(int i) : base(i) { }
        public TestCoproduct(decimal d) : base(d) { }
        public TestCoproduct(string s) : base(s) { }
        public TestCoproduct(object o) : base(o.AsCoproduct<bool, int, decimal, string>()) { }
    }
}