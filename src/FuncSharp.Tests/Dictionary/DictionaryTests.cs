using System.Linq;
using Xunit;

namespace FuncSharp.Tests
{
    public class DictionaryTests
    {
        [Fact]
        public void GetOrElseSet()
        {
            var dictionary = Enumerable.Range(0, 1000).ToDictionary(i => i, i => $"{i} potatoes");

            OptionAssert.NonEmptyWithValue("0 potatoes", dictionary.Get(0));
            OptionAssert.NonEmptyWithValue("14 potatoes", dictionary.Get(14));
            OptionAssert.NonEmptyWithValue("128 potatoes", dictionary.Get(128));
            OptionAssert.NonEmptyWithValue("999 potatoes", dictionary.Get(999));

            OptionAssert.IsEmpty(dictionary.Get(-14));
            OptionAssert.IsEmpty(dictionary.Get(1000));
            OptionAssert.IsEmpty(dictionary.Get(123561));
            OptionAssert.IsEmpty(dictionary.Get(-156859615));
        }
    }
}
