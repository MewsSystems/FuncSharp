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

            Assert.Equal(42, "42".ToByte().Get());
            Assert.Equal(42, "42".ToShort().Get());
            Assert.Equal(42, "42".ToInt().Get());
            Assert.Equal(42, "42".ToLong().Get());
            Assert.Equal(0.5f, "0.5".ToFloat().Get());
            Assert.Equal(0.5, "0.5".ToDouble().Get());
            Assert.Equal(1.234m, "1.234".ToDecimal().Get());
            Assert.True("true".ToBool().Get());
            Assert.Equal(new DateTime(2000, 1, 1), "1/1/2000".ToDateTime().Get());
            Assert.Equal(new TimeSpan(1, 2, 3), "01:02:03".ToTimeSpan().Get());
            Assert.Equal(NumberStyles.Integer, "Integer".ToEnum<NumberStyles>().Get());
            Assert.Equal(Option.Empty<NumberStyles>(), "Integer,Number".ToEnum<NumberStyles>());
            Assert.Equal((NumberStyles)2, "AllowTrailingWhite".ToEnum<NumberStyles>().Get());
            Assert.Equal(Option.Empty<NumberStyles>(), "2".ToEnum<NumberStyles>());
            Assert.Equal(Option.Empty<NumberStyles>(), "999999999".ToEnum<NumberStyles>());
        }
    }
}
