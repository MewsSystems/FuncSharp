using System;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class ObjectExtensionsBenchmarks
    {
        private static readonly TestEnum Enum = TestEnum.Value3;
        private static readonly TestEnum? NullableEnum_Value = TestEnum.Value3;
        private static readonly TestEnum? NullableEnum_Null = null;
        private static readonly String String_Value = "Some text.";
        private static readonly String String_Null = null;

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MatchRefToBool_Null()
        {
            bool x = String_Null.MatchRef(e => true);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MatchRefToBool_Value()
        {
            bool x = String_Value.MatchRef(e => true);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapRefToVal_Null()
        {
            TestEnum? x = String_Null.MapRefToVal(e => Enum);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapRefToVal_Value()
        {
            TestEnum? x = String_Value.MapRefToVal(e => Enum);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapRefToValToNullable_Null()
        {
            TestEnum? x = String_Null.MapRefToVal(e => NullableEnum_Value);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapRefToValToNullable_Value()
        {
            TestEnum? x = String_Value.MapRefToVal(e => NullableEnum_Value);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MatchValToBool_Null()
        {
            bool x = NullableEnum_Null.MatchVal(e => true);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MatchValToBool_Value()
        {
            bool x = NullableEnum_Value.MatchVal(e => true);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MatchVal_Null()
        {
            TestEnum x = NullableEnum_Null.MatchVal(e => Enum, _ => Enum);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MatchVal_Value()
        {
            TestEnum x = NullableEnum_Value.MatchVal(e => Enum, _ => Enum);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapVal_Null()
        {
            TestEnum? x = NullableEnum_Null.MapVal(e => Enum);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapVal_Value()
        {
            TestEnum? x = NullableEnum_Value.MapVal(e => Enum);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapValToNullable_Null()
        {
            TestEnum? x = NullableEnum_Null.MapVal(e => NullableEnum_Value);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapValToNullable_Value()
        {
            TestEnum? x = NullableEnum_Value.MapVal(e => NullableEnum_Value);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapValToRef_Null()
        {
            string x = NullableEnum_Null.MapValToRef(e => String_Value);
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void MapValToRef_Value()
        {
            string x = NullableEnum_Value.MapValToRef(e => String_Value);
        }
    }
}