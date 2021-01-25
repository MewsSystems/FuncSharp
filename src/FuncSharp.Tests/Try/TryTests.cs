using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class TryTests
    {
        private static readonly Exception Exception = new NotImplementedException();
        private static readonly ITry<int, NotImplementedException> S1 = Try.Catch<int, NotImplementedException>(_ => 42);
        private static readonly ITry<int, NotImplementedException> E1 = Try.Catch<int, NotImplementedException>(_ => throw Exception);
        private static readonly ITry<int> S2 = Try.Create<int, Exception>(_ => 42);
        private static readonly ITry<int> E2 = Try.Create<int, Exception>(_ => throw Exception);

        [Fact]
        public void Catch()
        {
            Assert.True(S1.IsSuccess);
            Assert.Equal(42, S1.Get());

            Assert.True(E1.IsError);
            Assert.Throws<NotImplementedException>(() => E1.Get());
        }

        [Fact]
        public void Create()
        {
            Assert.True(S2.IsSuccess);
            Assert.Equal(42, S2.Get());

            Assert.True(E2.IsError);
            Assert.Throws<NotImplementedException>(() => E2.Get());
        }

        [Fact]
        public void Get()
        {
            Assert.Equal(42, S1.Get());
            Assert.Equal(42, S1.Get(e => new InvalidOperationException("test")));
            Assert.Equal(42, S2.Get());
            Assert.Equal(42, S2.Get(e => new InvalidOperationException("test")));

            Assert.Throws<NotImplementedException>(() => E1.Get());
            Assert.Throws<InvalidOperationException>(() => E1.Get(e => new InvalidOperationException("foo", e)));
            Assert.Throws<NotImplementedException>(() => E2.Get());
            Assert.Throws<InvalidOperationException>(() => E2.Get(e => new InvalidOperationException("foo", e.First())));
        }

        [Fact]
        public void Map()
        {
            Assert.Equal(45, S1.Map(i => i + 3).Get());
            Assert.Equal(45, S2.Map(i => i + 3).Get());

            Assert.True(E1.Map(i => i + 3).IsError);
            Assert.True(E2.Map(i => i + 3).IsError);
        }

        [Fact]
        public void MapError()
        {
            Assert.Equal(42, S1.MapError(e => new InvalidOperationException("foo", e)).Get());
            Assert.Equal(42, S2.MapError(e => new InvalidOperationException("foo", e.First())).Get());

            Assert.Throws<InvalidOperationException>(() => E1.MapError(e => new InvalidOperationException("foo", e)).Get());
            Assert.Throws<InvalidOperationException>(() => E2.MapError(e => new InvalidOperationException("foo", e.First())).Get());
        }

        [Fact]
        public void Aggregate()
        {
            var as1 = Try.Aggregate(S1, S1, Product2.Create);
            Assert.Equal(42, as1.Get().ProductValue1);
            Assert.Equal(42, as1.Get().ProductValue2);

            var as2 = Try.Aggregate(S2, S2, Product2.Create);
            Assert.Equal(42, as2.Get().ProductValue1);
            Assert.Equal(42, as2.Get().ProductValue2);

            var am1 = Try.Aggregate(S1, E1, Product2.Create);
            Assert.Equal(Exception, am1.Error.Get());
            Assert.Throws<NotImplementedException>(() => am1.Get());

            var am2 = Try.Aggregate(S2, E2, Product2.Create);
            Assert.Equal(Exception, am2.Error.FlatMap(e => e.SingleOption()).Get());
            Assert.Throws<NotImplementedException>(() => am2.Get());

            var ae1 = Try.Aggregate(E1, E1, Product2.Create);
            Assert.True(ae1.Error.Get() is AggregateException a && a.InnerExceptions.SequenceEqual(new[] { Exception, Exception }));
            Assert.Throws<AggregateException>(() => ae1.Get());

            var ae2 = Try.Aggregate(E2, E2, Product2.Create);
            Assert.True(ae2.Error.Get().SequenceEqual(new[] { Exception, Exception }));
            Assert.Throws<AggregateException>(() => ae2.Get());

            var asc1 = Try.Aggregate(new List<ITry<int, Exception>> { S1, S1, S1 });
            Assert.True(asc1.Get().SequenceEqual(new[] { 42, 42, 42 }));

            var asc2 = Try.Aggregate(new[] { S2, S2, S2 });
            Assert.True(asc2.Get().SequenceEqual(new[] { 42, 42, 42 }));

            var ast1 = Try.Aggregate(new List<ITry<int, Exception>> { S1, S1, S1 }, i => i.Sum());
            Assert.Equal(126, ast1.Get());

            var amc1 = Try.Aggregate(new List<ITry<int, Exception>> { S1, E1, S1, E1 });
            Assert.True(amc1.Error.Get() is AggregateException ag && ag.InnerExceptions.SequenceEqual(new[] { Exception, Exception }));
            Assert.Throws<AggregateException>(() => amc1.Get());

            var amc2 = Try.Aggregate(new[] { S2, E2, S2, E2 });
            Assert.True(amc2.Error.Get().SequenceEqual(new[] { Exception, Exception }));
            Assert.Throws<AggregateException>(() => amc2.Get());
        }
    }
}
