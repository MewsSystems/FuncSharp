using System.Collections.Generic;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class FlattenTests_Enumerable
    {
        public FlattenTests_Enumerable()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void Flatten()
        {
            Assert.Empty(Option.Empty<List<int>>().Flatten());
            Assert.Empty(Option.Empty<Stack<ReferenceType>>().Flatten());

            Assert.Empty(Option.Valued(new int[]{}).Flatten());
            Assert.Empty(Option.Valued(new List<ReferenceType>()).Flatten());

            Assert.Single(Option.Valued(new [] { 42 }).Flatten(), 42);
            Assert.Single(Option.Valued(new [] { new ReferenceType(3) }).Flatten(), new ReferenceType(3));

            Assert.Equal(
                Option.Valued(new [] { 42, 12, 3, 16, 49, 78 }).Flatten(),
                new List<int> { 42, 12, 3, 16, 49, 78 }
            );
        }

        // WIP
    }
}
