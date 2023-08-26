using System;
using FsCheck;
using FsCheck.Xunit;
using FuncSharp.Tests.Generative;
using Xunit;

namespace FuncSharp.Tests.Options
{
    public class GetOrNullTests_WithFunc
    {
        public GetOrNullTests_WithFunc()
        {
            Arb.Register<OptionGenerators>();
        }

        [Fact]
        public void GetOrNull_WithFunc()
        {
            Assert.Equal(new ReferenceType(1), 2.ToOption().GetOrNull(v => new ReferenceType(v / 2)));
            Assert.Equal(new ReferenceType(14), Unit.Value.ToOption().GetOrNull(_ => new ReferenceType(14)));
            Assert.Null(Unit.Value.ToOption().GetOrNull(v => (ReferenceType)null));

            Assert.Null(Option.Empty<Unit>().GetOrNull(_ => new ReferenceType(14)));
        }

        [Property]
        internal void GetOrNull_WithFunc_int(Option<int> option)
        {
            AssertGetOrNullWithFunc(option, i => new ReferenceType(i * 2));
        }

        [Property]
        internal void GetOrNull_WithFunc_ReferenceType(Option<ReferenceType> option)
        {
            AssertGetOrNullWithFunc(option, d => new ReferenceType(d.Value * 3));
            AssertGetOrNullWithFunc(option, d => (ReferenceType)null);
        }

        private void AssertGetOrNullWithFunc<T, TResult>(Option<T> option, Func<T, TResult> map)
            where TResult : class
        {
            var result = option.GetOrNull(map);
            if (option.NonEmpty)
            {
                Assert.Equal(map(option.GetOrDefault()), result);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}
