using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FuncSharp.Tests.Collections.INonEmptyEnumerable
{
    public class OptionCreateTests
    {
        [Fact]
        public void Option_Create_IEnumerable()
        {
            var nonEmpty = NonEmptyEnumerable.Create(Enumerable.Repeat("1 potato", 10));
            var list = new List<string> { "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato"};
            OptionAssert.NonEmpty(nonEmpty);
            Assert.Equal(10, nonEmpty.Get().Count);
            Assert.Equivalent(list, nonEmpty.Get());

            OptionAssert.IsEmpty(NonEmptyEnumerable.Create(Enumerable.Repeat("1 potato", 0)));
            OptionAssert.IsEmpty(NonEmptyEnumerable.Create(Enumerable.Empty<string>()));
            OptionAssert.IsEmpty(NonEmptyEnumerable.Create(list.Where(s => s != "1 potato")));
        }

        [Fact]
        public void Option_Create_ReadonlyList()
        {
            var nonEmpty = NonEmptyEnumerable.Create<string>(Enumerable.Repeat("1 potato", 10).ToList());
            var list = new List<string> { "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato", "1 potato"};
            OptionAssert.NonEmpty(nonEmpty);
            Assert.Equal(10, nonEmpty.Get().Count);
            Assert.Equivalent(list, nonEmpty.Get());

            OptionAssert.IsEmpty(NonEmptyEnumerable.Create<string>(Enumerable.Repeat("1 potato", 0).ToList()));
            OptionAssert.IsEmpty(NonEmptyEnumerable.Create<string>(new List<string>()));
            OptionAssert.IsEmpty(NonEmptyEnumerable.Create<string>(Enumerable.Empty<string>().ToList()));
            OptionAssert.IsEmpty(NonEmptyEnumerable.Create<string>(list.Where(s => s != "1 potato").ToList()));
        }

        [Fact]
        public void Option_CreateFlat_Params()
        {
            var nonEmpty = NonEmptyEnumerable.CreateFlat("1 potato".ToOption(), Option.Empty<string>(), "2 potatoes".ToOption(), Option.Empty<string>(), Option.Empty<string>(), "3 potatoes".ToOption(), "4 potatoes".ToOption(), "5 potatoes".ToOption(), "6 potatoes".ToOption(), "7 potatoes".ToOption(), "8 potatoes".ToOption(), "9 potatoes".ToOption(), "Also a longer string".ToOption());
            var list = new List<string> { "1 potato", "2 potatoes", "3 potatoes", "4 potatoes", "5 potatoes", "6 potatoes", "7 potatoes", "8 potatoes", "9 potatoes", "Also a longer string" };
            OptionAssert.NonEmpty(nonEmpty);
            Assert.Equal(10, nonEmpty.Get().Count);
            Assert.Equivalent(list, nonEmpty.Get());

            OptionAssert.IsEmpty(NonEmptyEnumerable.CreateFlat<string>());
            OptionAssert.IsEmpty(NonEmptyEnumerable.CreateFlat<string>(Option.Empty<string>(), Option.Empty<string>(), Option.Empty<string>()));
        }
    }
}
