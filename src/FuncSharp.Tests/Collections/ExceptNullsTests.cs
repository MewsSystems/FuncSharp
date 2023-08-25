using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class ExceptNullsTests
    {
        [Fact]
        public void ExceptNulls()
        {
            var list = new List<string> { null, "1 potato", null, "2 potatoes", null };
            var result = list.ExceptNulls().ToArray();

            Assert.Equal(2, result.Length);
            Assert.Equivalent(new [] { "1 potato", "2 potatoes" }, result);
        }

        [Fact]
        public void ExceptNulls_Nullable()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var list = new List<Guid?> { null, guid1, null, guid2, null };
            Guid[] result = list.ExceptNulls().ToArray();

            Assert.Equal(2, result.Length);
            Assert.Equivalent(new [] { guid1, guid2 }, result);
        }
    }
}
