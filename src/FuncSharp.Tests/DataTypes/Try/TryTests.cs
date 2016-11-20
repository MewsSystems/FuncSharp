using System;
using Xunit;

namespace FuncSharp.Tests
{
    public class TryTests
    {
        [Fact]
        public void CreateGetTest()
        {
            var success = Try.Create<int, Exception>(_ => 42);
            var exception = Try.Create<int, Exception>(_ => { throw new NotImplementedException(); });

            Assert.True(success.IsSuccess);
            Assert.Equal(42, success.Get());

            Assert.True(exception.IsError);
            Assert.Throws<NotImplementedException>(() => exception.Get());
        }

        [Fact]
        public void RecoverTest()
        {
            Assert.Equal(42.ToTry(), 42.ToTry().Recover(_ => 0));
            Assert.Equal(42.ToTry(), Try.Error<int>(null).Recover(_ => 42));
        }
    }
}
