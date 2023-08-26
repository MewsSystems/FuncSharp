using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class FirstOptionTests
    {
        [Fact]
        public void FirstOption_Empty()
        {
            IEnumerable<string> enumerable = Enumerable.Empty<string>();
            string[] array = new string[]{};

            OptionAssert.IsEmpty(enumerable.FirstOption());
            OptionAssert.IsEmpty(array.FirstOption());

            OptionAssert.IsEmpty(enumerable.FirstOption(t => t.Contains("potato")));
            OptionAssert.IsEmpty(array.FirstOption(t => t.Contains("potato")));
        }

        [Fact]
        public void FirstOption_Single()
        {
            IEnumerable<string> enumerable = Enumerable.Repeat("A potato", 1);
            string[] array = new []{"A potato"};

            OptionAssert.NonEmptyWithValue("A potato", enumerable.FirstOption());
            OptionAssert.NonEmptyWithValue("A potato", array.FirstOption());

            OptionAssert.NonEmptyWithValue("A potato", enumerable.FirstOption(t => t.Contains("potato")));
            OptionAssert.NonEmptyWithValue("A potato", array.FirstOption(t => t.Contains("potato")));

            OptionAssert.IsEmpty(enumerable.FirstOption(t => t.Contains("ASDF")));
            OptionAssert.IsEmpty(array.FirstOption(t => t.Contains("ASDF")));
        }

        [Fact]
        public void FirstOption_Multiple()
        {
            IEnumerable<string> enumerable = Enumerable.Range(0, 10).Select(i => $"{i} potatoes");
            string[] array = Enumerable.Range(0, 10).Select(i => $"{i} potatoes").ToArray();

            OptionAssert.NonEmptyWithValue("0 potatoes", enumerable.FirstOption());
            OptionAssert.NonEmptyWithValue("0 potatoes", array.FirstOption());

            OptionAssert.NonEmptyWithValue("0 potatoes", enumerable.FirstOption(t => t.Contains("potato")));
            OptionAssert.NonEmptyWithValue("0 potatoes", array.FirstOption(t => t.Contains("potato")));

            OptionAssert.NonEmptyWithValue("3 potatoes", enumerable.FirstOption(t => t.Contains("3 pot")));
            OptionAssert.NonEmptyWithValue("3 potatoes", array.FirstOption(t => t.Contains("3 pot")));

            OptionAssert.IsEmpty(enumerable.FirstOption(t => t.Contains("ASDF")));
            OptionAssert.IsEmpty(array.FirstOption(t => t.Contains("ASDF")));
        }
    }
}
