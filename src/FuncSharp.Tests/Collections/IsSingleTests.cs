using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class IsSingleTests
    {
        private static readonly IEnumerable<string> Enumerable_Null = null;
        private static readonly IEnumerable<string> Enumerable_Empty;
        private static readonly IEnumerable<string> Enumerable_Single;
        private static readonly IEnumerable<string> Enumerable_Multiple;

        private static readonly string[] Array_Null = null;
        private static readonly string[] Array_Empty;
        private static readonly string[] Array_Single;
        private static readonly string[] Array_Multiple;

        static IsSingleTests()
        {
            Enumerable_Empty = Enumerable.Empty<string>();
            Enumerable_Single = Enumerable.Range(0, 1).Select(i => $"{i} potatoes");
            Enumerable_Multiple = Enumerable.Range(0, 10).Select(i => $"{i} potatoes");

            Array_Empty = Enumerable_Empty.ToArray();
            Array_Single = Enumerable_Single.ToArray();
            Array_Multiple = Enumerable_Multiple.ToArray();
        }

        [Fact]
        public void IsSingle_null()
        {
            Assert.False(Enumerable_Null.IsSingle());
            Assert.False(Array_Null.IsSingle());
        }

        [Fact]
        public void IsSingle_Empty()
        {
            Assert.False(Enumerable_Empty.IsSingle());
            Assert.False(Array_Empty.IsSingle());
        }

        [Fact]
        public void IsSingle_Single()
        {
            Assert.True(Enumerable_Single.IsSingle());
            Assert.True(Array_Single.IsSingle());
        }

        [Fact]
        public void IsSingle_Multiple()
        {
            Assert.False(Enumerable_Multiple.IsSingle());
            Assert.False(Array_Multiple.IsSingle());
        }
    }
}
