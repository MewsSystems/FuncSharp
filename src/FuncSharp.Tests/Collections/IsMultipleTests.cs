using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class IsMultipleTests
    {
        private static readonly IEnumerable<string> Enumerable_Null = null;
        private static readonly IEnumerable<string> Enumerable_Empty;
        private static readonly IEnumerable<string> Enumerable_Single;
        private static readonly IEnumerable<string> Enumerable_Multiple;

        private static readonly string[] Array_Null = null;
        private static readonly string[] Array_Empty;
        private static readonly string[] Array_Single;
        private static readonly string[] Array_Multiple;

        static IsMultipleTests()
        {
            Enumerable_Empty = Enumerable.Empty<string>();
            Enumerable_Single = Enumerable.Range(0, 1).Select(i => $"{i} potatoes");
            Enumerable_Multiple = Enumerable.Range(0, 10).Select(i => $"{i} potatoes");

            Array_Empty = Enumerable_Empty.ToArray();
            Array_Single = Enumerable_Single.ToArray();
            Array_Multiple = Enumerable_Multiple.ToArray();
        }

        [Fact]
        public void IsMultiple_null()
        {
            Assert.False(Enumerable_Null.IsMultiple());
            Assert.False(Array_Null.IsMultiple());
        }

        [Fact]
        public void IsMultiple_Empty()
        {
            Assert.False(Enumerable_Empty.IsMultiple());
            Assert.False(Array_Empty.IsMultiple());
        }

        [Fact]
        public void IsMultiple_Single()
        {
            Assert.False(Enumerable_Single.IsMultiple());
            Assert.False(Array_Single.IsMultiple());
        }

        [Fact]
        public void IsMultiple_Multiple()
        {
            Assert.True(Enumerable_Multiple.IsMultiple());
            Assert.True(Array_Multiple.IsMultiple());
        }
    }
}
