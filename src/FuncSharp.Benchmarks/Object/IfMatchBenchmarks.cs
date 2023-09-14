using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks;

[MemoryDiagnoser]
public class IfMatchBenchmarks
{
    // Last Result - 14.9.2023 - 5.959 ns - 48 B
    [Benchmark]
    public void MapTrue()
    {
        var result = this.Map(true);
    }
    
    // Last Result - 14.9.2023 - 0.0046 ns - 0 B
    [Benchmark]
    public void MapValueTrue()
    {
        var result = this.MapValue(true);
    }
    
    // Last Result - 14.9.2023 - 0.0012 ns - 0 B
    [Benchmark]
    public void IfTrue()
    {
        var result = this.IF(true);
    }
    
    public int Map(bool source)
    {
        return source.Match(true, a => 5, a => 11);
    }
    
    public int MapValue(bool source)
    {
        return source.Match(true, 5, 11);
    }

    public int IF(bool source)
    {
        if (source)
            return 5;
        
        return 11;
    }
}