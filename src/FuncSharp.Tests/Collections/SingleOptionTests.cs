using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class SingleOptionTests
    {
        [Fact]
        public void SingleOption_Empty()
        {
            IEnumerable<string> enumerableEmpty = Enumerable.Empty<string>();
            string[] arrayEmpty = new string[]{};

            OptionAssert.IsEmpty(enumerableEmpty.SingleOption());
            OptionAssert.IsEmpty(arrayEmpty.SingleOption());
        }

        [Fact]
        public void SingleOption_Single()
        {
            IEnumerable<string> enumerableSingle = Enumerable.Repeat("A potato", 1);
            string[] arraySingle = new []{"A potato"};

            OptionAssert.NonEmptyWithValue("A potato", enumerableSingle.SingleOption());
            OptionAssert.NonEmptyWithValue("A potato", arraySingle.SingleOption());
        }

        [Fact]
        public void SingleOption_Multiple()
        {
            IEnumerable<string> enumerableMultiple = Enumerable.Range(0, 10).Select(i => $"{i} potatoes");
            string[] arrayMultiple = Enumerable.Range(0, 10).Select(i => $"{i} potatoes").ToArray();

            OptionAssert.IsEmpty(enumerableMultiple.SingleOption());
            OptionAssert.IsEmpty(arrayMultiple.SingleOption());
        }
    }
}
