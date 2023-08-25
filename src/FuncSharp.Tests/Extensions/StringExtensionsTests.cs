using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace FuncSharp.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ConversionsWork()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Assert.Equivalent(42, "42".ToByte().Get());
            Assert.Equivalent(42, "42".ToShort().Get());
            Assert.Equivalent(42, "42".ToInt().Get());
            Assert.Equivalent(42, "42".ToLong().Get());
            Assert.Equivalent(0.5f, "0.5".ToFloat().Get());
            Assert.Equivalent(0.5, "0.5".ToDouble().Get());
            Assert.Equivalent(1.234m, "1.234".ToDecimal().Get());
            Assert.True("true".ToBool().Get());
            Assert.Equivalent(new DateTime(2000, 1, 1), "1/1/2000".ToDateTime().Get());
            Assert.Equivalent(new TimeSpan(1, 2, 3), "01:02:03".ToTimeSpan().Get());
            Assert.Equivalent(NumberStyles.Integer, "Integer".ToEnum<NumberStyles>().Get());
            Assert.Equivalent(Option.Empty<NumberStyles>(), "Integer,Number".ToEnum<NumberStyles>());
            Assert.Equivalent((NumberStyles)2, "AllowTrailingWhite".ToEnum<NumberStyles>().Get());
            Assert.Equivalent(Option.Empty<NumberStyles>(), "2".ToEnum<NumberStyles>());
            Assert.Equivalent(Option.Empty<NumberStyles>(), "999999999".ToEnum<NumberStyles>());
            Assert.Equivalent(Option.Empty<Guid>(), "c0fb150f6bf344df984a3a0611ae5e4a".ToGuidExact());
        }
    }
}
