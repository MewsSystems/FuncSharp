using System;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks;

[MemoryDiagnoser]
public class ObjectExtensionsBenchmarks
{
    private static readonly BenchmarkEnum Enum = BenchmarkEnum.Value3;
    private static readonly BenchmarkEnum? NullableEnum_Value = BenchmarkEnum.Value3;
    private static readonly BenchmarkEnum? NullableEnum_Null = null;
    private static readonly String String_Value = "Some text.";
    private static readonly String String_Null = null;

    // Last Result - 26.8.2023 - 1.6 ns - 0 B
    [Benchmark]
    public void MatchRefToBool_Null()
    {
        bool x = String_Null.MatchRef(e => true);
    }

    // Last Result - 26.8.2023 - 1.2 ns - 0 B
    [Benchmark]
    public void MatchRefToBool_Value()
    {
        bool x = String_Value.MatchRef(e => true);
    }

    // Last Result - 26.8.2023 - 0.4 ns - 0 B
    [Benchmark]
    public void MapRefToVal_Null()
    {
        BenchmarkEnum? x = String_Null.MapRefToVal(e => Enum);
    }

    // Last Result - 26.8.2023 - 1.2 ns - 0 B
    [Benchmark]
    public void MapRefToVal_Value()
    {
        BenchmarkEnum? x = String_Value.MapRefToVal(e => Enum);
    }

    // Last Result - 26.8.2023 - 0.4 ns - 0 B
    [Benchmark]
    public void MapRefToValToNullable_Null()
    {
        BenchmarkEnum? x = String_Null.MapRefToVal(e => NullableEnum_Value);
    }

    // Last Result - 26.8.2023 - 1.4 ns - 0 B
    [Benchmark]
    public void MapRefToValToNullable_Value()
    {
        BenchmarkEnum? x = String_Value.MapRefToVal(e => NullableEnum_Value);
    }

    // Last Result - 26.8.2023 - 0.6 ns - 0 B
    [Benchmark]
    public void MatchValToBool_Null()
    {
        bool x = NullableEnum_Null.MatchVal(e => true);
    }

    // Last Result - 26.8.2023 - 1.4 ns - 0 B
    [Benchmark]
    public void MatchValToBool_Value()
    {
        bool x = NullableEnum_Value.MatchVal(e => true);
    }

    // Last Result - 26.8.2023 - 2.1 ns - 0 B
    [Benchmark]
    public void MatchVal_Null()
    {
        BenchmarkEnum x = NullableEnum_Null.MatchVal(e => Enum, _ => Enum);
    }

    // Last Result - 26.8.2023 - 2.0 ns - 0 B
    [Benchmark]
    public void MatchVal_Value()
    {
        BenchmarkEnum x = NullableEnum_Value.MatchVal(e => Enum, _ => Enum);
    }

    // Last Result - 26.8.2023 - 3.0 ns - 0 B
    [Benchmark]
    public void MapVal_Null()
    {
        BenchmarkEnum? x = NullableEnum_Null.MapVal(e => Enum);
    }

    // Last Result - 26.8.2023 - 7.0 ns - 0 B
    [Benchmark]
    public void MapVal_Value()
    {
        BenchmarkEnum? x = NullableEnum_Value.MapVal(e => Enum);
    }

    // Last Result - 26.8.2023 - 0.4 ns - 0 B
    [Benchmark]
    public void MapValToNullable_Null()
    {
        BenchmarkEnum? x = NullableEnum_Null.MapVal(e => NullableEnum_Value);
    }

    // Last Result - 26.8.2023 - 1.8 ns - 0 B
    [Benchmark]
    public void MapValToNullable_Value()
    {
        BenchmarkEnum? x = NullableEnum_Value.MapVal(e => NullableEnum_Value);
    }

    // Last Result - 26.8.2023 - 0.4 ns - 0 B
    [Benchmark]
    public void MapValToRef_Null()
    {
        string x = NullableEnum_Null.MapValToRef(e => String_Value);
    }

    // Last Result - 26.8.2023 - 1.6 ns - 0 B
    [Benchmark]
    public void MapValToRef_Value()
    {
        string x = NullableEnum_Value.MapValToRef(e => String_Value);
    }
}