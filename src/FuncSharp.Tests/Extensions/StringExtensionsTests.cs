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

            Assert.Equal<byte>(42, "42".ToByte().Value);
            Assert.Equal<short>(42, "42".ToShort().Value);
            Assert.Equal<int>(42, "42".ToInt().Value);
            Assert.Equal<long>(42, "42".ToLong().Value);
            Assert.Equal<float>(0.5f, "0.5".ToFloat().Value);
            Assert.Equal<double>(0.5, "0.5".ToDouble().Value);
            Assert.Equal<decimal>(1.234m, "1.234".ToDecimal().Value);
            Assert.Equal<bool>(true, "true".ToBool().Value);
            Assert.Equal<DateTime>(new DateTime(2000, 1, 1), "1/1/2000".ToDateTime().Value);
            Assert.Equal<TimeSpan>(new TimeSpan(1, 2, 3), "01:02:03".ToTimeSpan().Value);
            Assert.Equal<NumberStyles>(NumberStyles.Integer, "Integer".ToEnum<NumberStyles>().Value);
        }
    }
}
