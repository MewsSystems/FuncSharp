using System;
using BenchmarkDotNet.Attributes;

namespace FuncSharp.Benchmarks
{
    [MemoryDiagnoser]
    public class StringBenchmarks
    {
        private static readonly string ValidGuid = Guid.NewGuid().ToString();
        private static readonly string ValidBool = "true";
        private static readonly string ValidByte = "214";
        private static readonly string ValidShort = "31592";
        private static readonly string ValidDecimal = "2548.5";
        private static readonly string ValidDateTime = "2022-01-13T16:25:35";
        private static readonly string ValidTimeSpan = "1.12:24:02";
        private static readonly string ValidEnum = BenchmarkEnum.Value4.ToString();
        private static readonly string LongRandomString = $"{ValidGuid} - {ValidGuid}";

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void ToGuid_Valid()
        {
            var x = ValidGuid.ToGuid();
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void ToGuid_Invalid()
        {
            var x = LongRandomString.ToGuid();
        }

        [Benchmark]
        public void ToGuid_Empty()
        {
            var x = String.Empty.ToGuid();
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void ToInt_Valid()
        {
            var x = ValidShort.ToInt();
        }

        // Last Result - 26.8.2023 -  ns -  B
        [Benchmark]
        public void ToInt_Invalid()
        {
            var x = ValidGuid.ToInt();
        }

        [Benchmark]
        public void ToInt_Empty()
        {
            var x = String.Empty.ToInt();
        }

        [Benchmark]
        public void ToByte_Valid()
        {
            var x = ValidShort.ToByte();
        }

        [Benchmark]
        public void ToShort_Valid()
        {
            var x = ValidShort.ToShort();
        }

        [Benchmark]
        public void ToLong_Valid()
        {
            var x = ValidShort.ToLong();
        }

        [Benchmark]
        public void ToFloat_Valid()
        {
            var x = ValidDecimal.ToFloat();
        }

        [Benchmark]
        public void ToDouble_Valid()
        {
            var x = ValidDecimal.ToDouble();
        }

        [Benchmark]
        public void ToDecimal_Valid()
        {
            var x = ValidDecimal.ToDecimal();
        }

        [Benchmark]
        public void ToBool_Valid()
        {
            var x = ValidBool.ToBool();
        }

        [Benchmark]
        public void ToDateTime_Valid()
        {
            var x = ValidDateTime.ToDateTime();
        }

        [Benchmark]
        public void ToTimeSpan_Valid()
        {
            var x = ValidTimeSpan.ToTimeSpan();
        }

        [Benchmark]
        public void ToEnum_Valid()
        {
            var x = ValidEnum.ToEnum<BenchmarkEnum>();
        }
    }
}