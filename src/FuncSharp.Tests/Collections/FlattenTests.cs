using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class FlattenTests
    {
        [Fact]
        public void Flatten()
        {
            var list = new List<IOption<string>> { Option.Empty<string>(), "1 potato".ToOption(), Option.Empty<string>(), "2 potatoes".ToOption(), Option.Empty<string>() };
            var result = list.Flatten().ToArray();

            Assert.Equivalent(2, result.Length);
            Assert.Equivalent(new [] { "1 potato", "2 potatoes" }, result);
        }
    }
}
