using System;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class TryTests
    {
        private static readonly Try<int> Success = Try.Create<int, Exception>(_ => 42);
        private static readonly Try<int> Exception = Try.Create<int, Exception>(_ => throw new NotImplementedException());

        [Fact]
        public void Create()
        {
            Assert.True(Success.IsSuccess);
            Assert.Equal(42, Success.Get());

            Assert.True(Exception.IsError);
            Assert.Throws<NotImplementedException>(() => Exception.Get());
        }

        [Fact]
        public void Get()
        {
            Assert.Equal(42, Success.Get());
            Assert.Equal(42, Success.Get(e => new InvalidOperationException("test")));
            Assert.Throws<NotImplementedException>(() => Exception.Get());
            Assert.Throws<InvalidOperationException>(() => Exception.Get(e => new InvalidOperationException("foo", e)));
        }

        [Fact]
        public void Map()
        {
            Assert.Equal(45, Success.Map(i => i + 3).Get());
            Assert.True(Exception.Map(i => i + 3).IsError);
        }

        [Fact]
        public void MapError()
        {
            Assert.Equal(42, Success.MapError(e => new InvalidOperationException("foo", e)).Get());
            Assert.Throws<InvalidOperationException>(() => Exception.MapError(e => new InvalidOperationException("foo", e)).Get());
        }

        [Fact]
        public void Aggregate()
        {
            var a1 = Try.Aggregate(Success, Success, Product2.Create);
            Assert.True(a1.IsSuccess);
            Assert.Equal(42, a1.Get().ProductValue1);
            Assert.Equal(42, a1.Get().ProductValue2);

            var a2 = Try.Aggregate(Success, Exception, Product2.Create);
            Assert.True(a2.IsError);
            Assert.NotNull(a2.Error.Get());
            Assert.True(a2.Error.Get() is NotImplementedException);
            Assert.Throws<NotImplementedException>(() => a2.Get());

            var a3 = Try.Aggregate(Exception, Exception, Product2.Create);
            Assert.True(a3.IsError);
            Assert.True(a3.Error.Get() is AggregateException e1 && e1.InnerExceptions.Count == 2 && e1.InnerExceptions.All(i => i is NotImplementedException));
            Assert.Throws<AggregateException>(() => a3.Get());

            var a4 = Try.Aggregate(new[] { Success, Success, Success });
            Assert.True(a4.IsSuccess);
            Assert.True(a4.Get().SequenceEqual(new[] { 42, 42, 42 }));

            var a5 = Try.Aggregate(new[] { Success, Exception, Success, Exception });
            Assert.True(a5.IsError);
            Assert.True(a5.Error.Get() is AggregateException e2 && e2.InnerExceptions.Count == 2 && e2.InnerExceptions.All(i => i is NotImplementedException));
        }
    }
}
