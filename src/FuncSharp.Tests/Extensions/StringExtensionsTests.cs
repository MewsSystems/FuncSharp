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

            Assert.Equal<byte>(42, "42".ToByte().Get());
            Assert.Equal<short>(42, "42".ToShort().Get());
            Assert.Equal<int>(42, "42".ToInt().Get());
            Assert.Equal<long>(42, "42".ToLong().Get());
            Assert.Equal<float>(0.5f, "0.5".ToFloat().Get());
            Assert.Equal<double>(0.5, "0.5".ToDouble().Get());
            Assert.Equal<decimal>(1.234m, "1.234".ToDecimal().Get());
            Assert.Equal<bool>(true, "true".ToBool().Get());
            Assert.Equal<DateTime>(new DateTime(2000, 1, 1), "1/1/2000".ToDateTime().Get());
            Assert.Equal<TimeSpan>(new TimeSpan(1, 2, 3), "01:02:03".ToTimeSpan().Get());
            Assert.Equal<NumberStyles>(NumberStyles.Integer, "Integer".ToEnum<NumberStyles>().Get());
        }
    }
}
