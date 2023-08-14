using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class OptionEmptyTests
    {
        public OptionEmptyTests()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        public void Empty()
        {
            OptionAssert.IsEmpty(Option.Empty<int>());
            OptionAssert.IsEmpty(Option.Empty<int?>());
            OptionAssert.IsEmpty(Option.Empty<ReferenceType>());
            OptionAssert.IsEmpty(Option.Empty<Unit>());
        }
    }
}
