using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class TryTests
    {
        private static readonly NotImplementedException Exception = new NotImplementedException();
        private static readonly Try<int, NotImplementedException> Success = Try.Success<int, NotImplementedException>(42);
        private static readonly Try<int, NotImplementedException> Error = Try.Error<int, NotImplementedException>(Exception);


        [Fact]
        public void Catch()
        {
            var s = Try.Catch<int, Exception>(_ => 42);
            Assert.True(s.IsSuccess);
            Assert.Equivalent(42, s.Get());

            var e = Try.Catch<int, Exception>(_ => throw Exception);
            Assert.True(e.IsError);
            Assert.Throws<NotImplementedException>(() => e.Get());
        }

        [Fact]
        public void Get()
        {
            Assert.Equivalent(42, Success.Get());
            Assert.Equivalent(42, Success.Get(e => new InvalidOperationException("test")));

            Assert.Throws<NotImplementedException>(() => Error.Get());
            Assert.Throws<InvalidOperationException>(() => Error.Get(e => new InvalidOperationException("foo", e)));
        }

        [Fact]
        public void Map()
        {
            Assert.Equivalent(45, Success.Map(i => i + 3).Get());

            Assert.True(Error.Map(i => i + 3).IsError);
        }

        [Fact]
        public void MapError()
        {
            Assert.Equivalent(42, Success.MapError(e => new InvalidOperationException("foo", e)).Get());

            Assert.Throws<InvalidOperationException>(() => Error.MapError(e => new InvalidOperationException("foo", e)).Get());
        }

        [Fact]
        public void Where()
        {
            Assert.Equivalent(42, Success.Where(i => i > 40, _ => Exception).Get());
            Assert.Throws<NotImplementedException>(() => Success.Where(i => i > 50, _ => Exception).Get());
            Assert.Throws<NotImplementedException>(() => Error.Where(i => i > 40, _ => Exception).Get());
            Assert.Throws<NotImplementedException>(() => Error.Where(i => i > 50, _ => Exception).Get());

            var success = Try.Success<int, IEnumerable<NotImplementedException>>(42);
            var error = Try.Error<int, IEnumerable<NotImplementedException>>(new[] { Exception });
            Assert.Equivalent(42, success.Where(i => i > 40, _ => Exception).Get(e => e.First()));
            Assert.Throws<NotImplementedException>(() => success.Where(i => i > 50, _ => Exception).Get(e => e.First()));
            Assert.Throws<NotImplementedException>(() => error.Where(i => i > 40, _ => Exception).Get(e => e.First()));
            Assert.Throws<NotImplementedException>(() => error.Where(i => i > 50, _ => Exception).Get(e => e.First()));
        }

        [Fact]
        public void Aggregate()
        {
            var r1 = Try.Aggregate(Success, Success, success: Product2.Create);
            Assert.Equivalent(42, r1.Success.Get().ProductValue1);
            Assert.Equivalent(42, r1.Success.Get().ProductValue2);

            var r2 = Try.Aggregate(Success, Error, Product2.Create);
            Assert.Equivalent(Exception, r2.Error.Get().First());

            var r3 = Try.Aggregate(Error, Error, Product2.Create);
            Assert.True(r3.Error.Get().SequenceEqual(new[] { Exception, Exception }));

            var r4 = Try.Aggregate(new[] { Success, Success, Success });
            Assert.True(r4.Success.Get().SequenceEqual(new[] { 42, 42, 42 }));

            var r5 = Try.Aggregate(new[] { Success, Success, Success }, i => i.Sum(), e => e.Count);
            Assert.Equivalent(126, r5);

            var r6 = Try.Aggregate(new[] { Success, Error, Error }, i => i.Sum(), e => e.Count);
            Assert.Equivalent(2, r6);

            var r7 = Try.Aggregate(new[] { Success, Error, Success, Error });
            Assert.True(r7.Error.Get().SequenceEqual(new[] { Exception, Exception }));
        }
    }
}
