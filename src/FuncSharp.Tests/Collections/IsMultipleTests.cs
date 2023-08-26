using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class IsMultipleTests
    {
        [Fact]
        public void IsMultiple_null()
        {
            IEnumerable<string> enumerableNull = null;
            string[] arrayNull = null;

            Assert.False(enumerableNull.IsMultiple());
            Assert.False(arrayNull.IsMultiple());
        }

        [Fact]
        public void IsMultiple_Empty()
        {
            IEnumerable<string> enumerableEmpty = Enumerable.Empty<string>();
            string[] arrayEmpty = new string[]{};


            Assert.False(enumerableEmpty.IsMultiple());
            Assert.False(arrayEmpty.IsMultiple());
        }

        [Fact]
        public void IsMultiple_Single()
        {
            IEnumerable<string> enumerableSingle = Enumerable.Repeat("A potato", 1);
            string[] arraySingle = new []{"A potato"};

            Assert.False(enumerableSingle.IsMultiple());
            Assert.False(arraySingle.IsMultiple());
        }

        [Fact]
        public void IsMultiple_Multiple()
        {
            IEnumerable<string> enumerableMultiple = Enumerable.Range(0, 10).Select(i => $"{i} potatoes");
            string[] arrayMultiple = Enumerable.Range(0, 10).Select(i => $"{i} potatoes").ToArray();

            Assert.True(enumerableMultiple.IsMultiple());
            Assert.True(arrayMultiple.IsMultiple());
        }
    }
}
